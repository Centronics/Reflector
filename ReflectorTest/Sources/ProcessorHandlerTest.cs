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
            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(3, ph.Count);

            ProcessorContainer procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(ph.Count, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual("ABC", ph.ToString());
        }

        [TestMethod]
        public void PHTest()
        {
            ProcessorHandler ph = new ProcessorHandler();
            Assert.AreEqual(true, ph.IsEmpty);
            Assert.AreEqual(0, ph.Count);
            Assert.AreEqual(string.Empty, ph.ToString());

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

            ProcessorContainer procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(1, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual("A", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(3) }, "b"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(2, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(2, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual("AB", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(4) }, "C"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "A"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(3) }, "b"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(4) }, "C"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "A1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(3) }, "b1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(4) }, "C1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(2) }, "a1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(3) }, "B1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(4) }, "c1"));

            CheckProcessorHandler(ph);

            ph.Add(new Processor(new[] { new SignValue(13) }, "b1"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(4, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(4, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual("ABCB", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(14) }, "B1"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(5, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(5, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual(new SignValue(14), procs[4][0, 0]);
            Assert.AreEqual("B1", procs[4].Tag);
            Assert.AreEqual("ABCBB", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(15) }, "B"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(6, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(6, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual(new SignValue(14), procs[4][0, 0]);
            Assert.AreEqual("B1", procs[4].Tag);
            Assert.AreEqual(new SignValue(15), procs[5][0, 0]);
            Assert.AreEqual("B0", procs[5].Tag);
            Assert.AreEqual("ABCBBB", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(16) }, "b"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(7, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(7, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual(new SignValue(14), procs[4][0, 0]);
            Assert.AreEqual("B1", procs[4].Tag);
            Assert.AreEqual(new SignValue(15), procs[5][0, 0]);
            Assert.AreEqual("B0", procs[5].Tag);
            Assert.AreEqual(new SignValue(16), procs[6][0, 0]);
            Assert.AreEqual("b0", procs[6].Tag);
            Assert.AreEqual("ABCBBBB", ph.ToString());

            bex = false;
            try
            {
                SignValue[,] prc = new SignValue[2, 1];
                prc[0, 0] = new SignValue(16);
                prc[1, 0] = new SignValue(100);
                ph.Add(new Processor(prc, "b"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                Assert.AreEqual($"{nameof(ProcessorHandler)}: Добавляемая карта отличается по размерам от первой карты, добавленной в коллекцию. Требуется: 1, 1. Фактически: 2, 1.", ex.Message);
                bex = true;
            }

            Assert.AreEqual(true, bex);

            bex = false;
            try
            {
                SignValue[,] prc = new SignValue[1, 2];
                prc[0, 0] = new SignValue(16);
                prc[0, 1] = new SignValue(100);
                ph.Add(new Processor(prc, "b"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                Assert.AreEqual($"{nameof(ProcessorHandler)}: Добавляемая карта отличается по размерам от первой карты, добавленной в коллекцию. Требуется: 1, 1. Фактически: 1, 2.", ex.Message);
                bex = true;
            }

            Assert.AreEqual(true, bex);

            ph.Add(new Processor(new[] { new SignValue(3) }, "r"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(8, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(8, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual(new SignValue(14), procs[4][0, 0]);
            Assert.AreEqual("B1", procs[4].Tag);
            Assert.AreEqual(new SignValue(15), procs[5][0, 0]);
            Assert.AreEqual("B0", procs[5].Tag);
            Assert.AreEqual(new SignValue(16), procs[6][0, 0]);
            Assert.AreEqual("b0", procs[6].Tag);
            Assert.AreEqual(new SignValue(3), procs[7][0, 0]);
            Assert.AreEqual("r", procs[7].Tag);
            Assert.AreEqual("ABCBBBBR", ph.ToString());

            ph.Add(new Processor(new[] { new SignValue(2) }, "v1"));

            Assert.AreEqual(false, ph.IsEmpty);
            Assert.AreEqual(9, ph.Count);

            procs = ph.Processors;
            Assert.AreNotEqual(null, procs);
            Assert.AreEqual(9, procs.Count);
            Assert.AreEqual(new SignValue(2), procs[0][0, 0]);
            Assert.AreEqual("A", procs[0].Tag);
            Assert.AreEqual(new SignValue(3), procs[1][0, 0]);
            Assert.AreEqual("b", procs[1].Tag);
            Assert.AreEqual(new SignValue(4), procs[2][0, 0]);
            Assert.AreEqual("C", procs[2].Tag);
            Assert.AreEqual(new SignValue(13), procs[3][0, 0]);
            Assert.AreEqual("b1", procs[3].Tag);
            Assert.AreEqual(new SignValue(14), procs[4][0, 0]);
            Assert.AreEqual("B1", procs[4].Tag);
            Assert.AreEqual(new SignValue(15), procs[5][0, 0]);
            Assert.AreEqual("B0", procs[5].Tag);
            Assert.AreEqual(new SignValue(16), procs[6][0, 0]);
            Assert.AreEqual("b0", procs[6].Tag);
            Assert.AreEqual(new SignValue(3), procs[7][0, 0]);
            Assert.AreEqual("r", procs[7].Tag);
            Assert.AreEqual(new SignValue(2), procs[8][0, 0]);
            Assert.AreEqual("v1", procs[8].Tag);
            Assert.AreEqual("ABCBBBBRV", ph.ToString());

            Processor renameProcessor2 = ProcessorHandler.ChangeProcessorTag(new Processor(new[] { SignValue.MaxValue }, "mmM"), "zZz");
            Assert.AreNotEqual(null, renameProcessor2);
            Assert.AreEqual("zZz", renameProcessor2.Tag);
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
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_5()
        {
            ProcessorHandler.ChangeProcessorTag(new Processor(new[] { SignValue.MaxValue }, "mmm"), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_6()
        {
            ProcessorHandler.ChangeProcessorTag(new Processor(new[] { SignValue.MaxValue }, "mmm"), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PHTestException_7()
        {
            ProcessorHandler.ChangeProcessorTag(new Processor(new[] { SignValue.MaxValue }, "mmm"), " ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_8()
        {
            ProcessorHandler.ChangeProcessorTag(null, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_9()
        {
            ProcessorHandler.ChangeProcessorTag(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_10()
        {
            ProcessorHandler.ChangeProcessorTag(null, " ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PHTestException_11()
        {
            ProcessorHandler.ChangeProcessorTag(null, "a");
        }
    }
}
