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
        private readonly static Pixel _filling = Pixel.BlackSpace;
        #endregion

        #region StaticMethodsTests
        [TestCaseSource(nameof(GetAllUniquePointsCase))]
        public void GetAllUniquePoints_Textures_ReturnExpectedPoints(in IEnumerable<IReadOnlyTexture> textures, in IReadOnlyCollection<Vector2Int> expectedPoints)
        {
            var actualPoints = Texture.GetAllUniquePoints(textures);

            Assert.That(expectedPoints, Is.EquivalentTo(actualPoints));
        }

        [TestCaseSource(nameof(SubtractCase))]
        public void Subtract_MinuendAndSubtrahendTextures_ReturnDifference(in IReadOnlyTexture minuend, in IReadOnlyTexture subtrahend, in Texture expectedDifference)
        {
            var actualDifference = Texture.Subtract(minuend, subtrahend);

            Assert.That(expectedDifference, Is.EquivalentTo(actualDifference));
        }
        #endregion

        #region TestCases
        private static object[] GetAllUniquePointsCase() => new object[]
        {
            new object[] { new Texture[]
            {
                new Texture(new Vector2Int[]
                {
                    new Vector2Int(0, 0),
                    new Vector2Int(0, 1),
                    new Vector2Int(1, 0)
                }, _filling),

                new Texture(new Vector2Int[]
                {
                    new Vector2Int(1, 0),
                    new Vector2Int(0, 2),
                    new Vector2Int(3, 0),
                    new Vector2Int(0, 3)
                }, _filling),

                new Texture(new Vector2Int[]
                {
                    new Vector2Int(0, 3),
                    new Vector2Int(0, 2),
                    new Vector2Int(1, 0),
                    new Vector2Int(1, 2),
                    new Vector2Int(1, 3)
                }, _filling),

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

        private static object[] SubtractCase() => new object[]
       {
           new object[] { new Texture(new Vector2Int[]
           {
               new Vector2Int(0, 0),
               new Vector2Int(1, 0),
               new Vector2Int(1, 2),
               new Vector2Int(1, 3)
           }, _filling),

           new Texture(new Vector2Int[]
           {
               new Vector2Int(1, 0),
               new Vector2Int(2, 0),
               new Vector2Int(1, 2),
               new Vector2Int(2, 3),
           }, _filling),

           new Texture(new Vector2Int[]
           {
               new Vector2Int(0, 0),
               new Vector2Int(1, 3)
           }, _filling) }
       };
        #endregion
    }
}
