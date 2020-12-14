using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.UnitTests.Maths
{
    [TestFixture]
    public class RectangleTests
    {
        #region ConstructorsTests
        [TestCaseSource(nameof(ConstructorAndCreateCases))]
        public void Constructor_TopLeftAngleAndSize_ExpectedOtherAngles(in Vector2Int topLeftAngle, in Vector2Int size,
                        in Vector2Int expectedTopRightAngle, in Vector2Int expectedBottomLeftAngle, in Vector2Int expectedBottomRightAngle)
        {
            Rectangle rectangle = new Rectangle(topLeftAngle, size);

            Vector2Int actualTopRightAngle = rectangle.TopRightAngle;
            Vector2Int actualBottomLeftAngle = rectangle.BottomLeftAngle;
            Vector2Int actualBottomRightAngle = rectangle.BottomRightAngle;

            Assert.AreEqual(expectedTopRightAngle, actualTopRightAngle);
            Assert.AreEqual(expectedBottomLeftAngle, actualBottomLeftAngle);
            Assert.AreEqual(expectedBottomRightAngle, actualBottomRightAngle);
        }
        #endregion

        #region StaticMethodsTests
        [TestCaseSource(nameof(ConstructorAndCreateCases))]
        public void Create_TopLeftAngleAndBottomRightAngle_ExpectedOtherAnglesAndSize(in Vector2Int topLeftAngle, in Vector2Int expectedSize,
                        in Vector2Int expectedTopRightAngle, in Vector2Int expectedBottomLeftAngle, in Vector2Int bottomRightAngle)
        {
            Rectangle rectangle = Rectangle.Create(topLeftAngle, bottomRightAngle);

            Vector2Int actualSize = rectangle.Size;
            Vector2Int actualTopRightAngle = rectangle.TopRightAngle;
            Vector2Int actualBottomLeftAngle = rectangle.BottomLeftAngle;

            Assert.AreEqual(expectedSize, actualSize);
            Assert.AreEqual(expectedTopRightAngle, actualTopRightAngle);
            Assert.AreEqual(expectedBottomLeftAngle, actualBottomLeftAngle);
        }
        #endregion

        #region MethodTests
        [TestCaseSource(nameof(RectangleContainsPointCases), new object[] { true })]
        [TestCaseSource(nameof(RectangleNotContainsPointCases), new object[] { false })]
        public void Contains_RectangleAndPoint_ReturnExpectedBool(in Rectangle rectangle, in Vector2Int point, bool expected)
        {
            bool actual = rectangle.Contains(point);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TestsCases
        private static object[] ConstructorAndCreateCases() => new object[]
        {
            new object[] { new Vector2Int(0, 0), new Vector2Int(7, 7),
                           new Vector2Int(6, 0), new Vector2Int(0, 6), new Vector2Int(6, 6) },

            new object[] { new Vector2Int(5, 8), new Vector2Int(3, 4),
                           new Vector2Int(7, 8), new Vector2Int(5, 11), new Vector2Int(7, 11) }
        };

        private static object[] RectangleContainsPointCases(bool result)
        {
            Rectangle rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

            return new object[]
            {
                new object[] { rectangle, new Vector2Int(0, 0), result },
                new object[] { rectangle, new Vector2Int(5, 6), result },
                new object[] { rectangle, new Vector2Int(7, 3), result },
                new object[] { rectangle, new Vector2Int(7, 7), result }
            };
        }
        private static object[] RectangleNotContainsPointCases(bool result)
        {
            Rectangle rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

            return new object[]
            {
                new object[] { rectangle, new Vector2Int(0, -1), result },
                new object[] { rectangle, new Vector2Int(-3, 6), result },
                new object[] { rectangle, new Vector2Int(8, 8), result },
                new object[] { rectangle, new Vector2Int(5, 10), result }
            };
        }
        #endregion
    }
}
