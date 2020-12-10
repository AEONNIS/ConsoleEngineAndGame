using ConsoleEngine.DisplaySystem;
using NUnit.Framework;
using System;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class PixelForegroundTests
    {
        #region OperatorsTests
        [TestCaseSource(nameof(EqualPixelForegroundsCases), new object[] { true })]
        [TestCaseSource(nameof(NotEqualPixelForegroundsCases), new object[] { false })]
        public void OperatorEquals_VariousPixelForegrounds_ChecksThem(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a == b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(EqualPixelForegroundsCases), new object[] { false })]
        [TestCaseSource(nameof(NotEqualPixelForegroundsCases), new object[] { true })]
        public void OperatorNotEquals_VariousPixelForegrounds_ChecksThem(PixelForeground a, PixelForeground b, bool expected)
        {
            bool actual = (a != b);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(OperatorPlusCases))]
        public void OperatorPlus_VariousPixelForegrounds_ReturnExpectedPixelForegrounds(PixelForeground a, PixelForeground b, PixelForeground expected)
        {
            PixelForeground actual = (a + b);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region MethodTests
        [TestCaseSource(nameof(ToStringCases))]
        public void ToString_VariousPixelForegrounds_ReturnExpectedStringRepresentation(PixelForeground pixelForeground, string expected)
        {
            string actual = pixelForeground.ToString();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region OperatorsTestsCases
        private static object[] EqualPixelForegroundsCases(bool comparisonResult)
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
        private static object[] NotEqualPixelForegroundsCases(bool comparisonResult)
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

        private static object[] OperatorPlusCases()
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
                               new PixelForeground { Color = ConsoleColor.White, Symbol = '-' } }
            };
        }
        #endregion

        #region MethodsTestsCases
        private static object[] ToStringCases()
        {
            return new object[]
            {
                new object[] { new PixelForeground { Color = ConsoleColor.Black, Symbol = '-' },
                               $"FgC:{ConsoleColor.Black}, Smb:'-'" },
                new object[] { new PixelForeground { Color = null,               Symbol = '-' },
                               $"FgC:Empty, Smb:'-'" }
            };
        }
        #endregion
    }
}