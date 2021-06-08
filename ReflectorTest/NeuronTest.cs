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

        /// <summary>
        /// Используется для теста, где используется одна и та же физическая карта <see cref="GetGlobalProcessorForNeuron"/> и <see cref="GetCorrectGlobalProcessorQuery"/>.
        /// </summary>
        static Processor _globalProcessor;

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

        static IEnumerable<Processor> GetProcessors1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return new Processor(sv, "a");
            sv[0, 0] = new SignValue(2222);
            yield return new Processor(sv, "b");
        }

        static IEnumerable<Processor> GetProcessors2()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return new Processor(sv, "q");
            yield return new Processor(sv, "w");
        }

        static IEnumerable<Processor> GetProcessors3()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return new Processor(sv, "k");
            yield return new Processor(sv, "k1");
        }

        static IEnumerable<Processor> GetProcessors4()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return new Processor(sv, "y");
            sv[0, 0] = new SignValue(7777);
            yield return new Processor(sv, "y1");
        }

        static IEnumerable<Processor> GetGlobalProcessorForNeuron()
        {
            if (_globalProcessor == null)
            {
                SignValue[,] sv = new SignValue[3, 3];
                sv[0, 0] = new SignValue(1111);
                sv[1, 0] = new SignValue(2222);
                sv[2, 0] = new SignValue(3333);
                sv[0, 1] = new SignValue(4444);
                sv[1, 1] = new SignValue(5555);
                sv[2, 1] = new SignValue(6666);
                sv[0, 2] = new SignValue(7777);
                sv[1, 2] = new SignValue(8888);
                sv[2, 2] = new SignValue(9999);
                _globalProcessor = new Processor(sv, "Global");
            }
            yield return _globalProcessor;
        }

        static IEnumerable<Processor> GetProcessors8Exception()
        {
            yield return new Processor(new SignValue[2, 2], "Exception8");
        }

        static IEnumerable<Processor> GetProcessors9Exception()
        {
            yield return new Processor(new SignValue[1, 2], "Exception9");
        }

        static IEnumerable<Processor> GetProcessors10Exception()
        {
            yield return new Processor(new SignValue[2, 1], "Exception10");
        }

        #region Results

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
            yield return new Processor(sv, "Y");
            yield return new Processor(sv, "I");
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
            sv[0, 0] = new SignValue(100005);
            yield return new Processor(sv, "t");
            sv[0, 0] = new SignValue(100006);
            yield return new Processor(sv, "U");
            sv[0, 0] = new SignValue(100007);
            yield return new Processor(sv, "h");
            sv[0, 0] = new SignValue(100008);
            yield return new Processor(sv, "w");
        }

        #endregion //Results

        #endregion //GetProcessors

        #region Correct

        static IEnumerable<(Processor, string)> GetCorrectQueries0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            for (int k = 0; k < 2; k++)
            {
                svq[0, 0] = new SignValue(999);
                yield return (new Processor(svq, "p1"), "1");
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
                yield return (new Processor(svq, "p5"), "Y");
                yield return (new Processor(svq, "p51"), "I");
                yield return (new Processor(svq, "p6"), "y");
                yield return (new Processor(svq, "p61"), "i");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "p52"), "Y");
                svq[0, 0] = new SignValue(5666);
                yield return (new Processor(svq, "p53"), "I");
                svq[0, 0] = new SignValue(5444);
                yield return (new Processor(svq, "p52"), "Y");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "p53"), "I");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "p52"), "y");
                svq[0, 0] = new SignValue(5666);
                yield return (new Processor(svq, "p53"), "i");
                svq[0, 0] = new SignValue(5444);
                yield return (new Processor(svq, "p52"), "y");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "p53"), "i");
                svq[0, 0] = new SignValue(7000);
                yield return (new Processor(svq, "p6"), "f");
                svq[0, 0] = new SignValue(13332);
                yield return (new Processor(svq, "p61"), "f");
                svq[0, 0] = new SignValue(13333);
                yield return (new Processor(svq, "p62"), "v");
                yield return (new Processor(svq, "p62"), "V");
                svq[0, 0] = new SignValue(9999);
                yield return (new Processor(svq, "p63"), "F");
                svq[0, 0] = new SignValue(19000);
                yield return (new Processor(svq, "p7"), "v");
                svq[0, 0] = new SignValue(19999);
                yield return (new Processor(svq, "p71"), "V");
                svq[0, 0] = new SignValue(25656);
                yield return (new Processor(svq, "p72"), "V");
                svq[0, 0] = new SignValue(25656);
                yield return (new Processor(svq, "p73"), "v");
                svq[0, 0] = new SignValue(25657);
                yield return (new Processor(svq, "p74"), "s");
                svq[0, 0] = new SignValue(25657);
                yield return (new Processor(svq, "p75"), "S");
                svq[0, 0] = new SignValue(90688);
                yield return (new Processor(svq, "p8"), "s");
                svq[0, 0] = new SignValue(32535);
                yield return (new Processor(svq, "p80"), "s");
                yield return (new Processor(svq, "p81"), "S");
                svq[0, 0] = new SignValue(35100);
                yield return (new Processor(svq, "p82"), "S");
                yield return (new Processor(svq, "p83"), "s");
                svq[0, 0] = new SignValue(35101);
                yield return (new Processor(svq, "p84"), "S");
                yield return (new Processor(svq, "p85"), "s");
                svq[0, 0] = new SignValue(63666);
                yield return (new Processor(svq, "p86"), "S");
                yield return (new Processor(svq, "p87"), "s");
                svq[0, 0] = new SignValue(63667);
                yield return (new Processor(svq, "p88"), "z");
                yield return (new Processor(svq, "p89"), "Z");
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1227);
            yield return (new Processor(svq, "0"), "a");
            svq[0, 0] = new SignValue(1449);
            yield return (new Processor(svq, "1"), "A");
            svq[0, 0] = new SignValue(2338);
            yield return (new Processor(svq, "2"), "b");
            svq[0, 0] = new SignValue(2005);
            yield return (new Processor(svq, "3"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1229);
            yield return (new Processor(svq, "q"), "A");
            svq[0, 0] = new SignValue(1451);
            yield return (new Processor(svq, "w"), "a");
            svq[0, 0] = new SignValue(2340);
            yield return (new Processor(svq, "e"), "B");
            svq[0, 0] = new SignValue(2007);
            yield return (new Processor(svq, "r"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries3()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1225);
            yield return (new Processor(svq, "t"), "a");
            svq[0, 0] = new SignValue(1447);
            yield return (new Processor(svq, "y"), "a");
            svq[0, 0] = new SignValue(2336);
            yield return (new Processor(svq, "u"), "b");
            svq[0, 0] = new SignValue(2003);
            yield return (new Processor(svq, "i"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries4()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1223);
            yield return (new Processor(svq, "o"), "A");
            svq[0, 0] = new SignValue(1445);
            yield return (new Processor(svq, "p"), "A");
            svq[0, 0] = new SignValue(2334);
            yield return (new Processor(svq, "s"), "B");
            svq[0, 0] = new SignValue(2001);
            yield return (new Processor(svq, "d"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries5()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1227);
            yield return (new Processor(svq, "0"), "a");
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(1449);
            yield return (new Processor(svq, "1"), "A");
            yield return (new Processor(svq, "b"), "A");
            svq[0, 0] = new SignValue(2338);
            yield return (new Processor(svq, "2"), "b");
            yield return (new Processor(svq, "c"), "b");
            svq[0, 0] = new SignValue(2005);
            yield return (new Processor(svq, "3"), "B");
            yield return (new Processor(svq, "d"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries5_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2338);
            yield return (new Processor(svq, "2"), "b");
            yield return (new Processor(svq, "c"), "b");
            svq[0, 0] = new SignValue(2005);
            yield return (new Processor(svq, "3"), "B");
            yield return (new Processor(svq, "d"), "B");
            svq[0, 0] = new SignValue(1227);
            yield return (new Processor(svq, "0"), "a");
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(1449);
            yield return (new Processor(svq, "1"), "A");
            yield return (new Processor(svq, "b"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries6()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1229);
            yield return (new Processor(svq, "q"), "A");
            yield return (new Processor(svq, "1"), "A");
            svq[0, 0] = new SignValue(1451);
            yield return (new Processor(svq, "w"), "a");
            yield return (new Processor(svq, "2"), "a");
            svq[0, 0] = new SignValue(2340);
            yield return (new Processor(svq, "e"), "B");
            yield return (new Processor(svq, "3"), "B");
            svq[0, 0] = new SignValue(2007);
            yield return (new Processor(svq, "r"), "b");
            yield return (new Processor(svq, "4"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries6_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2340);
            yield return (new Processor(svq, "e"), "B");
            yield return (new Processor(svq, "3"), "B");
            svq[0, 0] = new SignValue(2007);
            yield return (new Processor(svq, "r"), "b");
            yield return (new Processor(svq, "4"), "b");
            svq[0, 0] = new SignValue(1229);
            yield return (new Processor(svq, "q"), "A");
            yield return (new Processor(svq, "1"), "A");
            svq[0, 0] = new SignValue(1451);
            yield return (new Processor(svq, "w"), "a");
            yield return (new Processor(svq, "2"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries7()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1225);
            yield return (new Processor(svq, "t"), "a");
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(1447);
            yield return (new Processor(svq, "y"), "a");
            yield return (new Processor(svq, "b"), "a");
            svq[0, 0] = new SignValue(2336);
            yield return (new Processor(svq, "u"), "b");
            yield return (new Processor(svq, "c"), "b");
            svq[0, 0] = new SignValue(2003);
            yield return (new Processor(svq, "i"), "b");
            yield return (new Processor(svq, "d"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries7_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2336);
            yield return (new Processor(svq, "u"), "b");
            yield return (new Processor(svq, "c"), "b");
            svq[0, 0] = new SignValue(2003);
            yield return (new Processor(svq, "i"), "b");
            yield return (new Processor(svq, "d"), "b");
            svq[0, 0] = new SignValue(1225);
            yield return (new Processor(svq, "t"), "a");
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(1447);
            yield return (new Processor(svq, "y"), "a");
            yield return (new Processor(svq, "b"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1223);
            yield return (new Processor(svq, "o"), "A");
            yield return (new Processor(svq, "4"), "A");
            svq[0, 0] = new SignValue(1445);
            yield return (new Processor(svq, "p"), "A");
            yield return (new Processor(svq, "5"), "A");
            svq[0, 0] = new SignValue(2334);
            yield return (new Processor(svq, "s"), "B");
            yield return (new Processor(svq, "6"), "B");
            svq[0, 0] = new SignValue(2001);
            yield return (new Processor(svq, "d"), "B");
            yield return (new Processor(svq, "7"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2334);
            yield return (new Processor(svq, "s"), "B");
            yield return (new Processor(svq, "6"), "B");
            svq[0, 0] = new SignValue(2001);
            yield return (new Processor(svq, "d"), "B");
            yield return (new Processor(svq, "7"), "B");
            svq[0, 0] = new SignValue(1223);
            yield return (new Processor(svq, "o"), "A");
            yield return (new Processor(svq, "4"), "A");
            svq[0, 0] = new SignValue(1445);
            yield return (new Processor(svq, "p"), "A");
            yield return (new Processor(svq, "5"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8_2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "B"), "B");
            yield return (new Processor(svq, "B"), "B");
            svq[0, 0] = new SignValue(2008);
            yield return (new Processor(svq, "B"), "B");
            yield return (new Processor(svq, "B"), "B");
            svq[0, 0] = new SignValue(1230);
            yield return (new Processor(svq, "A"), "A");
            yield return (new Processor(svq, "A"), "A");
            svq[0, 0] = new SignValue(1452);
            yield return (new Processor(svq, "A"), "A");
            yield return (new Processor(svq, "A"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "A"), "A");
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "B"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_1_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "A");
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "a");
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "B"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_3()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "A"), "A");
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_0()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "b");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "B"), "B");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "A"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_1_1()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "B");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_2()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "B"), "B");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_3()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2341);
            yield return (new Processor(svq, "b"), "b");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "A"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries11()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(2351);
            svq[0, 1] = new SignValue(1239);
            yield return (new Processor(svq, "fg"), "ab");
            svq[0, 0] = new SignValue(1238);
            svq[0, 1] = new SignValue(1238);
            yield return (new Processor(svq, "s"), "A");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries12()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(2361);
            svq[0, 1] = new SignValue(1349);
            yield return (new Processor(svq, "ab"), "AB");
            svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1248);
            yield return (new Processor(svq, "b"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries13()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[0, 0] = new SignValue(1258);
            yield return (new Processor(svq, "s"), "A");
            svq[0, 0] = new SignValue(2371);
            svq[1, 0] = new SignValue(1278);
            yield return (new Processor(svq, "fg"), "ab");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries14()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[0, 0] = new SignValue(1328);
            yield return (new Processor(svq, "b"), "B");
            svq[0, 0] = new SignValue(2441);
            svq[1, 0] = new SignValue(1320);
            yield return (new Processor(svq, "ab"), "AB");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries15()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "fg"), "jkl");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "s"), "A");
            svq[0, 0] = new SignValue(2446);
            yield return (new Processor(svq, "b"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries16()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2445);
            yield return (new Processor(svq, "b"), "B");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "b"), "a");
            svq[0, 0] = new SignValue(2445);
            yield return (new Processor(svq, "ab"), "jkl");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries17()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "fg"), "JKL");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "s"), "A");
            svq[0, 0] = new SignValue(2446);
            yield return (new Processor(svq, "b"), "B");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries18()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2445);
            yield return (new Processor(svq, "b"), "B");
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "b"), "a");
            svq[0, 0] = new SignValue(2445);
            yield return (new Processor(svq, "ab"), "JKL");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries19()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[1, 0] = new SignValue(2222);
            svq[0, 0] = new SignValue(1228);
            yield return (new Processor(svq, "b"), "AB");
            svq[0, 0] = new SignValue(1335);
            svq[1, 0] = new SignValue(3999);
            yield return (new Processor(svq, "b"), "ba");
            yield return (new Processor(svq, "ab"), "JKL");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries20()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[0, 0] = new SignValue(1138);
            svq[1, 0] = new SignValue(5229);
            yield return (new Processor(svq, "abc"), "ab");
            svq[0, 0] = new SignValue(1228);
            svq[1, 0] = new SignValue(5329);
            yield return (new Processor(svq, "b"), "BA");
            svq[0, 0] = new SignValue(2341);
            svq[1, 0] = new SignValue(1000);
            yield return (new Processor(svq, "ab"), "JKL");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries21()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(2341);
            svq[0, 1] = new SignValue(1237);
            yield return (new Processor(svq, "ab"), "JKL");
            svq[0, 0] = new SignValue(1500);
            svq[0, 1] = new SignValue(2671);
            yield return (new Processor(svq, "b"), "AB");
            svq[0, 0] = new SignValue(1129);
            svq[0, 1] = new SignValue(5641);
            yield return (new Processor(svq, "b"), "ba");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries22()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[0, 0] = new SignValue(1009);
            svq[1, 0] = new SignValue(3008);
            yield return (new Processor(svq, "ab"), "JKL");
            svq[0, 0] = new SignValue(1001);
            svq[1, 0] = new SignValue(2002);
            yield return (new Processor(svq, "b"), "ba");
            svq[0, 0] = new SignValue(9341);
            svq[1, 0] = new SignValue(91);
            yield return (new Processor(svq, "b"), "AB");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries23()
        {
            SignValue[,] svq = new SignValue[2, 1];
            svq[0, 0] = new SignValue(1256);
            svq[1, 0] = new SignValue(2356);
            yield return (new Processor(svq, "b"), "AB");
            svq[0, 0] = new SignValue(1116);
            svq[1, 0] = new SignValue(2226);
            yield return (new Processor(svq, "ab"), "JKL");
            svq[0, 0] = new SignValue(1156);
            svq[1, 0] = new SignValue(2156);
            yield return (new Processor(svq, "b"), "ba");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries24()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(801);
            svq[0, 1] = new SignValue(2411);
            yield return (new Processor(svq, "a"), "ba");
            svq[0, 0] = new SignValue(701);
            svq[0, 1] = new SignValue(2968);
            yield return (new Processor(svq, "ab"), "JKL");
            svq[0, 0] = new SignValue(1205);
            svq[0, 1] = new SignValue(4164);
            yield return (new Processor(svq, "a"), "AB");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries25()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "j"), "q");
            yield return (new Processor(sv, "k"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries26()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "o"), "q");
            yield return (new Processor(sv, "p"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries27()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "g"), "q");
            yield return (new Processor(sv, "h"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries28()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "i1"), "k");
            yield return (new Processor(sv, "i1"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries29()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "L"), "k");
            yield return (new Processor(sv, "A"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries30()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(3333);
            yield return (new Processor(sv, "L"), "k");
            yield return (new Processor(sv, "A"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries31()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6464);
            yield return (new Processor(sv, "L"), "k");
            yield return (new Processor(sv, "A"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries32()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8989);
            yield return (new Processor(sv, "t"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries33()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "t"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries34()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "t"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries35()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "L"), "k");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "A"), "k");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "S"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries36()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "A"), "k");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "S"), "k");
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "L"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries37()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "S"), "k");
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "L"), "k");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "A"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries38()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5556);
            yield return (new Processor(sv, "L"), "k");
            sv[0, 0] = new SignValue(6667);
            yield return (new Processor(sv, "A"), "k");
            sv[0, 0] = new SignValue(2223);
            yield return (new Processor(sv, "S"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries39()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6669);
            yield return (new Processor(sv, "A"), "k");
            sv[0, 0] = new SignValue(2220);
            yield return (new Processor(sv, "S"), "k");
            sv[0, 0] = new SignValue(5551);
            yield return (new Processor(sv, "L"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries40()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2226);
            yield return (new Processor(sv, "S"), "k");
            sv[0, 0] = new SignValue(5554);
            yield return (new Processor(sv, "L"), "k");
            sv[0, 0] = new SignValue(6663);
            yield return (new Processor(sv, "A"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries41()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "y");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries42()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries43()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries44()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries45()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries46()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries47()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "qw");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4545);
            yield return (new Processor(sv, "f"), "q");
            sv[0, 0] = new SignValue(6657);
            yield return (new Processor(sv, "v"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries48()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
            sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries49()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5554);
            yield return (new Processor(sv, "u"), "q");
            sv[0, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries50()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            sv[2, 0] = new SignValue(4545);
            sv[3, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries51()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(4444);
            sv[3, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries52()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(5554);
            sv[3, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries53()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            sv[2, 0] = new SignValue(4545);
            sv[3, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries54()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(4444);
            sv[3, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries55()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(5554);
            sv[3, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries56()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            sv[2, 0] = new SignValue(4545);
            sv[3, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries57()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(4444);
            sv[3, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries58()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(5554);
            sv[3, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries59()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            sv[2, 0] = new SignValue(4545);
            sv[3, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries60()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(4444);
            sv[3, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries61()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(5554);
            sv[3, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries62()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4545);
            sv[1, 0] = new SignValue(6657);
            sv[2, 0] = new SignValue(4545);
            sv[3, 0] = new SignValue(6657);
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries63()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(4444);
            sv[3, 0] = new SignValue(6666);
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries64()
        {
            SignValue[,] sv = new SignValue[4, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(5554);
            sv[3, 0] = new SignValue(5553);
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "w");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "qw");
            yield return (new Processor(sv, "u"), "q");
            yield return (new Processor(sv, "u"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries65()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries66()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "K");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries67()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "u"), "k");
            yield return (new Processor(sv, "u"), "k");
            yield return (new Processor(sv, "u"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries68()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "p"), "k");
            yield return (new Processor(sv, "k"), "k");
            yield return (new Processor(sv, "l"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries69()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries70()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "K");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "k");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries71()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "p"), "k");
            yield return (new Processor(sv, "k"), "K");
            yield return (new Processor(sv, "l"), "k");
            yield return (new Processor(sv, "l"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries72()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "k1");
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries73()
        {
            SignValue[,] sv = new SignValue[1, 3];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "u"), "k");
            yield return (new Processor(sv, "u"), "k");
            yield return (new Processor(sv, "u"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries74()
        {
            SignValue[,] sv = new SignValue[1, 3];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            sv[0, 2] = new SignValue(5555);
            yield return (new Processor(sv, "l"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries75()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries76()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries77()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(4444);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries78()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(5555);
            sv[2, 0] = new SignValue(5555);
            yield return (new Processor(sv, "p"), "k");
            yield return (new Processor(sv, "k"), "K");
            yield return (new Processor(sv, "l"), "k");
            yield return (new Processor(sv, "l"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries79()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "k1");
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries80()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "k1");
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries81()
        {
            SignValue[,] sv = new SignValue[3, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            sv[2, 0] = new SignValue(6666);
            yield return (new Processor(sv, "3"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries82()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "k");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "k");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "K");
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "c"), "k1");
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "c"), "K1");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries83()
        {
            SignValue[,] sv = new SignValue[1, 5];
            sv[0, 0] = new SignValue(4444);
            sv[0, 1] = new SignValue(6666);
            sv[0, 2] = new SignValue(7777);
            sv[0, 3] = new SignValue(8888);
            sv[0, 4] = new SignValue(9999);
            yield return (new Processor(sv, "c"), "K");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries84()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries85()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "K1");
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7878);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries86()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "K");
            yield return (new Processor(sv, "2"), "K");
            yield return (new Processor(sv, "3"), "k");
            yield return (new Processor(sv, "l"), "a");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7879);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries87()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(7777);
            yield return (new Processor(sv, "1"), "K");
            yield return (new Processor(sv, "2"), "K");
            yield return (new Processor(sv, "3"), "k");
            yield return (new Processor(sv, "l"), "a");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7880);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries88()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(8888);
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7881);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries89()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(4444);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "K1");
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7882);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries90()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "l"), "K1");
            yield return (new Processor(sv, "1"), "k");
            yield return (new Processor(sv, "2"), "k");
            yield return (new Processor(sv, "3"), "k");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7883);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries91()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "0"), "Q");
            yield return (new Processor(sv, "1"), "W");
            yield return (new Processor(sv, "2"), "q");
            yield return (new Processor(sv, "3"), "w");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7884);
            yield return (new Processor(sv, "4"), "k");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries92()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "0"), "Q");
            yield return (new Processor(sv, "1"), "W");
            yield return (new Processor(sv, "2"), "q");
            yield return (new Processor(sv, "3"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries93()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "0"), "QW");
            yield return (new Processor(sv, "1"), "qw");
            yield return (new Processor(sv, "2"), "qW");
            yield return (new Processor(sv, "3"), "Qw");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries94()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "O"), "a");
            yield return (new Processor(sv, "0"), "Q");
            yield return (new Processor(sv, "1"), "W");
            yield return (new Processor(sv, "2"), "q");
            yield return (new Processor(sv, "3"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries95()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "0"), "Q");
            yield return (new Processor(sv, "1"), "W");
            yield return (new Processor(sv, "2"), "q");
            yield return (new Processor(sv, "3"), "w");
            yield return (new Processor(sv, "O"), "b");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries96()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries97()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "qqQWww");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "y"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries98()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(3333);
            yield return (new Processor(sv, "n"), "qqQWww");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "y"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries99()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "qqQWww");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries100()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "qqQWww");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries101()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries102()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries103()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries104()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "qqQWww");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries96_1()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries97_1()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "WwwqqQ");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "y"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries98_1()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(3333);
            yield return (new Processor(sv, "n"), "WwwqqQ");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "y"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries99_1()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "WwwqqQ");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries100_1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "WwwqqQ");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries101_1()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries102_1()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries103_1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries104_1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "WwwqqQ");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries105()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "s"), "q");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "d"), "w");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries106()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "s"), "y");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "d"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries107()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(7777);
            yield return (new Processor(sv, "s"), "y");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "d"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries108()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "s"), "y1");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "d"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries109()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "s"), "y");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "d"), "y1");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries110()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries111()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "u"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries112()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "u"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries113()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries114()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "u"), "y");
            yield return (new Processor(sv, "u"), "y");
            yield return (new Processor(sv, "u"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries115()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "p"), "y");
            yield return (new Processor(sv, "k"), "y");
            yield return (new Processor(sv, "l"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries116()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries117()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "Y");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "y");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries118()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "p"), "y");
            yield return (new Processor(sv, "k"), "Y");
            yield return (new Processor(sv, "l"), "y");
            yield return (new Processor(sv, "l"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries119()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "k1");
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries120()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "y");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "y");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "Y");
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "c"), "k1");
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "c"), "Y1");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries121()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries122()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "Y1");
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries123()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "1"), "Y");
            yield return (new Processor(sv, "2"), "Y");
            yield return (new Processor(sv, "3"), "y");
            yield return (new Processor(sv, "l"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries124()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(7777);
            yield return (new Processor(sv, "1"), "Y");
            yield return (new Processor(sv, "2"), "Y");
            yield return (new Processor(sv, "3"), "y");
            yield return (new Processor(sv, "l"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries125()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(8888);
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries126()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(4444);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "Y1");
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries127()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "l"), "Y1");
            yield return (new Processor(sv, "1"), "y");
            yield return (new Processor(sv, "2"), "y");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries128()
        {
            SignValue[,] sv = new SignValue[1, 5];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            sv[0, 2] = new SignValue(7777);
            sv[0, 3] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "Y1");
            yield return (new Processor(sv, "3"), "y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries129()
        {
            SignValue[,] sv = new SignValue[1, 5];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            sv[0, 2] = new SignValue(7777);
            sv[0, 3] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "Y1");
            yield return (new Processor(sv, "3"), "y");
            yield return (new Processor(sv, "3"), "y");
            yield return (new Processor(sv, "3"), "a");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries130()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "Y");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "y"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries131()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(3333);
            yield return (new Processor(sv, "n"), "Y");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "y"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries132()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "Y");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries133()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "Y");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries134()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "h"), "Y");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries135()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "h"), "Y");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries136()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "h"), "Y");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(7777);
            sv[0, 1] = new SignValue(7777);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries137()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries138()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "Y");
        }

        static IEnumerable<(Processor, string)> GetCorrectGlobalProcessorQuery()
        {
            if (_globalProcessor == null)
                throw new Exception($"Сначала необходимо вызвать метод {nameof(GetGlobalProcessorForNeuron)}.");
            yield return (_globalProcessor, "A");
        }

        #endregion //Correct

        #region Incorrect

        static IEnumerable<(Processor, string)> GetIncorrectQueries0()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "c");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries1()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries2()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries3()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries4()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "c"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "d"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries5()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries6()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "a");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries7()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "b");
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries8()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "a"), "c");
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries9()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "a"), "d");
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries10()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "c"), "c");
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries11()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries12()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2245);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(999);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries13()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries14()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries15()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries16()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "a"), "A");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries17()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries18()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1300);
            yield return (new Processor(sv, "a"), "a");
            sv[0, 0] = new SignValue(2265);
            yield return (new Processor(sv, "b"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries19()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries20()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries21()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "B");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries22()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "A");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries23()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries24()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "A");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries25()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "B");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries26()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "A");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "A");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries27()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "F"), "f");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "22"), "2");
            svq[0, 0] = new SignValue(3444);
            yield return (new Processor(svq, "3"), "3");
            svq[0, 0] = new SignValue(4555);
            yield return (new Processor(svq, "444"), "4");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries28()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries29()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries30()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "b");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries31()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries32()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries33()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries34()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries35()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries36()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2222);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries37()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2222);
            yield return (new Processor(svq, "p"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries38()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1111);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries39()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1111);
            yield return (new Processor(svq, "p"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries41()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries42()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "b"), "b");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "a"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries43()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "d");
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "a"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries44()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "b"), "c");
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "a"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries45()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries46()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "c"), "c");
            sv[0, 0] = new SignValue(1000);
            yield return (new Processor(sv, "d"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries47()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p6"), "b");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p7"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries48()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "c");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries49()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "d");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries50()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "c");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries51()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "d");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries52()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2245);
            yield return (new Processor(sv, "d"), "a");
            sv[0, 0] = new SignValue(999);
            yield return (new Processor(sv, "c"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries53()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "a");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries54()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "a");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries55()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "b");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries56()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "b");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries57()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "b");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries58()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1300);
            yield return (new Processor(sv, "c"), "a");
            sv[0, 0] = new SignValue(2265);
            yield return (new Processor(sv, "d"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries59()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "b");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries60()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries61()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "B");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries62()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "A");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries63()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "b");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries64()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "a");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "A");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries65()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "B");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries66()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "A");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "A");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries67()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2245);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(999);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries68()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries69()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries70()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries71()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries72()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries73()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1300);
            yield return (new Processor(sv, "c"), "c");
            sv[0, 0] = new SignValue(2265);
            yield return (new Processor(sv, "d"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries74()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries75()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries76()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "D");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries77()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "C");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries78()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "D");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries79()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries80()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "D");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "D");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries81()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "C");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries82()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2245);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(999);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries83()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries84()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries85()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries86()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2000);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(3000);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries87()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(978);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(900);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries88()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(1300);
            yield return (new Processor(sv, "c"), "c");
            sv[0, 0] = new SignValue(2265);
            yield return (new Processor(sv, "d"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries89()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries90()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries91()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "D");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries92()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "C");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries93()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "d");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "D");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries94()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "c");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries95()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "D");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "D");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries96()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(2222);
            yield return (new Processor(sv, "d"), "C");
            sv[0, 0] = new SignValue(1111);
            yield return (new Processor(sv, "c"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries98()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "a");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries99()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "b");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries100()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "c");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries101()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "e"), "d");
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p"), "b");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries102()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "c");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries103()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "d");
            svq[0, 0] = new SignValue(1222);
            yield return (new Processor(svq, "p6"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries104()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "ab");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries105()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "p7"), "aaaabbbbb");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries106()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "ab"), "AB");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries107()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "BA"), "cdABvdgd");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries108()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "cdABvdgd"), "cdABvdgd");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries109()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "ab"), "ABC");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries110()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "cdgd"), "cdvdgd");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries111()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2333);
            yield return (new Processor(svq, "cdvdgd"), "cdvdgd");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries112()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries113()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries114()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "Q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries115()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries116()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(8888);
            yield return (new Processor(svq, "Q"), "Q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries117()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9999);
            yield return (new Processor(svq, "W"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries118()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1114);
            yield return (new Processor(svq, "q"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries119()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2225);
            yield return (new Processor(svq, "W"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries120()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1111);
            yield return (new Processor(svq, "Q"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries121()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2222);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries122()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1112);
            yield return (new Processor(svq, "q"), "q");
            yield return (new Processor(svq, "w"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries123()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2223);
            yield return (new Processor(svq, "W"), "w");
            yield return (new Processor(svq, "Q"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries124()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(100);
            yield return (new Processor(svq, "q"), "Q");
            svq[0, 0] = new SignValue(9957);
            yield return (new Processor(svq, "w"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries125()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9956);
            yield return (new Processor(svq, "w"), "w");
            svq[0, 0] = new SignValue(101);
            yield return (new Processor(svq, "q"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries126()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9947);
            yield return (new Processor(svq, "w"), "q");
            svq[0, 0] = new SignValue(109);
            yield return (new Processor(svq, "q"), "Q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries127()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(107);
            yield return (new Processor(svq, "q"), "W");
            svq[0, 0] = new SignValue(9916);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries128()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9927);
            yield return (new Processor(svq, "W"), "A");
            svq[0, 0] = new SignValue(110);
            yield return (new Processor(svq, "Q"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries129()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9958);
            yield return (new Processor(svq, "W"), "b");
            svq[0, 0] = new SignValue(102);
            yield return (new Processor(svq, "Q"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries130()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9960);
            yield return (new Processor(svq, "w"), "c");
            svq[0, 0] = new SignValue(103);
            yield return (new Processor(svq, "q"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries131()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(104);
            yield return (new Processor(svq, "q"), "D");
            svq[0, 0] = new SignValue(9986);
            yield return (new Processor(svq, "w"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries132()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1117);
            yield return (new Processor(svq, "q"), "o");
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries133()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2123);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries134()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1166);
            yield return (new Processor(svq, "q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries135()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2189);
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries136()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1117);
            yield return (new Processor(svq, "Q"), "o");
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries137()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2123);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries138()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1166);
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries139()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2189);
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries140()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(5555);
            svq[0, 1] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries141()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(5555);
            svq[0, 1] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries142()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "Q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries143()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries144()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries145()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries146()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries147()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries148()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "q");
            yield return (new Processor(svq, "w"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries149()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "w");
            yield return (new Processor(svq, "Q"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries150()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "Q");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries151()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries152()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "q");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "Q");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries153()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "W");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries154()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "A");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries155()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "b");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries156()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "c");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries157()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "D");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries158()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "o");
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries159()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries160()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries161()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries162()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "o");
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries163()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries164()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "Q"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries165()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries166()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries167()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries168()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "K5");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries169()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries170()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(8888);
            yield return (new Processor(svq, "K"), "K2");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries171()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9999);
            yield return (new Processor(svq, "W"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries172()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1114);
            yield return (new Processor(svq, "k"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries173()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2225);
            yield return (new Processor(svq, "W"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries174()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1111);
            yield return (new Processor(svq, "K"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries175()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2222);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries176()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1112);
            yield return (new Processor(svq, "k"), "k1");
            yield return (new Processor(svq, "w"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries177()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2223);
            yield return (new Processor(svq, "W"), "w");
            yield return (new Processor(svq, "K"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries178()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(100);
            yield return (new Processor(svq, "k"), "K1");
            svq[0, 0] = new SignValue(9957);
            yield return (new Processor(svq, "w"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries179()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9956);
            yield return (new Processor(svq, "w"), "w");
            svq[0, 0] = new SignValue(101);
            yield return (new Processor(svq, "k"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries180()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9947);
            yield return (new Processor(svq, "w"), "k1");
            svq[0, 0] = new SignValue(109);
            yield return (new Processor(svq, "k"), "K1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries181()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(107);
            yield return (new Processor(svq, "k"), "W");
            svq[0, 0] = new SignValue(9916);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries182()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9927);
            yield return (new Processor(svq, "W"), "A");
            svq[0, 0] = new SignValue(110);
            yield return (new Processor(svq, "K"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries189()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9958);
            yield return (new Processor(svq, "W"), "b");
            svq[0, 0] = new SignValue(102);
            yield return (new Processor(svq, "K"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries190()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(9960);
            yield return (new Processor(svq, "w"), "c");
            svq[0, 0] = new SignValue(103);
            yield return (new Processor(svq, "k"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries191()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(104);
            yield return (new Processor(svq, "k"), "D");
            svq[0, 0] = new SignValue(9986);
            yield return (new Processor(svq, "w"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries192()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1117);
            yield return (new Processor(svq, "k"), "o");
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries193()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2123);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries194()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1166);
            yield return (new Processor(svq, "k"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries195()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2189);
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries196()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1117);
            yield return (new Processor(svq, "K"), "o");
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries197()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2123);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries198()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(1166);
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries199()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(2189);
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries200()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(5555);
            svq[0, 1] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries201()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(5555);
            svq[0, 1] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries202()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "K1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries203()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries204()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries205()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries206()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries207()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries208()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "k1");
            yield return (new Processor(svq, "w"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries209()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "w");
            yield return (new Processor(svq, "K"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries210()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "K1");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "k1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries211()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "W");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries212()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "k1");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "K1");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries213()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "W");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "w");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries214()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "A");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "a");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries215()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "b");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "B");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries216()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "c");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "C");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries217()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "D");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "d");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries218()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "o");
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries219()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries220()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "k"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries221()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "w"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries222()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "o");
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries223()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries224()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "K"), "o");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries225()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries226()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(7777);
            yield return (new Processor(svq, "W"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries227()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "k");
            svq[0, 0] = new SignValue(7777);
            yield return (new Processor(svq, "q"), "p");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries228()
        {
            SignValue[,] svq = new SignValue[1, 1];
            svq[0, 0] = new SignValue(7777);
            yield return (new Processor(svq, "q"), "p");
            svq[0, 0] = new SignValue(5555);
            yield return (new Processor(svq, "W"), "k");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries229()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "Y1");
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "c"), "y1");
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "k1");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "K1");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "K1");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "y1");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "Y1");
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "c"), "k1");
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "c"), "Y1");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "y1");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries230()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(4444);
            yield return (new Processor(sv, "a"), "Y1");
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "y1");
            sv[0, 0] = new SignValue(4445);
            yield return (new Processor(sv, "a"), "k1");
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "b"), "K1");
            sv[0, 0] = new SignValue(6667);
            yield return (new Processor(sv, "b"), "K1");
            sv[0, 0] = new SignValue(7778);
            yield return (new Processor(sv, "c"), "y1");
            sv[0, 0] = new SignValue(7779);
            yield return (new Processor(sv, "c"), "Y1");
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "c"), "k1");
            sv[0, 0] = new SignValue(9998);
            yield return (new Processor(sv, "c"), "Y1");
            sv[0, 0] = new SignValue(7780);
            yield return (new Processor(sv, "c"), "y1");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries231()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "a"), "a");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries232()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "b"), "b");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries233()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "c"), "c");
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries234()
        {
            SignValue[,] svq = new SignValue[1, 2];
            svq[0, 0] = new SignValue(5555);
            svq[0, 1] = new SignValue(7777);
            yield return (new Processor(svq, "K"), "i");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries235()
        {
            SignValue[,] sv = new SignValue[1, 5];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            sv[0, 2] = new SignValue(7777);
            sv[0, 3] = new SignValue(6666);
            yield return (new Processor(sv, "l"), "B1");
            yield return (new Processor(sv, "3"), "n");
            yield return (new Processor(sv, "3"), "m");
            yield return (new Processor(sv, "3"), "a");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries236()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(2222);
            yield return (new Processor(sv, "n"), "F");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(8888);
            yield return (new Processor(sv, "y"), "F");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries237()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(8888);
            sv[0, 1] = new SignValue(3333);
            yield return (new Processor(sv, "n"), "G");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(9999);
            yield return (new Processor(sv, "y"), "H");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries238()
        {
            SignValue[,] sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "J");
            sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "J");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries239()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(6666);
            yield return (new Processor(sv, "h"), "K");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "K");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries240()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "h"), "K1");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(6666);
            sv[0, 1] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "K1");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries241()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(7777);
            yield return (new Processor(sv, "h"), "Q");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(5555);
            sv[0, 1] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "q");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries242()
        {
            SignValue[,] sv = new SignValue[1, 1];
            sv[0, 0] = new SignValue(5555);
            yield return (new Processor(sv, "h"), "w");
            sv = new SignValue[1, 2];
            sv[0, 0] = new SignValue(7777);
            sv[0, 1] = new SignValue(7777);
            yield return (new Processor(sv, "m"), "W");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries243()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(5555);
            sv[1, 0] = new SignValue(5555);
            yield return (new Processor(sv, "m"), "A");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries244()
        {
            SignValue[,] sv = new SignValue[2, 1];
            sv[0, 0] = new SignValue(6666);
            sv[1, 0] = new SignValue(6666);
            yield return (new Processor(sv, "m"), "a");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries245Exception()
        {
            yield return (new Processor(new SignValue[1, 1], "q"), "a");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries246Exception()
        {
            yield return (new Processor(new SignValue[2, 1], "w"), "b");
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries247Exception()
        {
            yield return (new Processor(new SignValue[1, 2], "e"), "c");
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

        #endregion //SelfTests

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
            //NeuronTestSub(GetProcessors0(), GetProcessors0(), GetCorrectQueries2(), CorrectQueries2Answer());
            //GetCorrectQueries3
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