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

        static IEnumerable<Processor> GetProcessors0
        {
            get
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
        }

        static IEnumerable<Processor> GetProcessors1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return new Processor(sv, "a");
                sv[0, 0] = new SignValue(2222);
                yield return new Processor(sv, "b");
            }
        }

        static IEnumerable<Processor> GetProcessors2
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "q");
                yield return new Processor(sv, "w");
            }
        }

        static IEnumerable<Processor> GetProcessors3
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                yield return new Processor(sv, "k1");
            }
        }

        static IEnumerable<Processor> GetProcessors4
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "y");
                sv[0, 0] = new SignValue(7777);
                yield return new Processor(sv, "y1");
            }
        }

        static IEnumerable<Processor> GetGlobalProcessorForNeuron
        {
            get
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
        }

        static IEnumerable<Processor> GetProcessors8Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 2], "Exception8");
            }
        }

        static IEnumerable<Processor> GetProcessors9Exception
        {
            get
            {
                yield return new Processor(new SignValue[1, 2], "Exception9");
            }
        }

        static IEnumerable<Processor> GetProcessors10Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 1], "Exception10");
            }
        }

        #region Results

        static IEnumerable<Processor> GetProcessors0Result
        {
            get
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
        }

        #endregion //Results

        #endregion //GetProcessors

        #region Correct

        static IEnumerable<(Processor, string)> GetCorrectQueries0
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries1
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries2
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries3
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries4
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries5
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries5_1
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries6
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries6_1
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries7
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries7_1
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8_1
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries8_2
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_0
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "a");
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_1
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "A"), "A");
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "B"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_1_1
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "A");
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_2
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "a");
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "B"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries9_3
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "A"), "A");
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_0
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "b");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_1
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "B"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "A"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_1_1
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_2
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "B"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries10_3
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2341);
                yield return (new Processor(svq, "b"), "b");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "A"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries11
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(2351);
                svq[0, 1] = new SignValue(1239);
                yield return (new Processor(svq, "fg"), "ab");
                svq[0, 0] = new SignValue(1238);
                svq[0, 1] = new SignValue(1238);
                yield return (new Processor(svq, "s"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries12
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(2361);
                svq[0, 1] = new SignValue(1349);
                yield return (new Processor(svq, "ab"), "AB");
                svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1248);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries13
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[0, 0] = new SignValue(1258);
                yield return (new Processor(svq, "s"), "A");
                svq[0, 0] = new SignValue(2371);
                svq[1, 0] = new SignValue(1278);
                yield return (new Processor(svq, "fg"), "ab");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries14
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[0, 0] = new SignValue(1328);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(2441);
                svq[1, 0] = new SignValue(1320);
                yield return (new Processor(svq, "ab"), "AB");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries14Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2441);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(1320);
                yield return new Processor(svq, "A");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries15
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "s"), "A");
                svq[0, 0] = new SignValue(2446);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries16
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "b"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries17
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "s"), "A");
                svq[0, 0] = new SignValue(2446);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries18
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "b"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries19
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[1, 0] = new SignValue(2222);
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "b"), "AB");
                svq[0, 0] = new SignValue(1335);
                svq[1, 0] = new SignValue(3999);
                yield return (new Processor(svq, "b"), "ba");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries19Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(1335);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(2222);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(3999);
                yield return new Processor(svq, "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries20
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[0, 0] = new SignValue(1138);
                svq[1, 0] = new SignValue(5229);
                yield return (new Processor(svq, "abc"), "ab");
                svq[0, 0] = new SignValue(1228);
                svq[1, 0] = new SignValue(5329);
                yield return (new Processor(svq, "b"), "BA");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries20Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1138);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(1228);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(5229);
                yield return new Processor(svq, "b");
                svq[0, 0] = new SignValue(5329);
                yield return new Processor(svq, "B");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries21
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(1500);
                svq[0, 1] = new SignValue(2671);
                yield return (new Processor(svq, "b"), "AB");
                svq[0, 0] = new SignValue(1129);
                svq[0, 1] = new SignValue(5641);
                yield return (new Processor(svq, "b"), "ba");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries21Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1500);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(1129);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(2671);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(5641);
                yield return new Processor(svq, "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries22
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[0, 0] = new SignValue(1001);
                svq[1, 0] = new SignValue(2002);
                yield return (new Processor(svq, "b"), "ba");
                svq[0, 0] = new SignValue(9341);
                svq[1, 0] = new SignValue(91);
                yield return (new Processor(svq, "b"), "AB");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries22Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(91);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(1001);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(9341);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(2002);
                yield return new Processor(svq, "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries23
        {
            get
            {
                SignValue[,] svq = new SignValue[2, 1];
                svq[0, 0] = new SignValue(1256);
                svq[1, 0] = new SignValue(2356);
                yield return (new Processor(svq, "b"), "AB");
                svq[0, 0] = new SignValue(1156);
                svq[1, 0] = new SignValue(2156);
                yield return (new Processor(svq, "b"), "ba");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries23Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1256);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(1156);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(2356);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(2156);
                yield return new Processor(svq, "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries24
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(801);
                svq[0, 1] = new SignValue(2411);
                yield return (new Processor(svq, "a"), "ba");
                svq[0, 0] = new SignValue(1205);
                svq[0, 1] = new SignValue(4164);
                yield return (new Processor(svq, "a"), "AB");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries24Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1205);
                yield return new Processor(svq, "A");
                svq[0, 0] = new SignValue(801);
                yield return new Processor(svq, "a");
                svq[0, 0] = new SignValue(4164);
                yield return new Processor(svq, "B");
                svq[0, 0] = new SignValue(2411);
                yield return new Processor(svq, "b");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries25
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "j"), "q");
                yield return (new Processor(sv, "k"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries26
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "o"), "q");
                yield return (new Processor(sv, "p"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries27
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "g"), "q");
                yield return (new Processor(sv, "h"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries28
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "i1"), "k");
                yield return (new Processor(sv, "i1"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries29
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries30
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries31
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6464);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries32
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8989);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries33
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries34
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries35
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "L"), "k");
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "A"), "k");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "S"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries36
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "A"), "k");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "S"), "k");
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "L"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries37
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "S"), "k");
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "L"), "k");
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries38
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5556);
                yield return (new Processor(sv, "L"), "k");
                sv[0, 0] = new SignValue(6667);
                yield return (new Processor(sv, "A"), "k");
                sv[0, 0] = new SignValue(2223);
                yield return (new Processor(sv, "S"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries39
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6669);
                yield return (new Processor(sv, "A"), "k");
                sv[0, 0] = new SignValue(2220);
                yield return (new Processor(sv, "S"), "k");
                sv[0, 0] = new SignValue(5551);
                yield return (new Processor(sv, "L"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries40
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2226);
                yield return (new Processor(sv, "S"), "k");
                sv[0, 0] = new SignValue(5554);
                yield return (new Processor(sv, "L"), "k");
                sv[0, 0] = new SignValue(6663);
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries41
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "y");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries42
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries43
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries44
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries45
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries46
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "qw");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries46Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries47
        {
            get
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
        }

        static IEnumerable<Processor> GetCorrectQueries47Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries48
        {
            get
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
        }

        static IEnumerable<Processor> GetCorrectQueries48Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries49
        {
            get
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
        }

        static IEnumerable<Processor> GetCorrectQueries49Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries50
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                sv[2, 0] = new SignValue(4545);
                sv[3, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "qw");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries50Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries51
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(4444);
                sv[3, 0] = new SignValue(6666);
                yield return (new Processor(sv, "u"), "qw");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries51Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries52
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(5554);
                sv[3, 0] = new SignValue(5553);
                yield return (new Processor(sv, "u"), "qw");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries52Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries53
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                sv[2, 0] = new SignValue(4545);
                sv[3, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "w");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries53Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries54
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(4444);
                sv[3, 0] = new SignValue(6666);
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "w");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries54Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries55
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(5554);
                sv[3, 0] = new SignValue(5553);
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "w");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries55Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries56
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                sv[2, 0] = new SignValue(4545);
                sv[3, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries56Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries57
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(4444);
                sv[3, 0] = new SignValue(6666);
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries57Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries58
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(5554);
                sv[3, 0] = new SignValue(5553);
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries58Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries59
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                sv[2, 0] = new SignValue(4545);
                sv[3, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries59Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries60
        {
            get
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
            }
        }

        static IEnumerable<Processor> GetCorrectQueries60Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries61
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(5554);
                sv[3, 0] = new SignValue(5553);
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries61Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries62
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                sv[2, 0] = new SignValue(4545);
                sv[3, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries62Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6657);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4545);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries63
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(4444);
                sv[3, 0] = new SignValue(6666);
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries63Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries64
        {
            get
            {
                SignValue[,] sv = new SignValue[4, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(5554);
                sv[3, 0] = new SignValue(5553);
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "w");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "q");
                yield return (new Processor(sv, "u"), "qw");
                yield return (new Processor(sv, "u"), "q");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries64Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "w");
                svq[0, 0] = new SignValue(5554);
                yield return new Processor(svq, "q");
                svq[0, 0] = new SignValue(5553);
                yield return new Processor(svq, "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries65
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries66
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "K");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries67
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "u"), "k");
                yield return (new Processor(sv, "u"), "k");
                yield return (new Processor(sv, "u"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries68
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "p"), "k");
                yield return (new Processor(sv, "k"), "k");
                yield return (new Processor(sv, "l"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries69
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "k");
                yield return (new Processor(sv, "2"), "k");
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries70
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "a"), "K");
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "b"), "k");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "c"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries71
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "p"), "k");
                yield return (new Processor(sv, "k"), "K");
                yield return (new Processor(sv, "l"), "k");
                yield return (new Processor(sv, "l"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries72
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "k1");
                yield return (new Processor(sv, "1"), "k");
                yield return (new Processor(sv, "2"), "k");
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries73
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 3];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "u"), "k");
                yield return (new Processor(sv, "u"), "k");
                yield return (new Processor(sv, "u"), "k");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries73Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries74
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 3];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                sv[0, 2] = new SignValue(5555);
                yield return (new Processor(sv, "l"), "k");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries74Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries75
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "k");
                yield return (new Processor(sv, "2"), "k");
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries75Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "k");
                svq[0, 0] = new SignValue(0);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries76
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<Processor> GetCorrectQueries76Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(6666);
                yield return new Processor(svq, "k");
                svq[0, 0] = new SignValue(0);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries77
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(4444);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(7777);
                yield return (new Processor(sv, "c"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries78
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries79
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries80
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "k1");
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries81
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                sv[2, 0] = new SignValue(6666);
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries82
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries83
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 5];
                sv[0, 0] = new SignValue(4444);
                sv[0, 1] = new SignValue(6666);
                sv[0, 2] = new SignValue(7777);
                sv[0, 3] = new SignValue(8888);
                sv[0, 4] = new SignValue(9999);
                yield return (new Processor(sv, "c"), "K");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries84
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries85
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries86
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries87
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries88
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries89
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries90
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries91
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries92
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "0"), "Q");
                yield return (new Processor(sv, "1"), "W");
                yield return (new Processor(sv, "2"), "q");
                yield return (new Processor(sv, "3"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries93
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "0"), "QW");
                yield return (new Processor(sv, "1"), "qw");
                yield return (new Processor(sv, "2"), "qW");
                yield return (new Processor(sv, "3"), "Qw");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries94
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries95
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries96
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries97
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "qqQWww");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "y"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries98
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(3333);
                yield return (new Processor(sv, "n"), "qqQWww");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(9999);
                yield return (new Processor(sv, "y"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries99
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries100
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "qqQWww");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries101
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries102
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries103
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries104
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries96_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries97_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "WwwqqQ");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "y"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries98_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(3333);
                yield return (new Processor(sv, "n"), "WwwqqQ");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(9999);
                yield return (new Processor(sv, "y"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries99_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries100_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "WwwqqQ");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries101_1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries102_1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries103_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries104_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries105
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "s"), "q");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "d"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries106
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "s"), "y");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "d"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries107
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(7777);
                yield return (new Processor(sv, "s"), "y");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "d"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries108
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "s"), "y1");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "d"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries109
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "s"), "y");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "d"), "y1");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries110
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries111
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries112
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries113
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries114
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "u"), "y");
                yield return (new Processor(sv, "u"), "y");
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries115
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "p"), "y");
                yield return (new Processor(sv, "k"), "y");
                yield return (new Processor(sv, "l"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries116
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries117
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "a"), "Y");
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "b"), "y");
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "c"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries118
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "p"), "y");
                yield return (new Processor(sv, "k"), "Y");
                yield return (new Processor(sv, "l"), "y");
                yield return (new Processor(sv, "l"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries119
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "k1");
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries120
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries121
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries122
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "Y1");
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries123
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "Y");
                yield return (new Processor(sv, "2"), "Y");
                yield return (new Processor(sv, "3"), "y");
                yield return (new Processor(sv, "l"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries124
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(7777);
                yield return (new Processor(sv, "1"), "Y");
                yield return (new Processor(sv, "2"), "Y");
                yield return (new Processor(sv, "3"), "y");
                yield return (new Processor(sv, "l"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries125
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(8888);
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries126
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(4444);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "Y1");
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries127
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "l"), "Y1");
                yield return (new Processor(sv, "1"), "y");
                yield return (new Processor(sv, "2"), "y");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries128
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 5];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                sv[0, 2] = new SignValue(7777);
                sv[0, 3] = new SignValue(6666);
                yield return (new Processor(sv, "l"), "Y1");
                yield return (new Processor(sv, "3"), "y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries129
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries130
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "Y");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "y"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries131
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(3333);
                yield return (new Processor(sv, "n"), "Y");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(9999);
                yield return (new Processor(sv, "y"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries132
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries133
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "Y");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries134
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "h"), "Y");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries135
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "h"), "Y");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries136
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "h"), "Y");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(7777);
                sv[0, 1] = new SignValue(7777);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries137
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectQueries138
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> GetCorrectGlobalProcessorQuery
        {
            get
            {
                if (_globalProcessor == null)
                    throw new Exception($"Сначала необходимо вызвать метод {nameof(GetGlobalProcessorForNeuron)}.");
                yield return (_globalProcessor, "A");
            }
        }

        #endregion //Correct

        #region Incorrect

        static IEnumerable<(Processor, string)> GetIncorrectQueriesNull => null;

        static IEnumerable<(Processor, string)> GetIncorrectQueriesBreak
        {
            get
            {
                yield break;
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries0
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "c");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries2
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries3
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries4
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "c"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "d"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries5
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries6
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "a");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries7
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "b");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries8
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "a"), "c");
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries9
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "a"), "d");
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries10
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "c"), "c");
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries11
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries12
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2245);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(999);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries13
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries14
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries15
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries16
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "a"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries17
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries18
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1300);
                yield return (new Processor(sv, "a"), "a");
                sv[0, 0] = new SignValue(2265);
                yield return (new Processor(sv, "b"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries19
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries20
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries21
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "B");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries22
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "A");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries23
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries24
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries25
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "B");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries26
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "A");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries27
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries28
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries29
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries30
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "b");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries31
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries32
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries33
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries34
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries35
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries36
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries37
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries38
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries39
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries41
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries42
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "b"), "b");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "a"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries43
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "d");
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "a"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries44
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "b"), "c");
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "a"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries45
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries46
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "c"), "c");
                sv[0, 0] = new SignValue(1000);
                yield return (new Processor(sv, "d"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries47
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p6"), "b");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p7"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries48
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "c");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries49
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "d");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries50
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "c");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries51
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "d");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries52
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2245);
                yield return (new Processor(sv, "d"), "a");
                sv[0, 0] = new SignValue(999);
                yield return (new Processor(sv, "c"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries53
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "a");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries54
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "a");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries55
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "b");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries56
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "b");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries57
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "b");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries58
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1300);
                yield return (new Processor(sv, "c"), "a");
                sv[0, 0] = new SignValue(2265);
                yield return (new Processor(sv, "d"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries59
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "b");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries60
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries61
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "B");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries62
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "A");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries63
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "b");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries64
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "a");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries65
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "B");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries66
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "A");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries67
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2245);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(999);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries68
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries69
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries70
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries71
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries72
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries73
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1300);
                yield return (new Processor(sv, "c"), "c");
                sv[0, 0] = new SignValue(2265);
                yield return (new Processor(sv, "d"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries74
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries75
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries76
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "D");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries77
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "C");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries78
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "D");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries79
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries80
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "D");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "D");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries81
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "C");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries82
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2245);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(999);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries83
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries84
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries85
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries86
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2000);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(3000);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries87
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(978);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(900);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries88
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(1300);
                yield return (new Processor(sv, "c"), "c");
                sv[0, 0] = new SignValue(2265);
                yield return (new Processor(sv, "d"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries89
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries90
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries91
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "D");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries92
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "C");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries93
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "d");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "D");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries94
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "c");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries95
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "D");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "D");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries96
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "d"), "C");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "c"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries98
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "a");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries99
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "b");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries100
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "c");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries101
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "e"), "d");
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries102
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "c");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries103
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "d");
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p6"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries104
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "ab");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries105
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "aaaabbbbb");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries106
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "ab"), "AB");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries107
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "BA"), "cdABvdgd");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries108
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdABvdgd"), "cdABvdgd");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries109
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "ab"), "ABC");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries110
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdgd"), "cdvdgd");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries111
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdvdgd"), "cdvdgd");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries112
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries113
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries114
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries115
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries116
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(8888);
                yield return (new Processor(svq, "Q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries117
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9999);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries118
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1114);
                yield return (new Processor(svq, "q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries119
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2225);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries120
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "Q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries121
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries122
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1112);
                yield return (new Processor(svq, "q"), "q");
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries123
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2223);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries124
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(100);
                yield return (new Processor(svq, "q"), "Q");
                svq[0, 0] = new SignValue(9957);
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries125
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9956);
                yield return (new Processor(svq, "w"), "w");
                svq[0, 0] = new SignValue(101);
                yield return (new Processor(svq, "q"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries126
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9947);
                yield return (new Processor(svq, "w"), "q");
                svq[0, 0] = new SignValue(109);
                yield return (new Processor(svq, "q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries127
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(107);
                yield return (new Processor(svq, "q"), "W");
                svq[0, 0] = new SignValue(9916);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries128
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9927);
                yield return (new Processor(svq, "W"), "A");
                svq[0, 0] = new SignValue(110);
                yield return (new Processor(svq, "Q"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries129
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9958);
                yield return (new Processor(svq, "W"), "b");
                svq[0, 0] = new SignValue(102);
                yield return (new Processor(svq, "Q"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries130
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9960);
                yield return (new Processor(svq, "w"), "c");
                svq[0, 0] = new SignValue(103);
                yield return (new Processor(svq, "q"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries131
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(104);
                yield return (new Processor(svq, "q"), "D");
                svq[0, 0] = new SignValue(9986);
                yield return (new Processor(svq, "w"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries132
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "q"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries133
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries134
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries135
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries136
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "Q"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries137
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries138
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries139
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries140
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries141
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries142
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries143
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries144
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries145
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries146
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries147
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries148
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "q");
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries149
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries150
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "Q");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries151
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries152
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "q");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries153
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "W");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries154
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "A");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries155
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "b");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries156
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "c");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries157
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "D");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries158
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries159
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries160
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries161
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries162
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries163
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries164
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries165
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries166
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries167
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries168
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "K5");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries169
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries170
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(8888);
                yield return (new Processor(svq, "K"), "K2");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries171
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9999);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries172
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1114);
                yield return (new Processor(svq, "k"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries173
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2225);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries174
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "K"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries175
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries176
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1112);
                yield return (new Processor(svq, "k"), "k1");
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries177
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2223);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries178
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(100);
                yield return (new Processor(svq, "k"), "K1");
                svq[0, 0] = new SignValue(9957);
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries179
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9956);
                yield return (new Processor(svq, "w"), "w");
                svq[0, 0] = new SignValue(101);
                yield return (new Processor(svq, "k"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries180
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9947);
                yield return (new Processor(svq, "w"), "k1");
                svq[0, 0] = new SignValue(109);
                yield return (new Processor(svq, "k"), "K1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries181
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(107);
                yield return (new Processor(svq, "k"), "W");
                svq[0, 0] = new SignValue(9916);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries182
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9927);
                yield return (new Processor(svq, "W"), "A");
                svq[0, 0] = new SignValue(110);
                yield return (new Processor(svq, "K"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries189
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9958);
                yield return (new Processor(svq, "W"), "b");
                svq[0, 0] = new SignValue(102);
                yield return (new Processor(svq, "K"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries190
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9960);
                yield return (new Processor(svq, "w"), "c");
                svq[0, 0] = new SignValue(103);
                yield return (new Processor(svq, "k"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries191
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(104);
                yield return (new Processor(svq, "k"), "D");
                svq[0, 0] = new SignValue(9986);
                yield return (new Processor(svq, "w"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries192
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "k"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries193
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries194
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "k"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries195
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries196
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "K"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries197
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries198
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries199
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries200
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries201
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries202
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "K1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries203
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries204
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries205
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries206
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries207
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries208
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "k1");
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries209
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries210
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "K1");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries211
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries212
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "k1");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "K1");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries213
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "W");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries214
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "A");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries215
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "b");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries216
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "c");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "C");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries217
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "D");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "d");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries218
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries219
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries220
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries221
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries222
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries223
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries224
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries225
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries226
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(7777);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries227
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "k");
                svq[0, 0] = new SignValue(7777);
                yield return (new Processor(svq, "q"), "p");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries228
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(7777);
                yield return (new Processor(svq, "q"), "p");
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "k");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries229
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries230
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries231
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries232
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "b"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries233
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetIncorrectQueries234
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(7777);
                yield return (new Processor(svq, "K"), "i");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries235
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries236
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "F");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "y"), "F");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries237
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(3333);
                yield return (new Processor(sv, "n"), "G");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(9999);
                yield return (new Processor(sv, "y"), "H");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries238
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "J");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "J");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries239
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "K");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "K");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries240
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "h"), "K1");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "K1");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries241
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "h"), "Q");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "q");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries242
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "h"), "w");
                sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(7777);
                sv[0, 1] = new SignValue(7777);
                yield return (new Processor(sv, "m"), "W");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries243
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "A");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries244
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries245
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "fg"), "jkl");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "s"), "A");
                svq[0, 0] = new SignValue(2446);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries246
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "b"), "a");
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "ab"), "jkl");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries247
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "fg"), "JKL");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "s"), "A");
                svq[0, 0] = new SignValue(2446);
                yield return (new Processor(svq, "b"), "B");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries248
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "b"), "B");
                svq[0, 0] = new SignValue(1228);
                yield return (new Processor(svq, "b"), "a");
                svq[0, 0] = new SignValue(2445);
                yield return (new Processor(svq, "ab"), "JKL");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries249
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries250
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries251
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries252
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries253
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries254
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries255Exception
        {
            get
            {
                yield return (new Processor(new SignValue[1, 1], "q"), "a");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries256Exception
        {
            get
            {
                yield return (new Processor(new SignValue[2, 1], "w"), "b");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries257Exception
        {
            get
            {
                yield return (new Processor(new SignValue[1, 2], "e"), "c");
            }
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries258
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries259
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries260
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries261
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries262
        {
            get
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
        }

        static IEnumerable<(Processor, string)> GetInCorrectQueries263
        {
            get
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
            Neuron parentNeuron = new Neuron(new ProcessorContainer(pcActual.ToArray()));
            CheckNeuronMapValue(parentNeuron, pcExpected);
            CheckNeuronMapValue(parentNeuron.FindRelation(pcRequest), pcRequestProcessors);
            CheckNeuronMapValue(parentNeuron, pcExpected);
        }

        [TestMethod]
        public void NeuronTest0()
        {
            NeuronTestSub(GetProcessors0, GetProcessors0, GetCorrectQueries0, GetCorrectQueries0.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries1, GetCorrectQueries1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries2, GetCorrectQueries2.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries3, GetCorrectQueries3.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries4, GetCorrectQueries4.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries5, GetCorrectQueries5.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries5_1, GetCorrectQueries5_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries6, GetCorrectQueries6.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries6_1, GetCorrectQueries6_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries7, GetCorrectQueries7.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries7_1, GetCorrectQueries7_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries8, GetCorrectQueries8.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries8_1, GetCorrectQueries8_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries8_2, GetCorrectQueries8_2.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries90, GetCorrectQueries90.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries9_0, GetCorrectQueries9_0.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries9_1, GetCorrectQueries9_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries9_1_1, GetCorrectQueries9_1_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries9_2, GetCorrectQueries9_2.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries9_3, GetCorrectQueries9_3.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries10_0, GetCorrectQueries10_0.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries10_1, GetCorrectQueries10_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries10_1_1, GetCorrectQueries10_1.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries10_2, GetCorrectQueries10_2.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries10_3, GetCorrectQueries10_3.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries11, GetCorrectQueries11.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries12, GetCorrectQueries12.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries13, GetCorrectQueries13.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries14, GetCorrectQueries14Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries15, GetCorrectQueries15.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries16, GetCorrectQueries16.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries17, GetCorrectQueries17.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries18, GetCorrectQueries18.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries19, GetCorrectQueries19Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries20, GetCorrectQueries20Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries21, GetCorrectQueries21Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries22, GetCorrectQueries22Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries23, GetCorrectQueries23Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries24, GetCorrectQueries24Result);
            NeuronTestSub(GetProcessors1, GetProcessors1, GetCorrectQueries24, GetCorrectQueries46Result);

            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries25.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries26.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries27.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries28.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries29.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries30.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries31.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries32.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries33.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries34.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries35.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries36.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries37.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries38.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries39.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries40.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries41.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries42.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries43.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries44.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries45.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries46.Select(tuple => tuple.Item1));
            NeuronTestSub(GetProcessors2, GetProcessors2, GetCorrectQueries2, GetCorrectQueries47.Select(tuple => tuple.Item1));
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