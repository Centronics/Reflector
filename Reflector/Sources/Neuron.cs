using System;
using System.Collections.Generic;
using System.Linq;
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

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();
            Dictionary<int, Processor> chi = new Dictionary<int, Processor>(pc.Count);
            _dicProcessors = new Dictionary<char, Processor>(pc.Count);
            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                char cTag = char.ToUpper(p.Tag[0]);
                if (!_hashSetOriginalUniqueQuery.Add(cTag))
                    throw new ArgumentException();
                int hash = HashCreator.GetHash(p);
                if (chi.TryGetValue(hash, out Processor proc) && ProcessorCompare(proc, p))
                    throw new ArgumentException("Одинаковое содержимое карт недопустимо");
                chi.Add(hash, p);
                _dicProcessors.Add(cTag, p);
            }
            _workReflex = new Reflex(pc);
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

        static HashSet<char> ToHashSet(IEnumerable<string> query)
        {
            HashSet<char> chs = new HashSet<char>();
            foreach (string q in query)
            {
                if (string.IsNullOrWhiteSpace(q))
                    throw new ArgumentNullException();
                if (q.Length > 1)
                    throw new ArgumentException();
                if (q.Any(c => !chs.Add(char.ToUpper(c))))
                    throw new ArgumentException();
            }

            return chs;
        }

        IEnumerable<Processor> GetNewProcessors(Reflex start, Reflex finish, string query)
        {
            if (finish == null)
                yield break;

            Dictionary<char, Processor> dic = new Dictionary<char, Processor>();
            for (int k = start.Count; k < finish.Count; k++)
            {
                Processor p = finish[k];
                dic.Add(char.ToUpper(p.Tag[0]), p);
            }

            foreach (char c in query.Where(c => !dic.ContainsKey(char.ToUpper(c))))
                dic.Add(c, _dicProcessors[c]);

            foreach (Processor p in dic.Values)
                yield return p;
        }

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queryPairs)
        {
            if (queryPairs == null)
                throw new ArgumentNullException();
            //карты (обе стороны) должны совпадать по размерам
            //карты должны различаться по названиям и содержимому одновременно
            IEnumerable<(Processor, string queryString)> queries = queryPairs as (Processor, string)[] ?? queryPairs.ToArray();
            if (!ToHashSet(queries.Select(q => q.queryString)).SetEquals(_hashSetOriginalUniqueQuery))
                return null;

            object lockObject = new object();

            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ProcessorHandler result = new ProcessorHandler();

            //Parallel.ForEach(queries, ((Processor processor, string query) q, ParallelLoopState state) =>
            foreach ((Processor processor, string query) in queries)
            {
                try
                {
                    //if (state.IsStopped)
                    //  return;

                    Reflex reflex = _workReflex.FindRelation(processor, query);
                    //if (reflex == null)// || state.IsStopped)
                    //  continue;//return;

                    lock (lockObject)
                        foreach (Processor p in GetNewProcessors(_workReflex, reflex, query))
                            result.Add(p);
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

            return _hashSetOriginalUniqueQuery.SetEquals(result.ToString()) ? new Neuron(result.Processors) : null;
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