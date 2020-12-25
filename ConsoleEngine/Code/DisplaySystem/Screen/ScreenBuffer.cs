namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly ScreenLayersOrder _layersOrder = new ScreenLayersOrder();
        #endregion

        #region Methods
        public bool Contains(IGraphicObject graphicObject) => _layersOrder.Contains(graphicObject);

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.GetNewLayer(graphicObject);
            ScreenLayersGraphicsService.ToCover(_layersOrder.LayersTopToBottom, layer.Total);
            _layersOrder.AddToTop(layer);

            return layer.Total;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersAbove = _layersOrder.SelectLayersTopToBottomAbove(graphicObject);
                var layerNode = _layersOrder.ExtractLayerNode(graphicObject);
                ScreenLayersGraphicsService.ToCover(layersAbove, layer.CoveredPart);
                _layersOrder.AddToTop(layerNode);

                return layer.GetCoveredPartCloneAndCleanIt();
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

        public IReadOnlyTexture Hide(IGraphicObject graphicObject, Pixel emptyPixel)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersTopToBottomBelow(graphicObject);
                var result = ScreenLayersGraphicsService.ToUncover(layersBelow, layer.UncoveredPart, emptyPixel);
                layer.Hide();

                return result;
            }
            else
            {
                return new Texture();
            }
        }

        public IReadOnlyTexture Remove(IGraphicObject graphicObject, Pixel emptyPixel)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersTopToBottomBelow(graphicObject);
                var result = ScreenLayersGraphicsService.ToUncover(layersBelow, layer.UncoveredPart, emptyPixel);
                _layersOrder.Remove(layer);

                return result;
            }
            else
            {
                _layersOrder.Remove(layer);

                return new Texture();
            }
        }

        public IReadOnlyTexture Clear(Pixel emptyPixel)
        {
            var result = ScreenLayersGraphicsService.GetEmptyTextureFrom(_layersOrder.LayersTopToBottom, emptyPixel);
            _layersOrder.Clear();

            return result;
        }
        #endregion
    }
}