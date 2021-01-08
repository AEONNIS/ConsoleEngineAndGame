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
        private static readonly Vector2Int _point_0_0 = new Vector2Int(0, 0);
        private static readonly Vector2Int _point_0_1 = new Vector2Int(0, 1);
        private static readonly Vector2Int _point_1_0 = new Vector2Int(1, 0);
        private static readonly Vector2Int _point_1_1 = new Vector2Int(1, 1);
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
                _point_0_0,
                _point_0_1,
            }, Pixel.BlackSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
                _point_0_0,
            }, Pixel.BlackSpace);

            var textures_1 = new Texture[] { texture_1, texture_2 };
            var allUniquePoints_1 = new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
                _point_1_0,
            };

            var textures_2 = new Texture[] { texture_2, texture_3 };
            var allUniquePoints_2 = new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
                _point_1_1,
                _point_0_0,
            };

            var case_1 = new object[] { textures_1, allUniquePoints_1 };
            var case_2 = new object[] { textures_2, allUniquePoints_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(Static_Subtract_Cases))]
        public void Subtract_SomeTextures_ReturnsDifference(IReadOnlyTexture minuend, IReadOnlyTexture subtrahend, Texture difference)
        {
            var actualDifference = Texture.Subtract(minuend, subtrahend);

            Assert.That(difference, Is.EquivalentTo(actualDifference));
        }

        private static object[] Static_Subtract_Cases()
        {
            var texture_1 = new Texture(new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
            }, Pixel.WhiteSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
                _point_0_0,
            }, Pixel.RedSpace);

            var difference_1_2 = new Texture(new Vector2Int[]
            {
                _point_0_0,
            }, Pixel.WhiteSpace);

            var difference_3_1 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
            }, Pixel.RedSpace);

            var case_1 = new object[] { texture_1, texture_2, difference_1_2 };
            var case_2 = new object[] { texture_3, texture_1, difference_3_1 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(SubtractAndGetIntersection_Cases))]
        public void SubtractAndGetIntersection_SomeTextures_ReturnsDifferenceAndIntersection(ref Texture minuend, IReadOnlyTexture intersectionSource,
                                                                                             IReadOnlyTexture difference, IReadOnlyTexture intersection)
        {
            var actualIntersection = Texture.SubtractAndGetIntersection(ref minuend, intersectionSource);
            var actualDifference = minuend.Clone();

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
                _point_0_0,
                _point_0_1,
            }, Pixel.WhiteSpace);

            var texture_2 = new Texture(new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var texture_3 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
                _point_0_0,
            }, Pixel.RedSpace);

            var difference_1_2 = new Texture(new Vector2Int[]
            {
                _point_0_0,
            }, Pixel.WhiteSpace);

            var intersection_2_1 = new Texture(new Vector2Int[]
            {
                _point_0_1,
            }, Pixel.BlackSpace);

            var difference_3_1 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
            }, Pixel.RedSpace);

            var intersection_1_3 = new Texture(new Vector2Int[]
            {
                _point_0_0,
            }, Pixel.WhiteSpace);

            var case_1 = new Texture[] { texture_1, texture_2, difference_1_2, intersection_2_1 };
            var case_2 = new Texture[] { texture_3, texture_1, difference_3_1, intersection_1_3 };

            return new object[] { case_1, case_2 };
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
                _point_0_0,
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var textureContainsPointCase = new object[] { texture, _point_0_1, true };
            var textureNotContainsPointCase = new object[] { texture, _point_1_1, false };

            return new object[] { textureContainsPointCase, textureNotContainsPointCase };
        }

        [TestCaseSource(nameof(GetPixelIn_Cases))]
        public void GetPixelIn_TextureAndPoint_PixelOrNull(IReadOnlyTexture texture, in Vector2Int point, Pixel? pixel)
        {
            var actualPixel = texture.GetPixelIn(point);

            Assert.That(pixel, Is.EqualTo(actualPixel));
        }

        private static object[] GetPixelIn_Cases()
        {
            var texture = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_point_0_0, Pixel.BlackSpace),
                new (_point_0_1, Pixel.WhiteSpace),
                new (_point_1_0, Pixel.RedSpace),
            });

            var case_1 = new object[] { texture, _point_0_1, new Pixel?(Pixel.WhiteSpace) };
            var case_2 = new object[] { texture, _point_1_0, new Pixel?(Pixel.RedSpace) };
            var case_3 = new object[] { texture, _point_1_1, new Pixel?() };

            return new object[] { case_1, case_2, case_3 };
        }

        [TestCaseSource(nameof(AddOrReplace_Cases))]
        public void AddOrReplace_SomeTextures_AdditionResult(Texture original, IReadOnlyTexture additional, Texture additionalResult)
        {
            var actualAdditionalResult = original.AddOrReplace(additional);

            Assert.That(additionalResult, Is.EquivalentTo(actualAdditionalResult));
        }

        public static object[] AddOrReplace_Cases()
        {
            var original = new Texture(new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
            }, Pixel.WhiteSpace);

            var additional_1 = new Texture(new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var additional_2 = new Texture(new Vector2Int[]
            {
                _point_1_1,
                _point_0_0,
            }, Pixel.RedSpace);

            var additionalResult_1 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_point_0_0, Pixel.WhiteSpace),
                new (_point_0_1, Pixel.BlackSpace),
                new (_point_1_0, Pixel.BlackSpace),
            });

            var additionalResult_2 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_point_0_0, Pixel.RedSpace),
                new (_point_0_1, Pixel.WhiteSpace),
                new (_point_1_1, Pixel.RedSpace),
            });

            var case_1 = new Texture[] { original.Clone(), additional_1, additionalResult_1 };
            var case_2 = new Texture[] { original.Clone(), additional_2, additionalResult_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(Subtract_Cases))]
        public void Subtract_SomeTextures_SubtractionResult(Texture original, IReadOnlyTexture subtrahend, Texture subtractionResult)
        {
            var actualSubtractionResult = original.Subtract(subtrahend);

            Assert.That(subtractionResult, Is.EquivalentTo(actualSubtractionResult));
        }

        public static object[] Subtract_Cases()
        {
            var original = new Texture(new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
            }, Pixel.WhiteSpace);

            var subtrahend_1 = new Texture(new Vector2Int[]
            {
                _point_0_1,
                _point_1_0,
            }, Pixel.BlackSpace);

            var subtrahend_2 = new Texture(new Vector2Int[]
            {
                _point_1_1,
                _point_0_0,
            }, Pixel.RedSpace);

            var subtractionResult_1 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_point_0_0, Pixel.WhiteSpace),
            });

            var subtractionResult_2 = new Texture(new KeyValuePair<Vector2Int, Pixel>[]
            {
                new (_point_0_1, Pixel.WhiteSpace),
            });

            var case_1 = new Texture[] { original.Clone(), subtrahend_1, subtractionResult_1 };
            var case_2 = new Texture[] { original.Clone(), subtrahend_2, subtractionResult_2 };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(Clear_Case))]
        public void Clear_SomeTexture_ReturnsEmptyTexture(Texture texture, Texture emptyTexture)
        {
            var cleaningResult = texture.Clear();

            Assert.That(emptyTexture, Is.EquivalentTo(cleaningResult));
        }

        private static object[] Clear_Case()
        {
            var texture = new Texture(new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
            }, Pixel.BlackSpace);

            var case_1 = new IReadOnlyTexture[] { texture, Texture.Empty };

            return new object[] { case_1 };
        }

        [TestCaseSource(nameof(Clone_Cases))]
        public void Clone_SomeTexture_ReturnsClone(Texture original)
        {
            var actualClone = original.Clone();

            Assert.That(original, Is.EquivalentTo(actualClone));
        }

        private static object[] Clone_Cases()
        {
            var original_1 = new Texture(new Vector2Int[]
            {
                _point_0_0,
                _point_0_1,
            }, Pixel.BlackSpace);

            var original_2 = new Texture(new Vector2Int[]
            {
                _point_1_0,
                _point_1_1,
            }, Pixel.RedSpace);

            var case_1 = new object[] { original_1 };
            var case_2 = new object[] { original_2 };

            return new object[] { case_1, case_2 };
        }
        #endregion
    }
}
