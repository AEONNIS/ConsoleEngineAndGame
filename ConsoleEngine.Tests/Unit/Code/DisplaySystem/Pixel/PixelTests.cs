using ConsoleEngine.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.Tests.Unit.DisplaySystem
{
    [TestFixture]
    public class PixelTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_SomePixels_ReturnsAdditionResult(in Pixel minor, in Pixel major, in Pixel additionResult)
        {
            Pixel actualAdditionResult = minor + major;

            Assert.That(additionResult, Is.EqualTo(actualAdditionResult));
        }

        private static object[] OperatorPlusCases()
        {
            var minor1 = new Pixel(null, PixelForeground.BlackSpace);
            var major1 = new Pixel(null, PixelForeground.WhiteSpace);
            var additionResult1 = new Pixel(null, PixelForeground.WhiteSpace);
            var case1 = new Pixel[] { minor1, major1, additionResult1 };

            var minor2 = new Pixel(null, PixelForeground.BlackSpace);
            var major2 = new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace);
            var additionResult2 = new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace);
            var case2 = new Pixel[] { minor2, major2, additionResult2 };

            var minor3 = new Pixel(ConsoleColor.Black, PixelForeground.BlackSpace);
            var major3 = new Pixel(null, PixelForeground.WhiteSpace);
            var additionResult3 = new Pixel(ConsoleColor.Black, PixelForeground.WhiteSpace);
            var case3 = new Pixel[] { minor3, major3, additionResult3 };

            var minor4 = new Pixel(ConsoleColor.Black, PixelForeground.BlackSpace);
            var major4 = new Pixel(ConsoleColor.White, PixelForeground.WhiteSpace);
            var additionResult4 = new Pixel(ConsoleColor.White, PixelForeground.WhiteSpace);
            var case4 = new Pixel[] { minor4, major4, additionResult4 };

            return new object[] { case1, case2, case3, case4 };
        }
        #endregion
    }
}
