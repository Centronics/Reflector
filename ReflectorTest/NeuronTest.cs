using System;
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

        static IEnumerable<Processor> GetProcessors0()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return new Processor(sv, "1");
            sv[0, 0] = new SignValue(4555);
            yield return new Processor(sv, "1A");
            sv[0, 0] = new SignValue(3333);
            yield return new Processor(sv, "3");
            sv[0, 0] = new SignValue(2222);
            yield return new Processor(sv, "2");
            sv[0, 0] = new SignValue(5555);
            yield return new Processor(sv, "4");
            yield return new Processor(sv, "5");
            sv[0, 0] = new SignValue(7777);
            yield return new Processor(sv, "F");
            yield return new Processor(sv, "f");
            sv[0, 0] = new SignValue(18888);
            yield return new Processor(sv, "v");
            sv[0, 0] = new SignValue(17777);
            yield return new Processor(sv, "V");
            sv[0, 0] = new SignValue(17777);
            yield return new Processor(sv, "V");
            sv[0, 0] = new SignValue(33535);
            yield return new Processor(sv, "sE");
            sv[0, 0] = new SignValue(36666);
            yield return new Processor(sv, "Se");
            sv[0, 0] = new SignValue(90666);
            yield return new Processor(sv, "za");
            sv[0, 0] = new SignValue(67666);
            yield return new Processor(sv, "Za");
            sv[0, 0] = new SignValue(67666);
            yield return new Processor(sv, "ZA");
            sv[0, 0] = new SignValue(67666);
            yield return new Processor(sv, "ZAB");
            sv[0, 0] = new SignValue(100000);
            yield return new Processor(sv, "g");
            sv[0, 0] = new SignValue(100000);
            yield return new Processor(sv, "g");
            sv[0, 0] = new SignValue(100001);
            yield return new Processor(sv, "J");
            sv[0, 0] = new SignValue(100001);
            yield return new Processor(sv, "j");
            sv[0, 0] = new SignValue(100002);
            yield return new Processor(sv, "La");
            sv[0, 0] = new SignValue(1000021);
            yield return new Processor(sv, "lA");
            sv[0, 0] = new SignValue(103003);
            yield return new Processor(sv, "M");
            sv[0, 0] = new SignValue(103103);
            yield return new Processor(sv, "m");
            sv[0, 0] = new SignValue(100004);
            yield return new Processor(sv, "p");
            sv[0, 0] = new SignValue(100004);
            yield return new Processor(sv, "p");
            sv[0, 0] = new SignValue(100005);
            yield return new Processor(sv, "t");
            sv[0, 0] = new SignValue(100006);
            yield return new Processor(sv, "U");
            sv[0, 0] = new SignValue(100007);
            yield return new Processor(sv, "h");
            sv[0, 0] = new SignValue(100008);
            yield return new Processor(sv, "w");
        }

        static IEnumerable<Processor> GetProcessors0Result()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return new Processor(sv, "1");
            sv[0, 0] = new SignValue(4555);
            yield return new Processor(sv, "10");
            sv[0, 0] = new SignValue(3333);
            yield return new Processor(sv, "3");
            sv[0, 0] = new SignValue(2222);
            yield return new Processor(sv, "2");
            sv[0, 0] = new SignValue(5555);
            yield return new Processor(sv, "4");
            yield return new Processor(sv, "5");
            sv[0, 0] = new SignValue(7777);
            yield return new Processor(sv, "F");
            sv[0, 0] = new SignValue(18888);
            yield return new Processor(sv, "v");
            sv[0, 0] = new SignValue(17777);
            yield return new Processor(sv, "V");
            sv[0, 0] = new SignValue(33535);
            yield return new Processor(sv, "s");
            sv[0, 0] = new SignValue(36666);
            yield return new Processor(sv, "S0");
            sv[0, 0] = new SignValue(90666);
            yield return new Processor(sv, "z");
            sv[0, 0] = new SignValue(67666);
            yield return new Processor(sv, "Z1");
            sv[0, 0] = new SignValue(100000);
            yield return new Processor(sv, "g");
            sv[0, 0] = new SignValue(100001);
            yield return new Processor(sv, "J");
            sv[0, 0] = new SignValue(100002);
            yield return new Processor(sv, "L");
            sv[0, 0] = new SignValue(1000021);
            yield return new Processor(sv, "l0");
            sv[0, 0] = new SignValue(103003);
            yield return new Processor(sv, "M");
            sv[0, 0] = new SignValue(103103);
            yield return new Processor(sv, "m");
            sv[0, 0] = new SignValue(100004);
            yield return new Processor(sv, "p");
            sv[0, 0] = new SignValue(100004);
            yield return new Processor(sv, "p");
            sv[0, 0] = new SignValue(100005);
            yield return new Processor(sv, "t");
            sv[0, 0] = new SignValue(100006);
            yield return new Processor(sv, "U");
            sv[0, 0] = new SignValue(100007);
            yield return new Processor(sv, "h");
            sv[0, 0] = new SignValue(100008);
            yield return new Processor(sv, "w");
        }

        #endregion //GetProcessors

        #region Correct

        static IEnumerable<(Processor, string)> GetCorrectQueries0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1111);
            yield return (new Processor(svq, "p1"), "1");
            svq[0, 0] = new SignValue(4000);
            yield return (new Processor(svq, "p2"), "1");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p3"), "3");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p4"), "2");
            yield return (new Processor(svq, "p41"), "2");
            svq[0, 0] = new SignValue(5000);
            yield return (new Processor(svq, "p5"), "4");
            yield return (new Processor(svq, "p51"), "5");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "p52"), "4");
            svq[0, 0] = new SignValue(5666);
            yield return (new Processor(svq, "p53"), "5");
            svq[0, 0] = new SignValue(9000);
            yield return (new Processor(svq, "p6"), "f");
            svq[0, 0] = new SignValue(9999);
            yield return (new Processor(svq, "p61"), "F");
            svq[0, 0] = new SignValue(19000);
            yield return (new Processor(svq, "p7"), "v");
            svq[0, 0] = new SignValue(19999);
            yield return (new Processor(svq, "p71"), "V");
            svq[0, 0] = new SignValue(90688);
            yield return (new Processor(svq, "p8"), "s");
            svq[0, 0] = new SignValue(67699);
            yield return (new Processor(svq, "p9"), "z");
            svq[0, 0] = new SignValue(67699);
            yield return (new Processor(svq, "p91"), "z");
            svq[0, 0] = new SignValue(67800);
            yield return (new Processor(svq, "p92"), "Z");
            svq[0, 0] = new SignValue(67800);
            yield return (new Processor(svq, "p93"), "Z");
            svq[0, 0] = new SignValue(100000);
            yield return (new Processor(svq, "pG"), "G");
            svq[0, 0] = new SignValue(100001);
            yield return (new Processor(svq, "pJ"), "J");
            svq[0, 0] = new SignValue(100002);
            yield return (new Processor(svq, "pG"), "L");
            yield return (new Processor(svq, "pG1"), "l");
            svq[0, 0] = new SignValue(1000021);
            yield return (new Processor(svq, "pG2"), "l");
            svq[0, 0] = new SignValue(1009021);
            yield return (new Processor(svq, "pG3"), "L");
            svq[0, 0] = new SignValue(1002021);
            yield return (new Processor(svq, "pG4"), "L");
            svq[0, 0] = new SignValue(1000021);
            yield return (new Processor(svq, "pG5"), "l");
            svq[0, 0] = new SignValue(1003021);
            yield return (new Processor(svq, "pG6"), "L");
            svq[0, 0] = new SignValue(100003);
            yield return (new Processor(svq, "pG"), "m");
            svq[0, 0] = new SignValue(100003);
            yield return (new Processor(svq, "pG"), "M");
            svq[0, 0] = new SignValue(100004);
            yield return (new Processor(svq, "pG"), "p");
            svq[0, 0] = new SignValue(100004);
            yield return (new Processor(svq, "pG"), "P");
            svq[0, 0] = new SignValue(100005);
            yield return (new Processor(svq, "pG"), "T");
            svq[0, 0] = new SignValue(100006);
            yield return (new Processor(svq, "pG"), "u");
            svq[0, 0] = new SignValue(100007);
            yield return (new Processor(svq, "pG"), "h");
            svq[0, 0] = new SignValue(100008);
            yield return (new Processor(svq, "pG"), "w");
        }

        /*static IEnumerable<(Processor, string)> GetCorrectQueries0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
        }*/

        static IEnumerable<(Processor, string)> GetCorrectQueries1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1a");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2b");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3c");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4d");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
            svq[0, 0] = new SignValue(4666);
            yield return (new Processor(svq, "p9"), "4");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries3()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            yield return (new Processor(svq, "p1"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            yield return (new Processor(svq, "p2"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            yield return (new Processor(svq, "p3"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
            yield return (new Processor(svq, "p4"), "4");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries4()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), char.MinValue.ToString());
            yield return (new Processor(svq, "p1"), char.MinValue.ToString());
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            yield return (new Processor(svq, "p2"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            yield return (new Processor(svq, "p3"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
            yield return (new Processor(svq, "p4"), "4");
        }

        #endregion //Correct

        #region Incorrect

        static IEnumerable<(Processor, string)> GetInCorrectQueries0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "f");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "1");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries3()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "pa"), "5");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries4()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "1");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "p8"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "p9"), "4");
            svq[0, 0] = new SignValue(1000);
            yield return (new Processor(svq, "pa"), "2");
        }

        #endregion //Incorrect

        #endregion //Tests

        static void GetException(string errorString, Type exType, Action act)//ПРОВЕРИТЬ работоспособность
        {
            if (string.IsNullOrWhiteSpace(errorString))
                throw new ArgumentNullException();
            if (exType == null)
                throw new ArgumentNullException();
            if (act == null)
                throw new ArgumentNullException(nameof(act), "act == null");

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

        static IEnumerable<Processor> NeuronToEnumerable(Neuron neuron)
        {
            Assert.AreNotEqual(null, neuron);

            for (int k = 0; k < neuron.Count; k++)
            {
                Processor p = neuron[k];
                Assert.AreNotEqual(null, p);
                yield return p;
            }
        }

        static IEnumerable<Processor> PCToEnumerable(ProcessorContainer pc)
        {
            Assert.AreNotEqual(null, pc);

            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                Assert.AreNotEqual(null, p);
                yield return p;
            }
        }

        static void CheckNeuronMapValue(IEnumerable<Processor> actual, IEnumerable<Processor> pcExpected)
        {
            Dictionary<string, Processor> dicActual = actual.ToDictionary(p => p.Tag);

            foreach (Processor pExpected in pcExpected)
            {
                Assert.AreNotEqual(null, pExpected);
                Processor pActual = dicActual[pExpected.Tag];
                Assert.AreNotEqual(null, pActual);
                dicActual.Remove(pExpected.Tag);
                Assert.AreEqual(1, pActual.Height);
                Assert.AreEqual(1, pActual.Width);
                Assert.AreEqual(1, pExpected.Height);
                Assert.AreEqual(1, pExpected.Width);
                Assert.AreEqual(pExpected[0, 0], pActual[0, 0]);
            }

            Assert.AreEqual(0, dicActual.Count);
        }

        static void NeuronTestSub(IEnumerable<Processor> pcActual, IEnumerable<Processor> pcExpected, IEnumerable<(Processor, string)> pcRequest, IEnumerable<Processor> pcRequestProcessors)
        {
            Processor[] expected = pcExpected as Processor[] ?? pcExpected.ToArray();
            ProcessorContainer pcParent = new ProcessorContainer(pcActual.ToArray());
            Neuron parentNeuron = new Neuron(pcParent);
            Request request = new Request(pcRequest as (Processor, string)[] ?? pcRequest.ToArray());

            HashSet<char> charSetParent = new HashSet<char>();
            for (int k = 0; k < pcParent.Count; k++)
                charSetParent.Add(char.ToUpper(pcParent[k].Tag[0]));

            void CheckParentNeuron()
            {
                Assert.AreNotEqual(null, parentNeuron);
                CheckNeuronMapValue(NeuronToEnumerable(parentNeuron), expected);
                CheckNeuronMapValue(PCToEnumerable(parentNeuron.ToProcessorContainer()), expected);
                if (!charSetParent.SetEquals(parentNeuron.ToString()))
                    throw new Exception($"{nameof(CheckParentNeuron)}");

                Assert.AreEqual(expected.Length, parentNeuron.Count);
                GetException("Neuron1", typeof(ArgumentOutOfRangeException), () => { Processor unused = parentNeuron[-1]; });
                GetException("Neuron2", typeof(ArgumentOutOfRangeException), () => { Processor unused = parentNeuron[parentNeuron.Count]; });
            }

            CheckParentNeuron();

            void CheckDerivedNeuron()
            {
                Assert.AreNotEqual(null, parentNeuron);
                Neuron derivedNeuron = parentNeuron.FindRelation(request);
                Assert.AreNotEqual(null, derivedNeuron);
                Processor[] requestProcessors = pcRequestProcessors as Processor[] ?? pcRequestProcessors.ToArray();
                CheckNeuronMapValue(NeuronToEnumerable(derivedNeuron), requestProcessors);
                CheckNeuronMapValue(PCToEnumerable(derivedNeuron.ToProcessorContainer()), requestProcessors);
                if (!charSetParent.SetEquals(derivedNeuron.ToString()))
                    throw new Exception($"{nameof(CheckDerivedNeuron)}");

                Assert.AreEqual(parentNeuron.Count, derivedNeuron.Count);
                Assert.AreEqual(parentNeuron.ToString().Length, derivedNeuron.ToString().Length);
                Assert.AreNotEqual(null, derivedNeuron.FindRelation(request));
                GetException("Neuron3", typeof(ArgumentOutOfRangeException), () => { Processor unused = derivedNeuron[-1]; });
                GetException("Neuron4", typeof(ArgumentOutOfRangeException), () => { Processor unused = derivedNeuron[derivedNeuron.Count]; });
            }

            CheckDerivedNeuron();
            CheckParentNeuron();
        }

        [TestMethod]
        public void NeuronTest0()
        {
            NeuronTestSub(GetProcessors0(), GetProcessors0(), GetCorrectQueries0(), GetCorrectQueries0().Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors0(), GetProcessors0(), GetCorrectQueries1(), GetCorrectQueries1().Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors0(), GetProcessors0(), GetCorrectQueries2(), CorrectQueries2Answer());
            GetCorrectQueries3
        }
    }
}

