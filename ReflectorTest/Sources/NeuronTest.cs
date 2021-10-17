using System;
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
        }

        static IEnumerable<Processor> Processors1
        {
            get
            {
                yield return new Processor(new[] { new SignValue(12451893) }, "A");
                yield return new Processor(new[] { new SignValue(8418982) }, "B");
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

        static IEnumerable<Processor> Processors17
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

        static IEnumerable<Processor> Processors17Result
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

        static IEnumerable<Processor> Processors18
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

        static IEnumerable<Processor> Processors18Result
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

        static IEnumerable<Processor> Processors19
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

        static IEnumerable<Processor> Processors19Result
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

        static IEnumerable<Processor> Processors20
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

        static IEnumerable<Processor> Processors20Result
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

        #endregion //Processors

        #region Correct

        static IEnumerable<(Processor, char)> CorrectQuery0
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
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

        static IEnumerable<(Processor, char)> CorrectQuery1
        {
            get
            {
                yield return (new Processor(new[] { new SignValue(12451382) }, "pA"), 'a');
                yield return (new Processor(new[] { new SignValue(8418581) }, "pB"), 'b');
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

        static IEnumerable<(Processor, char)> CorrectQuery2
        {
            get
            {
                yield return (new Processor(new[] { new SignValue(12451893) }, "qA"), 'a');
                yield return (new Processor(new[] { new SignValue(8418982) }, "qB"), 'b');
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

        static IEnumerable<(Processor, char)> CorrectGlobalProcessorQuery
        {
            get
            {
                if (_globalProcessor0 == null || _globalProcessor1 == null)
                    throw new Exception($"Сначала необходимо вызвать метод {nameof(ProcessorsForNeuronGlobal)}.");
                yield return (_globalProcessor0, 'G');
                yield return (_globalProcessor1, 'H');
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

        static IEnumerable<(Processor, char)> IncorrectQuery0
        {
            get
            {
                SignValue[,] sv = new SignValue[1, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(3333);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery1
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 1];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(3333);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery2
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery3
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery4
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery5
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery6
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                sv[0, 0] = new SignValue(777);
                yield return (new Processor(sv, "p5"), '5');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery7
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (null, '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery8
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (null, '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery9
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (null, '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (null, '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery10
        {
            get
            {
                yield return (null, '5');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery11
        {
            get
            {
                yield return (null, ' ');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery12
        {
            get
            {
                yield return (null, '\t');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery15
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
                yield return (null, ' ');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery16
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
                yield return (null, '\t');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery19
        {
            get
            {
                yield return (null, ' ');
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery20
        {
            get
            {
                yield return (null, '\t');
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery23
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), ' ');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery24
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
                sv[1, 1] = new SignValue(1112);
                yield return (new Processor(sv, "p5"), '\t');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery27
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), ' ');
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery28
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2234);
                yield return (new Processor(sv, "p0"), '\t');
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery31
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), ' ');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery32
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '\t');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '4');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery35
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), ' ');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery36
        {
            get
            {
                SignValue[,] sv = new SignValue[2, 2];
                sv[0, 0] = new SignValue(2233);
                yield return (new Processor(sv, "p1"), '2');
                sv[0, 0] = new SignValue(3333);
                yield return (new Processor(sv, "p1"), '1');
                sv[0, 0] = new SignValue();
                sv[1, 0] = new SignValue(1111);
                yield return (new Processor(sv, "p3"), '3');
                sv[1, 0] = new SignValue();
                sv[1, 1] = new SignValue(1111);
                yield return (new Processor(sv, "p4"), '\t');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery41
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), ' ');
            }
        }

        static IEnumerable<(Processor, char)> IncorrectQuery42
        {
            get
            {
                yield return (new Processor(new[] { SignValue.MaxValue, SignValue.MaxValue, SignValue.MaxValue }, "t"), '\t');
            }
        }

        #endregion //Incorrect

        #endregion //Tests

        static void CheckNeuronValue(Neuron actual, IEnumerable<Processor> pcExpected, int width, int height)
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
                    Assert.AreEqual(width, pActual.Width);
                    Assert.AreEqual(height, pActual.Height);
                    Assert.AreEqual(width, pExpected.Width);
                    Assert.AreEqual(height, pExpected.Height);
                }
                else
                {
                    Assert.AreEqual(3, pActual.Width);
                    Assert.AreEqual(3, pActual.Height);
                    Assert.AreEqual(3, pExpected.Width);
                    Assert.AreEqual(3, pExpected.Height);
                }

                Assert.AreEqual(pExpected[0, 0], pActual[0, 0]);
            }

            Assert.AreEqual(0, dicActual.Count);
        }

        static void CheckException(Action act, Type exType = null)
        {
            exType = exType ?? typeof(ArgumentException);
            try
            {
                act();
            }
            catch (Exception ex)
            {
                if (ex.GetType() != exType)
                    throw;
            }
        }

        [TestMethod]
        public void NeuronTest0()
        {
            Neuron parentNeuron = new Neuron(new ProcessorContainer(Processors0.ToArray()));
            List<Thread> thrs = new List<Thread>(200);

            for (int thrIndex = 0; thrIndex < 1 /*200*/; thrIndex++)
            {
                Thread thread = new Thread(() =>
                {
                    Neuron childNeuron0 = parentNeuron.FindRelation(CorrectQuery0);
                    for (int k = 0; k < 3; k++)
                    {
                        void CheckCurrentState()
                        {
                            CheckNeuronValue(parentNeuron, Processors0, 2, 2);
                            CheckNeuronValue(parentNeuron.FindRelation(CorrectQuery0), CorrectQuery0Result, 2, 2);
                            CheckNeuronValue(childNeuron0, CorrectQuery0Result, 2, 2);
                        }

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
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery7), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery8), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery9), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery10), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery11), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery12), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery15), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery16), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery19), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery20), typeof(ArgumentNullException));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery23));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery24));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery27));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery28));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery31));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery32));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery35));
                        CheckCurrentState();
                        CheckException(() => parentNeuron.FindRelation(IncorrectQuery36));
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
                CheckNeuronValue(neuron.FindRelation(CorrectQuery1), CorrectQuery1Result, 1, 1);
                CheckNeuronValue(neuron, Processors1, 1, 1);
            }
        }

        [TestMethod]
        public void NeuronTest2() => CheckNeuronValue(new Neuron(new ProcessorContainer(Processors17.ToArray())), Processors17Result, 2, 2);

        [TestMethod]
        public void NeuronTest3() => CheckNeuronValue(new Neuron(new ProcessorContainer(Processors19.ToArray())), Processors19Result, 2,2);

        [TestMethod]
        public void NeuronTest4() => CheckNeuronValue(new Neuron(new ProcessorContainer(Processors20.ToArray())), Processors20Result,2,2);

        [TestMethod]
        public void NeuronTest5() => CheckNeuronValue(new Neuron(new ProcessorContainer(Processors18.ToArray())), Processors18Result,2,2);

        [TestMethod]
        public void NeuronTest6()
        {
            Neuron neuron = new Neuron(new ProcessorContainer(Processors1.ToArray()));

            for (int k = 0; k < 2; k++)
            {
                CheckNeuronValue(neuron.FindRelation(CorrectQuery2), CorrectQuery2Result, 1, 1);
                CheckNeuronValue(neuron, Processors1, 1, 1);
            }
        }

        [TestMethod]
        public void NeuronTest7()
        {
            Neuron neuron = new Neuron(new ProcessorContainer(ProcessorsForNeuronGlobal.ToArray()));

            for (int k = 0; k < 2; k++)
            {
                CheckNeuronValue(neuron.FindRelation(CorrectGlobalProcessorQuery), CorrectGlobalProcessorQueryResult, 1, 1);
                CheckNeuronValue(neuron, ProcessorsForNeuronGlobal, 1, 1);
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeuronTestException17() => new Neuron(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NeuronTestException18() => new Neuron(new ProcessorContainer(new Processor(new[] { SignValue.MaxValue }, "t")));
    }
}