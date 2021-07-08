using Engine.DisplaySystem;
using NUnit.Framework;
using System;

namespace Engine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class PixelForegroundTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_SomePixelForegrounds_ReturnsAdditionResult(in PixelForeground minor, in PixelForeground major,
                                                                            in PixelForeground additionResult)
        {
            PixelForeground actualAdditionResult = minor + major;

            Assert.That(additionResult, Is.EqualTo(actualAdditionResult));
        }

        private static object[] OperatorPlusCases()
        {
            var minor1 = new PixelForeground(null, ' ');
            var major1 = new PixelForeground(null, '-');
            var additionResult1 = new PixelForeground(null, '-');
            var case1 = new PixelForeground[] { minor1, major1, additionResult1 };

            var minor2 = new PixelForeground(null, ' ');
            var major2 = new PixelForeground(ConsoleColor.Black, '-');
            var additionResult2 = new PixelForeground(ConsoleColor.Black, '-');
            var case2 = new PixelForeground[] { minor2, major2, additionResult2 };

            var minor3 = new PixelForeground(ConsoleColor.Black, ' ');
            var major3 = new PixelForeground(null, '-');
            var additionResult3 = new PixelForeground(ConsoleColor.Black, '-');
            var case3 = new PixelForeground[] { minor3, major3, additionResult3 };

            var minor4 = new PixelForeground(ConsoleColor.Black, ' ');
            var major4 = new PixelForeground(ConsoleColor.White, '-');
            var additionResult4 = new PixelForeground(ConsoleColor.White, '-');
            var case4 = new PixelForeground[] { minor4, major4, additionResult4 };

            return new object[] { case1, case2, case3, case4 };
        }
        #endregion
    }
}
