﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        #region Processors

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

        static IEnumerable<Processor> Processors1
        {
            get
            {
                yield return new Processor(new[] { new SignValue(12451893) }, "a");
                yield return new Processor(new[] { new SignValue(8418982) }, "b");
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

        static IEnumerable<Processor> Processors0Exception
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

        static IEnumerable<Processor> Processors1Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "y");
                yield return new Processor(sv, "y1");
            }
        }

        static IEnumerable<Processor> Processors2Exception
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

        static IEnumerable<Processor> Processors3Exception
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

        static IEnumerable<Processor> Processors4Exception
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

        static IEnumerable<Processor> Processors5Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "y");
                yield return new Processor(sv, "Y1");
            }
        }

        static IEnumerable<Processor> Processors6Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "Y");
                yield return new Processor(sv, "y1");
            }
        }

        static IEnumerable<Processor> Processors7Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "Y");
                yield return new Processor(sv, "Y1");
            }
        }

        static IEnumerable<Processor> Processors8Exception
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

        static IEnumerable<Processor> Processors9Exception
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

        static IEnumerable<Processor> Processors10Exception
        {
            get { yield return new Processor(new SignValue[2, 2], "Exception8"); }
        }

        static IEnumerable<Processor> Processors11Exception
        {
            get { yield return new Processor(new SignValue[1, 2], "Exception9"); }
        }

        static IEnumerable<Processor> Processors12Exception
        {
            get { yield return new Processor(new SignValue[2, 1], "Exception10"); }
        }

        static IEnumerable<Processor> Processors13Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "a");
                yield return new Processor(sv, "b");
            }
        }

        static IEnumerable<Processor> Processors14Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                sv[0, 0] = new SignValue(5555);
                yield return new Processor(sv, "k");
                yield return new Processor(sv, "k");
            }
        }

        static IEnumerable<Processor> Processors15Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 1];
                yield return new Processor(sv, "a");
                sv = new SignValue[2, 1];
                yield return new Processor(sv, "b");
            }
        }

        static IEnumerable<Processor> Processors16Exception
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                yield return new Processor(sv, "b");
                sv = new SignValue[1, 1];
                yield return new Processor(sv, "a");
            }
        }

        static IEnumerable<Processor> Processors17Exception
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

        static IEnumerable<Processor> Processors18Exception
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

        static IEnumerable<Processor> Processors19Exception
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
                yield return new Processor(sv, "40");
            }
        }

        #endregion //Processors

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

        static IEnumerable<(Processor, string)> CorrectQuery1
        {
            get
            {
                yield return (new Processor(new[] { new SignValue(12451382) }, "pA"), "a");
                yield return (new Processor(new[] { new SignValue(8418581) }, "pB"), "b");
            }
        }

        static IEnumerable<Processor> CorrectQuery1Result
        {
            get
            {
                yield return new Processor(new[] { new SignValue(12451382) }, "A");
                yield return new Processor(new[] { new SignValue(8418581) }, "B");
            }
        }

        static IEnumerable<(Processor, string)> CorrectQuery2
        {
            get
            {
                yield return (new Processor(new[] { new SignValue(12451893) }, "qA"), "a");
                yield return (new Processor(new[] { new SignValue(8418982) }, "qB"), "b");
            }
        }

        static IEnumerable<Processor> CorrectQuery2Result
        {
            get
            {
                yield return new Processor(new[] { new SignValue(12451893) }, "A");
                yield return new Processor(new[] { new SignValue(8418982) }, "B");
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

        static IEnumerable<Processor> CorrectGlobalProcessorQueryResult
        {
            get
            {
                yield return _globalProcessor0;
                yield return _globalProcessor1;
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

        static IEnumerable<(Processor, string)> IncorrectQuery2
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
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

        static IEnumerable<(Processor, string)> IncorrectQuery3
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), "2");
                sv[0, 0] = new SignValue(3333);
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), "4");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery4
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
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), "4");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery5
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
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery6
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
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                yield return (new Processor(sv, "p5"), "5");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery7
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (null, "2");
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

        static IEnumerable<(Processor, string)> IncorrectQuery8
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
                yield return (null, "4");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery9
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (null, "2");
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), "1");
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), "3");
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (null, "4");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery10
        {
            get
            {
                yield return (null, "5");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery11
        {
            get
            {
                yield return (null, null);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery12
        {
            get
            {
                yield return (null, string.Empty);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery13
        {
            get
            {
                yield return (null, " ");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery14
        {
            get
            {
                yield return (null, "\t");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery15
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
                yield return (null, null);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery16
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
                yield return (null, string.Empty);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery17
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
                yield return (null, " ");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery18
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
                yield return (null, "\t");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery19
        {
            get
            {
                yield return (null, null);
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

        static IEnumerable<(Processor, string)> IncorrectQuery20
        {
            get
            {
                yield return (null, string.Empty);
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

        static IEnumerable<(Processor, string)> IncorrectQuery21
        {
            get
            {
                yield return (null, " ");
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

        static IEnumerable<(Processor, string)> IncorrectQuery22
        {
            get
            {
                yield return (null, "\t");
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

        static IEnumerable<(Processor, string)> IncorrectQuery23
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
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), null);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery24
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
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), string.Empty);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery25
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
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), " ");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery26
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
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), "\t");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery27
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), null);
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

        static IEnumerable<(Processor, string)> IncorrectQuery28
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), string.Empty);
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

        static IEnumerable<(Processor, string)> IncorrectQuery29
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), " ");
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

        static IEnumerable<(Processor, string)> IncorrectQuery30
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), "\t");
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

        static IEnumerable<(Processor, string)> IncorrectQuery31
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), null);
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

        static IEnumerable<(Processor, string)> IncorrectQuery32
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), string.Empty);
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

        static IEnumerable<(Processor, string)> IncorrectQuery33
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), " ");
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

        static IEnumerable<(Processor, string)> IncorrectQuery34
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), "\t");
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

        static IEnumerable<(Processor, string)> IncorrectQuery35
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
                yield return (new Processor(sv, "p4"), null);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery36
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
                yield return (new Processor(sv, "p4"), string.Empty);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery37
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
                yield return (new Processor(sv, "p4"), " ");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery38
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
                yield return (new Processor(sv, "p4"), "\t");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery39
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), null);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery40
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), string.Empty);
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery41
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), " ");
            }
        }

        static IEnumerable<(Processor, string)> IncorrectQuery42
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), "\t");
            }
        }

        #endregion //Incorrect

        #endregion //Tests

        static void CheckNeuronValue(Neuron actual, IEnumerable<Processor> pcExpected)
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

        static void CheckException(Action act)
        {
            try
            {
                act();
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(ArgumentException))
                    throw;
            }
        }

        [TestMethod]
        public void NeuronTest0()
        {
            IEnumerable<Processor> GetProcessors()
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3338);
                yield return new Processor(sv, "1");
                sv[0, 0] = new SignValue(2227);
                yield return new Processor(sv, "2");
                sv[0, 0] = new SignValue(1116);
                yield return new Processor(sv, "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1116);
                yield return new Processor(sv, "4");
            }

            IEnumerable<(Processor, string)> GetCorrectQuery()
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), "1");
                sv[0, 0] = new SignValue(2222);
                yield return (new Processor(sv, "p2"), "2");
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), "4");
            }

            IEnumerable<(Processor, string)> GetProcessorsReverse()
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(3338);
                yield return (new Processor(sv, "pr1"), "1");
                sv[0, 0] = new SignValue(2227);
                yield return (new Processor(sv, "pr2"), "2");
                sv[0, 0] = new SignValue(1116);
                yield return (new Processor(sv, "pr3"), "3");
                sv[0, 0] = new SignValue();
                sv[0, 1] = new SignValue(1116);
                yield return (new Processor(sv, "pr4"), "3");
            }

            Neuron mainNeuron = new Neuron(new ProcessorContainer(GetProcessors().ToArray()));
            Neuron parentNeuron = mainNeuron.FindRelation(GetCorrectQuery());

            List<Thread> thrs = new List<Thread>(200);
            for (int thrIndex = 0; thrIndex < 200; thrIndex++)
            {
                Thread thread = new Thread(() =>
                    {
                        List<Neuron> derivedNeurons1 = new List<Neuron>(1000000);
                        List<Neuron> derivedNeurons2 = new List<Neuron>(1000000);
                        List<Neuron> derivedNeuronsMain = new List<Neuron>(1000000);

                        for (int k = 0; k < 1000000; k++)
                        {
                            void CheckCurrentState()
                            {
                                CheckNeuronValue(mainNeuron, GetProcessors());
                                CheckNeuronValue(parentNeuron, Processors0);

                                CheckNeuronValue(mainNeuron.FindRelation(GetCorrectQuery()), Processors0);
                                CheckNeuronValue(parentNeuron.FindRelation(CorrectQuery0), CorrectQuery0Result);
                                CheckNeuronValue(parentNeuron.FindRelation(GetProcessorsReverse()), GetProcessors());

                                foreach (Neuron derivedNeuron in derivedNeuronsMain)
                                    CheckNeuronValue(derivedNeuron, Processors0);

                                foreach (Neuron derivedNeuron in derivedNeurons1)
                                    CheckNeuronValue(derivedNeuron, CorrectQuery0Result);

                                foreach (Neuron derivedNeuron in derivedNeurons2)
                                    CheckNeuronValue(derivedNeuron, GetProcessors());
                            }

                            derivedNeuronsMain.Add(mainNeuron.FindRelation(GetCorrectQuery()));
                            CheckCurrentState();
                            derivedNeurons1.Add(parentNeuron.FindRelation(CorrectQuery0));
                            CheckCurrentState();
                            derivedNeurons2.Add(parentNeuron.FindRelation(GetProcessorsReverse()));
                            CheckCurrentState();

                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery0));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery1));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery2));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery3));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery4));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery5));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery6));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery7));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery8));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery9));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery10));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery11));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery12));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery13));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery14));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery15));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery16));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery17));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery18));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery19));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery20));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery21));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery22));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery23));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery24));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery25));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery26));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery27));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery28));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery29));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery30));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery31));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery32));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery33));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery34));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery35));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery36));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery37));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery38));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery39));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery40));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery41));
                            CheckCurrentState();
                            CheckException(() => parentNeuron.FindRelation(IncorrectQuery42));
                            CheckCurrentState();
                        }
                    })
                { IsBackground = true, Priority = ThreadPriority.AboveNormal, Name = $"Number: {thrIndex}" };
                thread.Start();
                thrs.Add(thread);
            }

            foreach (Thread t in thrs)
                t.Join();
        }

        [TestMethod]
        public void NeuronTest1()
        {
            Neuron neuron = new Neuron(new ProcessorContainer(Processors1.ToArray()));

            for (int k = 0; k < 2; k++)
            {
                CheckNeuronValue(neuron.FindRelation(CorrectQuery1), CorrectQuery1Result);
                CheckNeuronValue(neuron, Processors1);
            }
        }

        [TestMethod]
        public void NeuronTest2()
        {
            Neuron neuron = new Neuron(new ProcessorContainer(Processors1.ToArray()));

            for (int k = 0; k < 2; k++)
            {
                CheckNeuronValue(neuron.FindRelation(CorrectQuery2), CorrectQuery2Result);
                CheckNeuronValue(neuron, Processors1);
            }
        }

        [TestMethod]
        public void NeuronTest3()
        {
            Neuron neuron = new Neuron(new ProcessorContainer(ProcessorsForNeuronGlobal.ToArray()));

            for (int k = 0; k < 2; k++)
            {
                CheckNeuronValue(neuron.FindRelation(CorrectGlobalProcessorQuery), CorrectGlobalProcessorQueryResult);
                CheckNeuronValue(neuron, ProcessorsForNeuronGlobal);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException0() => new Neuron(new ProcessorContainer(Processors0Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException1() => new Neuron(new ProcessorContainer(Processors1Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException2() => new Neuron(new ProcessorContainer(Processors2Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException3() => new Neuron(new ProcessorContainer(Processors3Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException4() => new Neuron(new ProcessorContainer(Processors4Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException5() => new Neuron(new ProcessorContainer(Processors5Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException6() => new Neuron(new ProcessorContainer(Processors6Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException7() => new Neuron(new ProcessorContainer(Processors7Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException8() => new Neuron(new ProcessorContainer(Processors8Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException9() => new Neuron(new ProcessorContainer(Processors9Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException10() => new Neuron(new ProcessorContainer(Processors10Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException11() => new Neuron(new ProcessorContainer(Processors11Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException12() => new Neuron(new ProcessorContainer(Processors12Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException13() => new Neuron(new ProcessorContainer(Processors13Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException14() => new Neuron(new ProcessorContainer(Processors14Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException15() => new Neuron(new ProcessorContainer(Processors15Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException16() => new Neuron(new ProcessorContainer(Processors16Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException17() => new Neuron(new ProcessorContainer(Processors17Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException18() => new Neuron(new ProcessorContainer(Processors18Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException19() => new Neuron(new ProcessorContainer(Processors19Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException20() => new Neuron(new ProcessorContainer(Processors20Exception.ToArray()));

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronTestException21() => new Neuron(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException22() => new Neuron(new ProcessorContainer(new Processor(new[] { SignValue.MaxValue }, "t")));
    }
}