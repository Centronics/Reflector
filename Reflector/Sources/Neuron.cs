using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMosaic;
using DynamicParser;
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
            FillNeuron(pc);
            _workReflex = new Reflex(pc);
            _mainSize = new Size(pc.Width, pc.Height);
        }

        void FillNeuron(ProcessorContainer pc)
        {
            Dictionary<int, Processor> chi = new Dictionary<int, Processor>(pc.Count);
            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                char cTag = char.ToUpper(p.Tag[0]);
                if (!_hashSetOriginalUniqueQuery.Add(cTag))
                    throw new ArgumentException();
                int hash = HashCreator.GetHash(p);
                if (!chi.TryGetValue(hash, out Processor proc))
                    chi.Add(hash, p);
                else
                if (ProcessorCompare(proc, p))
                    throw new ArgumentException("Одинаковое содержимое карт недопустимо");
                _dicProcessors.Add(cTag, p);
            }
        }

        /// <summary>
        /// Сравнивает указанные карты.
        /// Сравнение производится как по содержимому, так и по первым буквам значения свойста <see cref="Processor.Tag"/>, без учёта регистра.
        /// Если карты различаются только по первой букве значения свойства <see cref="Processor.Tag"/>, они считаются разными.
        /// </summary>
        /// <param name="p1">Первая карта.</param>
        /// <param name="p2">Вторая карта.</param>
        /// <returns>
        /// В случае равенства карт по всем признакам, возвращается значение <see langword="true" />, в противном случае - <see langword="false" />.
        /// </returns>
        static bool ProcessorCompare(Processor p1, Processor p2)
        {
            for (int i = 0; i < p1.Width; i++)
                for (int j = 0; j < p1.Height; j++)
                    if (p1[i, j] != p2[i, j])
                        return false;
            return true;
        }

        Processor GetNewProcessor(Reflex start, Reflex finish, char query)
        {
            if (finish == null)
                throw new Exception();
            if (finish.Count > start.Count + 1)
                throw new ArgumentException();

            return finish.Count == start.Count + 1 ? finish[start.Count] : _dicProcessors[char.ToUpper(query)];
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
                if (q.Length > 1)
                    throw new ArgumentException();
                if (q.Any(c => !chs.Add(char.ToUpper(c))))
                    throw new ArgumentException();
                int hash = HashCreator.GetHash(p);
                if (!chi.TryGetValue(hash, out Processor proc))
                    chi.Add(hash, p);
                else
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
                        result.Add(GetNewProcessor(_workReflex, reflex, query[0]));
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