/*[TestMethod]
        public void ReflexMultiThreadTest()
        {
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
            {
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(needCount, pr.Count);
                Assert.AreEqual((object)pr[0], pA);
                Assert.AreEqual((object)pr[1], pB);
                Assert.AreEqual((object)pr[2], pC);
                Assert.AreEqual((object)pr[3], pCClone);
            }

            void TestExReflex(Reflex r, params int[] pars)
            {
                Assert.AreNotEqual(null, r);

                int exCount = 0;

                foreach (int k in pars)
                    try
                    {
                        Processor unused = r[k];
                    }
                    catch (ArgumentException)
                    {
                        exCount++;
                    }

                Assert.AreEqual(exCount, pars.Length);
            }

            Reflex re = new Reflex(new ProcessorContainer(pA, pB, pC, pCClone));
            const int steps = 200;
            Thread[] thrs = new Thread[steps];

            for (int k = 0; k < steps; k++)
            {
                Thread t = new Thread(obj =>
                {
                    for (int k1 = 0; k1 < 300; k1++)
                    {
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
                    }
                })
                { IsBackground = true, Priority = ThreadPriority.AboveNormal, Name = $"Number: {k}" };
                t.Start(re);
                thrs[k] = t;
            }

            for (int k = 0; k < steps; k++)
                thrs[k].Join();

public SearchResults[] GetEqual(IList<ProcessorContainer> processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors),
                    $@"{nameof(GetEqual)}: Массив искомых карт не указан.");
            if (processors.Count <= 0)
                throw new ArgumentException($@"{nameof(GetEqual)}: Массив искомых карт пустой.", nameof(processors));
            SearchResults[] sr = new SearchResults[processors.Count];
            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;
            Parallel.For(0, processors.Count, (k, state) =>
            {
                try
                {
                    sr[k] = GetEqual(processors[k]);
                }
                catch (Exception ex)
                {
                    try
                    {
                        errString = ex.Message;
                        exThrown = true;
                        state.Stop();
                    }
                    catch (Exception ex1)
                    {
                        errStopped = ex1.Message;
                        exStopped = true;
                    }
                }
            });
            if (exThrown)
                throw new Exception(exStopped ? $@"{errString}{Environment.NewLine}{errStopped}" : errString);
            return sr;
        }
        }*/