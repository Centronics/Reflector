﻿using System;
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
    public class ReflectionTest
    {
        static Processor MainProcessor
        {
            get
            {
                SignValue[,] svv = new SignValue[4, 4];
                svv[0, 0] = new SignValue(3333);
                svv[1, 0] = new SignValue(4444);
                svv[2, 0] = new SignValue(1234);
                svv[3, 0] = new SignValue(2345);
                svv[0, 1] = new SignValue(2385);
                svv[1, 1] = new SignValue(7845);
                svv[2, 1] = new SignValue(3456);
                svv[3, 1] = new SignValue(4567);
                svv[0, 2] = new SignValue(7890);
                svv[1, 2] = new SignValue(6789);
                svv[2, 2] = new SignValue(9898);
                svv[3, 2] = new SignValue(8787);
                svv[0, 3] = new SignValue(3498);
                svv[1, 3] = new SignValue(9000);
                svv[2, 3] = new SignValue(1020);
                svv[3, 3] = new SignValue(1515);
                return new Processor(svv, "Map");
            }
        }

        static ProcessorContainer[,] MainReflectionDiff
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                sv[1, 0] = new SignValue(4444);
                sv[0, 1] = new SignValue(3000);
                sv[1, 1] = new SignValue(4000);
                Processor p1 = new Processor(sv, "1");
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(7777);
                sv[1, 1] = new SignValue(6565);
                Processor p2 = new Processor(sv, "2");
                sv[0, 0] = new SignValue(1111);
                sv[1, 0] = new SignValue(2222);
                sv[0, 1] = new SignValue(3433);
                sv[1, 1] = new SignValue(2323);
                Processor p3 = new Processor(sv, "3");
                sv[0, 0] = new SignValue(9999);
                sv[1, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(0000);
                sv[1, 1] = new SignValue(1010);
                Processor p4 = new Processor(sv, "4");
                sv[0, 0] = new SignValue(4343);
                sv[1, 0] = new SignValue(7990);
                sv[0, 1] = new SignValue(9909);
                sv[1, 1] = new SignValue(1200);
                Processor p5 = new Processor(sv, "5");
                sv[0, 0] = new SignValue(3956);
                sv[1, 0] = new SignValue(5678);
                sv[0, 1] = new SignValue(4214);
                sv[1, 1] = new SignValue(9876);
                Processor p6 = new Processor(sv, "6");
                sv[0, 0] = new SignValue(1234);
                sv[1, 0] = new SignValue(2345);
                sv[0, 1] = new SignValue(3456);
                sv[1, 1] = new SignValue(4567);
                Processor p7 = new Processor(sv, "7");
                sv[0, 0] = new SignValue(7890);
                sv[1, 0] = new SignValue(6789);
                sv[0, 1] = new SignValue(3498);
                sv[1, 1] = new SignValue(9000);
                Processor p8 = new Processor(sv, "8");
                sv[0, 0] = new SignValue(7590);
                sv[1, 0] = new SignValue(6889);
                sv[0, 1] = new SignValue(3408);
                sv[1, 1] = new SignValue(9002);
                Processor p9 = new Processor(sv, "9");
                sv[0, 0] = new SignValue(7892);
                sv[1, 0] = new SignValue(6785);
                sv[0, 1] = new SignValue(3428);
                sv[1, 1] = new SignValue(9007);
                Processor p10 = new Processor(sv, "A");
                sv[0, 0] = new SignValue(7899);
                sv[1, 0] = new SignValue(6783);
                sv[0, 1] = new SignValue(3494);
                sv[1, 1] = new SignValue(9005);
                Processor p11 = new Processor(sv, "B");
                sv[0, 0] = new SignValue(7896);
                sv[1, 0] = new SignValue(6787);
                sv[0, 1] = new SignValue(3398);
                sv[1, 1] = new SignValue(9500);
                Processor p12 = new Processor(sv, "C");
                sv[0, 0] = new SignValue(7899);
                sv[1, 0] = new SignValue(6783);
                sv[0, 1] = new SignValue(3494);
                sv[1, 1] = new SignValue(9005);
                Processor p13 = new Processor(sv, "D");
                sv[0, 0] = new SignValue(7896);
                sv[1, 0] = new SignValue(6787);
                sv[0, 1] = new SignValue(3398);
                sv[1, 1] = new SignValue(9500);
                Processor p14 = new Processor(sv, "E");
                sv[0, 0] = new SignValue(7899);
                sv[1, 0] = new SignValue(6783);
                sv[0, 1] = new SignValue(3494);
                sv[1, 1] = new SignValue(9005);
                Processor p15 = new Processor(sv, "F");
                sv[0, 0] = new SignValue(7896);
                sv[1, 0] = new SignValue(6787);
                sv[0, 1] = new SignValue(3398);
                sv[1, 1] = new SignValue(9500);
                Processor p16 = new Processor(sv, "G");
                sv[0, 0] = new SignValue(7899);
                sv[1, 0] = new SignValue(6783);
                sv[0, 1] = new SignValue(3494);
                sv[1, 1] = new SignValue(9005);
                Processor p17 = new Processor(sv, "H");
                sv[0, 0] = new SignValue(7896);
                sv[1, 0] = new SignValue(6787);
                sv[0, 1] = new SignValue(3398);
                sv[1, 1] = new SignValue(9500);
                Processor p18 = new Processor(sv, "I");
                ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
                pc[0, 0] = new ProcessorContainer(p1, p2, p9);
                pc[1, 0] = new ProcessorContainer(p3, p4, p10, p11);
                pc[0, 1] = new ProcessorContainer(p5, p6, p12, p13, p14);
                pc[1, 1] = new ProcessorContainer(p7, p8, p15, p16, p17, p18);

                byte result = 0;
                try
                {
                    try
                    {
                        ProcessorContainer[,] pc1 = new ProcessorContainer[2, 2];
                        pc1[0, 0] = new ProcessorContainer(p1);
                        pc1[1, 0] = new ProcessorContainer(p3, p4);
                        pc1[0, 1] = new ProcessorContainer(p5, p6);
                        pc1[1, 1] = new ProcessorContainer(p7, p8);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Reflection(pc1);
                    }
                    catch (ArgumentException)
                    {
                        result++;
                    }
                    try
                    {
                        ProcessorContainer[,] pc1 = new ProcessorContainer[2, 2];
                        pc1[0, 0] = new ProcessorContainer(p1, p2);
                        pc1[1, 0] = new ProcessorContainer(p3);
                        pc1[0, 1] = new ProcessorContainer(p5, p6);
                        pc1[1, 1] = new ProcessorContainer(p7, p8);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Reflection(pc1);
                    }
                    catch (ArgumentException)
                    {
                        result++;
                    }
                    try
                    {
                        ProcessorContainer[,] pc1 = new ProcessorContainer[2, 2];
                        pc1[0, 0] = new ProcessorContainer(p1, p2);
                        pc1[1, 0] = new ProcessorContainer(p3, p4);
                        pc1[0, 1] = new ProcessorContainer(p5);
                        pc1[1, 1] = new ProcessorContainer(p7, p8);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Reflection(pc1);
                    }
                    catch (ArgumentException)
                    {
                        result++;
                    }
                    try
                    {
                        ProcessorContainer[,] pc1 = new ProcessorContainer[2, 2];
                        pc1[0, 0] = new ProcessorContainer(p1, p2);
                        pc1[1, 0] = new ProcessorContainer(p3, p4);
                        pc1[0, 1] = new ProcessorContainer(p5, p6);
                        pc1[1, 1] = new ProcessorContainer(p7);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Reflection(pc1);
                    }
                    catch (ArgumentException)
                    {
                        result++;
                    }
                    try
                    {
                        ProcessorContainer[,] pc1 = new ProcessorContainer[2, 2];
                        pc1[0, 0] = new ProcessorContainer(p1, p2);
                        pc1[1, 0] = new ProcessorContainer(p3, p4);
                        pc1[0, 1] = new ProcessorContainer(p5);
                        pc1[1, 1] = new ProcessorContainer(p7);
                        // ReSharper disable once ObjectCreationAsStatement
                        new Reflection(pc1);
                    }
                    catch (ArgumentException)
                    {
                        result++;
                    }
                }
                finally
                {
                    Assert.AreEqual(5, result);
                    // ReSharper disable once ObjectCreationAsStatement
                    new Reflection(pc);
                }
                return pc;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReflectionTestNullArgs()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReflectionEmptyTest0()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReflectionEmptyTest1()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[0, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReflectionEmptyTest2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[2, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RangeTest1()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RangeTest2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[0, 1]);
        }

        static Processor GetTestProcessor(Processor p)
        {
            SignValue[,] sv = new SignValue[p.Width, p.Height];
            for (int y = 0; y < p.Height; y++)
                for (int x = 0; x < p.Width; x++)
                    sv[x, y] = new SignValue(p[x, y] + 1);
            return new Processor(sv, p.Tag);
        }

        [TestMethod]
        public void ReflectionTest0()
        {
            SignValue[,] sv = new SignValue[2, 2];
            sv[0, 0] = new SignValue(3333);
            sv[1, 0] = new SignValue(4444);
            sv[0, 1] = new SignValue(3000);
            sv[1, 1] = new SignValue(4000);
            Processor p1 = new Processor(sv, "1");
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(7777);
            sv[1, 1] = new SignValue(6565);
            Processor p2 = new Processor(sv, "2");
            sv[0, 0] = new SignValue(1111);
            sv[1, 0] = new SignValue(2222);
            sv[0, 1] = new SignValue(3433);
            sv[1, 1] = new SignValue(2323);
            Processor p3 = new Processor(sv, "3");
            sv[0, 0] = new SignValue(9999);
            sv[1, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(0000);
            sv[1, 1] = new SignValue(1010);
            Processor p4 = new Processor(sv, "4");
            sv[0, 0] = new SignValue(4343);
            sv[1, 0] = new SignValue(7990);
            sv[0, 1] = new SignValue(9909);
            sv[1, 1] = new SignValue(1200);
            Processor p5 = new Processor(sv, "5");
            sv[0, 0] = new SignValue(3956);
            sv[1, 0] = new SignValue(5678);
            sv[0, 1] = new SignValue(4214);
            sv[1, 1] = new SignValue(9876);
            Processor p6 = new Processor(sv, "6");
            sv[0, 0] = new SignValue(1234);
            sv[1, 0] = new SignValue(2345);
            sv[0, 1] = new SignValue(3456);
            sv[1, 1] = new SignValue(4567);
            Processor p7 = new Processor(sv, "7");
            sv[0, 0] = new SignValue(7890);
            sv[1, 0] = new SignValue(6789);
            sv[0, 1] = new SignValue(3498);
            sv[1, 1] = new SignValue(9000);
            Processor p8 = new Processor(sv, "8");
            sv[0, 0] = new SignValue(7590);
            sv[1, 0] = new SignValue(6889);
            sv[0, 1] = new SignValue(3408);
            sv[1, 1] = new SignValue(9002);
            Processor p9 = new Processor(sv, "9");
            sv[0, 0] = new SignValue(7892);
            sv[1, 0] = new SignValue(6785);
            sv[0, 1] = new SignValue(3428);
            sv[1, 1] = new SignValue(9007);
            Processor p10 = new Processor(sv, "A");
            sv[0, 0] = new SignValue(7899);
            sv[1, 0] = new SignValue(6783);
            sv[0, 1] = new SignValue(3494);
            sv[1, 1] = new SignValue(9005);
            Processor p11 = new Processor(sv, "b");
            sv[0, 0] = new SignValue(7896);
            sv[1, 0] = new SignValue(6787);
            sv[0, 1] = new SignValue(3398);
            sv[1, 1] = new SignValue(9500);
            Processor p12 = new Processor(sv, "C");
            sv[0, 0] = new SignValue(7899);
            sv[1, 0] = new SignValue(6783);
            sv[0, 1] = new SignValue(3494);
            sv[1, 1] = new SignValue(9005);

            ProcessorContainer[,] pc = new ProcessorContainer[3, 2];
            pc[0, 0] = new ProcessorContainer(p1, p2);
            pc[1, 0] = new ProcessorContainer(p3, p4);
            pc[2, 0] = new ProcessorContainer(p9, p10);
            pc[0, 1] = new ProcessorContainer(p5, p6);
            pc[1, 1] = new ProcessorContainer(p7, p8);
            pc[2, 1] = new ProcessorContainer(p11, p12);
            Reflection reflection = new Reflection(pc);
            Assert.AreEqual(6, reflection.MapWidth);
            Assert.AreEqual(4, reflection.MapHeight);

            pc = new ProcessorContainer[2, 3];
            pc[0, 0] = new ProcessorContainer(p1, p2);
            pc[1, 0] = new ProcessorContainer(p3, p4);
            pc[0, 1] = new ProcessorContainer(p9, p10);
            pc[1, 1] = new ProcessorContainer(p5, p6);
            pc[0, 2] = new ProcessorContainer(p7, p8);
            pc[1, 2] = new ProcessorContainer(p11, p12);
            reflection = new Reflection(pc);
            Assert.AreEqual(4, reflection.MapWidth);
            Assert.AreEqual(6, reflection.MapHeight);
        }

        [TestMethod]
        // ReSharper disable once FunctionComplexityOverflow
        public void ReflectionTest1()
        {
            Reflection reflection = new Reflection(MainReflectionDiff);
            Assert.AreEqual(4, reflection.MapWidth);
            Assert.AreEqual(4, reflection.MapHeight);
            Processor[] pcs = reflection.Push(GetTestProcessor(MainProcessor)).ToArray();
            Assert.AreEqual(8, pcs.Length);
            Assert.AreEqual(0, pcs.Count(p => p == null));

            Assert.AreEqual(3333, pcs[0][0, 0].Value);
            Assert.AreEqual(3000, pcs[0][0, 1].Value);
            Assert.AreEqual(7896, pcs[0][0, 2].Value);
            Assert.AreEqual(3398, pcs[0][0, 3].Value);

            Assert.AreEqual(4444, pcs[0][1, 0].Value);
            Assert.AreEqual(4000, pcs[0][1, 1].Value);
            Assert.AreEqual(6787, pcs[0][1, 2].Value);
            Assert.AreEqual(9500, pcs[0][1, 3].Value);

            Assert.AreEqual(1111, pcs[0][2, 0].Value);
            Assert.AreEqual(3433, pcs[0][2, 1].Value);
            Assert.AreEqual(1234, pcs[0][2, 2].Value);
            Assert.AreEqual(3456, pcs[0][2, 3].Value);

            Assert.AreEqual(2222, pcs[0][3, 0].Value);
            Assert.AreEqual(2323, pcs[0][3, 1].Value);
            Assert.AreEqual(2345, pcs[0][3, 2].Value);
            Assert.AreEqual(4567, pcs[0][3, 3].Value);

            Assert.AreEqual(3333, pcs[1][0, 0].Value);
            Assert.AreEqual(3000, pcs[1][0, 1].Value);
            Assert.AreEqual(7899, pcs[1][0, 2].Value);
            Assert.AreEqual(3494, pcs[1][0, 3].Value);

            Assert.AreEqual(4444, pcs[1][1, 0].Value);
            Assert.AreEqual(4000, pcs[1][1, 1].Value);
            Assert.AreEqual(6783, pcs[1][1, 2].Value);
            Assert.AreEqual(9005, pcs[1][1, 3].Value);

            Assert.AreEqual(1111, pcs[1][2, 0].Value);
            Assert.AreEqual(3433, pcs[1][2, 1].Value);
            Assert.AreEqual(1234, pcs[1][2, 2].Value);
            Assert.AreEqual(3456, pcs[1][2, 3].Value);

            Assert.AreEqual(2222, pcs[1][3, 0].Value);
            Assert.AreEqual(2323, pcs[1][3, 1].Value);
            Assert.AreEqual(2345, pcs[1][3, 2].Value);
            Assert.AreEqual(4567, pcs[1][3, 3].Value);

            Assert.AreEqual(3333, pcs[2][0, 0].Value);
            Assert.AreEqual(3000, pcs[2][0, 1].Value);
            Assert.AreEqual(7896, pcs[2][0, 2].Value);
            Assert.AreEqual(3398, pcs[2][0, 3].Value);

            Assert.AreEqual(4444, pcs[2][1, 0].Value);
            Assert.AreEqual(4000, pcs[2][1, 1].Value);
            Assert.AreEqual(6787, pcs[2][1, 2].Value);
            Assert.AreEqual(9500, pcs[2][1, 3].Value);

            Assert.AreEqual(1111, pcs[2][2, 0].Value);
            Assert.AreEqual(3433, pcs[2][2, 1].Value);
            Assert.AreEqual(7890, pcs[2][2, 2].Value);
            Assert.AreEqual(3498, pcs[2][2, 3].Value);

            Assert.AreEqual(2222, pcs[2][3, 0].Value);
            Assert.AreEqual(2323, pcs[2][3, 1].Value);
            Assert.AreEqual(6789, pcs[2][3, 2].Value);
            Assert.AreEqual(9000, pcs[2][3, 3].Value);

            Assert.AreEqual(3333, pcs[3][0, 0].Value);
            Assert.AreEqual(3000, pcs[3][0, 1].Value);
            Assert.AreEqual(7899, pcs[3][0, 2].Value);
            Assert.AreEqual(3494, pcs[3][0, 3].Value);

            Assert.AreEqual(4444, pcs[3][1, 0].Value);
            Assert.AreEqual(4000, pcs[3][1, 1].Value);
            Assert.AreEqual(6783, pcs[3][1, 2].Value);
            Assert.AreEqual(9005, pcs[3][1, 3].Value);

            Assert.AreEqual(1111, pcs[3][2, 0].Value);
            Assert.AreEqual(3433, pcs[3][2, 1].Value);
            Assert.AreEqual(7890, pcs[3][2, 2].Value);
            Assert.AreEqual(3498, pcs[3][2, 3].Value);

            Assert.AreEqual(2222, pcs[3][3, 0].Value);
            Assert.AreEqual(2323, pcs[3][3, 1].Value);
            Assert.AreEqual(6789, pcs[3][3, 2].Value);
            Assert.AreEqual(9000, pcs[3][3, 3].Value);

            Assert.AreEqual(3333, pcs[4][0, 0].Value);
            Assert.AreEqual(3000, pcs[4][0, 1].Value);
            Assert.AreEqual(7896, pcs[4][0, 2].Value);
            Assert.AreEqual(3398, pcs[4][0, 3].Value);

            Assert.AreEqual(4444, pcs[4][1, 0].Value);
            Assert.AreEqual(4000, pcs[4][1, 1].Value);
            Assert.AreEqual(6787, pcs[4][1, 2].Value);
            Assert.AreEqual(9500, pcs[4][1, 3].Value);

            Assert.AreEqual(1111, pcs[4][2, 0].Value);
            Assert.AreEqual(3433, pcs[4][2, 1].Value);
            Assert.AreEqual(7899, pcs[4][2, 2].Value);
            Assert.AreEqual(3494, pcs[4][2, 3].Value);

            Assert.AreEqual(2222, pcs[4][3, 0].Value);
            Assert.AreEqual(2323, pcs[4][3, 1].Value);
            Assert.AreEqual(6783, pcs[4][3, 2].Value);
            Assert.AreEqual(9005, pcs[4][3, 3].Value);

            Assert.AreEqual(3333, pcs[5][0, 0].Value);
            Assert.AreEqual(3000, pcs[5][0, 1].Value);
            Assert.AreEqual(7899, pcs[5][0, 2].Value);
            Assert.AreEqual(3494, pcs[5][0, 3].Value);

            Assert.AreEqual(4444, pcs[5][1, 0].Value);
            Assert.AreEqual(4000, pcs[5][1, 1].Value);
            Assert.AreEqual(6783, pcs[5][1, 2].Value);
            Assert.AreEqual(9005, pcs[5][1, 3].Value);

            Assert.AreEqual(1111, pcs[5][2, 0].Value);
            Assert.AreEqual(3433, pcs[5][2, 1].Value);
            Assert.AreEqual(7899, pcs[5][2, 2].Value);
            Assert.AreEqual(3494, pcs[5][2, 3].Value);

            Assert.AreEqual(2222, pcs[5][3, 0].Value);
            Assert.AreEqual(2323, pcs[5][3, 1].Value);
            Assert.AreEqual(6783, pcs[5][3, 2].Value);
            Assert.AreEqual(9005, pcs[5][3, 3].Value);

            Assert.AreEqual(3333, pcs[6][0, 0].Value);
            Assert.AreEqual(3000, pcs[6][0, 1].Value);
            Assert.AreEqual(7896, pcs[6][0, 2].Value);
            Assert.AreEqual(3398, pcs[6][0, 3].Value);

            Assert.AreEqual(4444, pcs[6][1, 0].Value);
            Assert.AreEqual(4000, pcs[6][1, 1].Value);
            Assert.AreEqual(6787, pcs[6][1, 2].Value);
            Assert.AreEqual(9500, pcs[6][1, 3].Value);

            Assert.AreEqual(1111, pcs[6][2, 0].Value);
            Assert.AreEqual(3433, pcs[6][2, 1].Value);
            Assert.AreEqual(7896, pcs[6][2, 2].Value);
            Assert.AreEqual(3398, pcs[6][2, 3].Value);

            Assert.AreEqual(2222, pcs[6][3, 0].Value);
            Assert.AreEqual(2323, pcs[6][3, 1].Value);
            Assert.AreEqual(6787, pcs[6][3, 2].Value);
            Assert.AreEqual(9500, pcs[6][3, 3].Value);

            Assert.AreEqual(3333, pcs[7][0, 0].Value);
            Assert.AreEqual(3000, pcs[7][0, 1].Value);
            Assert.AreEqual(7899, pcs[7][0, 2].Value);
            Assert.AreEqual(3494, pcs[7][0, 3].Value);

            Assert.AreEqual(4444, pcs[7][1, 0].Value);
            Assert.AreEqual(4000, pcs[7][1, 1].Value);
            Assert.AreEqual(6783, pcs[7][1, 2].Value);
            Assert.AreEqual(9005, pcs[7][1, 3].Value);

            Assert.AreEqual(1111, pcs[7][2, 0].Value);
            Assert.AreEqual(3433, pcs[7][2, 1].Value);
            Assert.AreEqual(7896, pcs[7][2, 2].Value);
            Assert.AreEqual(3398, pcs[7][2, 3].Value);

            Assert.AreEqual(2222, pcs[7][3, 0].Value);
            Assert.AreEqual(2323, pcs[7][3, 1].Value);
            Assert.AreEqual(6787, pcs[7][3, 2].Value);
            Assert.AreEqual(9500, pcs[7][3, 3].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReflectionException7()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReflectionException8()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(new ProcessorContainer[0, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReflectionException9()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Reflection(null);
        }

        [TestMethod]
        public void ProcessorSameTest()
        {
            SignValue[,] sv1 = new SignValue[1, 2];
            sv1[0, 0] = new SignValue(1000);
            SignValue[,] sv2 = new SignValue[1, 2];
            sv1[0, 0] = new SignValue(1001);

            Reflection.ProcessorSame ps = new Reflection.ProcessorSame();
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "1"), new Processor(sv2, "1")));

            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "1"), new Processor(sv2, "2")));

            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            for (int k = 0; k < 50000; k++)
                Assert.AreEqual(ps.GetHashCode(new Processor(sv1, "3")), ps.GetHashCode(new Processor(sv1, "3")));

            for (int k = 0; k < 50000; k++)
                Assert.AreEqual(ps.GetHashCode(new Processor(sv1, "3u78")), ps.GetHashCode(new Processor(sv1, "4hgj")));

            long totalCheckSumm1 = 0;
            {
                double dbRep = 0.0, dbNotRep = 0.0;
                const int maxlen = 10000;
                for (int i = 1; i <= maxlen; i++)
                {
                    SignValue[] svv1 = new SignValue[i];
                    for (int u = 0; u < i; u++)
                        svv1[u] = new SignValue(u);
                    SignValue[] svv2 = new SignValue[i];
                    for (int u = 0; u < i; u++)
                        svv2[u] = new SignValue(maxlen - u);
                    int c1 = ps.GetHashCode(new Processor(svv1, "1")), c2 = ps.GetHashCode(new Processor(svv2, "1"));
                    totalCheckSumm1 = unchecked(totalCheckSumm1 + c1 + c2);
                    if (c1 == c2)
                        dbRep++;
                    else
                        dbNotRep++;
                }
                dbRep = dbRep / dbNotRep * 100.0;
                Assert.AreEqual(true, dbRep < 0.4);
            }

            long totalCheckSumm2 = 0;
            {
                // Двумерные карты
                double dbRep = 0.0, dbNotRep = 0.0;
                const int maxlen = 100;
                for (int y = 1; y <= 100; y++)
                    for (int x = 1; x <= maxlen; x++)
                    {
                        SignValue[,] svv1 = new SignValue[x, y];
                        for (int p = 0; p < y; p++)
                            for (int u = 0; u < x; u++)
                                svv1[u, p] = new SignValue(u);
                        SignValue[,] svv2 = new SignValue[x, y];
                        for (int p = 0; p < y; p++)
                            for (int u = 0; u < x; u++)
                                svv2[u, p] = new SignValue(maxlen - u);
                        Processor p1 = new Processor(svv1, "1");
                        Processor p2 = new Processor(svv2, "1");
                        int c1 = ps.GetHashCode(p1), c2 = ps.GetHashCode(p2);
                        totalCheckSumm2 = unchecked(totalCheckSumm2 + c1 + c2);
                        if (c1 == c2)
                            dbRep++;
                        else
                            dbNotRep++;
                    }
                dbRep = dbRep / dbNotRep * 100.0;
                Assert.AreEqual(true, dbRep < 0.6);
                Assert.AreNotEqual(totalCheckSumm1, totalCheckSumm2);
            }

            sv1 = new SignValue[1, 3];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            sv2 = new SignValue[1, 3];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1i")));

            sv1 = new SignValue[1, 3];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            sv1 = new SignValue[3, 1];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            sv2 = new SignValue[3, 1];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "1")));

            sv1 = new SignValue[1, 1];
            sv1[0, 0] = new SignValue(1000);
            sv2[0, 0] = new SignValue(1000);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "1"), new Processor(sv2, "1")));

            sv1 = new SignValue[2, 1];
            sv1[0, 0] = new SignValue(1);
            sv1[1, 0] = new SignValue(2);
            sv2 = new SignValue[2, 1];
            sv2[0, 0] = new SignValue(1);
            sv2[1, 0] = new SignValue(2);
            Assert.AreEqual(true, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "2")));

            sv1 = new SignValue[2, 1];
            sv1[0, 0] = new SignValue(3);
            sv1[1, 0] = new SignValue(2);
            sv2 = new SignValue[2, 1];
            sv2[0, 0] = new SignValue(1);
            sv2[1, 0] = new SignValue(2);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "2")));

            sv1 = new SignValue[1, 2];
            sv1[0, 0] = new SignValue(1);
            sv1[0, 1] = new SignValue(4);
            sv2 = new SignValue[1, 2];
            sv2[0, 0] = new SignValue(1);
            sv2[0, 1] = new SignValue(2);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "2")));

            sv1 = new SignValue[1, 2];
            sv1[0, 0] = new SignValue(1);
            sv1[0, 1] = new SignValue(2);
            sv2 = new SignValue[1, 2];
            sv2[0, 0] = new SignValue(32);
            sv2[0, 1] = new SignValue(2);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "2")));

            sv1 = new SignValue[1, 2];
            sv1[0, 0] = new SignValue(1);
            sv1[0, 1] = new SignValue(2);
            sv2 = new SignValue[1, 2];
            sv2[0, 0] = new SignValue(1);
            sv2[0, 1] = new SignValue(21);
            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), new Processor(sv2, "2")));

            Assert.AreEqual(true, ps.Equals(null, null));

            Assert.AreEqual(false, ps.Equals(new Processor(sv1, "2"), null));

            Assert.AreEqual(false, ps.Equals(null, new Processor(sv1, "2")));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcptReflection3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            new Reflection(MainReflectionDiff).Push(null).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcptReflection4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            new Reflection(MainReflectionDiff).Push(new Processor(new SignValue[1, 4], "Tag")).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcptReflection5()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            new Reflection(MainReflectionDiff).Push(new Processor(new SignValue[4, 5], "Tag")).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcptReflection6()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            new Reflection(MainReflectionDiff).Push(new Processor(new SignValue[4, 3], "Tag")).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcptReflection7()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            new Reflection(MainReflectionDiff).Push(new Processor(new SignValue[5, 4], "Tag")).ToArray();
        }

        [TestMethod]
        public void MultipleMap1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = SignValue.MaxValue;
            Processor p1 = new Processor(sv, "1");
            Processor p2 = new Processor(sv, "2");
            Processor p3 = new Processor(sv, "3");
            Processor p4 = new Processor(sv, "4");
            Processor p5 = new Processor(sv, "5");
            Processor p6 = new Processor(sv, "6");
            Processor p7 = new Processor(sv, "7");
            Processor p8 = new Processor(sv, "8");
            ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
            pc[0, 0] = new ProcessorContainer(p1, p2);
            pc[1, 0] = new ProcessorContainer(p3, p4);
            pc[0, 1] = new ProcessorContainer(p5, p6);
            pc[1, 1] = new ProcessorContainer(p7, p8);
            Reflection reflection = new Reflection(pc);
            sv = new SignValue[2, 2];
            sv[0, 0] = SignValue.MaxValue;
            sv[1, 0] = SignValue.MaxValue;
            sv[0, 1] = SignValue.MaxValue;
            sv[1, 1] = SignValue.MaxValue;
            Processor[] pr = reflection.Push(new Processor(sv, "Tag")).ToArray();
            Assert.AreNotEqual(null, pr);
            Assert.AreEqual(1, pr.Length);

            Assert.AreNotEqual(null, pr[0]);
            Assert.AreEqual(2, pr[0].Width);
            Assert.AreEqual(2, pr[0].Height);
            Assert.AreEqual("Tag", pr[0].Tag);
            Assert.AreEqual(SignValue.MaxValue, pr[0][0, 0]);
            Assert.AreEqual(SignValue.MaxValue, pr[0][1, 0]);
            Assert.AreEqual(SignValue.MaxValue, pr[0][0, 1]);
            Assert.AreEqual(SignValue.MaxValue, pr[0][1, 1]);
        }

        [TestMethod]
        public void MultipleMap2()
        {
            for (int k = 0; k < 3000; k++)
            {
                SignValue[,] sv1 = new SignValue[1, 1], sv2 = new SignValue[1, 1];
                sv1[0, 0] = SignValue.MaxValue;
                Processor p1 = new Processor(sv1, "1");
                Processor p2 = new Processor(sv2, "2");
                Processor p3 = new Processor(sv1, "3");
                Processor p4 = new Processor(sv2, "4");
                Processor p5 = new Processor(sv1, "5");
                Processor p6 = new Processor(sv2, "6");
                Processor p7 = new Processor(sv1, "7");
                Processor p8 = new Processor(sv2, "8");
                ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
                pc[0, 0] = new ProcessorContainer(p1, p2);
                pc[1, 0] = new ProcessorContainer(p3, p4);
                pc[0, 1] = new ProcessorContainer(p5, p6);
                pc[1, 1] = new ProcessorContainer(p7, p8);
                Reflection reflection = new Reflection(pc);
                sv1 = new SignValue[2, 2];
                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                Processor[] pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(1, pr.Length);

                Assert.AreNotEqual(null, pr[0]);
                Assert.AreEqual(2, pr[0].Width);
                Assert.AreEqual(2, pr[0].Height);
                Assert.AreEqual("Tag", pr[0].Tag);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 1]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 1]);

                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);

                pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(16, pr.Length);

                bool[] q = new bool[16];
                foreach (Processor p in pr)
                {
                    Assert.AreNotEqual(null, p);
                    Assert.AreEqual(2, p.Width);
                    Assert.AreEqual(2, p.Height);
                    Assert.AreEqual("Tag", p.Tag);

                    bool res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MaxValue &&
                               p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[0] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[1] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[2] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[3] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[4] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[5] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[6] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MaxValue;

                    if (res)
                    {
                        q[7] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[8] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[9] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[10] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MaxValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[11] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[12] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MaxValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[13] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MaxValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MinValue;

                    if (res)
                    {
                        q[14] = true;
                        continue;
                    }

                    res = p[0, 0] == SignValue.MinValue && p[1, 0] == SignValue.MinValue &&
                          p[0, 1] == SignValue.MinValue && p[1, 1] == SignValue.MinValue;

                    if (!res)
                        throw new Exception();
                    q[15] = true;
                }

                Assert.AreEqual(true, q.All(t => t));
            }
        }

        [TestMethod]
        public void MultipleMap3()
        {
            for (int k = 0; k < 1000; k++)
            {
                SignValue[,] sv1 = new SignValue[1, 1], sv2 = new SignValue[1, 1];
                sv1[0, 0] = SignValue.MaxValue;
                Processor p1 = new Processor(sv1, "1");
                Processor p2 = new Processor(sv2, "2");
                Processor p3 = new Processor(sv1, "3");
                Processor p4 = new Processor(sv2, "4");
                Processor p5 = new Processor(sv1, "5");
                Processor p6 = new Processor(sv2, "6");
                Processor p7 = new Processor(sv1, "7");
                Processor p8 = new Processor(sv2, "8");
                ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
                pc[0, 0] = new ProcessorContainer(p1, p2);
                pc[1, 0] = new ProcessorContainer(p3, p4);
                pc[0, 1] = new ProcessorContainer(p5, p6);
                pc[1, 1] = new ProcessorContainer(p7, p8);
                Reflection reflection = new Reflection(pc);
                sv1 = new SignValue[2, 2];
                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                Processor[] pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(1, pr.Length);

                Assert.AreNotEqual(null, pr[0]);
                Assert.AreEqual(2, pr[0].Width);
                Assert.AreEqual(2, pr[0].Height);
                Assert.AreEqual("Tag", pr[0].Tag);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 1]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 1]);

                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 1);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 1);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 1);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 1);

                pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(1, pr.Length);

                Assert.AreEqual(true,
                    pr[0][0, 0] == SignValue.MinValue && pr[0][1, 0] == SignValue.MinValue &&
                    pr[0][0, 1] == SignValue.MinValue && pr[0][1, 1] == SignValue.MinValue);
            }
        }

        [TestMethod]
        public void MultipleMap4()
        {
            for (int k = 0; k < 1000; k++)
            {
                SignValue[,] sv1 = new SignValue[1, 1], sv2 = new SignValue[1, 1], sv3 = new SignValue[1, 1];
                sv1[0, 0] = SignValue.MaxValue;
                sv3[0, 0] = new SignValue(SignValue.MaxValue.Value / 2);
                Processor p1 = new Processor(sv1, "1");
                Processor p2 = new Processor(sv2, "2");
                Processor p3 = new Processor(sv1, "3");
                Processor p4 = new Processor(sv2, "4");
                Processor p5 = new Processor(sv1, "5");
                Processor p6 = new Processor(sv2, "6");
                Processor p7 = new Processor(sv1, "7");
                Processor p8 = new Processor(sv2, "8");
                Processor p9 = new Processor(sv3, "9");
                ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
                pc[0, 0] = new ProcessorContainer(p1, p2);
                pc[1, 0] = new ProcessorContainer(p3, p4);
                pc[0, 1] = new ProcessorContainer(p5, p6);
                pc[1, 1] = new ProcessorContainer(p7, p8);
                Reflection reflection = new Reflection(pc);
                pc[1, 1].Add(p9);
                sv1 = new SignValue[2, 2];
                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                Processor[] pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(1, pr.Length);

                Assert.AreNotEqual(null, pr[0]);
                Assert.AreEqual(2, pr[0].Width);
                Assert.AreEqual(2, pr[0].Height);
                Assert.AreEqual("Tag", pr[0].Tag);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 1]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 1]);

                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);

                pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(16, pr.Length);
            }
        }

        [TestMethod]
        public void MultipleMap5()
        {
            for (int k = 0; k < 1000; k++)
            {
                SignValue[,] sv1 = new SignValue[1, 1], sv2 = new SignValue[1, 1], sv3 = new SignValue[1, 1];
                sv1[0, 0] = SignValue.MaxValue;
                sv3[0, 0] = new SignValue(SignValue.MaxValue.Value / 2);
                Processor p1 = new Processor(sv1, "1");
                Processor p2 = new Processor(sv2, "2");
                Processor p3 = new Processor(sv1, "3");
                Processor p4 = new Processor(sv2, "4");
                Processor p5 = new Processor(sv1, "5");
                Processor p6 = new Processor(sv2, "6");
                Processor p7 = new Processor(sv1, "7");
                Processor p8 = new Processor(sv2, "8");
                Processor p9 = new Processor(sv3, "9");
                ProcessorContainer[,] pc = new ProcessorContainer[2, 2];
                pc[0, 0] = new ProcessorContainer(p1, p2);
                pc[1, 0] = new ProcessorContainer(p3, p4);
                pc[0, 1] = new ProcessorContainer(p5, p6);
                pc[1, 1] = new ProcessorContainer(p7, p8, p9);
                Reflection reflection = new Reflection(pc);
                sv1 = new SignValue[2, 2];
                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 - 800000);
                Processor[] pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(1, pr.Length);

                Assert.AreNotEqual(null, pr[0]);
                Assert.AreEqual(2, pr[0].Width);
                Assert.AreEqual(2, pr[0].Height);
                Assert.AreEqual("Tag", pr[0].Tag);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][1, 0]);
                Assert.AreEqual(SignValue.MinValue, pr[0][0, 1]);
                Assert.AreEqual(new SignValue(SignValue.MaxValue.Value / 2), pr[0][1, 1]);

                sv1[0, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 0] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[0, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);
                sv1[1, 1] = new SignValue(SignValue.MaxValue.Value / 2 + 1);

                pr = reflection.Push(new Processor(sv1, "Tag")).ToArray();
                Assert.AreNotEqual(null, pr);
                Assert.AreEqual(8, pr.Length);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckSumTest0()
        {
            HashCreator.GetHash(null);
        }

        [TestMethod]
        public void CheckSumTest1()
        {
            const int hashSum = 45441;

            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "a")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "A")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "b")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "B")));

            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "a1")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "A2")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "b3")));
            Assert.AreEqual(hashSum, HashCreator.GetHash(new Processor(new[] { new SignValue(567) }, "B4")));
        }
    }
}