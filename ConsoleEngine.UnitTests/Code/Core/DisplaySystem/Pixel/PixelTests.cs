using ConsoleEngine.Core.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.Core.DisplaySystem
{
    [TestFixture]
    public class PixelTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(EqualPixelsCases), new object[] { true })]
        [TestCaseSource(nameof(NotEqualPixelsCases), new object[] { false })]
        public void OperatorEquals_VariousPixels_ChecksThem(Pixel a, Pixel b, bool expected)
        {
            bool actual = (a == b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(EqualPixelsCases), new object[] { false })]
        [TestCaseSource(nameof(NotEqualPixelsCases), new object[] { true })]
        public void OperatorNotEquals_VariousPixels_ChecksThem(Pixel a, Pixel b, bool expected)
        {
            bool actual = (a != b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_VariousPixels_ReturnExpectedPixels(Pixel a, Pixel b, Pixel expected)
        {
            Pixel actual = (a + b);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(ToStringCases))]
        public void ToString_VariousPixels_ReturnExpectedStringRepresentation(Pixel pixel, string expected)
        {
            string actual = pixel.ToString();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region OperatorsTestsCases
        private static object[] EqualPixelsCases(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               comparisonResult },
                new object[] { new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               comparisonResult }
            };
        }
        private static object[] NotEqualPixelsCases(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.WhiteSpace },
                               comparisonResult },
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.BlackSpace },
                               comparisonResult },
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.BlackSpace },
                               comparisonResult },
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               comparisonResult },
                new object[] { new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.BlackSpace },
                               comparisonResult }
            };
        }

        private static object[] OperatorPlusCases()
        {
            return new object[]
            {
                new object[] { new Pixel { BackgroundColor = null,               Foreground = PixelForeground.BlackSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace } },

                new object[] { new Pixel { BackgroundColor = null,               Foreground = PixelForeground.BlackSpace },
                               new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace } },

                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.BlackSpace },
                               new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace } },

                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.BlackSpace },
                               new Pixel { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.WhiteSpace },
                               new Pixel { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.WhiteSpace } }
            };
        }
        #endregion

        #region MethodsTestsCases
        private static object[] ToStringCases()
        {
            return new object[]
            {
                new object[] { new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.WhiteSpace },
                               $"BgC:{ConsoleColor.Black}, {PixelForeground.WhiteSpace}" },
                new object[] { new Pixel { BackgroundColor = null,               Foreground = PixelForeground.WhiteSpace },
                               $"BgC:Empty, {PixelForeground.WhiteSpace}" }
            };
        }
        #endregion
    }
}