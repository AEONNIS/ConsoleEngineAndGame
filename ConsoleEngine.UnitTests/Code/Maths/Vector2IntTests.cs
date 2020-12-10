using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.UnitTests.Maths
{
    [TestFixture]
    public class Vector2IntTests
    {
        #region MethodssTests
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
