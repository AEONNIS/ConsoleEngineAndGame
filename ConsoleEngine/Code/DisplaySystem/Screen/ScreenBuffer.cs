using ConsoleEngine.Maths;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly ScreenLayersOrder _layersOrder = new ScreenLayersOrder();
        #endregion

        #region Methods
        public bool Contains(IGraphics graphicObject) => _layersOrder.Contains(graphicObject);

        public Pixel? GetPixelIn(in Vector2Int point)
        {
            Pixel? result = null;

            foreach (var layer in _layersOrder.LayersTopToBottom)
            {
                result = layer.GetPixelIn(point);

                if (result.HasValue)
                    return result;
            }

            return result;
        }

        public IReadOnlyTexture AddToTop(IGraphics graphicObject)
        {
            var layer = _layersOrder.GetNewLayer(graphicObject);
            ScreenLayersGraphicsService.ToCover(_layersOrder.LayersTopToBottom, layer.Total);
            _layersOrder.AddToTop(layer);

            return layer.Total;
        }

        public IReadOnlyTexture RaiseToTop(IGraphics graphicObject)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersAbove = _layersOrder.SelectLayersTopToBottomAbove(graphicObject);
                var layerNode = _layersOrder.ExtractLayerNode(graphicObject);
                ScreenLayersGraphicsService.ToCover(layersAbove, layer.CoveredPart);
                _layersOrder.AddToTop(layerNode);

                return layer.GetCoveredPartCloneAndClearCoveredPart();
            }
            else
            {
                var layerNode = _layersOrder.ExtractLayerNode(graphicObject);
                ScreenLayersGraphicsService.ToCover(_layersOrder.LayersTopToBottom, layer.Total);
                _layersOrder.AddToTop(layerNode);
                layer.SetVisibility(true);

                return layer.Total;
            }
        }

        public IReadOnlyTexture Hide(IGraphics graphicObject, in Pixel empty)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersTopToBottomBelow(graphicObject);
                var result = ScreenLayersGraphicsService.ToUncover(layersBelow, layer.UncoveredPart, empty);
                layer.Hide();

                return result;
            }
            else
            {
                return Texture.Empty;
            }
        }

        public IReadOnlyTexture Remove(IGraphics graphicObject, in Pixel empty)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersTopToBottomBelow(graphicObject);
                var result = ScreenLayersGraphicsService.ToUncover(layersBelow, layer.UncoveredPart, empty);
                _layersOrder.Remove(layer);

                return result;
            }
            else
            {
                _layersOrder.Remove(layer);

                return Texture.Empty;
            }
        }

        public IReadOnlyTexture Clear(in Pixel empty)
        {
            var result = ScreenLayersGraphicsService.GetEmptyTextureFrom(_layersOrder.LayersTopToBottom, empty);
            _layersOrder.Clear();

            return result;
        }
        #endregion
    }
}