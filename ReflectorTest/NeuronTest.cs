using System;
using System.Collections.Generic;
using System.Linq;
using DynamicMosaic;
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
        static IEnumerable<(Processor, string)> GetQueries0()
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
        }

        static ProcessorContainer GetProcessorContainer0()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(2222);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(3333);
            Processor p3 = new Processor(sv, "3");
            sv[0, 0] = new SignValue(4444);
            Processor p4 = new Processor(sv, "4");
            return new ProcessorContainer(p1, p2, p3, p4);
        }

        static void GetException(string errorString, Type exType, Action act)//ПРОВЕРИТЬ работоспособность
        {
            if (act == null)
                throw new Exception("act == null");

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

        [TestMethod]
        public void NeuronTest0()
        {
            ProcessorContainer pcParent = GetProcessorContainer0();
            Neuron parentNeuron = new Neuron(GetProcessorContainer0());
            Request request = new Request(GetQueries0());

            void CheckParentNeuron()
            {
                Assert.AreNotEqual(null, parentNeuron);

                HashSet<char> charSet = new HashSet<char>();
                for (int k = 0; k < pcParent.Count; k++)
                    charSet.Add(char.ToUpper(pcParent[k].Tag[0]));
                for (int k = 0; k < parentNeuron.Count; k++)
                    if (!charSet.Contains(char.ToUpper(parentNeuron[0].Tag[0])))
                        throw new Exception($@"{nameof(NeuronTest0)}_0");
                if (parentNeuron.ToString().Any(c => !charSet.Contains(char.ToUpper(c))))
                    throw new Exception($"{nameof(NeuronTest0)}_1");

                Assert.AreEqual(4, parentNeuron.Count);
                Assert.AreEqual(4, parentNeuron.ToString().Length);
                Assert.AreEqual(true, parentNeuron.CheckRelation(request));
                Assert.AreEqual("1", parentNeuron[0]);
                GetException("Neuron1", typeof(ArgumentOutOfRangeException), () => { Processor unused = parentNeuron[-1]; });
                GetException("Neuron2", typeof(ArgumentOutOfRangeException), () => { Processor unused = parentNeuron[5]; });

                ProcessorContainer pc = parentNeuron.ToProcessorContainer();

            }

            CheckParentNeuron();

            void CheckDerivedNeuron()
            {
                Neuron derivedNeuron = parentNeuron.FindRelation(request);
                Assert.AreNotEqual(null, derivedNeuron);
                Assert.AreEqual("1234", derivedNeuron.ToString());
                Assert.AreEqual(parentNeuron.Count, derivedNeuron.Count);
                Assert.AreEqual(true, parentNeuron.CheckRelation(request));
                Assert.AreNotEqual(null, derivedNeuron.FindRelation(request));
            }

            CheckDerivedNeuron();
            CheckParentNeuron();
        }

        [TestMethod]
        public void NeuronTest1()
        {

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
        }*/