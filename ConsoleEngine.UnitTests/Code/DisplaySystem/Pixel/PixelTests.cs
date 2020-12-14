using ConsoleEngine.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class PixelTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_VariousPixels_ReturnExpectedPixel(in Pixel a, in Pixel b, in Pixel expectedPixel)
        {
            Pixel actualPixel = (a + b);

            Assert.AreEqual(expectedPixel, actualPixel);
        }
        #endregion

        #region TestsCases
        private static object[] OperatorPlusCases() => new object[]
        {
            new object[] { new Pixel(null, PixelForeground.BlackSpace), new Pixel(null, PixelForeground.WhiteSpace),
                           new Pixel(null, PixelForeground.WhiteSpace) },

            new object[] { new Pixel(null, PixelForeground.BlackSpace), new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace),
                           new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace) },

            new object[] { new Pixel(ConsoleColor.Black, PixelForeground.BlackSpace), new Pixel(null, PixelForeground.WhiteSpace),
                           new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace) },

            new object[] { new Pixel(ConsoleColor.Black, PixelForeground.BlackSpace), new Pixel(ConsoleColor.White, PixelForeground.WhiteSpace),
                           new Pixel(ConsoleColor.White, PixelForeground.WhiteSpace) }
        };
        #endregion
    }
}
