using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.UnitTests.Maths
{
    [TestFixture]
    public class RectangleTests
    {
        #region ConstructorsTests
        [TestCaseSource(nameof(ConstructorAndCreateCases))]
        public void Constructor_TopLeftAngleAndSize_ExpectedOtherAngles(Vector2Int topLeftAngle, Vector2Int size,
                        Vector2Int expectedTopRightAngle, Vector2Int expectedBottomLeftAngle, Vector2Int expectedBottomRightAngle)
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
        public void Create_TopLeftAngleAndBottomRightAngle_ExpectedOtherAnglesAndSize(Vector2Int topLeftAngle, Vector2Int expectedSize,
                        Vector2Int expectedTopRightAngle, Vector2Int expectedBottomLeftAngle, Vector2Int bottomRightAngle)
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
        [TestCaseSource(nameof(RectangleContainsPointCases))]
        [TestCaseSource(nameof(RectangleNotContainsPointCases))]
        public void Contains_RectangleAndPoint_ReturnExpectedBool(Rectangle rectangle, Vector2Int point, bool expected)
        {
            bool actual = rectangle.Contains(point);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TestsCases
        private static object[] ConstructorAndCreateCases()
        {
            return new object[]
            {
                new object[] { new Vector2Int(0, 0), new Vector2Int(7, 7),
                               new Vector2Int(6, 0), new Vector2Int(0, 6), new Vector2Int(6, 6) },

                new object[] { new Vector2Int(5, 8), new Vector2Int(3, 4),
                               new Vector2Int(7, 8), new Vector2Int(5, 11), new Vector2Int(7, 11) }
            };
        }

        private static object[] RectangleContainsPointCases()
        {
            Rectangle rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

            return new object[]
            {
                new object[] { rectangle, new Vector2Int(0, 0), true },
                new object[] { rectangle, new Vector2Int(5, 6), true },
                new object[] { rectangle, new Vector2Int(7, 3), true },
                new object[] { rectangle, new Vector2Int(7, 7), true }
            };
        }
        private static object[] RectangleNotContainsPointCases()
        {
            Rectangle rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

            return new object[]
            {
                new object[] { rectangle, new Vector2Int(0, -1), false },
                new object[] { rectangle, new Vector2Int(-3, 6), false },
                new object[] { rectangle, new Vector2Int(8, 8), false },
                new object[] { rectangle, new Vector2Int(5, 10), false }
            };
        }
        #endregion
    }
}
