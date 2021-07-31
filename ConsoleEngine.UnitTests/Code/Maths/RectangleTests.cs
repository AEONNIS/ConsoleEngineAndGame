using ConsoleEngine.Maths;
using NUnit.Framework;

namespace ConsoleEngine.UnitTests.Maths
{
    [TestFixture]
    public class RectangleTests
    {
        #region ConstructorsAndFactoryMethodsTests
        [TestCaseSource(nameof(ConstructorAndCreateCases))]
        public void Constructor_TopLeftAngleAndSize_ExpectedOtherAngles(in Vector2Int topLeftAngle, in Vector2Int size,
                        Vector2Int expectedTopRightAngle, Vector2Int expectedBottomLeftAngle, Vector2Int expectedBottomRightAngle)
        {
            Rectangle rectangle = new Rectangle(topLeftAngle, size);

            Vector2Int actualTopRightAngle = rectangle.TopRightAngle;
            Vector2Int actualBottomLeftAngle = rectangle.BottomLeftAngle;
            Vector2Int actualBottomRightAngle = rectangle.BottomRightAngle;

            Assert.Multiple(() =>
            {
                Assert.That(expectedTopRightAngle, Is.EqualTo(actualTopRightAngle));
                Assert.That(expectedBottomLeftAngle, Is.EqualTo(actualBottomLeftAngle));
                Assert.That(expectedBottomRightAngle, Is.EqualTo(actualBottomRightAngle));
            });
        }

        [TestCaseSource(nameof(ConstructorAndCreateCases))]
        public void Create_TopLeftAngleAndBottomRightAngle_ExpectedOtherAnglesAndSize(in Vector2Int topLeftAngle, Vector2Int expectedSize,
                        Vector2Int expectedTopRightAngle, Vector2Int expectedBottomLeftAngle, in Vector2Int bottomRightAngle)
        {
            Rectangle rectangle = Rectangle.Create(topLeftAngle, bottomRightAngle);

            Vector2Int actualSize = rectangle.Size;
            Vector2Int actualTopRightAngle = rectangle.TopRightAngle;
            Vector2Int actualBottomLeftAngle = rectangle.BottomLeftAngle;

            Assert.Multiple(() =>
            {
                Assert.That(expectedSize, Is.EqualTo(actualSize));
                Assert.That(expectedTopRightAngle, Is.EqualTo(actualTopRightAngle));
                Assert.That(expectedBottomLeftAngle, Is.EqualTo(actualBottomLeftAngle));
            });
        }

        private static object[] ConstructorAndCreateCases()
        {
            var topLeftAngle1 = new Vector2Int(0, 0);
            var size1 = new Vector2Int(7, 7);
            var topRightAngle1 = new Vector2Int(6, 0);
            var bottomLeftAngle1 = new Vector2Int(0, 6);
            var bottomRightAngle1 = new Vector2Int(6, 6);
            var case1 = new Vector2Int[] { topLeftAngle1, size1, topRightAngle1, bottomLeftAngle1, bottomRightAngle1 };

            var topLeftAngle2 = new Vector2Int(5, 8);
            var size2 = new Vector2Int(3, 4);
            var topRightAngle2 = new Vector2Int(7, 8);
            var bottomLeftAngle2 = new Vector2Int(5, 11);
            var bottomRightAngle2 = new Vector2Int(7, 11);
            var case2 = new Vector2Int[] { topLeftAngle2, size2, topRightAngle2, bottomLeftAngle2, bottomRightAngle2 };

            return new object[] { case1, case2 };
        }
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(RectangleContainsPointCases))]
        [TestCaseSource(nameof(RectangleNotContainsPointCases))]
        public void Contains_RectangleAndPoint_RectangleContainsPointResult(in Rectangle rectangle, in Vector2Int point, bool rectangleContainsPoint)
        {
            bool actualRectangleContainsPoint = rectangle.Contains(point);

            Assert.That(rectangleContainsPoint == actualRectangleContainsPoint, Is.True);
        }

        private static object[] RectangleContainsPointCases()
        {
            var rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

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
            var rectangle = new Rectangle(new Vector2Int(0, 0), new Vector2Int(8, 8));

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
