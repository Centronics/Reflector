using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using DynamicParser;
using DynamicProcessor;
using DynamicReflector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor = DynamicParser.Processor;

namespace ReflectorTest
{
    [TestClass]
    public class NeuronTest
    {
        #region Tests

        #region GetProcessors

        /// <summary>
        /// Используется для теста, где используется одна и та же физическая карта <see cref="ProcessorsForNeuronGlobal"/> и <see cref="CorrectGlobalProcessorQuery"/>.
        /// </summary>
        static Processor _globalProcessor0, _globalProcessor1;

        static IEnumerable<Processor> Processors0
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "2");
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return new Processor(sv, "4");
            }
        }

        static IEnumerable<Processor> ProcessorsForNeuronGlobal
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 3];

                if (_globalProcessor0 == null)
                {
                    sv[0, 0] = new SignValue(1111);
                    sv[1, 0] = new SignValue(2222);
                    sv[2, 0] = new SignValue(3333);
                    sv[0, 1] = new SignValue(4444);
                    sv[1, 1] = new SignValue(5555);
                    sv[2, 1] = new SignValue(6666);
                    sv[0, 2] = new SignValue(7777);
                    sv[1, 2] = new SignValue(8888);
                    sv[2, 2] = new SignValue(9999);
                    _globalProcessor0 = new Processor(sv, "G");
                }

                yield return _globalProcessor0;

                if (_globalProcessor1 == null)
                {
                    sv[0, 0] = new SignValue(1212);
                    sv[1, 0] = new SignValue(2323);
                    sv[2, 0] = new SignValue(3232);
                    sv[0, 1] = new SignValue(4646);
                    sv[1, 1] = new SignValue(5757);
                    sv[2, 1] = new SignValue(6464);
                    sv[0, 2] = new SignValue(7979);
                    sv[1, 2] = new SignValue(8181);
                    sv[2, 2] = new SignValue(9292);
                    _globalProcessor1 = new Processor(sv, "H");
                }

                yield return _globalProcessor1;
            }
        }

        static IEnumerable<Processor> Processors1Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "k1");
            }
        }

        static IEnumerable<Processor> Processors2Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "y");
                yield return new Processor(sv, "y1");
            }
        }

        static IEnumerable<Processor> Processors3Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "k");
            }
        }

        static IEnumerable<Processor> Processors4Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "K");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "k");
            }
        }

        static IEnumerable<Processor> Processors5Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "K");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "K");
            }
        }

        static IEnumerable<Processor> Processors6Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "y");
                yield return new Processor(sv, "Y1");
            }
        }

        static IEnumerable<Processor> Processors7Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "Y");
                yield return new Processor(sv, "y1");
            }
        }

        static IEnumerable<Processor> Processors8Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "Y");
                yield return new Processor(sv, "Y1");
            }
        }

        static IEnumerable<Processor> Processors9Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "K1");
            }
        }

        static IEnumerable<Processor> Processors10Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "K");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "k1");
            }
        }

        static IEnumerable<Processor> Processors11Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 2], "Exception8");
            }
        }

        static IEnumerable<Processor> Processors12Exception
        {
            get
            {
                yield return new Processor(new SignValue[1, 2], "Exception9");
            }
        }

        static IEnumerable<Processor> Processors13Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 1], "Exception10");
            }
        }

        static IEnumerable<Processor> Processors14Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "a");
                yield return new Processor(sv, "b");
            }
        }

        static IEnumerable<Processor> Processors15Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                yield return new Processor(sv, "k");
            }
        }

        static IEnumerable<Processor> Processors16Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                yield return new Processor(sv, "a");
                sv = new SignValue[2, 1];
                yield return new Processor(sv, "b");
            }
        }

        static IEnumerable<Processor> Processors17Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                yield return new Processor(sv, "b");
                sv = new SignValue[1, 1];
                yield return new Processor(sv, "a");
            }
        }

        static IEnumerable<Processor> Processors18Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "10");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "2");
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return new Processor(sv, "4");
            }
        }

        static IEnumerable<Processor> Processors20Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "20");
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return new Processor(sv, "4");
            }
        }

        static IEnumerable<Processor> Processors21Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "2");
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "30");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return new Processor(sv, "4");
            }
        }

        static IEnumerable<Processor> Processors22Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "20");
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return new Processor(sv, "40");
            }
        }

        #endregion //GetProcessors

        #region Correct

        static IEnumerable<(Processor, string)> CorrectQuery0
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), "2");
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), "1");
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), "4");
            }
        }

        static IEnumerable<Processor> CorrectQuery0Result
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2233);
                yield return new Processor(sv, "2");
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return new Processor(sv, "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return new Processor(sv, "4");
            }
        }

        static IEnumerable<(Processor, string)> CorrectGlobalProcessorQuery
        {
            get
            {
                if (_globalProcessor0 == null || _globalProcessor1 == null)
                    throw new Exception($"Сначала необходимо вызвать метод {nameof(ProcessorsForNeuronGlobal)}.");
                yield return (_globalProcessor0, "G");
                yield return (_globalProcessor1, "H");
            }
        }

        #endregion //Correct

        #region Incorrect

        static IEnumerable<(Processor, string)> IncorrectQuery0
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), "2");
                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p1"), "1");
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p3"), "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(3333);
                yield return (new Processor(sv, "p4"), "4");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), "2");
                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p1"), "1");
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p3"), "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(3333);
                yield return (new Processor(sv, "p4"), "4");
            }
        }

        #endregion //Incorrect

        #endregion //Tests

        #region SelfTests

        [TestMethod]
        public void NeuronAutoGetExceptionTest1()
        {
            GetException("123", typeof(ArgumentNullException), () => throw new ArgumentNullException());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronAutoGetExceptionTest2_0()
        {
            GetException(" ", typeof(Exception), () => throw new AggregateException());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronAutoGetExceptionTest2_1()
        {
            GetException(null, typeof(Exception), () => throw new AggregateException());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronAutoGetExceptionTest2_2()
        {
            GetException(string.Empty, typeof(Exception), () => throw new AggregateException());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronAutoGetExceptionTest3()
        {
            GetException("1234", null, () => throw new AggregateException());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronAutoGetExceptionTest4()
        {
            GetException("123", typeof(Exception), null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NeuronAutoGetExceptionTest5()
        {
            try
            {
                GetException("123456", typeof(Exception), () => throw new AggregateException());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("123456", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NeuronAutoGetExceptionTest6()
        {
            try
            {
                GetException("12345", typeof(Exception), () => { });
            }
            catch (Exception ex)
            {
                Assert.AreEqual("12345", ex.Message);
                throw;
            }
        }

        static void GetException(string errorString, Type exType, Action act)
        {
            if (string.IsNullOrWhiteSpace(errorString))
                throw new ArgumentNullException(nameof(errorString));
            if (exType == null)
                throw new ArgumentNullException(nameof(exType));
            if (act == null)
                throw new ArgumentNullException(nameof(act));

            try
            {
                act();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == exType)
                    return;
            }

            throw new Exception(errorString);
        }

        #endregion //SelfTests

        static void CheckNeuronMapValue(Neuron actual, IEnumerable<Processor> pcExpected)
        {
            Assert.AreNotEqual(null, actual);
            Assert.AreNotEqual(null, actual.Processors);
            Assert.AreNotEqual(null, pcExpected);

            Dictionary<string, Processor> dicActual = actual.Processors.ToDictionary(p => p.Tag);

            foreach (Processor pExpected in pcExpected)
            {
                Assert.AreNotEqual(null, pExpected);
                Processor pActual = dicActual[pExpected.Tag];
                Assert.AreNotEqual(null, pActual);
                dicActual.Remove(pExpected.Tag);
                Assert.AreEqual(pActual.Tag, pExpected.Tag);

                if (pExpected.Tag != "G" && pExpected.Tag != "H")
                {
                    Assert.AreEqual(1, pActual.Height);
                    Assert.AreEqual(1, pActual.Width);
                    Assert.AreEqual(1, pExpected.Height);
                    Assert.AreEqual(1, pExpected.Width);
                }
                else
                {
                    Assert.AreEqual(3, pActual.Height);
                    Assert.AreEqual(3, pActual.Width);
                    Assert.AreEqual(3, pExpected.Height);
                    Assert.AreEqual(3, pExpected.Width);
                }

                Assert.AreEqual(pExpected[0, 0], pActual[0, 0]);
            }

            Assert.AreEqual(0, dicActual.Count);
        }

        static IEnumerable<Processor> ProcessorContainerToEnumerable(ProcessorContainer pc)
        {
            for (int k = 0; k < pc.Count; k++)
                yield return pc[k];
        }

        static HashSet<char> GetHashSet(IEnumerable<(Processor, string)> q)
        {
            HashSet<char> chs = new HashSet<char>();
            foreach ((Processor _, string query) in q)
                foreach (char c in query)
                    chs.Add(char.ToUpper(c));
            return chs;
        }

        static HashSet<char> GetHashSet(Neuron neuron)
        {
            HashSet<char> chs = new HashSet<char>();
            foreach (Processor p in neuron.Processors)
                chs.Add(char.ToUpper(p.Tag[0]));
            return chs;
        }

        static IEnumerable<Neuron> GetNeurons()
        {
            foreach (PropertyInfo pi in typeof(NeuronTest).GetTypeInfo().DeclaredProperties)
                if (pi.Name.StartsWith("Processors"))
                {
                    Processor[] processors = ((IEnumerable<Processor>)pi.GetValue(null)).ToArray();
                    ProcessorContainer pc = new ProcessorContainer(processors);
                    if (pi.Name.EndsWith("Exception"))
                    {
                        bool bex = false;
                        try
                        {
                            Neuron unused = new Neuron(pc);
                        }
                        catch (ArgumentException)
                        {
                            bex = true;
                        }

                        Assert.AreEqual(true, bex);

                        continue;
                    }
                    Neuron neuron = new Neuron(pc);
                    ProcessorHandler ph = new ProcessorHandler();
                    foreach (Processor p in processors)
                        ph.Add(p);
                    CheckNeuronMapValue(neuron, ProcessorContainerToEnumerable(ph.Processors));
                    yield return neuron;
                }
        }

        static IEnumerable<(IEnumerable<(Processor, string)>, string)> GetCorrect(HashSet<char> hash)
        {
            foreach (PropertyInfo p in typeof(NeuronTest).GetTypeInfo().DeclaredProperties)
                if (p.Name.StartsWith("Correct") && !p.Name.EndsWith("Result"))
                {
                    (Processor, string)[] array = ((IEnumerable<(Processor, string)>)p.GetValue(null)).ToArray();

                    HashSet<char> c = GetHashSet(array);

                    if (hash.SetEquals(GetHashSet(array)))
                        yield return (array, p.Name);
                }
        }

        static IEnumerable<Processor> GetResult(string name)
        {
            IEnumerable<Processor> Find(string n) => (from p in typeof(NeuronTest).GetTypeInfo().DeclaredProperties where p.Name == n select (IEnumerable<Processor>)p.GetValue(null)).FirstOrDefault();
            return Find(name + "Result") ?? Find(name);
        }

        static IEnumerable<IEnumerable<(Processor, string)>> GetInCorrect()
        {
            foreach (PropertyInfo p in typeof(NeuronTest).GetTypeInfo().DeclaredProperties)
                if (p.Name.StartsWith("InCorrect"))
                    yield return (IEnumerable<(Processor, string)>)p.GetValue(null);
        }

        [TestMethod]
        public void NeuronTest0()
        {
            Neuron[] neurons = GetNeurons().ToArray();
            Processor[][] procs = neurons.Select(n => n.Processors).Select(s => s.ToArray()).ToArray();
            Assert.AreEqual(neurons.Length, procs.Length);
            for (int k = 0; k < 2; k++)
                for (int j = 0; j < neurons.Length; j++)
                {
                    foreach ((IEnumerable<(Processor, string)> query, string name) in GetCorrect(GetHashSet(neurons[j])))
                        CheckNeuronMapValue(neurons[j].FindRelation(query), GetResult(name));
                    foreach (IEnumerable<(Processor, string)> q in GetInCorrect())
                        Assert.AreEqual(null, neurons[j].FindRelation(q));
                    CheckNeuronMapValue(neurons[j], procs[j]);
                }
        }
    }
}

/*[TestMethod]
        public void ReflexMultiThreadTest
        {get{
            SignValue[,] minmap1 = new SignValue[1, 1];
            minmap1[0, 0] = new SignValue(1000);
            Processor p1 = new Processor(minmap1, "minmap1");

            SignValue[,] minmap6 = new SignValue[1, 1];
            minmap6[0, 0] = new SignValue(600);
            Processor p6 = new Processor(minmap6, "minmap6");

            SignValue[,] mapA = new SignValue[1, 1];
            mapA[0, 0] = new SignValue(3000);
            Processor pA = new Processor(mapA, "A");

            SignValue[,] mapB = new SignValue[1, 1];
            mapB[0, 0] = new SignValue(1500);
            Processor pB = new Processor(mapB, "B");

            SignValue[,] mapC = new SignValue[1, 1];
            mapC[0, 0] = new SignValue(500);
            Processor pC = new Processor(mapC, "C");
            Processor pCClone = new Processor(mapC, "D");

            void MapVerify(Reflex pr, int needCount)
            {get{
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(needCount, pr.Count);
                Assert.AreEqual((object)pr[0], pA);
                Assert.AreEqual((object)pr[1], pB);
                Assert.AreEqual((object)pr[2], pC);
                Assert.AreEqual((object)pr[3], pCClone);
            }}

            void TestExReflex(Reflex r, params int[] pars)
            {get{
                Assert.AreNotEqual(null, r);

                int exCount = 0;

                foreach (int k in pars)
                    try
                    {get{
                        Processor unused = r[k];
                    }}
                    catch (ArgumentException)
                    {get{
                        exCount++;
                    }}

                Assert.AreEqual(exCount, pars.Length);
            }}

            Reflex re = new Reflex(new ProcessorContainer(pA, pB, pC, pCClone));
            const int steps = 200;
            Thread[] thrs = new Thread[steps];

            for (int k = 0; k < steps; k++)
            {get{
                Thread t = new Thread(obj =>
                {get{
                    for (int k1 = 0; k1 < 300; k1++)
                    {get{
                        Reflex reflex = (Reflex)obj;
                        Reflex rZ6 = reflex.FindRelation(p6, "D");
                        Assert.AreNotEqual(null, rZ6);
                        MapVerify(reflex, 4);
                        MapVerify(rZ6, 5);
                        Assert.AreNotEqual((object)rZ6[4], p6);
                        Assert.AreEqual(true, ProcessorCompare(rZ6[4], p6));
                        Assert.AreEqual("D0", rZ6[4].Tag);

                        TestExReflex(rZ6, 5, 6, -1, -2);
                        TestExReflex(reflex, 4, 5, -1, -2);

                        Reflex rC = reflex.FindRelation(p1, "C");
                        Assert.AreNotEqual(null, rC);
                        MapVerify(reflex, 4);
                        MapVerify(rC, 5);
                        Assert.AreNotEqual((object)rC[4], p1);
                        Assert.AreEqual(true, ProcessorCompare(rC[4], p1));
                        Assert.AreEqual("C0", rC[4].Tag);

                        TestExReflex(rC, 5, 6, -1, -2);
                        TestExReflex(rZ6, 5, 6, -1, -2);
                        TestExReflex(reflex, 4, 5, -1, -2);

                        Reflex rB = reflex.FindRelation(p1, "B");
                        Assert.AreNotEqual(null, rB);
                        MapVerify(reflex, 4);
                        MapVerify(rB, 5);
                        Assert.AreNotEqual((object)rB[4], p1);
                        Assert.AreEqual(true, ProcessorCompare(rB[4], p1));
                        Assert.AreEqual("B0", rB[4].Tag);

                        TestExReflex(rB, 5, 6, -1, -2);
                        TestExReflex(reflex, 4, 5, -1, -2);
                        TestExReflex(rC, 5, 6, -1, -2);
                        TestExReflex(rZ6, 5, 6, -1, -2);
                    }}
                }})
                {get{ IsBackground = true, Priority = ThreadPriority.AboveNormal, Name = $"Number: {get{k}}" }};
                t.Start(re);
                thrs[k] = t;
            }}

            for (int k = 0; k < steps; k++)
                thrs[k].Join;

public SearchResults[] GetEqual(IList<ProcessorContainer> processors)
        {get{
            if (processors == null)
                throw new ArgumentNullException(nameof(processors),
                    $@"{get{nameof(GetEqual)}}: Массив искомых карт не указан.");
            if (processors.Count <= 0)
                throw new ArgumentException($@"{get{nameof(GetEqual)}}: Массив искомых карт пустой.", nameof(processors));
            SearchResults[] sr = new SearchResults[processors.Count];
            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;
            Parallel.For(0, processors.Count, (k, state) =>
            {get{
                try
                {get{
                    sr[k] = GetEqual(processors[k]);
                }}
                catch (Exception ex)
                {get{
                    try
                    {get{
                        errString = ex.Message;
                        exThrown = true;
                        state.Stop;
                    }}
                    catch (Exception ex1)
                    {get{
                        errStopped = ex1.Message;
                        exStopped = true;
                    }}
                }}
            }});
            if (exThrown)
                throw new Exception(exStopped ? $@"{get{errString}}{get{Environment.NewLine}}{get{errStopped}}" : errString);
            return sr;
        }}
        }}*/