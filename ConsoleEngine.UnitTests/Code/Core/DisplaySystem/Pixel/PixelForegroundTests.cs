using ConsoleEngine.Core.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.Core.DisplaySystem
{
    #region OperatorsTests
    public class PixelForegroundTests
    {
        [Test]
        public void OperatorEquals()
        {
            PixelForeground redDashA = new PixelForeground { Color = ConsoleColor.Red, Symbol = '-' };
            PixelForeground redDashB = new PixelForeground { Color = ConsoleColor.Red, Symbol = '-' };

            bool result = redDashA == redDashB;

            Assert.True(result);
        }
        #endregion
    }
}