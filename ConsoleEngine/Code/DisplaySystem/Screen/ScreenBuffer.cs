using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly ScreenLayerOrder _layerOrder = new ScreenLayerOrder();
        private readonly ScreenGraphicControl _graphicControl;
        #endregion

        #region Constructors
        public ScreenBuffer(in Pixel emptyPixel) => _graphicControl = new ScreenGraphicControl(emptyPixel);
        #endregion

        #region PublicMethods
        public bool Contains(IGraphicObject graphicObject) => _layerOrder.Contains(graphicObject);

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layerOrder.InitNewLayer(graphicObject);

            Overlap(graphicObject.Texture, _layerOrder.Layers);
            _layerOrder.AddToTop(layer);

            return graphicObject.Texture;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layersAbove = _layerOrder.SelectLayersAbove(graphicObject);
            var layerNode = _layerOrder.ExtractLayerNode(graphicObject);

            Overlap(graphicObject.Texture, layersAbove);
            _layerOrder.AddToTop(layerNode);

            if (layerNode.Value.IsVisible)
            {
                return layerNode.Value.HiddenPartGetAndClear();
            }
            else
            {
                layerNode.Value.SetVisibility(true);
                return layerNode.Value.GraphicObject.Texture;
            }
        }

        public IReadOnlyTexture Hide(IGraphicObject graphicObject)
        {
            var layersBelow = _layerOrder.SelectLayersBelow(graphicObject);
            var layerNode = _layerOrder.ExtractLayerNode(graphicObject); // Слой не должен извлекаться: порядок слоев не меняется, мы просто помечаем слой, как скрытый.

            var result = RemoveOverlap(layerNode.Value.VisiblePart, layersBelow);
            layerNode.Value.SetVisibility(false);

            return result;
        }

        public IReadOnlyTexture Remove(IGraphicObject graphicObject)
        {
            var layersBelow = _layerOrder.SelectLayersBelow(graphicObject);
            var layer = _layerOrder.FindLayer(graphicObject);

            var result = RemoveOverlap(layer.VisiblePart, layersBelow);
            _layerOrder.Clear(layer);

            return result;
        }

        public IReadOnlyTexture Clear()
        {
            var points = _layerOrder.AllPoints;
            Texture result = new Texture(points, Pixel.BlackSpace);
            _layerOrder.Clear();
            return result;
        }
        #endregion

        #region PrivateMethods
        private void Overlap(IReadOnlyTexture covering, IEnumerable<ScreenLayer> layers)
        {
            var coveringPart = covering.Clone();

            foreach (var layer in layers)
            {
                if (layer.IsVisible)
                    layer.Overlap(ref coveringPart);
            }
        }

        private IReadOnlyTexture RemoveOverlap(IReadOnlyTexture overlap, IEnumerable<ScreenLayer> layers)
        {
            return null;
        }
        #endregion
    }
}