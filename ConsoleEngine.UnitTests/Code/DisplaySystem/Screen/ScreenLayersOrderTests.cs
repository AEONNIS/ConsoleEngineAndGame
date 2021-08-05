using ConsoleEngine.DisplaySystem;
using ConsoleEngine.Maths;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleEngine.UnitTests.DisplaySystem
{
    [TestFixture]
    public class ScreenLayersOrderTests
    {
        #region StaticFields
        private static readonly Vector2Int _point_0_0 = new Vector2Int(0, 0);
        private static readonly Vector2Int _point_0_1 = new Vector2Int(0, 1);
        private static readonly Vector2Int _point_1_0 = new Vector2Int(1, 0);
        private static readonly Vector2Int _point_1_1 = new Vector2Int(1, 1);
        #endregion

        #region MethodsTests
        [TestCaseSource(nameof(SelectLayersTopToBottomAbove_Cases))]
        public void SelectLayersTopToBottomAbove_LayersOrderAndGraphics_ReturnsLayersTopToBottomAboveGraphics(ScreenLayersOrder layersOrder, IGraphics graphics,
                                                                                                              IEnumerable<ScreenLayer> layersTopToBottomAbove)
        {
            var actualLayersTopToBottomAbove = layersOrder.SelectLayersTopToBottomAbove(graphics);

            Assert.That(layersTopToBottomAbove, Is.EqualTo(actualLayersTopToBottomAbove));
        }

        private static object[] SelectLayersTopToBottomAbove_Cases()
        {
            var graphicsSet = GetGraphicsSet(GetTextures());
            var layers = GetLayers(graphicsSet);
            var layersOrder = GetLayersOrder(layers);

            var case_1 = new object[] { layersOrder, graphicsSet[1], new ScreenLayer[] { layers[0] } };
            var case_2 = new object[] { layersOrder, graphicsSet[2], new ScreenLayer[] { layers[0], layers[1] } };

            return new object[] { case_1, case_2 };
        }

        [TestCaseSource(nameof(SelectLayersTopToBottomBelow_Cases))]
        public void SelectLayersTopToBottomBelow_LayersOrderAndGraphics_ReturnsLayersTopToBottomBelowGraphics(ScreenLayersOrder layersOrder, IGraphics graphics,
                                                                                                              IEnumerable<ScreenLayer> layersTopToBottomBelow)
        {
            var actualLayersTopToBottomBelow = layersOrder.SelectLayersTopToBottomBelow(graphics);

            Assert.That(layersTopToBottomBelow, Is.EqualTo(actualLayersTopToBottomBelow));
        }

        private static object[] SelectLayersTopToBottomBelow_Cases()
        {
            var graphicsSet = GetGraphicsSet(GetTextures());
            var layers = GetLayers(graphicsSet);
            var layersOrder = GetLayersOrder(layers);

            var case_1 = new object[] { layersOrder, graphicsSet[1], new ScreenLayer[] { layers[2], layers[3] } };
            var case_2 = new object[] { layersOrder, graphicsSet[2], new ScreenLayer[] { layers[3] } };

            return new object[] { case_1, case_2 };
        }
        #endregion

        #region HelperMethodsForCases
        private static ScreenLayersOrder GetLayersOrder(ScreenLayer[] layers)
        {
            var result = new ScreenLayersOrder();

            for (int i = layers.Length - 1; i >= 0; i--)
                result.AddToTop(layers[i]);

            return result;
        }

        private static ScreenLayer[] GetLayers(IGraphics[] graphicsSet)
        {
            var result = new ScreenLayer[graphicsSet.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = new ScreenLayer().Init(graphicsSet[i]);

            return result;
        }

        private static IGraphics[] GetGraphicsSet(Texture[] textures)
        {
            var result = new IGraphics[textures.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = new TestGraphics(textures[i]);

            return result;
        }

        private static Texture[] GetTextures()
        {
            var texture_1 = new Texture(new Vector2Int[] { _point_0_0 }, Pixel.BlackSpace);
            var texture_2 = new Texture(new Vector2Int[] { _point_0_1 }, Pixel.WhiteSpace);
            var texture_3 = new Texture(new Vector2Int[] { _point_1_0 }, Pixel.RedSpace);
            var texture_4 = new Texture(new Vector2Int[] { _point_1_1 }, Pixel.GreenSpace);

            return new Texture[] { texture_1, texture_2, texture_3, texture_4 };
        }
        #endregion

        #region InterfacesImplementation
        private class TestGraphics : IGraphics
        {
            private readonly Texture _texture;

            public TestGraphics(Texture texture) => _texture = texture;

            public IReadOnlyTexture Texture => _texture;
        }
        #endregion
    }
}
