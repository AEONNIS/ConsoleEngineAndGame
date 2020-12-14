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
        public void Magnitude_Vector2Int_ExpectedMagnitude(in Vector2Int vector, double expectedMagnitude)
        {
            double actualMagnitude = vector.Magnitude;

            Assert.AreEqual(expectedMagnitude, actualMagnitude, _delta);
        }

        [TestCaseSource(nameof(SqrMagnitudeCases))]
        public void SqrMagnitude_Vector2Int_ExpectedSqrMagnitude(in Vector2Int vector, double expectedSqrMagnitude)
        {
            double actualSqrMagnitude = vector.SqrMagnitude;

            Assert.AreEqual(expectedSqrMagnitude, actualSqrMagnitude, _delta);
        }
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(DistanceCases))]
        public void Distance_Vector2Ints_ExpectedDistance(in Vector2Int a, in Vector2Int b, double expectedDistance)
        {
            double actualDistance = a.Distance(b);

            Assert.AreEqual(expectedDistance, actualDistance, _delta);
        }

        [TestCaseSource(nameof(SqrDistanceCases))]
        public void SqrDistance_Vector2Ints_ExpectedSqrDistance(in Vector2Int a, in Vector2Int b, double expectedSqrDistance)
        {
            double actualSqrDistance = a.SqrDistance(b);

            Assert.AreEqual(expectedSqrDistance, actualSqrDistance, _delta);
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

        private static object[] DistanceCases() => new object[]
        {
            new object[] { new Vector2Int(0, 0), new Vector2Int(2, 3), 3.606 },
            new object[] { new Vector2Int(5, 3), new Vector2Int(1, 2), 4.123 },
            new object[] { new Vector2Int(7, -9), new Vector2Int(-5, 3), 16.971 }
        };

        private static object[] SqrDistanceCases() => new object[]
        {
            new object[] { new Vector2Int(0, 0), new Vector2Int(2, 3), 13 },
            new object[] { new Vector2Int(5, 3), new Vector2Int(1, 2), 17 },
            new object[] { new Vector2Int(7, -9), new Vector2Int(-5, 3), 288 }
        };
        #endregion
    }
}
