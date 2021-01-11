using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.Tests.Unit.Maths
{
    [TestFixture]
    public class Vector2IntTests
    {
        #region ConstantFields
        private const float _delta = 0.0005f;
        #endregion

        #region PropertiesTests
        [TestCaseSource(nameof(MagnitudeCases))]
        public void Magnitude_SomeVector_ExpectedMagnitude(in Vector2Int vector, float expectedMagnitude)
        {
            float actualMagnitude = vector.Magnitude;

            Assert.That(expectedMagnitude, Is.EqualTo(actualMagnitude).Within(_delta));
        }

        private static object[] MagnitudeCases() => new object[]
        {
            new object[] { new Vector2Int(1, 1), 1.414f },
            new object[] { new Vector2Int(2, 3), 3.606f },
            new object[] { new Vector2Int(7, 9), 11.402f },
        };

        [TestCaseSource(nameof(SqrMagnitudeCases))]
        public void SqrMagnitude_SomeVector_ExpectedSqrMagnitude(in Vector2Int vector, int expectedSqrMagnitude)
        {
            int actualSqrMagnitude = vector.SqrMagnitude;

            Assert.That(expectedSqrMagnitude, Is.EqualTo(actualSqrMagnitude));
        }

        private static object[] SqrMagnitudeCases() => new object[]
        {
            new object[] { new Vector2Int(1, 1), 2 },
            new object[] { new Vector2Int(2, 3), 13 },
            new object[] { new Vector2Int(7, 9), 130 },
        };
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(DistanceCases))]
        public void Distance_SomeVectors_ExpectedDistance(in Vector2Int a, in Vector2Int b, float expectedDistance)
        {
            float actualDistance = a.Distance(b);

            Assert.That(expectedDistance, Is.EqualTo(actualDistance).Within(_delta));
        }

        private static object[] DistanceCases() => new object[]
        {
            new object[] { new Vector2Int(0, 0), new Vector2Int(2, 3), 3.606f },
            new object[] { new Vector2Int(5, 3), new Vector2Int(1, 2), 4.123f },
            new object[] { new Vector2Int(7, -9), new Vector2Int(-5, 3), 16.971f },
        };

        [TestCaseSource(nameof(SqrDistanceCases))]
        public void SqrDistance_SomeVectors_ExpectedSqrDistance(in Vector2Int a, in Vector2Int b, int expectedSqrDistance)
        {
            int actualSqrDistance = a.SqrDistance(b);

            Assert.That(expectedSqrDistance, Is.EqualTo(actualSqrDistance));
        }

        private static object[] SqrDistanceCases() => new object[]
        {
            new object[] { new Vector2Int(0, 0), new Vector2Int(2, 3), 13 },
            new object[] { new Vector2Int(5, 3), new Vector2Int(1, 2), 17 },
            new object[] { new Vector2Int(7, -9), new Vector2Int(-5, 3), 288 },
        };
        #endregion
    }
}
