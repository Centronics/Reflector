using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DynamicParser;
using DynamicProcessor;
using DynamicReflector;
using Processor = DynamicParser.Processor;

namespace ReflectorTest
{
    [TestClass]
    public class ProcessorHandlerTest
    {
        static void CheckProcessorHandler(ProcessorHandler ph)
        {
            Assert.AreNotEqual(null, ph);

            ProcessorContainer procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual("AbC", ph.ToString());
            Assert.AreEqual(3, procs.Count);
        }

        [TestMethod]
        public void PHTest()
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

            Assert.AreEqual(string.Empty, ph.ToString());
            ph.Add(new Processor(new[] { new SignValue(2) }, "A"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(1, ph.Count);

            ProcessorContainer procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual("A", ph.ToString());
            Assert.AreEqual(1, procs.Count);

            ph.AddRange(new[] { new Processor(new[] { new SignValue(3) }, "b"), new Processor(new[] { new SignValue(4) }, "C") });

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "A"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.AddRange(new[] { new Processor(new[] { new SignValue(3) }, "b"), new Processor(new[] { new SignValue(4) }, "C") });

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "A1"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.AddRange(new[] { new Processor(new[] { new SignValue(3) }, "b1"), new Processor(new[] { new SignValue(4) }, "C1") });

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "a1"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            ph.AddRange(new[] { new Processor(new[] { new SignValue(3) }, "B1"), new Processor(new[] { new SignValue(4) }, "c1") });

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            CheckProcessorHandler(ph);

            Processor renameProcessor2 = ProcessorHandler.RenameProcessor(new Processor(new[] { SignValue.MaxValue }, "mmm"), "zzz");
            Assert.AreNotEqual(null, renameProcessor2);
            Assert.AreEqual("zzz", renameProcessor2.Tag);
            Assert.AreEqual(SignValue.MaxValue, renameProcessor2[0, 0]);
            Assert.AreEqual(1, renameProcessor2.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_1()
        {
            new ProcessorHandler().Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_2()
        {
            new ProcessorHandler().AddRange(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_3()
        {
            new ProcessorHandler().AddRange(new Processor[] { null });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_4()
        {
            new ProcessorHandler().AddRange(new[] { new Processor(new[] { new SignValue(3) }, "b"), null, new Processor(new[] { new SignValue(4) }, "C") });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_5()
        {
            ProcessorHandler.RenameProcessor(new Processor(new[] { SignValue.MaxValue }, "mmm"), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_6()
        {
            ProcessorHandler.RenameProcessor(new Processor(new[] { SignValue.MaxValue }, "mmm"), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_7()
        {
            ProcessorHandler.RenameProcessor(new Processor(new[] { SignValue.MaxValue }, "mmm"), " ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_8()
        {
            ProcessorHandler.RenameProcessor(null, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_9()
        {
            ProcessorHandler.RenameProcessor(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_10()
        {
            ProcessorHandler.RenameProcessor(null, " ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_11()
        {
            ProcessorHandler.RenameProcessor(null, "a");
        }
    }
}
