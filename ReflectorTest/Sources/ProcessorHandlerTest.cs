using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DynamicParser;
using DynamicProcessor;
using DynamicReflector;
using Processor = DynamicParser.Processor;

namespace ReflectorTest
{
    [TestClass]
    public class ProcessorHandlerTest
    {
        [TestMethod]
        public void Test1()
        {
            ProcessorHandler ph = new ProcessorHandler();
            Assert.AreEqual(true, ph.IsEmpty);
            Assert.AreEqual(0, ph.Count);

            bool bex = false;
            try
            {
                ProcessorContainer unused = ph.Processors;
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(Exception), ex.GetType());
                Assert.AreEqual($"{nameof(ProcessorHandler)}: Список карт пуст.", ex.Message);
                bex = true;
            }

            Assert.AreEqual(true, bex);

            ph.Add(new Processor(new[] { new SignValue(2) }, "A"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(1, ph.Count);

            ph.AddRange(new[] { new Processor(new[] { new SignValue(3) }, "b"), new Processor(new[] { new SignValue(4) }, "C") });

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            ProcessorContainer procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(3, procs.Count);

            string str = ph.ToString();
            const string myStr = "AbC";
            Assert.AreEqual(myStr, str);
            HashSet<char> chs = ph.ToHashSet();
            Assert.AreNotEqual(null, chs);
            HashSet<char> chj = new HashSet<char>(myStr);
            Assert.AreNotEqual(null, chj);
            Assert.AreEqual(true, chs.SetEquals(chj));

        }
    }
}
