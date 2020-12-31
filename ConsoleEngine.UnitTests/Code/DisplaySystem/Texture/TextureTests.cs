using ConsoleEngine.DisplaySystem;
using ConsoleEngine.Maths;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class TextureTests // Размещать кейсы под соответствующими тестами, чтобы рядом.
    {
        #region StaticFields
        private readonly static Pixel _fillingBlack = Pixel.BlackSpace;
        private readonly static Pixel _fillingWhite = Pixel.WhiteSpace;
        #endregion

        #region StaticMethodsTests
        [TestCaseSource(nameof(GetAllUniquePointsCase))]
        public void GetAllUniquePoints_Textures_ReturnExpectedPoints(IEnumerable<IReadOnlyTexture> textures, IReadOnlyCollection<Vector2Int> expectedPoints)
        {
            var actualPoints = Texture.GetAllUniquePoints(textures);

            Assert.That(expectedPoints, Is.EquivalentTo(actualPoints));
        }

        private static object[] GetAllUniquePointsCase() => new object[]
        {
            new object[] { new Texture[]
            {
                new Texture(new Vector2Int[]
                {
                    new Vector2Int(0, 0),
                    new Vector2Int(0, 1),
                    new Vector2Int(1, 0)
                }, _fillingBlack),

                new Texture(new Vector2Int[]
                {
                    new Vector2Int(1, 0),
                    new Vector2Int(0, 2),
                    new Vector2Int(3, 0),
                    new Vector2Int(0, 3)
                }, _fillingBlack),

                new Texture(new Vector2Int[]
                {
                    new Vector2Int(0, 3),
                    new Vector2Int(0, 2),
                    new Vector2Int(1, 0),
                    new Vector2Int(1, 2),
                    new Vector2Int(1, 3)
                }, _fillingBlack),

            }, new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(1, 0),
                new Vector2Int(0, 2),
                new Vector2Int(3, 0),
                new Vector2Int(0, 3),
                new Vector2Int(1, 2),
                new Vector2Int(1, 3)
            } },
        };

        [TestCaseSource(nameof(SubtractCase))]
        public void Subtract_MinuendAndSubtrahendTextures_ReturnDifference(IReadOnlyTexture minuend, IReadOnlyTexture subtrahend, Texture expectedDifference)
        {
            var actualDifference = Texture.Subtract(minuend, subtrahend);

            Assert.That(expectedDifference, Is.EquivalentTo(actualDifference));
        }

        private static object[] SubtractCase() => new object[]
        {
            new object[] { new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(1, 2),
                new Vector2Int(1, 3)
            }, _fillingBlack),

            new Texture(new Vector2Int[]
            {
                new Vector2Int(1, 0),
                new Vector2Int(2, 0),
                new Vector2Int(1, 2),
                new Vector2Int(2, 3)
            }, _fillingBlack),

            new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 3)
            }, _fillingBlack) }
        };

        [TestCaseSource(nameof(SubtractAndGetIntersectionCase))]
        public void SubtractAndGetIntersection_MinuendAndIntersectionSourceTextures_ReturnDifferenceAndIntersection(
                        ref Texture minuend, IReadOnlyTexture intersectionSource, IReadOnlyTexture expectedDifference, IReadOnlyTexture expectedIntersection)
        {
            var actualIntersection = Texture.SubtractAndGetIntersection(ref minuend, intersectionSource);
            var actualDifference = minuend.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(expectedDifference, Is.EquivalentTo(actualDifference));
                Assert.That(expectedIntersection, Is.EquivalentTo(actualIntersection));
            });
        }

        private static object[] SubtractAndGetIntersectionCase() => new object[]
        {
            new object[] { new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(1, 2),
                new Vector2Int(1, 3)
            }, _fillingBlack),

            new Texture(new Vector2Int[]
            {
                new Vector2Int(1, 0),
                new Vector2Int(2, 0),
                new Vector2Int(1, 2),
                new Vector2Int(2, 3)
            }, _fillingWhite),

            new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 3)
            }, _fillingBlack),

            new Texture(new Vector2Int[]
            {
                new Vector2Int(1, 0),
                new Vector2Int(1, 2)
            }, _fillingWhite), }
        };
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(ContainsCases))]
        public void Contains_TextureAndPoints_ReturnExpectedResult(IReadOnlyTexture texture, in Vector2Int point, bool expected)
        {
            var actual = texture.Contains(point);

            Assert.That(expected == actual);
        }

        private static object[] ContainsCases() => new object[]
        {
            new object[] { new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(1, 2),
                new Vector2Int(1, 3)
            }, _fillingBlack), new Vector2Int(1, 2), true, },

            new object[] { new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(1, 2),
                new Vector2Int(1, 3)
            }, _fillingBlack), new Vector2Int(2, 3), false, }
        };

        public void GetPixelIn_TextureAndPoint_ExpectedPixel(IReadOnlyTexture texture, Vector2Int point, Pixel? expectedPixel)
        {
            var actualPixel = texture.GetPixelIn(point);

            Assert.That(expectedPixel == actualPixel);
        }

        private static object[] GetPixelInCases() => new object[]
        {
            new object[] { new Texture(new KeyValuePair<Vector2Int, Pixel>[] 
            { 

            }) }
        };
        #endregion
    }
}
