using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicParser;
using DynamicProcessor;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class ProcessorHandler
    {
        readonly Dictionary<int, List<Processor>> _dicProcsWithTag = new Dictionary<int, List<Processor>>();
        readonly HashSet<string> _hashProcs = new HashSet<string>();
        readonly StringBuilder _procNames = new StringBuilder();

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
                throw new ArgumentException($"{nameof(ProcessorHandler)}: Добавляемая карта отличается по размерам от первой карты, добавленной в коллекцию. Требуется: {t.Width}, {t.Height}. Фактически: {p.Width}, {p.Height}.");
        }

        Processor GetProcessorWithUniqueTag(Processor p)
        {
            string tTag = p.Tag.ToUpper();
            if (!_hashProcs.Contains(tTag))
                return _hashProcs.Add(tTag) ? ChangeProcessorTag(p, tTag) : p;

            do
            {
                tTag += '0';
            } while (_hashProcs.Contains(tTag));
            _hashProcs.Add(tTag);
            return ChangeProcessorTag(p, tTag);
        }

        public void Add(Processor p)
        {
            CheckProcessorSizes(p);

            void SetProps()
            {
                _procNames.Append(char.ToUpper(p.Tag[0]));
                Count++;
                IsEmpty = false;
            }

            int hash = HashCreator.GetHash(p);
            if (_dicProcsWithTag.TryGetValue(hash, out List<Processor> prcs))
            {
                if (prcs.Any(prc => ProcessorCompare(prc, p)))
                    return;
                prcs.Add(GetProcessorWithUniqueTag(p));
                SetProps();
                return;
            }
            _dicProcsWithTag.Add(hash, new List<Processor> { GetProcessorWithUniqueTag(p) });
            SetProps();
        }

        static bool ProcessorCompare(Processor p1, Processor p2)
        {
            if (p1 == null)
                throw new ArgumentNullException();
            if (p2 == null)
                throw new ArgumentNullException();
            if (char.ToUpper(p1.Tag[0]) != char.ToUpper(p2.Tag[0]))
                return false;
            for (int i = 0; i < p1.Width; i++)
                for (int j = 0; j < p1.Height; j++)
                    if (p1[i, j] != p2[i, j])
                        return false;
            return true;
        }

        public static Processor ChangeProcessorTag(Processor processor, string newTag)
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

        public override string ToString() => _procNames.ToString();
    }
}