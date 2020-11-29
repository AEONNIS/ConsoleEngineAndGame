using ConsoleEngine.Core.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.Core.DisplaySystem
{
    public class PixelForegroundTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(GetCasesWithEqualPixelForegrounds), new object[] { true })]
        [TestCaseSource(nameof(GetCasesWithNotEqualPixelForegrounds), new object[] { false })]
        public void OperatorEquals(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a == b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(GetCasesWithEqualPixelForegrounds), new object[] { false })]
        [TestCaseSource(nameof(GetCasesWithNotEqualPixelForegrounds), new object[] { true })]
        public void OperatorNotEquals(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a != b);

            Assert.AreEqual(expected, actual);
        }

        private static object[] GetCasesWithEqualPixelForegrounds(bool comparisonResult)
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
        private static object[] GetCasesWithNotEqualPixelForegrounds(bool comparisonResult)
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
        #endregion
    }
}