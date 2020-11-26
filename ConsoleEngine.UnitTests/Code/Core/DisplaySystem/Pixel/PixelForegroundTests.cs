using ConsoleEngine.Core.DisplaySystem;
using System;
using Xunit;

namespace ConsoleEngine.UnitTests.Core.DisplaySystemTests
{
    #region OperatorsTests
    public class PixelForegroundTests
    {
        [Fact]
        public void OperatorEquals_EqualPixels_ReturnTrue()
        {
            PixelForeground redDashA = new PixelForeground { Color = ConsoleColor.Red, Symbol = '-' };
            PixelForeground redDashB = new PixelForeground { Color = ConsoleColor.Red, Symbol = '-' };

            bool actual = (redDashA == redDashB);

            Assert.True(actual);
        }
    }
    #endregion
}
