using ConsoleEngine.Core.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.Core.DisplaySystem
{
    [TestFixture]
    public class PixelForegroundTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(CasesWithEqualPixelForegrounds), new object[] { true })]
        [TestCaseSource(nameof(CasesWithNotEqualPixelForegrounds), new object[] { false })]
        public void OperatorEquals_VariousPixelForegrounds_ChecksThem(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a == b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(CasesWithEqualPixelForegrounds), new object[] { false })]
        [TestCaseSource(nameof(CasesWithNotEqualPixelForegrounds), new object[] { true })]
        public void OperatorNotEquals_VariousPixelForegrounds_ChecksThem(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a != b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(PixelForegroundsCasesForOperatorPlus))]
        public void OperatorPlus(PixelForeground a, PixelForeground b, PixelForeground expected)
        {
            PixelForeground actual = (a + b);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region OperatorsCases
        private static object[] CasesWithEqualPixelForegrounds(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               comparisonResult },
                new object[] { new PixelForeground { Color = null,               Symbol = ' ' },
                               new PixelForeground { Color = null,               Symbol = ' ' },
                               comparisonResult }
            };
        }
        private static object[] CasesWithNotEqualPixelForegrounds(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.White, Symbol = ' ' },
                               comparisonResult },
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.Black, Symbol = '-' },
                               comparisonResult },
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.White, Symbol = '-' },
                               comparisonResult },
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = null,               Symbol = ' ' },
                               comparisonResult },
                new object[] { new PixelForeground { Color = null,               Symbol = ' '},
                               new PixelForeground { Color = null,               Symbol = '-' },
                               comparisonResult }
            };
        }

        private static object[] PixelForegroundsCasesForOperatorPlus()
        {
            return new object[]
            {
                new object[] { new PixelForeground { Color = null,               Symbol = ' ' },
                               new PixelForeground { Color = null,               Symbol = '-' },
                               new PixelForeground { Color = null,               Symbol = '-' } },

                new object[] { new PixelForeground { Color = null,               Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.Black, Symbol = '-' },
                               new PixelForeground { Color = ConsoleColor.Black, Symbol = '-' } },

                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = null,               Symbol = '-' },
                               new PixelForeground { Color = ConsoleColor.Black, Symbol = '-' } },

                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' },
                               new PixelForeground { Color = ConsoleColor.White, Symbol = '-' },
                               new PixelForeground { Color = ConsoleColor.White, Symbol = '-' } },
            };
        }
        #endregion
    }
}