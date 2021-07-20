using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMosaic;
using DynamicParser;
using DynamicProcessor;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class Neuron
    {
        readonly Reflex _workReflex;
        readonly HashSet<char> _hashSetOriginalUniqueQuery = new HashSet<char>();
        readonly Dictionary<char, Processor> _dicProcessors;
        readonly Size _mainSize;

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();
            if (pc.Count < 2)
                throw new ArgumentException();
            _dicProcessors = new Dictionary<char, Processor>(pc.Count);
            _mainSize = new Size(pc.Width, pc.Height);
            _workReflex = new Reflex(FillNeuron(pc));
        }

        ProcessorContainer FillNeuron(ProcessorContainer pc)
        {
            IEnumerable<Processor> GetProcessors()
            {
                Dictionary<int, Processor> chi = new Dictionary<int, Processor>(pc.Count);
                for (int k = 0; k < pc.Count; k++)
                {
                    Processor p = pc[k];
                    char cTag = char.ToUpper(p.Tag[0]);
                    p = ChangeProcessorTag(p, cTag.ToString());
                    if (!_hashSetOriginalUniqueQuery.Add(cTag))
                        throw new ArgumentException();
                    int hash = HashCreator.GetHash(p);
                    if (!chi.TryGetValue(hash, out Processor proc))
                        chi.Add(hash, p);
                    else if (ProcessorCompare(proc, p))
                        throw new ArgumentException("Одинаковое содержимое карт недопустимо");
                    _dicProcessors.Add(cTag, p);
                    yield return p;
                }
            }

            return new ProcessorContainer(GetProcessors().ToArray());
        }

        /// <summary>
        /// Генерирует карту с указанным новым значением свойства <see cref="Processor.Tag"/>.
        /// В случае, если новое и старое значения свойства <see cref="Processor.Tag"/> совпадают (с учётом регистра), то возвращается та же карта, которая была подана на вход.
        /// </summary>
        /// <param name="processor">Карта, значение свойства <see cref="Processor.Tag"/> которой требуется изменить.</param>
        /// <param name="newTag">Новое значение свойства <see cref="Processor.Tag"/>. Не может быть пустым.</param>
        /// <returns>Карта с новым значением свойства <see cref="Processor.Tag"/>.</returns>
        static Processor ChangeProcessorTag(Processor processor, string newTag)
        {
            if (processor == null)
                throw new ArgumentNullException(nameof(processor), $@"{nameof(ChangeProcessorTag)}: карта равна null.");
            if (processor.Tag == newTag)
                return processor;
            if (string.IsNullOrWhiteSpace(newTag))
                throw new ArgumentException($"{nameof(ChangeProcessorTag)}: \"{nameof(newTag)}\" не может быть пустым или содержать только пробел.", nameof(newTag));

            SignValue[,] sv = new SignValue[processor.Width, processor.Height];
            for (int i = 0; i < processor.Width; i++)
                for (int j = 0; j < processor.Height; j++)
                    sv[i, j] = processor[i, j];
            return new Processor(sv, newTag);
        }

        /// <summary>
        /// Сравнивает указанные карты.
        /// Сравнение производится только по содержимому.
        /// </summary>
        /// <param name="p1">Первая карта.</param>
        /// <param name="p2">Вторая карта.</param>
        /// <returns>
        /// В случае равенства карт возвращается значение <see langword="true" />, в противном случае - <see langword="false" />.
        /// </returns>
        static bool ProcessorCompare(Processor p1, Processor p2)
        {
            for (int i = 0; i < p1.Width; i++)
                for (int j = 0; j < p1.Height; j++)
                    if (p1[i, j] != p2[i, j])
                        return false;
            return true;
        }

        Processor GetNewProcessor(Reflex finish, char query)
        {
            if (finish == null)
                throw new Exception();
            if (finish.Count > _workReflex.Count + 1)
                throw new ArgumentException();

            query = char.ToUpper(query);
            Processor result = finish.Count == _workReflex.Count + 1 ? finish[_workReflex.Count] : _dicProcessors[query];
            return ChangeProcessorTag(result, query.ToString());
        }

        void CheckQuery(IEnumerable<(Processor processor, string queryString)> queries)
        {
            Dictionary<int, Processor> chi = new Dictionary<int, Processor>();
            HashSet<char> chs = new HashSet<char>();
            foreach ((Processor p, string q) in queries)
            {
                if (p == null)
                    throw new ArgumentNullException();
                if (string.IsNullOrWhiteSpace(q))
                    throw new ArgumentException();
                if (p.Size != _mainSize)
                    throw new ArgumentException();
                if (q.Length != 1)
                    throw new ArgumentException();
                if (!chs.Add(char.ToUpper(q[0])))
                    throw new ArgumentException();
                int hash = HashCreator.GetHash(p);
                if (!chi.TryGetValue(hash, out Processor proc))
                {
                    chi.Add(hash, p);
                    continue;
                }
                if (ProcessorCompare(proc, p))
                    throw new ArgumentException("Одинаковое содержимое карт в запросе недопустимо");
            }
            if (!chs.SetEquals(_hashSetOriginalUniqueQuery))
                throw new ArgumentException();
        }

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queryPairs)
        {
            if (queryPairs == null)
                throw new ArgumentNullException();
            IEnumerable<(Processor, string queryString)> queries = queryPairs as (Processor, string)[] ?? queryPairs.ToArray();
            CheckQuery(queries);

            object lockObject = new object();

            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ProcessorContainer result = new ProcessorContainer();

            //Parallel.ForEach(queries, ((Processor processor, string query) q, ParallelLoopState state) =>
            foreach ((Processor processor, string query) in queries)
            {
                try
                {
                    //if (state.IsStopped)
                    //  return;

                    Reflex reflex = _workReflex.FindRelation(processor, query);
                    //if (state.IsStopped)
                    //  continue;//return;

                    lock (lockObject)
                        result.Add(GetNewProcessor(reflex, query[0]));
                }
                catch (Exception ex)
                {
                    try
                    {
                        errString = ex.Message;
                        exThrown = true;
                        //state.Stop();
                    }
                    catch (Exception ex1)
                    {
                        errStopped = ex1.Message;
                        exStopped = true;
                    }
                }
            }//);

            if (exThrown)
                throw new Exception(exStopped ? $@"{errString}{Environment.NewLine}{errStopped}" : errString);

            return new Neuron(result);
        }

        public IEnumerable<Processor> Processors
        {
            get
            {
                for (int k = 0; k < _workReflex.Count; k++)
                    yield return _workReflex[k];
            }
        }
    }
}