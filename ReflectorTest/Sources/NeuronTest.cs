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
        /// Используется для теста, где используется одна и та же физическая карта <see cref="GlobalProcessorForNeuron"/> и <see cref="CorrectGlobalProcessorQuery"/>.
        /// </summary>
        static Processor _globalProcessor;

        static IEnumerable<Processor> Processors0
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

        static IEnumerable<Processor> Processors1
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

        static IEnumerable<Processor> Processors2
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "q");
                yield return new Processor(sv, "w");
            }
        }

        static IEnumerable<Processor> Processors3
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                yield return new Processor(sv, "k1");
            }
        }

        static IEnumerable<Processor> Processors4
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

        static IEnumerable<Processor> GlobalProcessorForNeuron
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

        static IEnumerable<Processor> Processors8Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 2], "Exception8");
            }
        }

        static IEnumerable<Processor> Processors9Exception
        {
            get
            {
                yield return new Processor(new SignValue[1, 2], "Exception9");
            }
        }

        static IEnumerable<Processor> Processors10Exception
        {
            get
            {
                yield return new Processor(new SignValue[2, 1], "Exception10");
            }
        }

        #endregion //GetProcessors

        #region Correct

        static IEnumerable<(Processor, string)> CorrectQuery0
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

        static IEnumerable<Processor> CorrectQuery0Result
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

        static IEnumerable<(Processor, string)> CorrectQuery1
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

        static IEnumerable<(Processor, string)> CorrectQuery2
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

        static IEnumerable<(Processor, string)> CorrectQuery3
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

        static IEnumerable<(Processor, string)> CorrectQuery4
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

        static IEnumerable<(Processor, string)> CorrectQuery5
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

        static IEnumerable<(Processor, string)> CorrectQuery5_1
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

        static IEnumerable<(Processor, string)> CorrectQuery6
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

        static IEnumerable<(Processor, string)> CorrectQuery6_1
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

        static IEnumerable<(Processor, string)> CorrectQuery7
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

        static IEnumerable<(Processor, string)> CorrectQuery7_1
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

        static IEnumerable<(Processor, string)> CorrectQuery8
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

        static IEnumerable<(Processor, string)> CorrectQuery8_1
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

        static IEnumerable<(Processor, string)> CorrectQuery8_2
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

        static IEnumerable<(Processor, string)> CorrectQuery9_0
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

        static IEnumerable<(Processor, string)> CorrectQuery9_1
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

        static IEnumerable<(Processor, string)> CorrectQuery9_1_1
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

        static IEnumerable<(Processor, string)> CorrectQuery9_2
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

        static IEnumerable<(Processor, string)> CorrectQuery9_3
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

        static IEnumerable<(Processor, string)> CorrectQuery10_0
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

        static IEnumerable<(Processor, string)> CorrectQuery10_1
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

        static IEnumerable<(Processor, string)> CorrectQuery10_1_1
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

        static IEnumerable<(Processor, string)> CorrectQuery10_2
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

        static IEnumerable<(Processor, string)> CorrectQuery10_3
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

        static IEnumerable<(Processor, string)> CorrectQuery11
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

        static IEnumerable<(Processor, string)> CorrectQuery12
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

        static IEnumerable<(Processor, string)> CorrectQuery13
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

        static IEnumerable<(Processor, string)> CorrectQuery14
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

        static IEnumerable<Processor> CorrectQuery14Result
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

        static IEnumerable<(Processor, string)> CorrectQuery15
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

        static IEnumerable<(Processor, string)> CorrectQuery16
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

        static IEnumerable<(Processor, string)> CorrectQuery17
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

        static IEnumerable<(Processor, string)> CorrectQuery18
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

        static IEnumerable<(Processor, string)> CorrectQuery19
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

        static IEnumerable<Processor> CorrectQuery19Result
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

        static IEnumerable<(Processor, string)> CorrectQuery20
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

        static IEnumerable<Processor> CorrectQuery20Result
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

        static IEnumerable<(Processor, string)> CorrectQuery21
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

        static IEnumerable<Processor> CorrectQuery21Result
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

        static IEnumerable<(Processor, string)> CorrectQuery22
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

        static IEnumerable<Processor> CorrectQuery22Result
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

        static IEnumerable<(Processor, string)> CorrectQuery23
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

        static IEnumerable<Processor> CorrectQuery23Result
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

        static IEnumerable<(Processor, string)> CorrectQuery24
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

        static IEnumerable<Processor> CorrectQuery24Result
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

        static IEnumerable<(Processor, string)> CorrectQuery25
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "j"), "q");
                yield return (new Processor(sv, "k"), "w");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery26
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "o"), "q");
                yield return (new Processor(sv, "p"), "w");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery27
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "g"), "q");
                yield return (new Processor(sv, "h"), "w");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery28
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "i1"), "k");
                yield return (new Processor(sv, "i1"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery29
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery30
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery31
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6464);
                yield return (new Processor(sv, "L"), "k");
                yield return (new Processor(sv, "A"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery32
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8989);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery33
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery34
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "t"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery35
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

        static IEnumerable<(Processor, string)> CorrectQuery36
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

        static IEnumerable<(Processor, string)> CorrectQuery37
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

        static IEnumerable<(Processor, string)> CorrectQuery38
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

        static IEnumerable<(Processor, string)> CorrectQuery39
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

        static IEnumerable<(Processor, string)> CorrectQuery40
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

        static IEnumerable<(Processor, string)> CorrectQuery41
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

        static IEnumerable<(Processor, string)> CorrectQuery42
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery43
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery44
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(8888);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery45
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(4444);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery46
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(4545);
                sv[1, 0] = new SignValue(6657);
                yield return (new Processor(sv, "u"), "qw");
            }
        }

        static IEnumerable<Processor> CorrectQuery46Result
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

        static IEnumerable<(Processor, string)> CorrectQuery47
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

        static IEnumerable<Processor> CorrectQuery47Result
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

        static IEnumerable<(Processor, string)> CorrectQuery48
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

        static IEnumerable<Processor> CorrectQuery48Result
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

        static IEnumerable<(Processor, string)> CorrectQuery49
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

        static IEnumerable<Processor> CorrectQuery49Result
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

        static IEnumerable<(Processor, string)> CorrectQuery50
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

        static IEnumerable<Processor> CorrectQuery50Result
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

        static IEnumerable<(Processor, string)> CorrectQuery51
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

        static IEnumerable<Processor> CorrectQuery51Result
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

        static IEnumerable<(Processor, string)> CorrectQuery52
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

        static IEnumerable<Processor> CorrectQuery52Result
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

        static IEnumerable<(Processor, string)> CorrectQuery53
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

        static IEnumerable<Processor> CorrectQuery53Result
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

        static IEnumerable<(Processor, string)> CorrectQuery54
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

        static IEnumerable<Processor> CorrectQuery54Result
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

        static IEnumerable<(Processor, string)> CorrectQuery55
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

        static IEnumerable<Processor> CorrectQuery55Result
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

        static IEnumerable<(Processor, string)> CorrectQuery56
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

        static IEnumerable<Processor> CorrectQuery56Result
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

        static IEnumerable<(Processor, string)> CorrectQuery57
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

        static IEnumerable<Processor> CorrectQuery57Result
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

        static IEnumerable<(Processor, string)> CorrectQuery58
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

        static IEnumerable<Processor> CorrectQuery58Result
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

        static IEnumerable<(Processor, string)> CorrectQuery59
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

        static IEnumerable<Processor> CorrectQuery59Result
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

        static IEnumerable<(Processor, string)> CorrectQuery60
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

        static IEnumerable<Processor> CorrectQuery60Result
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

        static IEnumerable<(Processor, string)> CorrectQuery61
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

        static IEnumerable<Processor> CorrectQuery61Result
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

        static IEnumerable<(Processor, string)> CorrectQuery62
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

        static IEnumerable<Processor> CorrectQuery62Result
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

        static IEnumerable<(Processor, string)> CorrectQuery63
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

        static IEnumerable<Processor> CorrectQuery63Result
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

        static IEnumerable<(Processor, string)> CorrectQuery64
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

        static IEnumerable<Processor> CorrectQuery64Result
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

        static IEnumerable<(Processor, string)> CorrectQuery65
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery66
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "K");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery67
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

        static IEnumerable<(Processor, string)> CorrectQuery68
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

        static IEnumerable<(Processor, string)> CorrectQuery69
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

        static IEnumerable<(Processor, string)> CorrectQuery70
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

        static IEnumerable<(Processor, string)> CorrectQuery71
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "p"), "k");
                yield return (new Processor(sv, "k"), "K");
                yield return (new Processor(sv, "l"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery72
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

        static IEnumerable<(Processor, string)> CorrectQuery73
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

        static IEnumerable<Processor> CorrectQuery73Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(4444);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery74
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

        static IEnumerable<(Processor, string)> CorrectQuery74_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 3];
                sv[0, 0] = new SignValue(5555);
                sv[0, 1] = new SignValue(5555);
                sv[0, 2] = new SignValue(5555);
                yield return (new Processor(sv, "a"), "k");
                sv[0, 0] = new SignValue(6676);
                sv[0, 1] = new SignValue(8976);
                sv[0, 2] = new SignValue(9034);
                yield return (new Processor(sv, "b"), "k");
            }
        }

        static IEnumerable<Processor> CorrectQuery74Result
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return new Processor(svq, "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery75
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

        static IEnumerable<Processor> CorrectQuery75Result
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

        static IEnumerable<(Processor, string)> CorrectQuery76
        {
            get
            {
                SignValue[,] sv = new SignValue[3, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "3"), "k");
            }
        }

        static IEnumerable<Processor> CorrectQuery76Result
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

        static IEnumerable<(Processor, string)> CorrectQuery77
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

        static IEnumerable<(Processor, string)> CorrectQuery78
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
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery79
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

        static IEnumerable<(Processor, string)> CorrectQuery80
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

        static IEnumerable<(Processor, string)> CorrectQuery81
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

        static IEnumerable<(Processor, string)> CorrectQuery82
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

        static IEnumerable<(Processor, string)> CorrectQuery83
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

        static IEnumerable<(Processor, string)> CorrectQuery84
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

        static IEnumerable<(Processor, string)> CorrectQuery85
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

        static IEnumerable<(Processor, string)> CorrectQuery86
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(6666);
                yield return (new Processor(sv, "1"), "K");
                yield return (new Processor(sv, "2"), "K");
                yield return (new Processor(sv, "3"), "k");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7879);
                yield return (new Processor(sv, "4"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery87
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(6666);
                sv[0, 1] = new SignValue(7777);
                yield return (new Processor(sv, "1"), "K");
                yield return (new Processor(sv, "2"), "K");
                yield return (new Processor(sv, "3"), "k");
                sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7880);
                yield return (new Processor(sv, "4"), "k");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery88
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

        static IEnumerable<(Processor, string)> CorrectQuery89
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

        static IEnumerable<(Processor, string)> CorrectQuery90
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

        static IEnumerable<(Processor, string)> CorrectQuery91
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

        static IEnumerable<(Processor, string)> CorrectQuery92
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

        static IEnumerable<(Processor, string)> CorrectQuery93
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

        static IEnumerable<(Processor, string)> CorrectQuery94
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

        static IEnumerable<(Processor, string)> CorrectQuery95
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

        static IEnumerable<(Processor, string)> CorrectQuery96
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery97
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

        static IEnumerable<(Processor, string)> CorrectQuery98
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

        static IEnumerable<(Processor, string)> CorrectQuery99
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

        static IEnumerable<(Processor, string)> CorrectQuery100
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

        static IEnumerable<(Processor, string)> CorrectQuery101
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery102
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery103
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery104
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "qqQWww");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery96_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(8888);
                sv[0, 1] = new SignValue(2222);
                yield return (new Processor(sv, "n"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery97_1
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

        static IEnumerable<(Processor, string)> CorrectQuery98_1
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

        static IEnumerable<(Processor, string)> CorrectQuery99_1
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

        static IEnumerable<(Processor, string)> CorrectQuery100_1
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

        static IEnumerable<(Processor, string)> CorrectQuery101_1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery102_1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery103_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery104_1
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "h"), "WwwqqQ");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery105
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

        static IEnumerable<(Processor, string)> CorrectQuery106
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

        static IEnumerable<(Processor, string)> CorrectQuery107
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

        static IEnumerable<(Processor, string)> CorrectQuery108
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

        static IEnumerable<(Processor, string)> CorrectQuery109
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

        static IEnumerable<(Processor, string)> CorrectQuery110
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery111
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery112
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "u"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery113
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "u"), "y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery114
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

        static IEnumerable<(Processor, string)> CorrectQuery115
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

        static IEnumerable<(Processor, string)> CorrectQuery116
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

        static IEnumerable<(Processor, string)> CorrectQuery117
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

        static IEnumerable<(Processor, string)> CorrectQuery118
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

        static IEnumerable<(Processor, string)> CorrectQuery119
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

        static IEnumerable<(Processor, string)> CorrectQuery120
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

        static IEnumerable<(Processor, string)> CorrectQuery121
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

        static IEnumerable<(Processor, string)> CorrectQuery122
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

        static IEnumerable<(Processor, string)> CorrectQuery123
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

        static IEnumerable<(Processor, string)> CorrectQuery124
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

        static IEnumerable<(Processor, string)> CorrectQuery125
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

        static IEnumerable<(Processor, string)> CorrectQuery126
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

        static IEnumerable<(Processor, string)> CorrectQuery127
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

        static IEnumerable<(Processor, string)> CorrectQuery128
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

        static IEnumerable<(Processor, string)> CorrectQuery129
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
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery130
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

        static IEnumerable<(Processor, string)> CorrectQuery131
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

        static IEnumerable<(Processor, string)> CorrectQuery132
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

        static IEnumerable<(Processor, string)> CorrectQuery133
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

        static IEnumerable<(Processor, string)> CorrectQuery134
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

        static IEnumerable<(Processor, string)> CorrectQuery135
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

        static IEnumerable<(Processor, string)> CorrectQuery136
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

        static IEnumerable<(Processor, string)> CorrectQuery137
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery138
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "Y");
            }
        }

        static IEnumerable<(Processor, string)> CorrectGlobalProcessorQuery
        {
            get
            {
                if (_globalProcessor == null)
                    throw new Exception($"Сначала необходимо вызвать метод {nameof(GlobalProcessorForNeuron)}.");
                yield return (_globalProcessor, "A");
            }
        }

        #endregion //Correct

        #region Incorrect

        static IEnumerable<(Processor, string)> InCorrectQueryNull => null;

        static IEnumerable<(Processor, string)> InCorrectQueryBreak
        {
            get
            {
                yield break;
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery0
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

        static IEnumerable<(Processor, string)> InCorrectQuery1
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

        static IEnumerable<(Processor, string)> InCorrectQuery2
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

        static IEnumerable<(Processor, string)> InCorrectQuery3
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

        static IEnumerable<(Processor, string)> InCorrectQuery4
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

        static IEnumerable<(Processor, string)> InCorrectQuery5
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

        static IEnumerable<(Processor, string)> InCorrectQuery6
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

        static IEnumerable<(Processor, string)> InCorrectQuery7
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

        static IEnumerable<(Processor, string)> InCorrectQuery8
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

        static IEnumerable<(Processor, string)> InCorrectQuery9
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

        static IEnumerable<(Processor, string)> InCorrectQuery10
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

        static IEnumerable<(Processor, string)> InCorrectQuery11
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

        static IEnumerable<(Processor, string)> InCorrectQuery12
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

        static IEnumerable<(Processor, string)> InCorrectQuery13
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

        static IEnumerable<(Processor, string)> InCorrectQuery14
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

        static IEnumerable<(Processor, string)> InCorrectQuery15
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

        static IEnumerable<(Processor, string)> InCorrectQuery16
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

        static IEnumerable<(Processor, string)> InCorrectQuery17
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

        static IEnumerable<(Processor, string)> InCorrectQuery18
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

        static IEnumerable<(Processor, string)> InCorrectQuery19
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

        static IEnumerable<(Processor, string)> InCorrectQuery20
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

        static IEnumerable<(Processor, string)> InCorrectQuery21
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

        static IEnumerable<(Processor, string)> InCorrectQuery22
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

        static IEnumerable<(Processor, string)> InCorrectQuery23
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

        static IEnumerable<(Processor, string)> InCorrectQuery24
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

        static IEnumerable<(Processor, string)> InCorrectQuery25
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

        static IEnumerable<(Processor, string)> InCorrectQuery26
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

        static IEnumerable<(Processor, string)> InCorrectQuery27
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

        static IEnumerable<(Processor, string)> InCorrectQuery28
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

        static IEnumerable<(Processor, string)> InCorrectQuery29
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery30
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

        static IEnumerable<(Processor, string)> InCorrectQuery31
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

        static IEnumerable<(Processor, string)> InCorrectQuery32
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

        static IEnumerable<(Processor, string)> InCorrectQuery33
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

        static IEnumerable<(Processor, string)> InCorrectQuery34
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

        static IEnumerable<(Processor, string)> InCorrectQuery35
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1222);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery36
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery37
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery38
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "p"), "b");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery39
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "p"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery41
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

        static IEnumerable<(Processor, string)> InCorrectQuery42
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

        static IEnumerable<(Processor, string)> InCorrectQuery43
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

        static IEnumerable<(Processor, string)> InCorrectQuery44
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

        static IEnumerable<(Processor, string)> InCorrectQuery45
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

        static IEnumerable<(Processor, string)> InCorrectQuery46
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

        static IEnumerable<(Processor, string)> InCorrectQuery47
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

        static IEnumerable<(Processor, string)> InCorrectQuery48
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

        static IEnumerable<(Processor, string)> InCorrectQuery49
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

        static IEnumerable<(Processor, string)> InCorrectQuery50
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

        static IEnumerable<(Processor, string)> InCorrectQuery51
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

        static IEnumerable<(Processor, string)> InCorrectQuery52
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

        static IEnumerable<(Processor, string)> InCorrectQuery53
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

        static IEnumerable<(Processor, string)> InCorrectQuery54
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

        static IEnumerable<(Processor, string)> InCorrectQuery55
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

        static IEnumerable<(Processor, string)> InCorrectQuery56
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

        static IEnumerable<(Processor, string)> InCorrectQuery57
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

        static IEnumerable<(Processor, string)> InCorrectQuery58
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

        static IEnumerable<(Processor, string)> InCorrectQuery59
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

        static IEnumerable<(Processor, string)> InCorrectQuery60
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

        static IEnumerable<(Processor, string)> InCorrectQuery61
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

        static IEnumerable<(Processor, string)> InCorrectQuery62
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

        static IEnumerable<(Processor, string)> InCorrectQuery63
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

        static IEnumerable<(Processor, string)> InCorrectQuery64
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

        static IEnumerable<(Processor, string)> InCorrectQuery65
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

        static IEnumerable<(Processor, string)> InCorrectQuery66
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

        static IEnumerable<(Processor, string)> InCorrectQuery67
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

        static IEnumerable<(Processor, string)> InCorrectQuery68
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

        static IEnumerable<(Processor, string)> InCorrectQuery69
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

        static IEnumerable<(Processor, string)> InCorrectQuery70
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

        static IEnumerable<(Processor, string)> InCorrectQuery71
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

        static IEnumerable<(Processor, string)> InCorrectQuery72
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

        static IEnumerable<(Processor, string)> InCorrectQuery73
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

        static IEnumerable<(Processor, string)> InCorrectQuery74
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

        static IEnumerable<(Processor, string)> InCorrectQuery75
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

        static IEnumerable<(Processor, string)> InCorrectQuery76
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

        static IEnumerable<(Processor, string)> InCorrectQuery77
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

        static IEnumerable<(Processor, string)> InCorrectQuery78
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

        static IEnumerable<(Processor, string)> InCorrectQuery79
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

        static IEnumerable<(Processor, string)> InCorrectQuery80
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

        static IEnumerable<(Processor, string)> InCorrectQuery81
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

        static IEnumerable<(Processor, string)> InCorrectQuery82
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

        static IEnumerable<(Processor, string)> InCorrectQuery83
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

        static IEnumerable<(Processor, string)> InCorrectQuery84
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

        static IEnumerable<(Processor, string)> InCorrectQuery85
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

        static IEnumerable<(Processor, string)> InCorrectQuery86
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

        static IEnumerable<(Processor, string)> InCorrectQuery87
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

        static IEnumerable<(Processor, string)> InCorrectQuery88
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

        static IEnumerable<(Processor, string)> InCorrectQuery89
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

        static IEnumerable<(Processor, string)> InCorrectQuery90
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

        static IEnumerable<(Processor, string)> InCorrectQuery91
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

        static IEnumerable<(Processor, string)> InCorrectQuery92
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

        static IEnumerable<(Processor, string)> InCorrectQuery93
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

        static IEnumerable<(Processor, string)> InCorrectQuery94
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

        static IEnumerable<(Processor, string)> InCorrectQuery95
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

        static IEnumerable<(Processor, string)> InCorrectQuery96
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

        static IEnumerable<(Processor, string)> InCorrectQuery98
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

        static IEnumerable<(Processor, string)> InCorrectQuery99
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

        static IEnumerable<(Processor, string)> InCorrectQuery100
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

        static IEnumerable<(Processor, string)> InCorrectQuery101
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

        static IEnumerable<(Processor, string)> InCorrectQuery102
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

        static IEnumerable<(Processor, string)> InCorrectQuery103
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

        static IEnumerable<(Processor, string)> InCorrectQuery104
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "ab");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery105
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "p7"), "aaaabbbbb");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery106
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "ab"), "AB");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery107
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "BA"), "cdABvdgd");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery108
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdABvdgd"), "cdABvdgd");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery109
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "ab"), "ABC");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery110
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdgd"), "cdvdgd");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery111
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2333);
                yield return (new Processor(svq, "cdvdgd"), "cdvdgd");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery112
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery113
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery114
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery115
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery116
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(8888);
                yield return (new Processor(svq, "Q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery117
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9999);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery118
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1114);
                yield return (new Processor(svq, "q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery119
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2225);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery120
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "Q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery121
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery122
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1112);
                yield return (new Processor(svq, "q"), "q");
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery123
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2223);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery124
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

        static IEnumerable<(Processor, string)> InCorrectQuery125
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

        static IEnumerable<(Processor, string)> InCorrectQuery126
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

        static IEnumerable<(Processor, string)> InCorrectQuery127
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

        static IEnumerable<(Processor, string)> InCorrectQuery128
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

        static IEnumerable<(Processor, string)> InCorrectQuery129
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

        static IEnumerable<(Processor, string)> InCorrectQuery130
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

        static IEnumerable<(Processor, string)> InCorrectQuery131
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

        static IEnumerable<(Processor, string)> InCorrectQuery132
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "q"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery133
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery134
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery135
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery136
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "Q"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery137
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery138
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery139
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery140
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery141
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery142
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "Q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery143
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery144
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery145
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery146
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery147
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery148
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "q");
                yield return (new Processor(svq, "w"), "q");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery149
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "Q"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery150
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

        static IEnumerable<(Processor, string)> InCorrectQuery151
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

        static IEnumerable<(Processor, string)> InCorrectQuery152
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

        static IEnumerable<(Processor, string)> InCorrectQuery153
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

        static IEnumerable<(Processor, string)> InCorrectQuery154
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

        static IEnumerable<(Processor, string)> InCorrectQuery155
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

        static IEnumerable<(Processor, string)> InCorrectQuery156
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

        static IEnumerable<(Processor, string)> InCorrectQuery157
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

        static IEnumerable<(Processor, string)> InCorrectQuery158
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery159
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery160
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery161
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery162
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery163
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery164
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "Q"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery165
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery166
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery167
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery168
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "K5");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery169
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery170
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(8888);
                yield return (new Processor(svq, "K"), "K2");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery171
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(9999);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery172
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1114);
                yield return (new Processor(svq, "k"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery173
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2225);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery174
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1111);
                yield return (new Processor(svq, "K"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery175
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2222);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery176
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1112);
                yield return (new Processor(svq, "k"), "k1");
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery177
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2223);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery178
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

        static IEnumerable<(Processor, string)> InCorrectQuery179
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

        static IEnumerable<(Processor, string)> InCorrectQuery180
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

        static IEnumerable<(Processor, string)> InCorrectQuery181
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

        static IEnumerable<(Processor, string)> InCorrectQuery182
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

        static IEnumerable<(Processor, string)> InCorrectQuery189
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

        static IEnumerable<(Processor, string)> InCorrectQuery190
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

        static IEnumerable<(Processor, string)> InCorrectQuery191
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

        static IEnumerable<(Processor, string)> InCorrectQuery192
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "k"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery193
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery194
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "k"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery195
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery196
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1117);
                yield return (new Processor(svq, "K"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery197
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2123);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery198
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(1166);
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery199
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(2189);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery200
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery201
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery202
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "K1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery203
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "W");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery204
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery205
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery206
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery207
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery208
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "k1");
                yield return (new Processor(svq, "w"), "k1");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery209
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "w");
                yield return (new Processor(svq, "K"), "w");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery210
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

        static IEnumerable<(Processor, string)> InCorrectQuery211
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

        static IEnumerable<(Processor, string)> InCorrectQuery212
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

        static IEnumerable<(Processor, string)> InCorrectQuery213
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

        static IEnumerable<(Processor, string)> InCorrectQuery214
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

        static IEnumerable<(Processor, string)> InCorrectQuery215
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

        static IEnumerable<(Processor, string)> InCorrectQuery216
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

        static IEnumerable<(Processor, string)> InCorrectQuery217
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

        static IEnumerable<(Processor, string)> InCorrectQuery218
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "o");
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery219
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery220
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "k"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery221
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "w"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery222
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "o");
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery223
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery224
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "K"), "o");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery225
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(5555);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery226
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 1];
                svq[0, 0] = new SignValue(7777);
                yield return (new Processor(svq, "W"), "p");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery227
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

        static IEnumerable<(Processor, string)> InCorrectQuery228
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

        static IEnumerable<(Processor, string)> InCorrectQuery229
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

        static IEnumerable<(Processor, string)> InCorrectQuery230
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

        static IEnumerable<(Processor, string)> InCorrectQuery231
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(6666);
                yield return (new Processor(sv, "a"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery232
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return (new Processor(sv, "b"), "b");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery233
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(7777);
                yield return (new Processor(sv, "c"), "c");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery234
        {
            get
            {
                SignValue[,] svq = new SignValue[1, 2];
                svq[0, 0] = new SignValue(5555);
                svq[0, 1] = new SignValue(7777);
                yield return (new Processor(svq, "K"), "i");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery235
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

        static IEnumerable<(Processor, string)> InCorrectQuery236
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

        static IEnumerable<(Processor, string)> InCorrectQuery237
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

        static IEnumerable<(Processor, string)> InCorrectQuery238
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

        static IEnumerable<(Processor, string)> InCorrectQuery239
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

        static IEnumerable<(Processor, string)> InCorrectQuery240
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

        static IEnumerable<(Processor, string)> InCorrectQuery241
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

        static IEnumerable<(Processor, string)> InCorrectQuery242
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

        static IEnumerable<(Processor, string)> InCorrectQuery243
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(5555);
                sv[1, 0] = new SignValue(5555);
                yield return (new Processor(sv, "m"), "A");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery244
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(6666);
                sv[1, 0] = new SignValue(6666);
                yield return (new Processor(sv, "m"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery245
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

        static IEnumerable<(Processor, string)> InCorrectQuery246
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

        static IEnumerable<(Processor, string)> InCorrectQuery247
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

        static IEnumerable<(Processor, string)> InCorrectQuery248
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

        static IEnumerable<(Processor, string)> InCorrectQuery249
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

        static IEnumerable<(Processor, string)> InCorrectQuery250
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

        static IEnumerable<(Processor, string)> InCorrectQuery251
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

        static IEnumerable<(Processor, string)> InCorrectQuery252
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

        static IEnumerable<(Processor, string)> InCorrectQuery253
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

        static IEnumerable<(Processor, string)> InCorrectQuery254
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

        static IEnumerable<(Processor, string)> InCorrectQuery255Exception
        {
            get
            {
                yield return (new Processor(new SignValue[1, 1], "q"), "a");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery256Exception
        {
            get
            {
                yield return (new Processor(new SignValue[2, 1], "w"), "b");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery257Exception
        {
            get
            {
                yield return (new Processor(new SignValue[1, 2], "e"), "c");
            }
        }

        static IEnumerable<(Processor, string)> InCorrectQuery258
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

        static IEnumerable<(Processor, string)> InCorrectQuery259
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

        static IEnumerable<(Processor, string)> InCorrectQuery260
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

        static IEnumerable<(Processor, string)> InCorrectQuery261
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

        static IEnumerable<(Processor, string)> InCorrectQuery262
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

        static IEnumerable<(Processor, string)> InCorrectQuery263
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

        static IEnumerable<(Processor, string)> InCorrectQuery264
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

        static IEnumerable<(Processor, string)> InCorrectQuery265
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

        static IEnumerable<(Processor, string)> InCorrectQuery266
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

        static IEnumerable<(Processor, string)> InCorrectQuery267
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

        static IEnumerable<(Processor, string)> InCorrectQuery268
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
                Assert.AreEqual(1, pActual.Height);
                Assert.AreEqual(1, pActual.Width);
                Assert.AreEqual(1, pExpected.Height);
                Assert.AreEqual(1, pExpected.Width);
                Assert.AreEqual(pExpected[0, 0], pActual[0, 0]);
            }

            Assert.AreEqual(0, dicActual.Count);
        }

        static IEnumerable<Processor> GetProcessorsFromQuery(IEnumerable<(Processor, string)> query)
        {
            Assert.AreNotEqual(null, query);

            string GetCleanTag(string tag)
            {
                int k = tag.Length;

                for (k--; k > 0; k--)
                    if (tag[k] != '0')
                        break;

                return tag.Substring(0, k + 1);
            }

            ProcessorHandler ph = new ProcessorHandler();

            foreach ((Processor p, string tag) in query)
                for (int x = 0; x < p.Width; x++)
                    for (int y = 0; y < p.Height; y++)
                        ph.Add(new Processor(new[] { p[x, y] }, tag));

            ProcessorContainer pc = ph.Processors;
            for (int k = 0; k < pc.Count; k++)
                yield return ProcessorHandler.ChangeProcessorTag(pc[k], GetCleanTag(pc[k].Tag));
        }

        static void NeuronTestSub(IEnumerable<Processor> pcActual, IEnumerable<(Processor, string)> pcRequest, IEnumerable<Processor> pcRequestProcessors)
        {
            Neuron parentNeuron = new Neuron(new ProcessorContainer(pcActual.ToArray()));
            CheckNeuronMapValue(parentNeuron, pcActual);
            CheckNeuronMapValue(parentNeuron.FindRelation(pcRequest), pcRequestProcessors);
            CheckNeuronMapValue(parentNeuron, pcActual);
        }

        static PropertyInfo GetResult(PropertyInfo prop)
        {
            foreach (PropertyInfo p in typeof(NeuronTest).GetTypeInfo().DeclaredProperties)
                if (p.Name.EndsWith("Result"))
                    if (p.Name.StartsWith(prop.Name))
                        return p;
            return prop;
        }

        [TestMethod]
        public void NeuronTest0()
        {
            foreach (PropertyInfo p in typeof(NeuronTest).GetTypeInfo().DeclaredProperties)
            {
                object pi = p.GetValue(null);
                if (p.Name.StartsWith("Correct"))
                {
                    IEnumerable<(Processor, string)> ppi = (IEnumerable<(Processor, string)>) pi;
                    PropertyInfo result = GetResult(p);
                    //связать наборы с запросами, сделать это можно по буквам
                }

                if (p.Name.StartsWith("InCorrect"))
                {
                    IEnumerable<(Processor, string)> ppi = (IEnumerable<(Processor, string)>) pi;
                }
            }

            NeuronTestSub(Processors0, CorrectQuery0, GetProcessorsFromQuery(CorrectQuery0));
            NeuronTestSub(Processors1, Processors1, CorrectQuery1, GetProcessorsFromQuery(CorrectQuery1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery2));
            NeuronTestSub(Processors1, Processors1, CorrectQuery3, GetProcessorsFromQuery(CorrectQuery3));
            NeuronTestSub(Processors1, Processors1, CorrectQuery4, GetProcessorsFromQuery(CorrectQuery4));
            NeuronTestSub(Processors1, Processors1, CorrectQuery5, GetProcessorsFromQuery(CorrectQuery5));
            NeuronTestSub(Processors1, Processors1, CorrectQuery5_1, GetProcessorsFromQuery(CorrectQuery5_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery6, GetProcessorsFromQuery(CorrectQuery6));
            NeuronTestSub(Processors1, Processors1, CorrectQuery6_1, GetProcessorsFromQuery(CorrectQuery6_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery7, GetProcessorsFromQuery(CorrectQuery7));
            NeuronTestSub(Processors1, Processors1, CorrectQuery7_1, GetProcessorsFromQuery(CorrectQuery7_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery8, GetProcessorsFromQuery(CorrectQuery8));
            NeuronTestSub(Processors1, Processors1, CorrectQuery8_1, GetProcessorsFromQuery(CorrectQuery8_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery8_2, GetProcessorsFromQuery(CorrectQuery8_2));
            NeuronTestSub(Processors1, Processors1, CorrectQuery90, GetProcessorsFromQuery(CorrectQuery90));
            NeuronTestSub(Processors1, Processors1, CorrectQuery9_0, GetProcessorsFromQuery(CorrectQuery9_0));
            NeuronTestSub(Processors1, Processors1, CorrectQuery9_1, GetProcessorsFromQuery(CorrectQuery9_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery9_1_1, GetProcessorsFromQuery(CorrectQuery9_1_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery9_2, GetProcessorsFromQuery(CorrectQuery9_2));
            NeuronTestSub(Processors1, Processors1, CorrectQuery9_3, GetProcessorsFromQuery(CorrectQuery9_3));
            NeuronTestSub(Processors1, Processors1, CorrectQuery10_0, GetProcessorsFromQuery(CorrectQuery10_0));
            NeuronTestSub(Processors1, Processors1, CorrectQuery10_1, GetProcessorsFromQuery(CorrectQuery10_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery10_1_1, GetProcessorsFromQuery(CorrectQuery10_1));
            NeuronTestSub(Processors1, Processors1, CorrectQuery10_2, GetProcessorsFromQuery(CorrectQuery10_2));
            NeuronTestSub(Processors1, Processors1, CorrectQuery10_3, GetProcessorsFromQuery(CorrectQuery10_3));
            NeuronTestSub(Processors1, Processors1, CorrectQuery11, GetProcessorsFromQuery(CorrectQuery11));
            NeuronTestSub(Processors1, Processors1, CorrectQuery12, GetProcessorsFromQuery(CorrectQuery12));
            NeuronTestSub(Processors1, Processors1, CorrectQuery13, GetProcessorsFromQuery(CorrectQuery13));
            NeuronTestSub(Processors1, Processors1, CorrectQuery14, CorrectQuery14Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery15, GetProcessorsFromQuery(CorrectQuery15));
            NeuronTestSub(Processors1, Processors1, CorrectQuery16, GetProcessorsFromQuery(CorrectQuery16));
            NeuronTestSub(Processors1, Processors1, CorrectQuery17, GetProcessorsFromQuery(CorrectQuery17));
            NeuronTestSub(Processors1, Processors1, CorrectQuery18, GetProcessorsFromQuery(CorrectQuery18));
            NeuronTestSub(Processors1, Processors1, CorrectQuery19, CorrectQuery19Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery20, CorrectQuery20Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery21, CorrectQuery21Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery22, CorrectQuery22Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery23, CorrectQuery23Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery24, CorrectQuery24Result);
            NeuronTestSub(Processors1, Processors1, CorrectQuery24, CorrectQuery46Result);

            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery25));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery26));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery27));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery28));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery29));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery30));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery31));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery32));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery33));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery34));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery35));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery36));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery37));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery38));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery39));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery40));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery41));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery42));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery43));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery44));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery45));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery46));
            NeuronTestSub(Processors2, Processors2, CorrectQuery2, GetProcessorsFromQuery(CorrectQuery47));
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