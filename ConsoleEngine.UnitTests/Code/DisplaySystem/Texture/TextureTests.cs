using ConsoleEngine.DisplaySystem;
using ConsoleEngine.Maths;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class TextureTests
    {
        #region StaticFields
        private static readonly Vector2Int _vector_0_0 = new Vector2Int(0, 0);
        private static readonly Vector2Int _vector_0_1 = new Vector2Int(0, 1);
        private static readonly Vector2Int _vector_1_0 = new Vector2Int(1, 0);
        private static readonly Vector2Int _vector_1_1 = new Vector2Int(1, 1);
        #endregion

        #region ConstructorsTests
        [TestCaseSource(nameof(ConstructorByRectangleAndPixel_Cases))]
        public void ConstructorByRectangleAndPixel_SomeRectangleAndFillingPixel_ReturnsTexture(in Rectangle rectangle, in Pixel filling, IReadOnlyTexture expected)
        {
            var actual = new Texture(rectangle, filling);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        private static object[] ConstructorByRectangleAndPixel_Cases()
        {
            var topLeftAngle_1 = new Vector2Int(0, 0);
            var size_1 = new Vector2Int(2, 2);
            var rectangle_1 = new Rectangle(topLeftAngle_1, size_1);
            var filling_1 = Pixel.BlackSpace;
            var expected_1 = new Texture(new Vector2Int[]
            {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(1, 0),
                new Vector2Int(1, 1),
            }, filling_1);

            var topLeftAngle_2 = new Vector2Int(1, 2);
            var size_2 = new Vector2Int(3, 2);
            var rectangle_2 = new Rectangle(topLeftAngle_2, size_2);
            var filling_2 = Pixel.WhiteSpace;
            var expected_2 = new Texture(new Vector2Int[]
            {
                new Vector2Int(1, 2),
                new Vector2Int(2, 2),
                new Vector2Int(3, 2),
                new Vector2Int(1, 3),
                new Vector2Int(2, 3),
                new Vector2Int(3, 3),
            }, filling_2);

            var case_1 = new object[] { rectangle_1, filling_1, expected_1 };
            var case_2 = new object[] { rectangle_2, filling_2, expected_2 };

            return new object[] { case_1, case_2 };
        }
        #endregion

        #region StaticMethodsTests
        [TestCaseSource(nameof(GetAllPointsFrom_Cases))]
        public void GetAllPointsFrom_SomeTextures_ReturnsAllUniquePoints(IEnumerable<IReadOnlyTexture> textures, IEnumerable<Vector2Int> allUniquePoints)
        {
            var actualAllUniquePoints = Texture.GetAllPointsFrom(textures);

            Assert.That(allUniquePoints, Is.EquivalentTo(actualAllUniquePoints));
        }

        private static object[] GetAllPointsFrom_Cases()
        {
            var texture_1 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.BlackSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _vector_1_0,
                _vector_1_1,
                _vector_0_0,
            }, Pixel.BlackSpace);

            var textures_1 = new Texture[] { texture_1, texture_2 };
            var allUniquePoints_1 = new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
                _vector_1_0,
            };

            var textures_2 = new Texture[] { texture_2, texture_3 };
            var allUniquePoints_2 = new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
                _vector_1_1,
                _vector_0_0,
            };

            var case_1 = new object[] { textures_1, allUniquePoints_1 };
            var case_2 = new object[] { textures_2, allUniquePoints_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(StaticSubtract_Cases))]
        public void StaticSubtract_SomeTextures_ReturnsDifference(IReadOnlyTexture minuend, IReadOnlyTexture subtrahend, IReadOnlyTexture difference)
        {
            var actualDifference = Texture.Subtract(minuend, subtrahend);

            Assert.That(difference, Is.EquivalentTo(actualDifference));
        }

        private static object[] StaticSubtract_Cases()
        {
            var texture_1 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.WhiteSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _vector_1_0,
                _vector_1_1,
                _vector_0_0,
            }, Pixel.RedSpace);

            var difference_1_2 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
            }, Pixel.WhiteSpace);

            var difference_3_1 = new Texture(new Vector2Int[]
            {
                _vector_1_0,
                _vector_1_1,
            }, Pixel.RedSpace);

            var texture_1_2_case = new IReadOnlyTexture[] { texture_1, texture_2, difference_1_2 };
            var texture_3_1_case = new IReadOnlyTexture[] { texture_3, texture_1, difference_3_1 };

            return new object[] { texture_1_2_case, texture_3_1_case };
        }

        [TestCaseSource(nameof(SubtractAndGetIntersection_Cases))]
        public void SubtractAndGetIntersection_SomeTextures_ReturnsDifferenceAndIntersection(Texture minuend, IReadOnlyTexture intersectionSource,
                                                                                             IReadOnlyTexture difference, IReadOnlyTexture intersection)
        {
            var actualIntersection = Texture.SubtractAndGetIntersection(minuend, intersectionSource);
            var actualDifference = minuend;

            Assert.Multiple(() =>
            {
                Assert.That(intersection, Is.EquivalentTo(actualIntersection));
                Assert.That(difference, Is.EquivalentTo(actualDifference));
            });
        }

        private static object[] SubtractAndGetIntersection_Cases()
        {
            var texture_1 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.WhiteSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _vector_1_0,
                _vector_1_1,
                _vector_0_0,
            }, Pixel.RedSpace);

            var difference_1_2 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
            }, Pixel.WhiteSpace);

            var intersection_2_1 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
            }, Pixel.BlackSpace);

            var difference_3_1 = new Texture(new Vector2Int[]
            {
                _vector_1_0,
                _vector_1_1,
            }, Pixel.RedSpace);

            var intersection_1_3 = new Texture(new Vector2Int[]
            {
                _vector_0_0,
            }, Pixel.WhiteSpace);

            var texture_1_2_case = new Texture[] { texture_1.Clone(), texture_2, difference_1_2, intersection_2_1 };
            var texture_3_1_case = new Texture[] { texture_3.Clone(), texture_1, difference_3_1, intersection_1_3 };

            return new object[] { texture_1_2_case, texture_3_1_case };
        }
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(Contains_Cases))]
        public void Contains_TextureAndPoint_TextureContainsPointResult(IReadOnlyTexture texture, in Vector2Int point, bool textureContainsPoint)
        {
            var actualTextureContainsPoint = texture.Contains(point);

            Assert.That(textureContainsPoint == actualTextureContainsPoint, Is.True);
        }

        private static object[] Contains_Cases()
        {
            var texture = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var textureContainsPoint_Case = new object[] { texture, _vector_0_1, true };
            var textureNotContainsPoint_Case = new object[] { texture, _vector_1_1, false };

            return new object[] { textureContainsPoint_Case, textureNotContainsPoint_Case };
        }

        [TestCaseSource(nameof(GetPixelIn_Cases))]
        public void GetPixelIn_TextureAndPoint_ReturnsPixelOrNull(IReadOnlyTexture texture, in Vector2Int point, in Pixel? pixel)
        {
            var actualPixel = texture.GetPixelIn(point);

            Assert.That(pixel, Is.EqualTo(actualPixel));
        }

        private static object[] GetPixelIn_Cases()
        {
            var texture = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_vector_0_0, Pixel.BlackSpace),
                new (_vector_0_1, Pixel.WhiteSpace),
                new (_vector_1_0, Pixel.RedSpace),
            });

            var whiteSpace_case = new object[] { texture, _vector_0_1, new Pixel?(Pixel.WhiteSpace) };
            var redSpace_case = new object[] { texture, _vector_1_0, new Pixel?(Pixel.RedSpace) };
            var null_case = new object[] { texture, _vector_1_1, new Pixel?() };

            return new object[] { whiteSpace_case, redSpace_case, null_case };
        }

        [TestCaseSource(nameof(AddOrReplace_Cases))]
        public void AddOrReplace_SomeTextures_AdditionResult(Texture original, IReadOnlyTexture additional, IReadOnlyTexture sum)
        {
            var actualSum = original.AddOrReplace(additional);

            Assert.That(sum, Is.EquivalentTo(actualSum));
        }

        public static object[] AddOrReplace_Cases()
        {
            var original = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.WhiteSpace);

            var additional_1 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var additional_2 = new Texture(new Vector2Int[]
            {
                _vector_1_1,
                _vector_0_0,
            }, Pixel.RedSpace);

            var sum_1 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_vector_0_0, Pixel.WhiteSpace),
                new (_vector_0_1, Pixel.BlackSpace),
                new (_vector_1_0, Pixel.BlackSpace),
            });

            var sum_2 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_vector_0_0, Pixel.RedSpace),
                new (_vector_0_1, Pixel.WhiteSpace),
                new (_vector_1_1, Pixel.RedSpace),
            });

            var case_1 = new Texture[] { original.Clone(), additional_1, sum_1 };
            var case_2 = new Texture[] { original.Clone(), additional_2, sum_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(Subtract_Cases))]
        public void Subtract_SomeTextures_ReturnsDifference(Texture original, IReadOnlyTexture subtrahend, IReadOnlyTexture difference)
        {
            var actualDifference = original.Subtract(subtrahend);

            Assert.That(difference, Is.EquivalentTo(actualDifference));
        }

        public static object[] Subtract_Cases()
        {
            var original = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.WhiteSpace);

            var subtrahend_1 = new Texture(new Vector2Int[]
            {
                _vector_0_1,
                _vector_1_0,
            }, Pixel.BlackSpace);

            var subtrahend_2 = new Texture(new Vector2Int[]
            {
                _vector_1_1,
                _vector_0_0,
            }, Pixel.RedSpace);

            var difference_1 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_vector_0_0, Pixel.WhiteSpace),
            });

            var difference_2 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_vector_0_1, Pixel.WhiteSpace),
            });

            var case_1 = new Texture[] { original.Clone(), subtrahend_1, difference_1 };
            var case_2 = new Texture[] { original.Clone(), subtrahend_2, difference_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(Clear_Cases))]
        public void Clear_SomeTexture_ReturnsEmptyTexture(Texture texture)
        {
            var cleanTexture = texture.Clear();

            Assert.That(cleanTexture, Is.Empty);
        }

        private static object[] Clear_Cases()
        {
            var texture = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.BlackSpace);

            var case_1 = new Texture[] { texture };

            return new object[] { case_1 };
        }

        [TestCaseSource(nameof(Clone_Cases))]
        public void Clone_SomeTexture_ReturnsClone(Texture original)
        {
            var actualClone = original.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(original, Is.EquivalentTo(actualClone));
                Assert.That(original, Is.Not.SameAs(actualClone));
            });
        }

        private static object[] Clone_Cases()
        {
            var original = new Texture(new Vector2Int[]
            {
                _vector_0_0,
                _vector_0_1,
            }, Pixel.BlackSpace);

            var case_1 = new Texture[] { original };

            return new object[] { case_1 };
        }
        #endregion
    }
}
