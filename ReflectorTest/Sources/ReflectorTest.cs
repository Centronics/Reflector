using System;
using DynamicParser;
using DynamicProcessor;
using DynamicReflector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor = DynamicParser.Processor;

// ReSharper disable InconsistentNaming

namespace ReflectorTest
{
    [TestClass]
    public class ReflectorTest
    {
        static ProcessorContainer Maps12
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p2 = new Processor(sv, "2");
                return new ProcessorContainer(p1, p2);
            }
        }

        static ProcessorContainer Maps34
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p3 = new Processor(sv, "3");
                sv[0, 0] = new SignValue(400000);
                sv[0, 1] = new SignValue(400000);
                sv[1, 0] = new SignValue(400000);
                sv[1, 1] = new SignValue(400000);
                Processor p4 = new Processor(sv, "4");
                return new ProcessorContainer(p3, p4);
            }
        }

        static ProcessorContainer Maps56
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(500000);
                sv[0, 1] = new SignValue(500000);
                sv[1, 0] = new SignValue(500000);
                sv[1, 1] = new SignValue(500000);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(600000);
                sv[0, 1] = new SignValue(600000);
                sv[1, 0] = new SignValue(600000);
                sv[1, 1] = new SignValue(600000);
                Processor p6 = new Processor(sv, "6");
                return new ProcessorContainer(p5, p6);
            }
        }

        static ProcessorContainer Maps78
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p8 = new Processor(sv, "8");
                return new ProcessorContainer(p7, p8);
            }
        }

        static ProcessorContainer Maps9A
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p9 = new Processor(sv, "9");
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pa = new Processor(sv, "a");
                return new ProcessorContainer(p9, pa);
            }
        }

        static ProcessorContainer MapsBC
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pb = new Processor(sv, "b");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pc = new Processor(sv, "c");
                return new ProcessorContainer(pb, pc);
            }
        }

        static ProcessorContainer MapsDE
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pd = new Processor(sv, "d");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pe = new Processor(sv, "e");
                return new ProcessorContainer(pd, pe);
            }
        }

        static ProcessorContainer MapsFG
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pf = new Processor(sv, "f");
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pg = new Processor(sv, "g");
                return new ProcessorContainer(pf, pg);
            }
        }

        static ProcessorContainer MapsHI
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor ph = new Processor(sv, "h");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pi = new Processor(sv, "i");
                return new ProcessorContainer(ph, pi);
            }
        }

        static ProcessorContainer[,] Pcs
        {
            get
            {
                ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
                pcs[0, 0] = Maps12;
                pcs[1, 0] = Maps34;
                pcs[2, 0] = Maps56;
                pcs[0, 1] = Maps78;
                pcs[1, 1] = Maps9A;
                pcs[2, 1] = MapsBC;
                pcs[0, 2] = MapsDE;
                pcs[1, 2] = MapsFG;
                pcs[2, 2] = MapsHI;

                return pcs;
            }
        }

        static Processor PrMas1
        {
            get
            {
                SignValue[,] prMas1 = new SignValue[6, 6];
                prMas1[0, 0] = new SignValue(440000);
                prMas1[1, 0] = new SignValue(440000);
                prMas1[2, 0] = new SignValue(250000);
                prMas1[3, 0] = new SignValue(250000);
                prMas1[4, 0] = new SignValue(240000);
                prMas1[5, 0] = new SignValue(240000);

                prMas1[0, 1] = new SignValue(440000);
                prMas1[1, 1] = new SignValue(440000);
                prMas1[2, 1] = new SignValue(250000);
                prMas1[3, 1] = new SignValue(250000);
                prMas1[4, 1] = new SignValue(240000);
                prMas1[5, 1] = new SignValue(240000);

                prMas1[0, 2] = new SignValue(400001);
                prMas1[1, 2] = new SignValue(400001);
                prMas1[2, 2] = new SignValue(100001);
                prMas1[3, 2] = new SignValue(100001);
                prMas1[4, 2] = new SignValue(300001);
                prMas1[5, 2] = new SignValue(300001);

                prMas1[0, 3] = new SignValue(400001);
                prMas1[1, 3] = new SignValue(400001);
                prMas1[2, 3] = new SignValue(100001);
                prMas1[3, 3] = new SignValue(100001);
                prMas1[4, 3] = new SignValue(300001);
                prMas1[5, 3] = new SignValue(300001);

                prMas1[0, 4] = new SignValue(540000);
                prMas1[1, 4] = new SignValue(540000);
                prMas1[2, 4] = new SignValue(200001);
                prMas1[3, 4] = new SignValue(200001);
                prMas1[4, 4] = new SignValue(100001);
                prMas1[5, 4] = new SignValue(100001);

                prMas1[0, 5] = new SignValue(540000);
                prMas1[1, 5] = new SignValue(540000);
                prMas1[2, 5] = new SignValue(200001);
                prMas1[3, 5] = new SignValue(200001);
                prMas1[4, 5] = new SignValue(100001);
                prMas1[5, 5] = new SignValue(100001);

                return new Processor(prMas1, "PrMas1");
            }
        }

        static Processor PrMas2
        {
            get
            {
                SignValue[,] prMas2 = new SignValue[6, 6];
                prMas2[0, 0] = new SignValue(470000);
                prMas2[1, 0] = new SignValue(470000);
                prMas2[2, 0] = new SignValue(230000);
                prMas2[3, 0] = new SignValue(230000);
                prMas2[4, 0] = new SignValue(260000);
                prMas2[5, 0] = new SignValue(260000);

                prMas2[0, 1] = new SignValue(470000);
                prMas2[1, 1] = new SignValue(470000);
                prMas2[2, 1] = new SignValue(230000);
                prMas2[3, 1] = new SignValue(230000);
                prMas2[4, 1] = new SignValue(260000);
                prMas2[5, 1] = new SignValue(260000);

                prMas2[0, 2] = new SignValue(400001);
                prMas2[1, 2] = new SignValue(400001);
                prMas2[2, 2] = new SignValue(100001);
                prMas2[3, 2] = new SignValue(100001);
                prMas2[4, 2] = new SignValue(300001);
                prMas2[5, 2] = new SignValue(300001);

                prMas2[0, 3] = new SignValue(400001);
                prMas2[1, 3] = new SignValue(400001);
                prMas2[2, 3] = new SignValue(100001);
                prMas2[3, 3] = new SignValue(100001);
                prMas2[4, 3] = new SignValue(300001);
                prMas2[5, 3] = new SignValue(300001);

                prMas2[0, 4] = new SignValue(560000);
                prMas2[1, 4] = new SignValue(560000);
                prMas2[2, 4] = new SignValue(200001);
                prMas2[3, 4] = new SignValue(200001);
                prMas2[4, 4] = new SignValue(100001);
                prMas2[5, 4] = new SignValue(100001);

                prMas2[0, 5] = new SignValue(560000);
                prMas2[1, 5] = new SignValue(560000);
                prMas2[2, 5] = new SignValue(200001);
                prMas2[3, 5] = new SignValue(200001);
                prMas2[4, 5] = new SignValue(100001);
                prMas2[5, 5] = new SignValue(100001);

                return new Processor(prMas2, "PrMas2");
            }
        }

        static Reflector GetReflector()
        {
            SignValue[] sv = {SignValue.MaxValue};
            Processor p1 = new Processor(sv, "1");
            sv[0] = new SignValue(1000);
            Processor p2 = new Processor(sv, "2");
            sv[0] = new SignValue(100);
            Processor p3 = new Processor(sv, "3");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 1];
            pcs[0, 0] = new ProcessorContainer(p1, p2, p3);
            Reflector reflector = new Reflector(pcs);
            Assert.AreEqual(reflector.MapWidth, 1);
            Assert.AreEqual(reflector.MapHeight, 1);
            return reflector;
        }

        static Reflector GetReflectorChanged()
        {
            SignValue[] sv = {SignValue.MaxValue};
            Processor p1 = new Processor(sv, "1");
            sv[0] = new SignValue(1000);
            Processor p2 = new Processor(sv, "2");
            sv[0] = new SignValue(100);
            Processor p3 = new Processor(sv, "3");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 1];
            pcs[0, 0] = new ProcessorContainer(p1, p2);
            Reflector reflector = new Reflector(pcs);
            pcs[0, 0].Add(p3);
            Assert.AreEqual(reflector.MapWidth, 1);
            Assert.AreEqual(reflector.MapHeight, 1);
            return reflector;
        }

        [TestMethod]
        public void SearchTest0()
        {
            Reflector reflector = GetReflectorChanged();
            Processor p11 = new Processor(new[] {SignValue.MaxValue}, "11");
            Processor p22 = new Processor(new[] {new SignValue(1000)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(100)}, "33");
            char[,] str = new char[1, 1];
            str[0, 0] = '1';
            Processor r1 = reflector.Push(p11, str);
            Assert.AreEqual(SignValue.MaxValue, r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '2';
            Processor r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p33, str));

            str[0, 0] = '1';
            r1 = reflector.Push(p11, str);
            Assert.AreEqual(SignValue.MaxValue, r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '2';
            r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p33, str));
        }

        [TestMethod]
        public void SearchTest1()
        {
            Reflector reflector = GetReflector();
            Processor p11 = new Processor(new[] {SignValue.MaxValue}, "11");
            Processor p22 = new Processor(new[] {new SignValue(1000)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(100)}, "33");
            char[,] str = new char[1, 1];
            str[0, 0] = '1';
            Processor r1 = reflector.Push(p11, str);
            Assert.AreEqual(SignValue.MaxValue, r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '2';
            Processor r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            Processor r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(100), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);

            str[0, 0] = '1';
            r1 = reflector.Push(p11, str);
            Assert.AreEqual(SignValue.MaxValue, r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '2';
            r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(100), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);
        }

        [TestMethod]
        public void SearchTest2()
        {
            Reflector reflector = GetReflector();
            Processor p11 = new Processor(new[] {SignValue.MaxValue}, "11");
            Processor p22 = new Processor(new[] {new SignValue(1000)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(100)}, "33");
            char[,] str = new char[1, 1];
            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p11, str));
            str[0, 0] = '1';
            Assert.AreEqual(null, reflector.Push(p22, str));
            str[0, 0] = '2';
            Assert.AreEqual(null, reflector.Push(p33, str));
            str[0, 0] = 'a';
            Assert.AreEqual(null, reflector.Push(p33, str));
            Assert.AreEqual(null, reflector.Push(p22, str));
            Assert.AreEqual(null, reflector.Push(p11, str));

            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p11, str));
            str[0, 0] = '1';
            Assert.AreEqual(null, reflector.Push(p22, str));
            str[0, 0] = '2';
            Assert.AreEqual(null, reflector.Push(p33, str));
            str[0, 0] = 'a';
            Assert.AreEqual(null, reflector.Push(p33, str));
            Assert.AreEqual(null, reflector.Push(p22, str));
            Assert.AreEqual(null, reflector.Push(p11, str));
        }

        [TestMethod]
        public void SearchTest3()
        {
            Reflector reflector = GetReflector();
            Processor p11 = new Processor(new[] {SignValue.MaxValue}, "11");
            Processor p22 = new Processor(new[] {new SignValue(1000)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(100)}, "33");
            char[,] str = new char[1, 1];
            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p11, str));
            str[0, 0] = '2';
            Processor r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '1';
            Assert.AreEqual(null, reflector.Push(p33, str));

            str[0, 0] = '3';
            Assert.AreEqual(null, reflector.Push(p11, str));
            str[0, 0] = '2';
            r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(1000), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '1';
            Assert.AreEqual(null, reflector.Push(p33, str));
        }

        [TestMethod]
        public void SearchTest4()
        {
            Reflector reflector = GetReflector();
            Processor p11 = new Processor(new[] {new SignValue(1000)}, "11");
            Processor p22 = new Processor(new[] {new SignValue(100)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(649)}, "33");
            Processor p44 = new Processor(new[] {new SignValue(549)}, "44");
            char[,] str = new char[1, 1];
            str[0, 0] = '2';
            Processor r1 = reflector.Push(p11, str);
            Assert.AreEqual(new SignValue(1000), r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '3';
            Processor r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(100), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '2';
            Processor r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(1000), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);
            str[0, 0] = '2';
            Processor r4 = reflector.Push(p44, str);
            Assert.AreEqual(new SignValue(1000), r4[0, 0]);
            Assert.AreEqual(1, r4.Length);

            str[0, 0] = '2';
            r1 = reflector.Push(p11, str);
            Assert.AreEqual(new SignValue(1000), r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '3';
            r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(100), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '2';
            r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(1000), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);
            str[0, 0] = '2';
            r4 = reflector.Push(p44, str);
            Assert.AreEqual(new SignValue(1000), r4[0, 0]);
            Assert.AreEqual(1, r4.Length);
        }

        [TestMethod]
        public void SearchTest5()
        {
            Reflector reflector = GetReflector();
            Processor p11 = new Processor(new[] {new SignValue(1000)}, "11");
            Processor p22 = new Processor(new[] {new SignValue(100)}, "22");
            Processor p33 = new Processor(new[] {new SignValue(549)}, "33");
            Processor p44 = new Processor(new[] {new SignValue(649)}, "44");
            char[,] str = new char[1, 1];
            str[0, 0] = '2';
            Processor r1 = reflector.Push(p11, str);
            Assert.AreEqual(new SignValue(1000), r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '3';
            Processor r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(100), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            Processor r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(100), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);
            str[0, 0] = '3';
            Processor r4 = reflector.Push(p44, str);
            Assert.AreEqual(new SignValue(100), r4[0, 0]);
            Assert.AreEqual(1, r4.Length);
            str[0, 0] = '2';
            Assert.AreEqual(null, reflector.Push(p44, str));

            str[0, 0] = '2';
            r1 = reflector.Push(p11, str);
            Assert.AreEqual(new SignValue(1000), r1[0, 0]);
            Assert.AreEqual(1, r1.Length);
            str[0, 0] = '3';
            r2 = reflector.Push(p22, str);
            Assert.AreEqual(new SignValue(100), r2[0, 0]);
            Assert.AreEqual(1, r2.Length);
            str[0, 0] = '3';
            r3 = reflector.Push(p33, str);
            Assert.AreEqual(new SignValue(100), r3[0, 0]);
            Assert.AreEqual(1, r3.Length);
            str[0, 0] = '3';
            r4 = reflector.Push(p44, str);
            Assert.AreEqual(new SignValue(100), r4[0, 0]);
            Assert.AreEqual(1, r4.Length);
            str[0, 0] = '2';
            Assert.AreEqual(null, reflector.Push(p44, str));
        }

        [TestMethod]
        public void SearchTest6()
        {
            SignValue[] sv = {SignValue.MaxValue, SignValue.MinValue};
            Processor p1 = new Processor(sv, "1");
            sv[0] = new SignValue(1000);
            sv[1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0] = new SignValue(100);
            sv[1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            sv[0] = SignValue.MaxValue;
            sv[1] = SignValue.MinValue;
            Processor p4 = new Processor(sv, "4");
            sv[0] = new SignValue(1000);
            sv[1] = new SignValue(200);
            Processor p5 = new Processor(sv, "5");
            sv[0] = new SignValue(100);
            sv[1] = new SignValue(500);
            Processor p6 = new Processor(sv, "6");
            sv[0] = SignValue.MaxValue;
            sv[1] = SignValue.MinValue;
            Processor p7 = new Processor(sv, "7");
            sv[0] = new SignValue(1000);
            sv[1] = new SignValue(200);
            Processor p8 = new Processor(sv, "8");
            sv[0] = new SignValue(100);
            sv[1] = new SignValue(500);
            Processor p9 = new Processor(sv, "9");
            ProcessorContainer[,] pcs = new ProcessorContainer[3, 1];
            pcs[0, 0] = new ProcessorContainer(p9, p8, p7);
            pcs[1, 0] = new ProcessorContainer(p5, p4, p6);
            pcs[2, 0] = new ProcessorContainer(p3, p2, p1);
            Processor processor = new Processor(new[]
            {
                new SignValue(SignValue.MaxValue - 100000), new SignValue(900000),
                new SignValue(2000), new SignValue(300),
                new SignValue(90), new SignValue(300)
            }, "map");
            char[,] str = new char[3, 1];
            str[0, 0] = '7';
            str[1, 0] = '5';
            str[2, 0] = '3';
            Reflector reflector = new Reflector(pcs);
            Processor p = reflector.Push(processor, str);
            Assert.AreNotEqual(null, p);
            Assert.AreEqual(6, p.Width);
            Assert.AreEqual(1, p.Height);
            Assert.AreEqual(SignValue.MaxValue, p[0, 0]);
            Assert.AreEqual(SignValue.MinValue, p[1, 0]);
            Assert.AreEqual(new SignValue(1000), p[2, 0]);
            Assert.AreEqual(new SignValue(200), p[3, 0]);
            Assert.AreEqual(new SignValue(100), p[4, 0]);
            Assert.AreEqual(new SignValue(500), p[5, 0]);
        }

        [TestMethod]
        public void SearchTest7()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p6 = new Processor(sv, "6");
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p7 = new Processor(sv, "7");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p8 = new Processor(sv, "8");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p9 = new Processor(sv, "9");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 1] = new ProcessorContainer(p4, p5, p6);
            pcs[0, 2] = new ProcessorContainer(p7, p8, p9);
            SignValue[,] prMas = new SignValue[1, 6];
            prMas[0, 0] = new SignValue(SignValue.MaxValue - 100000);
            prMas[0, 1] = new SignValue(900000);
            prMas[0, 2] = new SignValue(2000);
            prMas[0, 3] = new SignValue(300);
            prMas[0, 4] = new SignValue(90);
            prMas[0, 5] = new SignValue(300);
            char[,] str = new char[1, 3];
            str[0, 0] = '1';
            str[0, 1] = '5';
            str[0, 2] = '8';
            Processor p = new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
            Assert.AreNotEqual(null, p);
            Assert.AreEqual(1, p.Width);
            Assert.AreEqual(6, p.Height);
            Assert.AreEqual(SignValue.MaxValue, p[0, 0]);
            Assert.AreEqual(SignValue.MinValue, p[0, 1]);
            Assert.AreEqual(new SignValue(1000), p[0, 2]);
            Assert.AreEqual(new SignValue(200), p[0, 3]);
            Assert.AreEqual(new SignValue(1000), p[0, 4]);
            Assert.AreEqual(new SignValue(200), p[0, 5]);
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void SearchTest8()
        {
            for (int k = 0; k < 50000; k++)
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p2 = new Processor(sv, "2");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p3 = new Processor(sv, "3");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p4 = new Processor(sv, "4");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p6 = new Processor(sv, "6");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p8 = new Processor(sv, "8");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p9 = new Processor(sv, "9");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p10 = new Processor(sv, "A");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p11 = new Processor(sv, "b");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p12 = new Processor(sv, "c");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p13 = new Processor(sv, "d");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p14 = new Processor(sv, "E");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p15 = new Processor(sv, "f");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p16 = new Processor(sv, "g");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p17 = new Processor(sv, "h");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p18 = new Processor(sv, "i");

                ProcessorContainer pc1 = new ProcessorContainer(p1, p2);
                ProcessorContainer pc2 = new ProcessorContainer(p3, p4);
                ProcessorContainer pc3 = new ProcessorContainer(p5, p6);
                ProcessorContainer pc4 = new ProcessorContainer(p7, p8);
                ProcessorContainer pc5 = new ProcessorContainer(p9, p10);
                ProcessorContainer pc6 = new ProcessorContainer(p11, p12);
                ProcessorContainer pc7 = new ProcessorContainer(p13, p14);
                ProcessorContainer pc8 = new ProcessorContainer(p15, p16);
                ProcessorContainer pc9 = new ProcessorContainer(p17, p18);

                ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
                pcs[0, 0] = pc1;
                pcs[1, 0] = pc2;
                pcs[2, 0] = pc3;
                pcs[0, 1] = pc4;
                pcs[1, 1] = pc5;
                pcs[2, 1] = pc6;
                pcs[0, 2] = pc7;
                pcs[1, 2] = pc8;
                pcs[2, 2] = pc9;

                SignValue[,] prMas = new SignValue[6, 6];
                prMas[0, 0] = new SignValue(100001);
                prMas[1, 0] = new SignValue(100001);
                prMas[2, 0] = new SignValue(300001);
                prMas[3, 0] = new SignValue(300001);
                prMas[4, 0] = new SignValue(200001);
                prMas[5, 0] = new SignValue(200001);

                prMas[0, 1] = new SignValue(100001);
                prMas[1, 1] = new SignValue(100001);
                prMas[2, 1] = new SignValue(300001);
                prMas[3, 1] = new SignValue(300001);
                prMas[4, 1] = new SignValue(200001);
                prMas[5, 1] = new SignValue(200001);

                prMas[0, 2] = new SignValue(200001);
                prMas[1, 2] = new SignValue(200001);
                prMas[2, 2] = new SignValue(100001);
                prMas[3, 2] = new SignValue(100001);
                prMas[4, 2] = new SignValue(300001);
                prMas[5, 2] = new SignValue(300001);

                prMas[0, 3] = new SignValue(200001);
                prMas[1, 3] = new SignValue(200001);
                prMas[2, 3] = new SignValue(100001);
                prMas[3, 3] = new SignValue(100001);
                prMas[4, 3] = new SignValue(300001);
                prMas[5, 3] = new SignValue(300001);

                prMas[0, 4] = new SignValue(300001);
                prMas[1, 4] = new SignValue(300001);
                prMas[2, 4] = new SignValue(200001);
                prMas[3, 4] = new SignValue(200001);
                prMas[4, 4] = new SignValue(100001);
                prMas[5, 4] = new SignValue(100001);

                prMas[0, 5] = new SignValue(300001);
                prMas[1, 5] = new SignValue(300001);
                prMas[2, 5] = new SignValue(200001);
                prMas[3, 5] = new SignValue(200001);
                prMas[4, 5] = new SignValue(100001);
                prMas[5, 5] = new SignValue(100001);

                char[,] str = new char[3, 3];

                str[0, 0] = '1';
                str[1, 0] = '3';
                str[2, 0] = '5';

                str[0, 1] = '8';
                str[1, 1] = 'a';
                str[2, 1] = 'c';

                str[0, 2] = 'e';
                str[1, 2] = 'f';
                str[2, 2] = 'H';

                Processor p = new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
                Assert.AreNotEqual(null, p);
                Assert.AreEqual(6, p.Width);
                Assert.AreEqual(6, p.Height);

                Assert.AreEqual(new SignValue(100000), p[0, 0]);
                Assert.AreEqual(new SignValue(100000), p[1, 0]);
                Assert.AreEqual(new SignValue(300000), p[2, 0]);
                Assert.AreEqual(new SignValue(300000), p[3, 0]);
                Assert.AreEqual(new SignValue(200000), p[4, 0]);
                Assert.AreEqual(new SignValue(200000), p[5, 0]);

                Assert.AreEqual(new SignValue(100000), p[0, 1]);
                Assert.AreEqual(new SignValue(100000), p[1, 1]);
                Assert.AreEqual(new SignValue(300000), p[2, 1]);
                Assert.AreEqual(new SignValue(300000), p[3, 1]);
                Assert.AreEqual(new SignValue(200000), p[4, 1]);
                Assert.AreEqual(new SignValue(200000), p[5, 1]);

                Assert.AreEqual(new SignValue(200000), p[0, 2]);
                Assert.AreEqual(new SignValue(200000), p[1, 2]);
                Assert.AreEqual(new SignValue(100000), p[2, 2]);
                Assert.AreEqual(new SignValue(100000), p[3, 2]);
                Assert.AreEqual(new SignValue(300000), p[4, 2]);
                Assert.AreEqual(new SignValue(300000), p[5, 2]);

                Assert.AreEqual(new SignValue(200000), p[0, 3]);
                Assert.AreEqual(new SignValue(200000), p[1, 3]);
                Assert.AreEqual(new SignValue(100000), p[2, 3]);
                Assert.AreEqual(new SignValue(100000), p[3, 3]);
                Assert.AreEqual(new SignValue(300000), p[4, 3]);
                Assert.AreEqual(new SignValue(300000), p[5, 3]);

                Assert.AreEqual(new SignValue(200000), p[0, 4]);
                Assert.AreEqual(new SignValue(200000), p[1, 4]);
                Assert.AreEqual(new SignValue(300000), p[2, 4]);
                Assert.AreEqual(new SignValue(300000), p[3, 4]);
                Assert.AreEqual(new SignValue(200000), p[4, 4]);
                Assert.AreEqual(new SignValue(200000), p[5, 4]);

                Assert.AreEqual(new SignValue(200000), p[0, 5]);
                Assert.AreEqual(new SignValue(200000), p[1, 5]);
                Assert.AreEqual(new SignValue(300000), p[2, 5]);
                Assert.AreEqual(new SignValue(300000), p[3, 5]);
                Assert.AreEqual(new SignValue(200000), p[4, 5]);
                Assert.AreEqual(new SignValue(200000), p[5, 5]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchTest10()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 1] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 2] = new ProcessorContainer(p1, p2, p3);
            char[,] str = new char[1, 3];
            str[0, 0] = '1';
            str[0, 1] = '2';
            str[0, 2] = '3';
            new Reflector(pcs).Push(new Processor(new SignValue[1, 5], "Map"), str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchTest11()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 1] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 2] = new ProcessorContainer(p1, p2, p3);
            char[,] str = new char[1, 3];
            str[0, 0] = '1';
            str[0, 1] = '2';
            str[0, 2] = '3';
            new Reflector(pcs).Push(new Processor(new SignValue[1, 7], "Map"), str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchTest12()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p6 = new Processor(sv, "6");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2);
            pcs[0, 1] = new ProcessorContainer(p3, p4);
            pcs[0, 2] = new ProcessorContainer(p5, p6);
            char[,] str = new char[1, 3];
            str[0, 0] = '1';
            str[0, 1] = '4';
            str[0, 2] = '6';
            new Reflector(pcs).Push(null, str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchTest13()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p3 = new Processor(sv, "3");
            sv[0, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MinValue;
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(1000);
            sv[0, 1] = new SignValue(200);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(100);
            sv[0, 1] = new SignValue(500);
            Processor p6 = new Processor(sv, "6");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2);
            pcs[0, 1] = new ProcessorContainer(p3, p4);
            pcs[0, 2] = new ProcessorContainer(p5, p6);
            SignValue[,] prMas = new SignValue[1, 6];
            prMas[0, 0] = new SignValue(SignValue.MaxValue - 100000);
            prMas[0, 1] = new SignValue(900000);
            prMas[0, 2] = new SignValue(2000);
            prMas[0, 3] = new SignValue(300);
            prMas[0, 4] = new SignValue(90);
            prMas[0, 5] = new SignValue(300);
            new Reflector(pcs).Push(new Processor(prMas, "Map"), null);
        }

        [TestMethod]
        public void SearchTest15()
        {
            SignValue[,] sv = new SignValue[2, 2];
            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p3 = new Processor(sv, "3");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p6 = new Processor(sv, "6");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p7 = new Processor(sv, "7");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p8 = new Processor(sv, "8");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p9 = new Processor(sv, "9");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pa = new Processor(sv, "a");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor pb = new Processor(sv, "b");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pc = new Processor(sv, "c");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pd = new Processor(sv, "d");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor pe = new Processor(sv, "e");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pf = new Processor(sv, "f");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pg = new Processor(sv, "g");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor ph = new Processor(sv, "h");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pi = new Processor(sv, "i");

            ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2);
            pcs[1, 0] = new ProcessorContainer(p3, p4);
            pcs[2, 0] = new ProcessorContainer(p5, p6);
            pcs[0, 1] = new ProcessorContainer(p7, p8);
            pcs[1, 1] = new ProcessorContainer(p9, pa);
            pcs[2, 1] = new ProcessorContainer(pb, pc);
            pcs[0, 2] = new ProcessorContainer(pd, pe);
            pcs[1, 2] = new ProcessorContainer(pf, pg);
            pcs[2, 2] = new ProcessorContainer(ph, pi);

            Processor p = new Processor(new SignValue[6, 6], "Map");

            char[,] str = new char[3, 3];

            str[0, 0] = '1';
            str[1, 0] = '4';
            str[2, 0] = '5';

            str[0, 1] = '7';
            str[1, 1] = 'a';
            str[2, 1] = 'b';

            str[0, 2] = 'd';
            str[1, 2] = 'g';
            str[2, 2] = 'h';

            Assert.AreNotEqual(null, new Reflector(pcs).Push(p, str));

            byte count = 0;

            str = new char[4, 3];
            str[0, 0] = '1';
            str[1, 0] = '3';
            str[2, 0] = '4';
            str[3, 0] = '5';

            str[0, 1] = '6';
            str[1, 1] = '7';
            str[2, 1] = '8';
            str[3, 1] = '9';

            str[0, 2] = 'a';
            str[1, 2] = 'b';
            str[2, 2] = 'c';
            str[3, 2] = 'd';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (ArgumentException)
            {
                count++;
            }

            str = new char[3, 4];
            str[0, 0] = '1';
            str[1, 0] = '2';
            str[2, 0] = '3';

            str[0, 1] = '4';
            str[1, 1] = '5';
            str[2, 1] = '6';

            str[0, 2] = '7';
            str[1, 2] = '8';
            str[2, 2] = '9';

            str[0, 3] = 'a';
            str[1, 3] = 'b';
            str[2, 3] = 'c';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (ArgumentException)
            {
                count++;
            }

            str = new char[3, 2];
            str[0, 0] = '1';
            str[1, 0] = '3';
            str[2, 0] = '2';

            str[0, 1] = '4';
            str[1, 1] = '5';
            str[2, 1] = '6';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (ArgumentException)
            {
                count++;
            }

            str = new char[2, 3];
            str[0, 0] = '1';
            str[1, 0] = '3';

            str[0, 1] = '4';
            str[1, 1] = '5';

            str[0, 0] = '6';
            str[1, 0] = '7';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (ArgumentException)
            {
                count++;
            }

            str = new char[3, 3];
            str[0, 0] = '1';
            str[1, 0] = '2';
            str[2, 0] = '3';

            str[0, 1] = '4';
            str[1, 1] = '5';
            str[2, 1] = ' ';

            str[0, 2] = '7';
            str[1, 2] = '8';
            str[2, 2] = '9';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (Exception)
            {
                count++;
            }

            str = new char[3, 3];
            str[0, 0] = '1';
            str[1, 0] = '2';
            str[2, 0] = '3';

            str[0, 1] = '4';
            str[1, 1] = '5';
            str[2, 1] = (char) 9;

            str[0, 2] = '7';
            str[1, 2] = '8';
            str[2, 2] = '9';

            try
            {
                new Reflector(pcs).Push(p, str);
            }
            catch (Exception)
            {
                count++;
            }

            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void SearchTest16()
        {
            SignValue[,] sv = new SignValue[1, 2];
            Processor p1 = new Processor(sv, "1");
            Processor p2 = new Processor(sv, "35");
            Processor p3 = new Processor(sv, "32");
            ProcessorContainer[,] pcs = new ProcessorContainer[1, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 1] = new ProcessorContainer(p1, p2, p3);
            pcs[0, 2] = new ProcessorContainer(p1, p2, p3);
            SignValue[,] prMas = new SignValue[6, 6];
            Assert.AreEqual(true, TestMapNaming('\0', pcs, prMas));
            Assert.AreEqual(true, TestMapNaming(' ', pcs, prMas));
            Assert.AreEqual(true, TestMapNaming((char) 9, pcs, prMas));
        }

        static bool TestMapNaming(char s, ProcessorContainer[,] pcs, SignValue[,] prMas)
        {
            byte count = 0;
            char[,] str = new char[3, 3];
            for (int y = 0; y < str.GetLength(1); y++)
            for (int x = 0; x < str.GetLength(0); x++)
            {
                str[0, 0] = '1';
                str[1, 0] = '2';
                str[2, 0] = '3';
                str[0, 1] = '1';
                str[1, 1] = '3';
                str[2, 1] = '2';
                str[0, 2] = '2';
                str[1, 2] = '1';
                str[2, 2] = '3';

                str[x, y] = s;

                try
                {
                    new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
                }
                catch (ArgumentException)
                {
                    count++;
                }
            }
            return count == 9;
        }

        static bool CheckString(SignValue[,] prMas, char t, char[,] str, ProcessorContainer[,] pcs)
        {
            byte result = 0;
            for (int y = 0; y < str.GetLength(1); y++)
            for (int x = 0; x < str.GetLength(0); x++)
            {
                str[0, 0] = '1';
                str[1, 0] = '3';
                str[2, 0] = '2';

                str[0, 1] = '2';
                str[1, 1] = '1';
                str[2, 1] = '3';

                str[0, 2] = '3';
                str[1, 2] = '3';
                str[2, 2] = '1';

                str[x, y] = t;

                try
                {
                    new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
                }
                catch (ArgumentException)
                {
                    result++;
                }
            }
            return result == 9;
        }

        [TestMethod]
        public void SearchTest17()
        {
            SignValue[,] sv = new SignValue[2, 2];
            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p3 = new Processor(sv, "3");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p6 = new Processor(sv, "6");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor p7 = new Processor(sv, "7");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor p8 = new Processor(sv, "8");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor p9 = new Processor(sv, "9");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pa = new Processor(sv, "a");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor pb = new Processor(sv, "b");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pc = new Processor(sv, "c");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pd = new Processor(sv, "d");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor pe = new Processor(sv, "e");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pf = new Processor(sv, "f");

            sv[0, 0] = new SignValue(100000);
            sv[0, 1] = new SignValue(100000);
            sv[1, 0] = new SignValue(100000);
            sv[1, 1] = new SignValue(100000);
            Processor pg = new Processor(sv, "g");
            sv[0, 0] = new SignValue(200000);
            sv[0, 1] = new SignValue(200000);
            sv[1, 0] = new SignValue(200000);
            sv[1, 1] = new SignValue(200000);
            Processor ph = new Processor(sv, "h");
            sv[0, 0] = new SignValue(300000);
            sv[0, 1] = new SignValue(300000);
            sv[1, 0] = new SignValue(300000);
            sv[1, 1] = new SignValue(300000);
            Processor pi = new Processor(sv, "i");

            ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
            pcs[0, 0] = new ProcessorContainer(p1, p2);
            pcs[1, 0] = new ProcessorContainer(p3, p4);
            pcs[2, 0] = new ProcessorContainer(p5, p6);
            pcs[0, 1] = new ProcessorContainer(p7, p8);
            pcs[1, 1] = new ProcessorContainer(p9, pa);
            pcs[2, 1] = new ProcessorContainer(pb, pc);
            pcs[0, 2] = new ProcessorContainer(pd, pe);
            pcs[1, 2] = new ProcessorContainer(pf, pg);
            pcs[2, 2] = new ProcessorContainer(ph, pi);

            char[,] str = new char[3, 3];
            SignValue[,] prMas = new SignValue[6, 6];

            Assert.AreEqual(true, CheckString(prMas, ' ', str, pcs));
            Assert.AreEqual(true, CheckString(prMas, (char) 9, str, pcs));

            str[0, 0] = '1';
            str[1, 0] = '4';
            str[2, 0] = '5';

            str[0, 1] = '7';
            str[1, 1] = 'a';
            str[2, 1] = 'b';

            str[0, 2] = 'd';
            str[1, 2] = 'g';
            str[2, 2] = 'h';

            Processor p = new Reflector(pcs).Push(new Processor(prMas, "Map"), str);

            Assert.AreNotEqual(null, p);
            Assert.AreEqual(prMas.GetLength(0), p.Width);
            Assert.AreEqual(prMas.GetLength(1), p.Height);

            Assert.AreEqual(new SignValue(100000), p[0, 0]);
            Assert.AreEqual(new SignValue(100000), p[1, 0]);
            Assert.AreEqual(new SignValue(100000), p[2, 0]);
            Assert.AreEqual(new SignValue(100000), p[3, 0]);
            Assert.AreEqual(new SignValue(200000), p[4, 0]);
            Assert.AreEqual(new SignValue(200000), p[5, 0]);

            Assert.AreEqual(new SignValue(100000), p[0, 1]);
            Assert.AreEqual(new SignValue(100000), p[1, 1]);
            Assert.AreEqual(new SignValue(100000), p[2, 1]);
            Assert.AreEqual(new SignValue(100000), p[3, 1]);
            Assert.AreEqual(new SignValue(200000), p[4, 1]);
            Assert.AreEqual(new SignValue(200000), p[5, 1]);

            Assert.AreEqual(new SignValue(100000), p[0, 2]);
            Assert.AreEqual(new SignValue(100000), p[1, 2]);
            Assert.AreEqual(new SignValue(100000), p[2, 2]);
            Assert.AreEqual(new SignValue(100000), p[3, 2]);
            Assert.AreEqual(new SignValue(200000), p[4, 2]);
            Assert.AreEqual(new SignValue(200000), p[5, 2]);

            Assert.AreEqual(new SignValue(100000), p[0, 3]);
            Assert.AreEqual(new SignValue(100000), p[1, 3]);
            Assert.AreEqual(new SignValue(100000), p[2, 3]);
            Assert.AreEqual(new SignValue(100000), p[3, 3]);
            Assert.AreEqual(new SignValue(200000), p[4, 3]);
            Assert.AreEqual(new SignValue(200000), p[5, 3]);

            Assert.AreEqual(new SignValue(100000), p[0, 4]);
            Assert.AreEqual(new SignValue(100000), p[1, 4]);
            Assert.AreEqual(new SignValue(100000), p[2, 4]);
            Assert.AreEqual(new SignValue(100000), p[3, 4]);
            Assert.AreEqual(new SignValue(200000), p[4, 4]);
            Assert.AreEqual(new SignValue(200000), p[5, 4]);

            Assert.AreEqual(new SignValue(100000), p[0, 5]);
            Assert.AreEqual(new SignValue(100000), p[1, 5]);
            Assert.AreEqual(new SignValue(100000), p[2, 5]);
            Assert.AreEqual(new SignValue(100000), p[3, 5]);
            Assert.AreEqual(new SignValue(200000), p[4, 5]);
            Assert.AreEqual(new SignValue(200000), p[5, 5]);
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void SearchTest18()
        {
            for (int k = 0; k < 50000; k++)
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p2 = new Processor(sv, "2");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p3 = new Processor(sv, "3");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p4 = new Processor(sv, "4");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p6 = new Processor(sv, "6");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p8 = new Processor(sv, "8");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p9 = new Processor(sv, "9");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pa = new Processor(sv, "a");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pb = new Processor(sv, "b");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pc = new Processor(sv, "c");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pd = new Processor(sv, "d");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pe = new Processor(sv, "e");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pf = new Processor(sv, "f");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pg = new Processor(sv, "g");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor ph = new Processor(sv, "h");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pi = new Processor(sv, "i");

                ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
                pcs[0, 0] = new ProcessorContainer(p1, p2);
                pcs[1, 0] = new ProcessorContainer(p3, p4);
                pcs[2, 0] = new ProcessorContainer(p5, p6);
                pcs[0, 1] = new ProcessorContainer(p7, p8);
                pcs[1, 1] = new ProcessorContainer(p9, pa);
                pcs[2, 1] = new ProcessorContainer(pb, pc);
                pcs[0, 2] = new ProcessorContainer(pd, pe);
                pcs[1, 2] = new ProcessorContainer(pf, pg);
                pcs[2, 2] = new ProcessorContainer(ph, pi);

                SignValue[,] prMas = new SignValue[6, 6];
                prMas[0, 0] = new SignValue(500001);
                prMas[1, 0] = new SignValue(500001);
                prMas[2, 0] = new SignValue(300001);
                prMas[3, 0] = new SignValue(300001);
                prMas[4, 0] = new SignValue(200001);
                prMas[5, 0] = new SignValue(200001);

                prMas[0, 1] = new SignValue(500001);
                prMas[1, 1] = new SignValue(500001);
                prMas[2, 1] = new SignValue(300001);
                prMas[3, 1] = new SignValue(300001);
                prMas[4, 1] = new SignValue(200001);
                prMas[5, 1] = new SignValue(200001);

                prMas[0, 2] = new SignValue(400001);
                prMas[1, 2] = new SignValue(400001);
                prMas[2, 2] = new SignValue(100001);
                prMas[3, 2] = new SignValue(100001);
                prMas[4, 2] = new SignValue(300001);
                prMas[5, 2] = new SignValue(300001);

                prMas[0, 3] = new SignValue(400001);
                prMas[1, 3] = new SignValue(400001);
                prMas[2, 3] = new SignValue(100001);
                prMas[3, 3] = new SignValue(100001);
                prMas[4, 3] = new SignValue(300001);
                prMas[5, 3] = new SignValue(300001);

                prMas[0, 4] = new SignValue(600001);
                prMas[1, 4] = new SignValue(600001);
                prMas[2, 4] = new SignValue(200001);
                prMas[3, 4] = new SignValue(200001);
                prMas[4, 4] = new SignValue(100001);
                prMas[5, 4] = new SignValue(100001);

                prMas[0, 5] = new SignValue(600001);
                prMas[1, 5] = new SignValue(600001);
                prMas[2, 5] = new SignValue(200001);
                prMas[3, 5] = new SignValue(200001);
                prMas[4, 5] = new SignValue(100001);
                prMas[5, 5] = new SignValue(100001);

                char[,] str = new char[3, 3];

                str[0, 0] = '2';
                str[1, 0] = '3';
                str[2, 0] = '5';

                str[0, 1] = '8';
                str[1, 1] = 'a';
                str[2, 1] = 'c';

                str[0, 2] = 'e';
                str[1, 2] = 'f';
                str[2, 2] = 'h';

                Processor p = new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
                Assert.AreNotEqual(null, p);
                Assert.AreEqual(6, p.Width);
                Assert.AreEqual(6, p.Height);

                Assert.AreEqual(new SignValue(200000), p[0, 0]);
                Assert.AreEqual(new SignValue(200000), p[1, 0]);
                Assert.AreEqual(new SignValue(300000), p[2, 0]);
                Assert.AreEqual(new SignValue(300000), p[3, 0]);
                Assert.AreEqual(new SignValue(200000), p[4, 0]);
                Assert.AreEqual(new SignValue(200000), p[5, 0]);

                Assert.AreEqual(new SignValue(200000), p[0, 1]);
                Assert.AreEqual(new SignValue(200000), p[1, 1]);
                Assert.AreEqual(new SignValue(300000), p[2, 1]);
                Assert.AreEqual(new SignValue(300000), p[3, 1]);
                Assert.AreEqual(new SignValue(200000), p[4, 1]);
                Assert.AreEqual(new SignValue(200000), p[5, 1]);

                Assert.AreEqual(new SignValue(200000), p[0, 2]);
                Assert.AreEqual(new SignValue(200000), p[1, 2]);
                Assert.AreEqual(new SignValue(100000), p[2, 2]);
                Assert.AreEqual(new SignValue(100000), p[3, 2]);
                Assert.AreEqual(new SignValue(300000), p[4, 2]);
                Assert.AreEqual(new SignValue(300000), p[5, 2]);

                Assert.AreEqual(new SignValue(200000), p[0, 3]);
                Assert.AreEqual(new SignValue(200000), p[1, 3]);
                Assert.AreEqual(new SignValue(100000), p[2, 3]);
                Assert.AreEqual(new SignValue(100000), p[3, 3]);
                Assert.AreEqual(new SignValue(300000), p[4, 3]);
                Assert.AreEqual(new SignValue(300000), p[5, 3]);

                Assert.AreEqual(new SignValue(200000), p[0, 4]);
                Assert.AreEqual(new SignValue(200000), p[1, 4]);
                Assert.AreEqual(new SignValue(300000), p[2, 4]);
                Assert.AreEqual(new SignValue(300000), p[3, 4]);
                Assert.AreEqual(new SignValue(200000), p[4, 4]);
                Assert.AreEqual(new SignValue(200000), p[5, 4]);

                Assert.AreEqual(new SignValue(200000), p[0, 5]);
                Assert.AreEqual(new SignValue(200000), p[1, 5]);
                Assert.AreEqual(new SignValue(300000), p[2, 5]);
                Assert.AreEqual(new SignValue(300000), p[3, 5]);
                Assert.AreEqual(new SignValue(200000), p[4, 5]);
                Assert.AreEqual(new SignValue(200000), p[5, 5]);
            }
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void SearchTest19()
        {
            for (int k = 0; k < 50; k++)
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p2 = new Processor(sv, "2");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p3 = new Processor(sv, "3");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p4 = new Processor(sv, "4");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p6 = new Processor(sv, "6");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor p8 = new Processor(sv, "8");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor p9 = new Processor(sv, "9");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pa = new Processor(sv, "a");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pb = new Processor(sv, "b");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pc = new Processor(sv, "c");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pd = new Processor(sv, "d");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor pe = new Processor(sv, "e");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pf = new Processor(sv, "f");

                sv[0, 0] = new SignValue(100000);
                sv[0, 1] = new SignValue(100000);
                sv[1, 0] = new SignValue(100000);
                sv[1, 1] = new SignValue(100000);
                Processor pg = new Processor(sv, "g");
                sv[0, 0] = new SignValue(200000);
                sv[0, 1] = new SignValue(200000);
                sv[1, 0] = new SignValue(200000);
                sv[1, 1] = new SignValue(200000);
                Processor ph = new Processor(sv, "h");
                sv[0, 0] = new SignValue(300000);
                sv[0, 1] = new SignValue(300000);
                sv[1, 0] = new SignValue(300000);
                sv[1, 1] = new SignValue(300000);
                Processor pi = new Processor(sv, "i");

                ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
                pcs[0, 0] = new ProcessorContainer(p1, p2);
                pcs[1, 0] = new ProcessorContainer(p3, p4);
                pcs[2, 0] = new ProcessorContainer(p5, p6);
                pcs[0, 1] = new ProcessorContainer(p7, p8);
                pcs[1, 1] = new ProcessorContainer(p9, pa);
                pcs[2, 1] = new ProcessorContainer(pb, pc);
                pcs[0, 2] = new ProcessorContainer(pd, pe);
                pcs[1, 2] = new ProcessorContainer(pf, pg);
                pcs[2, 2] = new ProcessorContainer(ph, pi);

                SignValue[,] prMas = new SignValue[6, 6];
                prMas[0, 0] = new SignValue(500001);
                prMas[1, 0] = new SignValue(500001);
                prMas[2, 0] = new SignValue(300001);
                prMas[3, 0] = new SignValue(300001);
                prMas[4, 0] = new SignValue(200001);
                prMas[5, 0] = new SignValue(200001);

                prMas[0, 1] = new SignValue(500001);
                prMas[1, 1] = new SignValue(500001);
                prMas[2, 1] = new SignValue(300001);
                prMas[3, 1] = new SignValue(300001);
                prMas[4, 1] = new SignValue(200001);
                prMas[5, 1] = new SignValue(200001);

                prMas[0, 2] = new SignValue(400001);
                prMas[1, 2] = new SignValue(400001);
                prMas[2, 2] = new SignValue(100001);
                prMas[3, 2] = new SignValue(100001);
                prMas[4, 2] = new SignValue(300001);
                prMas[5, 2] = new SignValue(300001);

                prMas[0, 3] = new SignValue(400001);
                prMas[1, 3] = new SignValue(400001);
                prMas[2, 3] = new SignValue(100001);
                prMas[3, 3] = new SignValue(100001);
                prMas[4, 3] = new SignValue(300001);
                prMas[5, 3] = new SignValue(300001);

                prMas[0, 4] = new SignValue(600001);
                prMas[1, 4] = new SignValue(600001);
                prMas[2, 4] = new SignValue(200001);
                prMas[3, 4] = new SignValue(200001);
                prMas[4, 4] = new SignValue(100001);
                prMas[5, 4] = new SignValue(100001);

                prMas[0, 5] = new SignValue(600001);
                prMas[1, 5] = new SignValue(600001);
                prMas[2, 5] = new SignValue(200001);
                prMas[3, 5] = new SignValue(200001);
                prMas[4, 5] = new SignValue(100001);
                prMas[5, 5] = new SignValue(100001);

                char[,] str = new char[3, 3];

                str[0, 0] = '2';
                str[1, 0] = '3';
                str[2, 0] = '5';

                str[0, 1] = '8';
                str[1, 1] = 'a';
                str[2, 1] = 'c';

                str[0, 2] = 'e';
                str[1, 2] = 'f';
                str[2, 2] = 'h';

                ProcessorContainer pcNone1 = new ProcessorContainer(new Processor(new SignValue[6], "t"));
                ProcessorContainer pcNone2 = new ProcessorContainer(new Processor(new SignValue[1, 6], "t"));
                ProcessorContainer pcNone3 = new ProcessorContainer(new Processor(new SignValue[6, 7], "t"));
                ProcessorContainer pcNone4 = new ProcessorContainer(new Processor(new SignValue[7, 6], "t"));
                ProcessorContainer pcNone5 = new ProcessorContainer(new Processor(new SignValue[6, 6], "t"));
                ProcessorContainer pcNone6 = new ProcessorContainer(new Processor(new SignValue[3, 3], "t"));
                ProcessorContainer pcNone7 = new ProcessorContainer(new Processor(new SignValue[2, 2], "t"));

                Reflector reflector = new Reflector(pcs);
                Assert.AreNotEqual(null, reflector.Push(new Processor(prMas, "Map1"), str));
                Assert.AreNotEqual(null, reflector.Push(new Processor(prMas, "Map2"), str));

                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone1));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone2));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone3));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone4));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone5));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone6));
                Assert.AreEqual(true, ReflexTest(prMas, str, pcNone7));

                pcs = Pcs;
                sv[0, 0] = new SignValue(800001);
                sv[1, 0] = new SignValue(800001);
                sv[0, 1] = new SignValue(800001);
                sv[1, 1] = new SignValue(900001);
                Processor p11 = new Processor(sv, "z");
                sv[0, 0] = new SignValue(800001);
                sv[1, 0] = new SignValue(900001);
                sv[0, 1] = new SignValue(900001);
                sv[1, 1] = new SignValue(900001);
                Processor p12 = new Processor(sv, "p");
                sv[0, 0] = new SignValue(800001);
                sv[1, 0] = new SignValue(900001);
                sv[0, 1] = new SignValue(8000001);
                sv[1, 1] = new SignValue(9000001);
                Processor p13 = new Processor(sv, "l");

                pcs[0, 0] = new ProcessorContainer(p11, p12, p13);

                sv[0, 0] = new SignValue(800001);
                sv[0, 1] = new SignValue(800001);
                sv[1, 0] = new SignValue(800001);
                sv[1, 1] = new SignValue(900001);
                Processor p14 = new Processor(sv, "q");
                sv[0, 0] = new SignValue(800001);
                sv[0, 1] = new SignValue(900001);
                sv[1, 0] = new SignValue(900001);
                sv[1, 1] = new SignValue(900001);
                Processor p15 = new Processor(sv, "w");
                sv[0, 0] = new SignValue(800001);
                sv[0, 1] = new SignValue(900001);
                sv[1, 0] = new SignValue(8000001);
                sv[1, 1] = new SignValue(9000001);
                Processor p16 = new Processor(sv, "n");
                sv[0, 0] = new SignValue(800001);
                sv[1, 0] = new SignValue(900001);
                sv[0, 1] = new SignValue(8000001);
                sv[1, 1] = new SignValue(9000001);
                Processor p17 = new Processor(sv, "m");

                pcs[2, 2] = new ProcessorContainer(p14, p15, p16, p17);

                str[0, 0] = 'z';
                str[2, 2] = 'q';

                Assert.AreNotEqual(null, new Reflector(pcs).Push(new Processor(prMas, "Map"), str));
            }
        }

        static bool ReflexTest(SignValue[,] prMas, char[,] str, ProcessorContainer arg)
        {
            byte counter = 0;
            ProcessorContainer[,] pcs = Pcs;

            ProcessorContainer pc1 = pcs[0, 0];
            ProcessorContainer pc2 = pcs[1, 0];
            ProcessorContainer pc3 = pcs[2, 0];
            ProcessorContainer pc4 = pcs[0, 1];
            ProcessorContainer pc5 = pcs[1, 1];
            ProcessorContainer pc6 = pcs[2, 1];
            ProcessorContainer pc7 = pcs[0, 2];
            ProcessorContainer pc8 = pcs[1, 2];
            ProcessorContainer pc9 = pcs[2, 2];

            for (int y = 0; y < pcs.GetLength(1); y++)
            for (int x = 0; x < pcs.GetLength(0); x++)
            {
                pcs[0, 0] = pc1;
                pcs[1, 0] = pc2;
                pcs[2, 0] = pc3;
                pcs[0, 1] = pc4;
                pcs[1, 1] = pc5;
                pcs[2, 1] = pc6;
                pcs[0, 2] = pc7;
                pcs[1, 2] = pc8;
                pcs[2, 2] = pc9;

                pcs[x, y] = arg;
                try
                {
                    new Reflector(pcs).Push(new Processor(prMas, "Map"), str);
                }
                catch (ArgumentException)
                {
                    counter++;
                }
            }
            return counter == 9;
        }

        static void CheckParams(Processor p)
        {
            Assert.AreNotEqual(null, p);
            Assert.AreEqual(6, p.Width);
            Assert.AreEqual(6, p.Height);
        }

        static void TestEqual(Processor p)
        {
            Assert.AreEqual(new SignValue(200000), p[0, 0]);
            Assert.AreEqual(new SignValue(200000), p[1, 0]);
            Assert.AreEqual(new SignValue(300000), p[2, 0]);
            Assert.AreEqual(new SignValue(300000), p[3, 0]);
            Assert.AreEqual(new SignValue(500000), p[4, 0]);
            Assert.AreEqual(new SignValue(500000), p[5, 0]);

            Assert.AreEqual(new SignValue(200000), p[0, 1]);
            Assert.AreEqual(new SignValue(200000), p[1, 1]);
            Assert.AreEqual(new SignValue(300000), p[2, 1]);
            Assert.AreEqual(new SignValue(300000), p[3, 1]);
            Assert.AreEqual(new SignValue(500000), p[4, 1]);
            Assert.AreEqual(new SignValue(500000), p[5, 1]);

            Assert.AreEqual(new SignValue(200000), p[0, 2]);
            Assert.AreEqual(new SignValue(200000), p[1, 2]);
            Assert.AreEqual(new SignValue(100000), p[2, 2]);
            Assert.AreEqual(new SignValue(100000), p[3, 2]);
            Assert.AreEqual(new SignValue(300000), p[4, 2]);
            Assert.AreEqual(new SignValue(300000), p[5, 2]);

            Assert.AreEqual(new SignValue(200000), p[0, 3]);
            Assert.AreEqual(new SignValue(200000), p[1, 3]);
            Assert.AreEqual(new SignValue(100000), p[2, 3]);
            Assert.AreEqual(new SignValue(100000), p[3, 3]);
            Assert.AreEqual(new SignValue(300000), p[4, 3]);
            Assert.AreEqual(new SignValue(300000), p[5, 3]);

            Assert.AreEqual(new SignValue(200000), p[0, 4]);
            Assert.AreEqual(new SignValue(200000), p[1, 4]);
            Assert.AreEqual(new SignValue(300000), p[2, 4]);
            Assert.AreEqual(new SignValue(300000), p[3, 4]);
            Assert.AreEqual(new SignValue(200000), p[4, 4]);
            Assert.AreEqual(new SignValue(200000), p[5, 4]);

            Assert.AreEqual(new SignValue(200000), p[0, 5]);
            Assert.AreEqual(new SignValue(200000), p[1, 5]);
            Assert.AreEqual(new SignValue(300000), p[2, 5]);
            Assert.AreEqual(new SignValue(300000), p[3, 5]);
            Assert.AreEqual(new SignValue(200000), p[4, 5]);
            Assert.AreEqual(new SignValue(200000), p[5, 5]);
        }

        static void MasToLower(char[,] ch)
        {
            for (int y = 0; y < ch.GetLength(1); y++)
            for (int x = 0; x < ch.GetLength(0); x++)
                ch[x, y] = char.ToLower(ch[x, y]);
        }

        [TestMethod]
        public void SearchTest20()
        {
            char[,] c = new char[3, 3];

            c[0, 0] = '2';
            c[1, 0] = '3';
            c[2, 0] = '5';

            c[0, 1] = '8';
            c[1, 1] = 'A';
            c[2, 1] = 'C';

            c[0, 2] = 'E';
            c[1, 2] = 'F';
            c[2, 2] = 'H';

            void Act(char[,] ch)
            {
                Reflector r = new Reflector(Pcs);
                Processor p = r.Push(PrMas1, ch);
                CheckParams(p);

                TestEqual(p);

                p = r.Push(PrMas2, ch);
                CheckParams(p);

                TestEqual(p);
            }

            Act(c);

            MasToLower(c);

            Act(c);
        }

        [TestMethod]
        public void SearchTest21()
        {
            char[,] str = new char[3, 3];

            str[0, 0] = '2';
            str[1, 0] = '3';
            str[2, 0] = '5';

            str[0, 1] = '8';
            str[1, 1] = 'a';
            str[2, 1] = 'c';

            str[0, 2] = 'e';
            str[1, 2] = 'f';
            str[2, 2] = 'h';

            Processor p = new Reflector(Pcs).Push(PrMas2, str);
            CheckParams(p);

            Assert.AreEqual(new SignValue(200000), p[0, 0]);
            Assert.AreEqual(new SignValue(200000), p[1, 0]);
            Assert.AreEqual(new SignValue(300000), p[2, 0]);
            Assert.AreEqual(new SignValue(300000), p[3, 0]);
            Assert.AreEqual(new SignValue(500000), p[4, 0]);
            Assert.AreEqual(new SignValue(500000), p[5, 0]);

            Assert.AreEqual(new SignValue(200000), p[0, 1]);
            Assert.AreEqual(new SignValue(200000), p[1, 1]);
            Assert.AreEqual(new SignValue(300000), p[2, 1]);
            Assert.AreEqual(new SignValue(300000), p[3, 1]);
            Assert.AreEqual(new SignValue(500000), p[4, 1]);
            Assert.AreEqual(new SignValue(500000), p[5, 1]);

            Assert.AreEqual(new SignValue(200000), p[0, 2]);
            Assert.AreEqual(new SignValue(200000), p[1, 2]);
            Assert.AreEqual(new SignValue(100000), p[2, 2]);
            Assert.AreEqual(new SignValue(100000), p[3, 2]);
            Assert.AreEqual(new SignValue(300000), p[4, 2]);
            Assert.AreEqual(new SignValue(300000), p[5, 2]);

            Assert.AreEqual(new SignValue(200000), p[0, 3]);
            Assert.AreEqual(new SignValue(200000), p[1, 3]);
            Assert.AreEqual(new SignValue(100000), p[2, 3]);
            Assert.AreEqual(new SignValue(100000), p[3, 3]);
            Assert.AreEqual(new SignValue(300000), p[4, 3]);
            Assert.AreEqual(new SignValue(300000), p[5, 3]);

            Assert.AreEqual(new SignValue(200000), p[0, 4]);
            Assert.AreEqual(new SignValue(200000), p[1, 4]);
            Assert.AreEqual(new SignValue(300000), p[2, 4]);
            Assert.AreEqual(new SignValue(300000), p[3, 4]);
            Assert.AreEqual(new SignValue(200000), p[4, 4]);
            Assert.AreEqual(new SignValue(200000), p[5, 4]);

            Assert.AreEqual(new SignValue(200000), p[0, 5]);
            Assert.AreEqual(new SignValue(200000), p[1, 5]);
            Assert.AreEqual(new SignValue(300000), p[2, 5]);
            Assert.AreEqual(new SignValue(300000), p[3, 5]);
            Assert.AreEqual(new SignValue(200000), p[4, 5]);
            Assert.AreEqual(new SignValue(200000), p[5, 5]);
        }

        [TestMethod]
        public void SearchTest22()
        {
            void Act(char[,] ch)
            {
                Processor p = new Reflector(Pcs).Push(PrMas1, ch);
                CheckParams(p);

                Assert.AreEqual(new SignValue(200000), p[0, 0]);
                Assert.AreEqual(new SignValue(200000), p[1, 0]);
                Assert.AreEqual(new SignValue(300000), p[2, 0]);
                Assert.AreEqual(new SignValue(300000), p[3, 0]);
                Assert.AreEqual(new SignValue(500000), p[4, 0]);
                Assert.AreEqual(new SignValue(500000), p[5, 0]);

                Assert.AreEqual(new SignValue(200000), p[0, 1]);
                Assert.AreEqual(new SignValue(200000), p[1, 1]);
                Assert.AreEqual(new SignValue(300000), p[2, 1]);
                Assert.AreEqual(new SignValue(300000), p[3, 1]);
                Assert.AreEqual(new SignValue(500000), p[4, 1]);
                Assert.AreEqual(new SignValue(500000), p[5, 1]);

                Assert.AreEqual(new SignValue(200000), p[0, 2]);
                Assert.AreEqual(new SignValue(200000), p[1, 2]);
                Assert.AreEqual(new SignValue(100000), p[2, 2]);
                Assert.AreEqual(new SignValue(100000), p[3, 2]);
                Assert.AreEqual(new SignValue(300000), p[4, 2]);
                Assert.AreEqual(new SignValue(300000), p[5, 2]);

                Assert.AreEqual(new SignValue(200000), p[0, 3]);
                Assert.AreEqual(new SignValue(200000), p[1, 3]);
                Assert.AreEqual(new SignValue(100000), p[2, 3]);
                Assert.AreEqual(new SignValue(100000), p[3, 3]);
                Assert.AreEqual(new SignValue(300000), p[4, 3]);
                Assert.AreEqual(new SignValue(300000), p[5, 3]);

                Assert.AreEqual(new SignValue(200000), p[0, 4]);
                Assert.AreEqual(new SignValue(200000), p[1, 4]);
                Assert.AreEqual(new SignValue(300000), p[2, 4]);
                Assert.AreEqual(new SignValue(300000), p[3, 4]);
                Assert.AreEqual(new SignValue(200000), p[4, 4]);
                Assert.AreEqual(new SignValue(200000), p[5, 4]);

                Assert.AreEqual(new SignValue(200000), p[0, 5]);
                Assert.AreEqual(new SignValue(200000), p[1, 5]);
                Assert.AreEqual(new SignValue(300000), p[2, 5]);
                Assert.AreEqual(new SignValue(300000), p[3, 5]);
                Assert.AreEqual(new SignValue(200000), p[4, 5]);
                Assert.AreEqual(new SignValue(200000), p[5, 5]);
            }

            char[,] c = new char[3, 3];

            c[0, 0] = '2';
            c[1, 0] = '3';
            c[2, 0] = '5';

            c[0, 1] = '8';
            c[1, 1] = 'A';
            c[2, 1] = 'C';

            c[0, 2] = 'E';
            c[1, 2] = 'F';
            c[2, 2] = 'H';

            Act(c);

            MasToLower(c);

            Act(c);
        }

        [TestMethod]
        public void SearchTest23()
        {
            SignValue[,] sv = new SignValue[2, 2];
            sv[0, 0] = new SignValue(400000);
            sv[0, 1] = new SignValue(400000);
            sv[1, 0] = new SignValue(400000);
            sv[1, 1] = new SignValue(400000);
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(500000);
            sv[0, 1] = new SignValue(500000);
            sv[1, 0] = new SignValue(500000);
            sv[1, 1] = new SignValue(500000);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(600000);
            sv[0, 1] = new SignValue(600000);
            sv[1, 0] = new SignValue(600000);
            sv[1, 1] = new SignValue(600000);
            Processor p6 = new Processor(sv, "6");

            sv[0, 0] = new SignValue(600000);
            sv[0, 1] = new SignValue(600000);
            sv[1, 0] = new SignValue(600000);
            sv[1, 1] = new SignValue(600000);
            // ReSharper disable once InconsistentNaming
            Processor p6a = new Processor(sv, "6a");
            sv[0, 0] = new SignValue(700000);
            sv[0, 1] = new SignValue(700000);
            sv[1, 0] = new SignValue(700000);
            sv[1, 1] = new SignValue(700000);
            Processor p6A = new Processor(sv, "6A");
            sv[0, 0] = new SignValue(800000);
            sv[0, 1] = new SignValue(800000);
            sv[1, 0] = new SignValue(800000);
            sv[1, 1] = new SignValue(800000);
            Processor p61 = new Processor(sv, "61");

            ProcessorContainer arg1 = new ProcessorContainer(p4, p6a, p6);
            ProcessorContainer arg2 = new ProcessorContainer(p4, p6, p6A);
            ProcessorContainer arg3 = new ProcessorContainer(p61, p6, p5);

            Assert.AreEqual(true, TestNameException(arg1));
            Assert.AreEqual(true, TestNameException(arg2));
            Assert.AreEqual(true, TestNameException(arg3));
        }

        static bool TestNameException(ProcessorContainer arg)
        {
            for (int y = 0, my = Pcs.GetLength(1); y < my; y++)
            for (int x = 0, mx = Pcs.GetLength(0); x < mx; x++)
                try
                {
                    ProcessorContainer[,] pcs = Pcs;
                    pcs[x, y] = arg;

                    // ReSharper disable once ObjectCreationAsStatement
                    new Reflector(pcs);
                    return false;
                }
                catch (ArgumentException)
                {
                }
            return true;
        }

        [TestMethod]
        public void SearchTest24()
        {
            for (int k = 0; k < 50000; k++)
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(125550);
                sv[0, 1] = new SignValue(190456);
                sv[1, 0] = new SignValue(134578);
                sv[1, 1] = new SignValue(191473);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(293525);
                sv[0, 1] = new SignValue(228674);
                sv[1, 0] = new SignValue(243543);
                sv[1, 1] = new SignValue(244424);
                Processor p2 = new Processor(sv, "2");
                sv[0, 0] = new SignValue(265434);
                sv[0, 1] = new SignValue(396147);
                sv[1, 0] = new SignValue(341393);
                sv[1, 1] = new SignValue(309439);
                Processor p3 = new Processor(sv, "3");

                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(144450);
                sv[0, 1] = new SignValue(122356);
                sv[1, 0] = new SignValue(139568);
                sv[1, 1] = new SignValue(198393);
                Processor p4 = new Processor(sv, "4");
                sv[0, 0] = new SignValue(245525);
                sv[0, 1] = new SignValue(298374);
                sv[1, 0] = new SignValue(242843);
                sv[1, 1] = new SignValue(244414);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(165434);
                sv[0, 1] = new SignValue(396887);
                sv[1, 0] = new SignValue(342353);
                sv[1, 1] = new SignValue(309438);
                Processor p6 = new Processor(sv, "6");

                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(129950);
                sv[0, 1] = new SignValue(123656);
                sv[1, 0] = new SignValue(134668);
                sv[1, 1] = new SignValue(198273);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(123525);
                sv[0, 1] = new SignValue(208674);
                sv[1, 0] = new SignValue(247543);
                sv[1, 1] = new SignValue(244434);
                Processor p8 = new Processor(sv, "8");
                sv[0, 0] = new SignValue(965434);
                sv[0, 1] = new SignValue(396747);
                sv[1, 0] = new SignValue(343393);
                sv[1, 1] = new SignValue(309430);
                Processor p9 = new Processor(sv, "9");

                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(123950);
                sv[0, 1] = new SignValue(123956);
                sv[1, 0] = new SignValue(138568);
                sv[1, 1] = new SignValue(198483);
                Processor p11 = new Processor(sv, "A");
                sv[0, 0] = new SignValue(543525);
                sv[0, 1] = new SignValue(299674);
                sv[1, 0] = new SignValue(242043);
                sv[1, 1] = new SignValue(244464);
                Processor p21 = new Processor(sv, "B");
                sv[0, 0] = new SignValue(395434);
                sv[0, 1] = new SignValue(396647);
                sv[1, 0] = new SignValue(344393);
                sv[1, 1] = new SignValue(309435);
                Processor p31 = new Processor(sv, "C");

                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(129450);
                sv[0, 1] = new SignValue(143456);
                sv[1, 0] = new SignValue(131568);
                sv[1, 1] = new SignValue(198573);
                Processor p41 = new Processor(sv, "D");
                sv[0, 0] = new SignValue(843525);
                sv[0, 1] = new SignValue(298574);
                sv[1, 0] = new SignValue(249543);
                sv[1, 1] = new SignValue(244544);
                Processor p51 = new Processor(sv, "E");
                sv[0, 0] = new SignValue(375434);
                sv[0, 1] = new SignValue(395847);
                sv[1, 0] = new SignValue(342393);
                sv[1, 1] = new SignValue(309433);
                Processor p61 = new Processor(sv, "F");

                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(123450);
                sv[0, 1] = new SignValue(123456);
                sv[1, 0] = new SignValue(134568);
                sv[1, 1] = new SignValue(198473);
                Processor p71 = new Processor(sv, "G");
                sv[0, 0] = new SignValue(243525);
                sv[0, 1] = new SignValue(298674);
                sv[1, 0] = new SignValue(242543);
                sv[1, 1] = new SignValue(244444);
                Processor p81 = new Processor(sv, "H");
                sv[0, 0] = new SignValue(365434);
                sv[0, 1] = new SignValue(396847);
                sv[1, 0] = new SignValue(342493);
                sv[1, 1] = new SignValue(309437);
                Processor p91 = new Processor(sv, "J");

                ProcessorContainer[,] pcs = new ProcessorContainer[3, 3];
                pcs[0, 0] = new ProcessorContainer(p1, p11);
                pcs[1, 0] = new ProcessorContainer(p2, p21);
                pcs[2, 0] = new ProcessorContainer(p3, p31);
                pcs[0, 1] = new ProcessorContainer(p4, p41);
                pcs[1, 1] = new ProcessorContainer(p5, p51);
                pcs[2, 1] = new ProcessorContainer(p6, p61);
                pcs[0, 2] = new ProcessorContainer(p7, p71);
                pcs[1, 2] = new ProcessorContainer(p8, p81);
                pcs[2, 2] = new ProcessorContainer(p9, p91);

                SignValue[,] p = new SignValue[6, 6];
                p[0, 0] = new SignValue(1000);
                p[0, 0] = new SignValue(2000);
                p[0, 0] = new SignValue(3000);
                p[0, 0] = new SignValue(4000);
                p[0, 0] = new SignValue(5000);
                p[0, 0] = new SignValue(6000);
                p[0, 0] = new SignValue(7000);
                p[0, 0] = new SignValue(8000);
                p[0, 0] = new SignValue(9000);
                p[0, 0] = new SignValue(10000);

                p[0, 0] = new SignValue(11000);
                p[0, 0] = new SignValue(12000);
                p[0, 0] = new SignValue(13000);
                p[0, 0] = new SignValue(14000);
                p[0, 0] = new SignValue(15000);
                p[0, 0] = new SignValue(16000);
                p[0, 0] = new SignValue(17000);
                p[0, 0] = new SignValue(18000);
                p[0, 0] = new SignValue(19000);
                p[0, 0] = new SignValue(20000);

                p[0, 0] = new SignValue(21000);
                p[0, 0] = new SignValue(22000);
                p[0, 0] = new SignValue(23000);
                p[0, 0] = new SignValue(24000);
                p[0, 0] = new SignValue(25000);
                p[0, 0] = new SignValue(26000);
                p[0, 0] = new SignValue(27000);
                p[0, 0] = new SignValue(28000);
                p[0, 0] = new SignValue(29000);
                p[0, 0] = new SignValue(30000);

                p[0, 0] = new SignValue(31000);
                p[0, 0] = new SignValue(32000);
                p[0, 0] = new SignValue(33000);
                p[0, 0] = new SignValue(34000);
                p[0, 0] = new SignValue(35000);
                p[0, 0] = new SignValue(36000);

                char[,] str = new char[3, 3];

                str[0, 0] = '1';
                str[1, 0] = '2';
                str[2, 0] = '3';

                str[0, 1] = '4';
                str[1, 1] = '5';
                str[2, 1] = '6';

                str[0, 2] = 'G';
                str[1, 2] = '8';
                str[2, 2] = '9';

                Processor result = new Reflector(pcs).Push(new Processor(p, "Map"), str);
                Assert.AreNotEqual(null, result);

                Assert.AreEqual(new SignValue(125550), result[0, 0]);
                Assert.AreEqual(new SignValue(190456), result[0, 1]);
                Assert.AreEqual(new SignValue(134578), result[1, 0]);
                Assert.AreEqual(new SignValue(191473), result[1, 1]);

                Assert.AreEqual(new SignValue(293525), result[2, 0]);
                Assert.AreEqual(new SignValue(228674), result[2, 1]);
                Assert.AreEqual(new SignValue(243543), result[3, 0]);
                Assert.AreEqual(new SignValue(244424), result[3, 1]);

                Assert.AreEqual(new SignValue(265434), result[4, 0]);
                Assert.AreEqual(new SignValue(396147), result[4, 1]);
                Assert.AreEqual(new SignValue(341393), result[5, 0]);
                Assert.AreEqual(new SignValue(309439), result[5, 1]);

                Assert.AreEqual(new SignValue(144450), result[0, 2]);
                Assert.AreEqual(new SignValue(122356), result[0, 3]);
                Assert.AreEqual(new SignValue(139568), result[1, 2]);
                Assert.AreEqual(new SignValue(198393), result[1, 3]);

                Assert.AreEqual(new SignValue(245525), result[2, 2]);
                Assert.AreEqual(new SignValue(298374), result[2, 3]);
                Assert.AreEqual(new SignValue(242843), result[3, 2]);
                Assert.AreEqual(new SignValue(244414), result[3, 3]);

                Assert.AreEqual(new SignValue(165434), result[4, 2]);
                Assert.AreEqual(new SignValue(396887), result[4, 3]);
                Assert.AreEqual(new SignValue(342353), result[5, 2]);
                Assert.AreEqual(new SignValue(309438), result[5, 3]);

                Assert.AreEqual(new SignValue(123450), result[0, 4]);
                Assert.AreEqual(new SignValue(123456), result[0, 5]);
                Assert.AreEqual(new SignValue(134568), result[1, 4]);
                Assert.AreEqual(new SignValue(198473), result[1, 5]);

                Assert.AreEqual(new SignValue(123525), result[2, 4]);
                Assert.AreEqual(new SignValue(208674), result[2, 5]);
                Assert.AreEqual(new SignValue(247543), result[3, 4]);
                Assert.AreEqual(new SignValue(244434), result[3, 5]);

                Assert.AreEqual(new SignValue(965434), result[4, 4]);
                Assert.AreEqual(new SignValue(396747), result[4, 5]);
                Assert.AreEqual(new SignValue(343393), result[5, 4]);
                Assert.AreEqual(new SignValue(309430), result[5, 5]);
            }
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void SearchTest25()
        {
            for (int k = 0; k < 50000; k++)
            {
                SignValue[,] sv = new SignValue[2, 4];
                sv[0, 0] = new SignValue(123456);
                sv[1, 0] = new SignValue(123459);
                sv[0, 1] = new SignValue(123458);
                sv[1, 1] = new SignValue(123457);
                sv[0, 2] = new SignValue(123454);
                sv[1, 2] = new SignValue(123451);
                sv[0, 3] = new SignValue(123410);
                sv[1, 3] = new SignValue(123440);
                Processor p1 = new Processor(sv, "1");

                sv[0, 0] = new SignValue(134556);
                sv[1, 0] = new SignValue(134557);
                sv[0, 1] = new SignValue(134553);
                sv[1, 1] = new SignValue(134552);
                sv[0, 2] = new SignValue(134550);
                sv[1, 2] = new SignValue(134534);
                sv[0, 3] = new SignValue(134900);
                sv[1, 3] = new SignValue(134523);
                Processor p2 = new Processor(sv, "2");

                sv[0, 0] = new SignValue(134222);
                sv[1, 0] = new SignValue(134333);
                sv[0, 1] = new SignValue(134342);
                sv[1, 1] = new SignValue(134234);
                sv[0, 2] = new SignValue(134876);
                sv[1, 2] = new SignValue(134236);
                sv[0, 3] = new SignValue(134856);
                sv[1, 3] = new SignValue(134349);
                Processor p3 = new Processor(sv, "3");

                sv[0, 0] = new SignValue(134398);
                sv[1, 0] = new SignValue(134346);
                sv[0, 1] = new SignValue(139876);
                sv[1, 1] = new SignValue(134998);
                sv[0, 2] = new SignValue(134451);
                sv[1, 2] = new SignValue(134498);
                sv[0, 3] = new SignValue(134065);
                sv[1, 3] = new SignValue(134432);
                Processor p4 = new Processor(sv, "4");

                sv[0, 0] = new SignValue(159398);
                sv[1, 0] = new SignValue(159875);
                sv[0, 1] = new SignValue(159167);
                sv[1, 1] = new SignValue(159389);
                sv[0, 2] = new SignValue(159478);
                sv[1, 2] = new SignValue(159567);
                sv[0, 3] = new SignValue(159190);
                sv[1, 3] = new SignValue(159200);
                Processor p5 = new Processor(sv, "5");

                sv[0, 0] = new SignValue(459398);
                sv[1, 0] = new SignValue(459875);
                sv[0, 1] = new SignValue(459167);
                sv[1, 1] = new SignValue(459389);
                sv[0, 2] = new SignValue(459478);
                sv[1, 2] = new SignValue(459567);
                sv[0, 3] = new SignValue(459190);
                sv[1, 3] = new SignValue(459200);
                Processor p6 = new Processor(sv, "6");

                sv[0, 0] = new SignValue(546867);
                sv[1, 0] = new SignValue(546958);
                sv[0, 1] = new SignValue(546821);
                sv[1, 1] = new SignValue(546900);
                sv[0, 2] = new SignValue(546210);
                sv[1, 2] = new SignValue(546347);
                sv[0, 3] = new SignValue(546600);
                sv[1, 3] = new SignValue(546100);
                Processor pa = new Processor(sv, "a");

                sv[0, 0] = new SignValue(546390);
                sv[1, 0] = new SignValue(546245);
                sv[0, 1] = new SignValue(546758);
                sv[1, 1] = new SignValue(546460);
                sv[0, 2] = new SignValue(546123);
                sv[1, 2] = new SignValue(546386);
                sv[0, 3] = new SignValue(546103);
                sv[1, 3] = new SignValue(546278);
                Processor pb = new Processor(sv, "b");

                sv[0, 0] = new SignValue(547230);
                sv[1, 0] = new SignValue(547458);
                sv[0, 1] = new SignValue(547857);
                sv[1, 1] = new SignValue(547124);
                sv[0, 2] = new SignValue(547657);
                sv[1, 2] = new SignValue(547435);
                sv[0, 3] = new SignValue(547278);
                sv[1, 3] = new SignValue(547999);
                Processor pc = new Processor(sv, "c");

                sv[0, 0] = new SignValue(149698);
                sv[1, 0] = new SignValue(149321);
                sv[0, 1] = new SignValue(149545);
                sv[1, 1] = new SignValue(149199);
                sv[0, 2] = new SignValue(149177);
                sv[1, 2] = new SignValue(149378);
                sv[0, 3] = new SignValue(149534);
                sv[1, 3] = new SignValue(149237);
                Processor pd = new Processor(sv, "d");

                sv[0, 0] = new SignValue(160798);
                sv[1, 0] = new SignValue(160178);
                sv[0, 1] = new SignValue(160123);
                sv[1, 1] = new SignValue(160367);
                sv[0, 2] = new SignValue(160890);
                sv[1, 2] = new SignValue(160348);
                sv[0, 3] = new SignValue(160238);
                sv[1, 3] = new SignValue(160156);
                Processor pe = new Processor(sv, "e");

                sv[0, 0] = new SignValue(148798);
                sv[1, 0] = new SignValue(148598);
                sv[0, 1] = new SignValue(148467);
                sv[1, 1] = new SignValue(190148);
                sv[0, 2] = new SignValue(148489);
                sv[1, 2] = new SignValue(148120);
                sv[0, 3] = new SignValue(148248);
                sv[1, 3] = new SignValue(148294);
                Processor pf = new Processor(sv, "f");

                ProcessorContainer[,] pcs = new ProcessorContainer[2, 3];
                pcs[0, 0] = new ProcessorContainer(p1, pa);
                pcs[1, 0] = new ProcessorContainer(p2, pb);
                pcs[0, 1] = new ProcessorContainer(p3, pc);
                pcs[1, 1] = new ProcessorContainer(p4, pd);
                pcs[0, 2] = new ProcessorContainer(p5, pe);
                pcs[1, 2] = new ProcessorContainer(p6, pf);

                SignValue[,] pr = new SignValue[4, 12];
                pr[0, 0] = new SignValue(1000);
                pr[1, 0] = new SignValue(2000);
                pr[2, 0] = new SignValue(3000);
                pr[3, 0] = new SignValue(4000);

                pr[0, 1] = new SignValue(5000);
                pr[1, 1] = new SignValue(6000);
                pr[2, 1] = new SignValue(7000);
                pr[3, 1] = new SignValue(8000);

                pr[0, 2] = new SignValue(9000);
                pr[1, 2] = new SignValue(10000);
                pr[2, 2] = new SignValue(11000);
                pr[3, 2] = new SignValue(12000);

                pr[0, 3] = new SignValue(13000);
                pr[1, 3] = new SignValue(14000);
                pr[2, 3] = new SignValue(15000);
                pr[3, 3] = new SignValue(16000);

                pr[0, 4] = new SignValue(17000);
                pr[1, 4] = new SignValue(18000);
                pr[2, 4] = new SignValue(19000);
                pr[3, 4] = new SignValue(20000);

                pr[0, 5] = new SignValue(21000);
                pr[1, 5] = new SignValue(22000);
                pr[2, 5] = new SignValue(23000);
                pr[3, 5] = new SignValue(24000);

                pr[0, 6] = new SignValue(25000);
                pr[1, 6] = new SignValue(26000);
                pr[2, 6] = new SignValue(27000);
                pr[3, 6] = new SignValue(28000);

                pr[0, 7] = new SignValue(29000);
                pr[1, 7] = new SignValue(30000);
                pr[2, 7] = new SignValue(31000);
                pr[3, 7] = new SignValue(32000);

                pr[0, 8] = new SignValue(33000);
                pr[1, 8] = new SignValue(34000);
                pr[2, 8] = new SignValue(35000);
                pr[3, 8] = new SignValue(36000);

                pr[0, 9] = new SignValue(37000);
                pr[1, 9] = new SignValue(38000);
                pr[2, 9] = new SignValue(39000);
                pr[3, 9] = new SignValue(40000);

                pr[0, 10] = new SignValue(41000);
                pr[1, 10] = new SignValue(42000);
                pr[2, 10] = new SignValue(43000);
                pr[3, 10] = new SignValue(44000);

                pr[0, 11] = new SignValue(45000);
                pr[1, 11] = new SignValue(46000);
                pr[2, 11] = new SignValue(47000);
                pr[3, 11] = new SignValue(48000);

                char[,] str = new char[2, 3];
                str[0, 0] = '1';
                str[1, 0] = '2';

                str[0, 1] = '3';
                str[1, 1] = '4';

                str[0, 2] = '5';
                str[1, 2] = 'f';

                Processor result = new Reflector(pcs).Push(new Processor(pr, "Map"), str);
                Assert.AreNotEqual(null, result);
                Assert.AreEqual(4, result.Width);
                Assert.AreEqual(12, result.Height);

                Assert.AreEqual(new SignValue(123456), result[0, 0]);
                Assert.AreEqual(new SignValue(123459), result[1, 0]);
                Assert.AreEqual(new SignValue(123458), result[0, 1]);
                Assert.AreEqual(new SignValue(123457), result[1, 1]);
                Assert.AreEqual(new SignValue(123454), result[0, 2]);
                Assert.AreEqual(new SignValue(123451), result[1, 2]);
                Assert.AreEqual(new SignValue(123410), result[0, 3]);
                Assert.AreEqual(new SignValue(123440), result[1, 3]);

                Assert.AreEqual(new SignValue(134556), result[2, 0]);
                Assert.AreEqual(new SignValue(134557), result[3, 0]);
                Assert.AreEqual(new SignValue(134553), result[2, 1]);
                Assert.AreEqual(new SignValue(134552), result[3, 1]);
                Assert.AreEqual(new SignValue(134550), result[2, 2]);
                Assert.AreEqual(new SignValue(134534), result[3, 2]);
                Assert.AreEqual(new SignValue(134900), result[2, 3]);
                Assert.AreEqual(new SignValue(134523), result[3, 3]);

                Assert.AreEqual(new SignValue(134222), result[0, 4]);
                Assert.AreEqual(new SignValue(134333), result[1, 4]);
                Assert.AreEqual(new SignValue(134342), result[0, 5]);
                Assert.AreEqual(new SignValue(134234), result[1, 5]);
                Assert.AreEqual(new SignValue(134876), result[0, 6]);
                Assert.AreEqual(new SignValue(134236), result[1, 6]);
                Assert.AreEqual(new SignValue(134856), result[0, 7]);
                Assert.AreEqual(new SignValue(134349), result[1, 7]);

                Assert.AreEqual(new SignValue(134398), result[2, 4]);
                Assert.AreEqual(new SignValue(134346), result[3, 4]);
                Assert.AreEqual(new SignValue(139876), result[2, 5]);
                Assert.AreEqual(new SignValue(134998), result[3, 5]);
                Assert.AreEqual(new SignValue(134451), result[2, 6]);
                Assert.AreEqual(new SignValue(134498), result[3, 6]);
                Assert.AreEqual(new SignValue(134065), result[2, 7]);
                Assert.AreEqual(new SignValue(134432), result[3, 7]);

                Assert.AreEqual(new SignValue(134222), result[0, 4]);
                Assert.AreEqual(new SignValue(134333), result[1, 4]);
                Assert.AreEqual(new SignValue(134342), result[0, 5]);
                Assert.AreEqual(new SignValue(134234), result[1, 5]);
                Assert.AreEqual(new SignValue(134876), result[0, 6]);
                Assert.AreEqual(new SignValue(134236), result[1, 6]);
                Assert.AreEqual(new SignValue(134856), result[0, 7]);
                Assert.AreEqual(new SignValue(134349), result[1, 7]);

                Assert.AreEqual(new SignValue(159398), result[0, 8]);
                Assert.AreEqual(new SignValue(159875), result[1, 8]);
                Assert.AreEqual(new SignValue(159167), result[0, 9]);
                Assert.AreEqual(new SignValue(159389), result[1, 9]);
                Assert.AreEqual(new SignValue(159478), result[0, 10]);
                Assert.AreEqual(new SignValue(159567), result[1, 10]);
                Assert.AreEqual(new SignValue(159190), result[0, 11]);
                Assert.AreEqual(new SignValue(159200), result[1, 11]);

                Assert.AreEqual(new SignValue(148798), result[2, 8]);
                Assert.AreEqual(new SignValue(148598), result[3, 8]);
                Assert.AreEqual(new SignValue(148467), result[2, 9]);
                Assert.AreEqual(new SignValue(190148), result[3, 9]);
                Assert.AreEqual(new SignValue(148489), result[2, 10]);
                Assert.AreEqual(new SignValue(148120), result[3, 10]);
                Assert.AreEqual(new SignValue(148248), result[2, 11]);
                Assert.AreEqual(new SignValue(148294), result[3, 11]);
            }
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void SearchTest26()
        {
            for (int k = 0; k < 50000; k++)
            {
                SignValue[,] sv = new SignValue[4, 2];
                sv[0, 0] = new SignValue(178090);
                sv[1, 0] = new SignValue(178190);
                sv[2, 0] = new SignValue(178290);
                sv[3, 0] = new SignValue(178390);
                sv[0, 1] = new SignValue(178490);
                sv[1, 1] = new SignValue(178491);
                sv[2, 1] = new SignValue(178590);
                sv[3, 1] = new SignValue(178690);
                Processor p1 = new Processor(sv, "1");

                sv[0, 0] = new SignValue(178890);
                sv[1, 0] = new SignValue(179090);
                sv[2, 0] = new SignValue(179190);
                sv[3, 0] = new SignValue(179290);
                sv[0, 1] = new SignValue(179390);
                sv[1, 1] = new SignValue(179490);
                sv[2, 1] = new SignValue(179590);
                sv[3, 1] = new SignValue(179690);
                Processor p2 = new Processor(sv, "2");

                sv[0, 0] = new SignValue(179790);
                sv[1, 0] = new SignValue(179890);
                sv[2, 0] = new SignValue(179990);
                sv[3, 0] = new SignValue(180090);
                sv[0, 1] = new SignValue(180190);
                sv[1, 1] = new SignValue(180290);
                sv[2, 1] = new SignValue(180390);
                sv[3, 1] = new SignValue(180490);
                Processor p3 = new Processor(sv, "3");

                sv[0, 0] = new SignValue(180590);
                sv[1, 0] = new SignValue(180690);
                sv[2, 0] = new SignValue(180790);
                sv[3, 0] = new SignValue(180890);
                sv[0, 1] = new SignValue(180990);
                sv[1, 1] = new SignValue(181190);
                sv[2, 1] = new SignValue(181290);
                sv[3, 1] = new SignValue(181390);
                Processor p4 = new Processor(sv, "4");

                sv[0, 0] = new SignValue(181490);
                sv[1, 0] = new SignValue(181590);
                sv[2, 0] = new SignValue(181690);
                sv[3, 0] = new SignValue(181790);
                sv[0, 1] = new SignValue(181890);
                sv[1, 1] = new SignValue(181990);
                sv[2, 1] = new SignValue(182090);
                sv[3, 1] = new SignValue(182190);
                Processor p5 = new Processor(sv, "5");

                sv[0, 0] = new SignValue(183290);
                sv[1, 0] = new SignValue(183390);
                sv[2, 0] = new SignValue(183490);
                sv[3, 0] = new SignValue(183590);
                sv[0, 1] = new SignValue(183690);
                sv[1, 1] = new SignValue(183790);
                sv[2, 1] = new SignValue(183890);
                sv[3, 1] = new SignValue(183990);
                Processor p6 = new Processor(sv, "6");

                sv[0, 0] = new SignValue(184090);
                sv[1, 0] = new SignValue(184190);
                sv[2, 0] = new SignValue(184290);
                sv[3, 0] = new SignValue(184390);
                sv[0, 1] = new SignValue(184490);
                sv[1, 1] = new SignValue(184491);
                sv[2, 1] = new SignValue(184590);
                sv[3, 1] = new SignValue(184690);
                Processor pa = new Processor(sv, "a");

                sv[0, 0] = new SignValue(184890);
                sv[1, 0] = new SignValue(184990);
                sv[2, 0] = new SignValue(185090);
                sv[3, 0] = new SignValue(185190);
                sv[0, 1] = new SignValue(185290);
                sv[1, 1] = new SignValue(185390);
                sv[2, 1] = new SignValue(185490);
                sv[3, 1] = new SignValue(185590);
                Processor pb = new Processor(sv, "b");

                sv[0, 0] = new SignValue(185690);
                sv[1, 0] = new SignValue(185790);
                sv[2, 0] = new SignValue(185890);
                sv[3, 0] = new SignValue(185990);
                sv[0, 1] = new SignValue(186090);
                sv[1, 1] = new SignValue(186190);
                sv[2, 1] = new SignValue(186290);
                sv[3, 1] = new SignValue(186390);
                Processor pc = new Processor(sv, "c");

                sv[0, 0] = new SignValue(186490);
                sv[1, 0] = new SignValue(186590);
                sv[2, 0] = new SignValue(186690);
                sv[3, 0] = new SignValue(186790);
                sv[0, 1] = new SignValue(186890);
                sv[1, 1] = new SignValue(186990);
                sv[2, 1] = new SignValue(187090);
                sv[3, 1] = new SignValue(187190);
                Processor pd = new Processor(sv, "d");

                sv[0, 0] = new SignValue(188090);
                sv[1, 0] = new SignValue(188190);
                sv[2, 0] = new SignValue(188290);
                sv[3, 0] = new SignValue(188390);
                sv[0, 1] = new SignValue(188490);
                sv[1, 1] = new SignValue(188590);
                sv[2, 1] = new SignValue(188690);
                sv[3, 1] = new SignValue(188790);
                Processor pe = new Processor(sv, "e");

                sv[0, 0] = new SignValue(188890);
                sv[1, 0] = new SignValue(188990);
                sv[2, 0] = new SignValue(189090);
                sv[3, 0] = new SignValue(189190);
                sv[0, 1] = new SignValue(189290);
                sv[1, 1] = new SignValue(189390);
                sv[2, 1] = new SignValue(189490);
                sv[3, 1] = new SignValue(189590);
                Processor pf = new Processor(sv, "f");

                ProcessorContainer[,] pcs = new ProcessorContainer[3, 2];
                pcs[0, 0] = new ProcessorContainer(p1, pa);
                pcs[1, 0] = new ProcessorContainer(p2, pb);
                pcs[2, 0] = new ProcessorContainer(p3, pc);
                pcs[0, 1] = new ProcessorContainer(p4, pd);
                pcs[1, 1] = new ProcessorContainer(p5, pe);
                pcs[2, 1] = new ProcessorContainer(p6, pf);

                sv = new SignValue[12, 4];
                sv[0, 0] = new SignValue(188840);
                sv[1, 0] = new SignValue(187150);
                sv[2, 0] = new SignValue(186650);
                sv[3, 0] = new SignValue(185250);
                sv[4, 0] = new SignValue(186350);
                sv[5, 0] = new SignValue(189550);
                sv[6, 0] = new SignValue(7000);
                sv[7, 0] = new SignValue(188360);
                sv[8, 0] = new SignValue(186560);
                sv[9, 0] = new SignValue(10000);

                sv[10, 0] = new SignValue(11000);
                sv[11, 0] = new SignValue(12000);
                sv[0, 1] = new SignValue(13000);
                sv[1, 1] = new SignValue(186260);
                sv[2, 1] = new SignValue(188570);
                sv[3, 1] = new SignValue(16000);
                sv[4, 1] = new SignValue(17000);
                sv[5, 1] = new SignValue(188220);
                sv[6, 1] = new SignValue(19000);
                sv[7, 1] = new SignValue(185530);

                sv[8, 1] = new SignValue(21000);
                sv[9, 1] = new SignValue(22000);
                sv[10, 1] = new SignValue(23000);
                sv[11, 1] = new SignValue(24000);
                sv[0, 2] = new SignValue(25000);
                sv[1, 2] = new SignValue(26000);
                sv[2, 2] = new SignValue(27000);
                sv[3, 2] = new SignValue(28000);
                sv[4, 2] = new SignValue(29000);
                sv[5, 2] = new SignValue(30000);

                sv[6, 2] = new SignValue(31000);
                sv[7, 2] = new SignValue(32000);
                sv[8, 2] = new SignValue(33000);
                sv[9, 2] = new SignValue(183410);
                sv[10, 2] = new SignValue(35000);
                sv[11, 2] = new SignValue(181610);
                sv[0, 3] = new SignValue(183620);
                sv[1, 3] = new SignValue(38000);
                sv[2, 3] = new SignValue(180030);
                sv[3, 3] = new SignValue(40000);

                sv[4, 3] = new SignValue(41000);
                sv[5, 3] = new SignValue(42000);
                sv[6, 3] = new SignValue(43000);
                sv[7, 3] = new SignValue(44000);
                sv[8, 3] = new SignValue(45000);
                sv[9, 3] = new SignValue(46000);
                sv[10, 3] = new SignValue(47000);
                sv[11, 3] = new SignValue(48000);

                char[,] str = new char[3, 2];
                str[0, 0] = 'a';
                str[1, 0] = 'b';
                str[2, 0] = '3';
                str[0, 1] = '4';
                str[1, 1] = '5';
                str[2, 1] = '6';

                Processor result = new Reflector(pcs).Push(new Processor(sv, "Map"), str);
                Assert.AreNotEqual(null, result);
                Assert.AreEqual(12, result.Width);
                Assert.AreEqual(4, result.Height);

                Assert.AreEqual(new SignValue(184090), result[0, 0]);
                Assert.AreEqual(new SignValue(184190), result[1, 0]);
                Assert.AreEqual(new SignValue(184290), result[2, 0]);
                Assert.AreEqual(new SignValue(184390), result[3, 0]);
                Assert.AreEqual(new SignValue(184490), result[0, 1]);
                Assert.AreEqual(new SignValue(184491), result[1, 1]);
                Assert.AreEqual(new SignValue(184590), result[2, 1]);
                Assert.AreEqual(new SignValue(184690), result[3, 1]);

                Assert.AreEqual(new SignValue(184890), result[4, 0]);
                Assert.AreEqual(new SignValue(184990), result[5, 0]);
                Assert.AreEqual(new SignValue(185090), result[6, 0]);
                Assert.AreEqual(new SignValue(185190), result[7, 0]);
                Assert.AreEqual(new SignValue(185290), result[4, 1]);
                Assert.AreEqual(new SignValue(185390), result[5, 1]);
                Assert.AreEqual(new SignValue(185490), result[6, 1]);
                Assert.AreEqual(new SignValue(185590), result[7, 1]);

                Assert.AreEqual(new SignValue(179790), result[8, 0]);
                Assert.AreEqual(new SignValue(179890), result[9, 0]);
                Assert.AreEqual(new SignValue(179990), result[10, 0]);
                Assert.AreEqual(new SignValue(180090), result[11, 0]);
                Assert.AreEqual(new SignValue(180190), result[8, 1]);
                Assert.AreEqual(new SignValue(180290), result[9, 1]);
                Assert.AreEqual(new SignValue(180390), result[10, 1]);
                Assert.AreEqual(new SignValue(180490), result[11, 1]);

                Assert.AreEqual(new SignValue(180590), result[0, 2]);
                Assert.AreEqual(new SignValue(180690), result[1, 2]);
                Assert.AreEqual(new SignValue(180790), result[2, 2]);
                Assert.AreEqual(new SignValue(180890), result[3, 2]);
                Assert.AreEqual(new SignValue(180990), result[0, 3]);
                Assert.AreEqual(new SignValue(181190), result[1, 3]);
                Assert.AreEqual(new SignValue(181290), result[2, 3]);
                Assert.AreEqual(new SignValue(181390), result[3, 3]);

                Assert.AreEqual(new SignValue(181490), result[4, 2]);
                Assert.AreEqual(new SignValue(181590), result[5, 2]);
                Assert.AreEqual(new SignValue(181690), result[6, 2]);
                Assert.AreEqual(new SignValue(181790), result[7, 2]);
                Assert.AreEqual(new SignValue(181890), result[4, 3]);
                Assert.AreEqual(new SignValue(181990), result[5, 3]);
                Assert.AreEqual(new SignValue(182090), result[6, 3]);
                Assert.AreEqual(new SignValue(182190), result[7, 3]);

                Assert.AreEqual(new SignValue(183290), result[8, 2]);
                Assert.AreEqual(new SignValue(183390), result[9, 2]);
                Assert.AreEqual(new SignValue(183490), result[10, 2]);
                Assert.AreEqual(new SignValue(183590), result[11, 2]);
                Assert.AreEqual(new SignValue(183690), result[8, 3]);
                Assert.AreEqual(new SignValue(183790), result[9, 3]);
                Assert.AreEqual(new SignValue(183890), result[10, 3]);
                Assert.AreEqual(new SignValue(183990), result[11, 3]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest1()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(2)}, "1"),
                new Processor(new[] {new SignValue(20)}, "8"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "2"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "7"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "5"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest2()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "1"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(2)}, "2"),
                new Processor(new[] {new SignValue(20)}, "9"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "a"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "b"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest3()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "1"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "5"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "7"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(2)}, "2"),
                new Processor(new[] {new SignValue(20)}, "8"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest4()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "1"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "5"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(2)}, "2"),
                new Processor(new[] {new SignValue(20)}, "7"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest5()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(new ProcessorContainer[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest6()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(new ProcessorContainer[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeRangeTest7()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(new ProcessorContainer[0, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SizeRangeTest8()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = null;
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "2"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "7"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SizeRangeTest9()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[0, 1] = null;
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "2"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "9"));
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SizeRangeTest10()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "2"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "7"));
            pc[1, 0] = null;
            pc[1, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SizeRangeTest11()
        {
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "3"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "6"));
            pc[0, 1] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "2"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "9"));
            pc[1, 0] = new ProcessorContainer(new Processor(new[] {new SignValue(20), new SignValue(30)}, "4"),
                new Processor(new[] {new SignValue(20), new SignValue(30)}, "8"));
            pc[1, 1] = null;
            // ReSharper disable once ObjectCreationAsStatement
            new Reflector(pc);
        }

        [TestMethod]
        public void IncorrectSize()
        {
            Reflector reflector = new Reflector(Pcs);

            char[,] str = new char[3, 3];

            str[0, 0] = '2';
            str[1, 0] = '3';
            str[2, 0] = '5';

            str[0, 1] = '8';
            str[1, 1] = 'a';
            str[2, 1] = 'c';

            str[0, 2] = 'e';
            str[1, 2] = 'f';
            str[2, 2] = 'h';

            byte count = 0;
            try
            {
                reflector.Push(new Processor(new SignValue[6, 1], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[1, 1], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            char[,] c = new char[3, 3];

            c[0, 0] = '2';
            c[1, 0] = '3';
            c[2, 0] = '5';

            c[0, 1] = '8';
            c[1, 1] = 'A';
            c[2, 1] = 'C';

            c[0, 2] = 'E';
            c[1, 2] = 'F';
            c[2, 2] = 'H';

            Assert.AreNotEqual(null, reflector.Push(PrMas1, c));
            count++;
            try
            {
                reflector.Push(new Processor(new SignValue[1, 6], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[5, 6], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[6, 5], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[7, 6], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[6, 7], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[8, 8], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            try
            {
                reflector.Push(new Processor(new SignValue[2], "Map"), str);
            }
            catch (ArgumentException)
            {
                count++;
            }
            Assert.AreNotEqual(null, reflector.Push(PrMas1, c));
            count++;

            Assert.AreEqual(11, count);
        }

        static void GetTestInternalEx(int ex, int ey)
        {
            ProcessorContainer[,] pcs = new ProcessorContainer[2, 2];
            Processor p1 = new Processor(new SignValue[1], "1");
            Processor p2 = new Processor(new SignValue[1], "2");
            Processor p3 = new Processor(new SignValue[1], "3");
            Processor p4 = new Processor(new SignValue[1], "4");

            Processor p5 = new Processor(new SignValue[1], "5");
            Processor p6 = new Processor(new SignValue[1], "6");
            Processor p7 = new Processor(new SignValue[1], "7");
            Processor p8 = new Processor(new SignValue[1], "8");

            pcs[0, 0] = new ProcessorContainer(p1, p2);
            pcs[1, 0] = new ProcessorContainer(p3, p4);
            pcs[0, 1] = new ProcessorContainer(p5, p6);
            pcs[1, 1] = new ProcessorContainer(p7, p8);

            Processor main = new Processor(new SignValue[2, 2], "Main");
            char[,] c = new char[2, 2];
            c[0, 0] = '1';
            c[1, 0] = '3';
            c[0, 1] = '5';
            c[1, 1] = '7';

            ReflectorTestClass r = new ReflectorTestClass(pcs);
            r.ReflexNull(ex, ey);
            r.Push(main, c);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SearchTestInternalEx1()
        {
            GetTestInternalEx(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SearchTestInternalEx2()
        {
            GetTestInternalEx(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SearchTestInternalEx3()
        {
            GetTestInternalEx(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SearchTestInternalEx4()
        {
            GetTestInternalEx(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReflectorCopyProcessorContainerTest()
        {
            ReflectorTestClass rt = new ReflectorTestClass(Pcs);
            rt.CopyProcessorContainer(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReflectorGetMapByNameTest()
        {
            ReflectorTestClass rt = new ReflectorTestClass(Pcs);
            // ReSharper disable once UnusedVariable
            rt.GetMapByName(' ');
        }

        [TestMethod]
        public void ReflectorIsNullTest1()
        {
            Assert.AreEqual(true, ReflectorTestClass.IsNull(null));
        }

        [TestMethod]
        public void ReflectorIsNullTest2()
        {
            char[,] c = new char[0, 0];
            Assert.AreEqual(true, ReflectorTestClass.IsNull(c));
        }

        [TestMethod]
        public void ReflectorIsNullTest3()
        {
            char[,] c = new char[0, 1];
            Assert.AreEqual(true, ReflectorTestClass.IsNull(c));
        }

        [TestMethod]
        public void ReflectorIsNullTest4()
        {
            char[,] c = new char[1, 0];
            Assert.AreEqual(true, ReflectorTestClass.IsNull(c));
        }

        sealed class ReflectorTestClass : Reflector
        {
            public ReflectorTestClass(ProcessorContainer[,] processors) : base(processors)
            {
            }

            public void ReflexNull(int x, int y)
            {
                _processorContainers[x, y] = null;
            }

            public new Processor GetMapByName(char tag) => base.GetMapByName(tag);

            public new static bool IsNull(char[,] words) => Reflector.IsNull(words);

            public new void CopyProcessorContainer(ProcessorContainer pc) => base.CopyProcessorContainer(pc);
        }
    }
}