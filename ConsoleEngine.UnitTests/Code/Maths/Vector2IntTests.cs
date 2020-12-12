using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.UnitTests.Maths
{
    [TestFixture]
    public class Vector2IntTests
    {
        #region ConstantFields
        private const double _delta = 0.0005d;
        #endregion

        #region PropertiesTests
        [TestCaseSource(nameof(MagnitudeCases))]
        public void Magnitude_Vector2Int_ExpectedMagnitude(Vector2Int vector, double expectedMagnitude)
        {
            double actualMagnitude = vector.Magnitude;

            Assert.AreEqual(expectedMagnitude, actualMagnitude, _delta);
        }

        [TestCaseSource(nameof(SqrMagnitudeCases))]
        public void SqrMagnitude_Vector2Int_ExpectedSqrMagnitude(Vector2Int vector, double expectedSqrMagnitude)
        {
            double actualSqrMagnitude = vector.SqrMagnitude;

            Assert.AreEqual(expectedSqrMagnitude, actualSqrMagnitude, _delta);
        }
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(EqualVector2IntsCases), new object[] { true })]
        [TestCaseSource(nameof(NotEqualVector2IntsCases), new object[] { false })]
        public void GetHashCode_VariousVector2Ints_ChecksThem(Vector2Int a, Vector2Int b, bool expected)
        {
            int aHashCode = a.GetHashCode();
            int bHashCode = b.GetHashCode();

            bool actual = (aHashCode == bHashCode);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TestCases
        private static object[] MagnitudeCases() => new object[]
        {
            new object[] { new Vector2Int(1, 1), 1.414 },
            new object[] { new Vector2Int(2, 3), 3.606 },
            new object[] { new Vector2Int(7, 9), 11.402 }
        };

        private static object[] SqrMagnitudeCases() => new object[]
        {
            new object[] { new Vector2Int(1, 1), 2 },
            new object[] { new Vector2Int(2, 3), 13 },
            new object[] { new Vector2Int(7, 9), 130 }
        };


        private static object[] EqualVector2IntsCases(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new Vector2Int(0, 0), new Vector2Int(0, 0), comparisonResult },
                new object[] { new Vector2Int(-1, 5), new Vector2Int(-1, 5), comparisonResult },
                new object[] { new Vector2Int(3, 1), new Vector2Int(3, 1), comparisonResult }
            };
        }

        private static object[] NotEqualVector2IntsCases(bool comparisonResult)
        {
            return new object[]
            {
                new object[] { new Vector2Int(0, 0), new Vector2Int(1, 1), comparisonResult },
                new object[] { new Vector2Int(-1, 5), new Vector2Int(1, -5), comparisonResult },
                new object[] { new Vector2Int(3, 1), new Vector2Int(1, 3), comparisonResult }
            };
        }
        #endregion
    }
}
