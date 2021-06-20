using System;
using System.Collections.Generic;
using System.Linq;
using DynamicParser;
using DynamicProcessor;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class ProcessorHandler
    {
        readonly Dictionary<int, List<Processor>> _dicProcsWithTag = new Dictionary<int, List<Processor>>();
        readonly HashSet<string> _hashProcs = new HashSet<string>();
        readonly HashSet<char> _procNames = new HashSet<char>();

        public ProcessorContainer Processors
        {
            get
            {
                if (IsEmpty)
                    throw new Exception($"{nameof(ProcessorHandler)}: Список карт пуст.");
                ProcessorContainer pc = null;
                foreach (Processor p in _dicProcsWithTag.Values.SelectMany(processors => processors))
                    if (pc == null)
                        pc = new ProcessorContainer(p);
                    else
                        pc.Add(p);
                return pc;
            }
        }

        public int Count { get; private set; }

        public bool IsEmpty { get; private set; } = true;

        Processor FirstProcessor => _dicProcsWithTag.Values.FirstOrDefault()?.FirstOrDefault();

        void CheckProcessorSizes(Processor p)
        {
            if (p == null)
                throw new ArgumentNullException();
            Processor t = FirstProcessor;
            if (t == null)
                return;
            if (t.Size != p.Size)
                throw new ArgumentException();
        }

        Processor GetUniqueProcessor(Processor p)
        {
            if (!_hashProcs.Contains(p.Tag))
                return p;
            string tTag = p.Tag;
            do
            {
                tTag += '0';
            } while (_hashProcs.Contains(tTag));
            _hashProcs.Add(tTag);
            return RenameProcessor(p, tTag);
        }

        public void AddRange(IEnumerable<Processor> processors)
        {
            foreach (Processor processor in processors)
                Add(processor);
        }

        public void Add(Processor p)
        {
            CheckProcessorSizes(p);

            void SetProps()
            {
                _procNames.Add(char.ToUpper(p.Tag[0]));
                Count++;
                IsEmpty = false;
            }

            int hash = HashCreator.GetHash(p);
            if (_dicProcsWithTag.TryGetValue(hash, out List<Processor> prcs))
            {
                if (prcs.Any(prc => ProcessorCompare(prc, p, true)))
                    return;
                prcs.Add(GetUniqueProcessor(p));
                SetProps();
                return;
            }
            _dicProcsWithTag.Add(hash, new List<Processor> { GetUniqueProcessor(p) });
            SetProps();
        }

        static bool ProcessorCompare(Processor p1, Processor p2, bool includeTag)
        {
            if (p1 == null)
                throw new ArgumentNullException();
            if (p2 == null)
                throw new ArgumentNullException();
            if (includeTag && char.ToUpper(p1.Tag[0]) != char.ToUpper(p2.Tag[0]))
                return false;
            for (int i = 0; i < p1.Width; i++)
                for (int j = 0; j < p1.Height; j++)
                    if (p1[i, j] != p2[i, j])
                        return false;
            return true;
        }

        public static Processor RenameProcessor(Processor processor, string newTag)
        {
            if (processor == null)
                throw new ArgumentNullException(nameof(processor));
            if (processor.Tag == newTag)
                return processor;
            if (string.IsNullOrWhiteSpace(newTag))
                throw new ArgumentException($"\"{nameof(newTag)}\" не может быть пустым или содержать только пробел.", nameof(newTag));

            SignValue[,] sv = new SignValue[processor.Width, processor.Height];
            for (int i = 0; i < processor.Width; i++)
                for (int j = 0; j < processor.Height; j++)
                    sv[i, j] = processor[i, j];
            return new Processor(sv, newTag);
        }

        public bool SetEquals(IEnumerable<char> values) => _procNames.SetEquals(values);

        public HashSet<char> ToHashSet() => new HashSet<char>(_procNames);

        public override string ToString() => new string(_procNames.ToArray());
    }
}