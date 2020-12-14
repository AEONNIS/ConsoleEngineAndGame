using ConsoleEngine.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class PixelForegroundTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_VariousPixelForegrounds_ReturnExpectedPixelForeground(in PixelForeground a, in PixelForeground b,
                                                                                       in PixelForeground expectedPixelForeground)
        {
            PixelForeground actualPixelForeground = (a + b);

            Assert.AreEqual(expectedPixelForeground, actualPixelForeground);
        }
        #endregion

        #region TestsCases
        private static object[] OperatorPlusCases() => new object[]
        {
            new object[] { new PixelForeground(null, ' '), new PixelForeground(null, '-'),
                           new PixelForeground(null, '-') },

            new object[] { new PixelForeground(null, ' '), new PixelForeground(ConsoleColor.Black, '-'),
                           new PixelForeground(ConsoleColor.Black, '-') },

            new object[] { new PixelForeground(ConsoleColor.Black, ' '), new PixelForeground(null, '-'),
                           new PixelForeground(ConsoleColor.Black, '-') },

            new object[] { new PixelForeground(ConsoleColor.Black, ' '), new PixelForeground(ConsoleColor.White, '-'),
                           new PixelForeground(ConsoleColor.White, '-') }
        };
        #endregion
    }
}
