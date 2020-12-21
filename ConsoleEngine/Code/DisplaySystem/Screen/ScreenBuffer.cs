namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly ScreenLayersOrder _layersOrder = new ScreenLayersOrder();
        private readonly ScreenLayersGraphicsService _graphicsService;
        #endregion

        #region Constructors
        public ScreenBuffer(in Pixel emptyPixel) => _graphicsService = new ScreenLayersGraphicsService(emptyPixel);
        #endregion

        #region Methods
        public bool Contains(IGraphicObject graphicObject) => _layersOrder.Contains(graphicObject);

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.GetNewLayer(graphicObject);
            _graphicsService.ToCover(_layersOrder.Layers, layer.Total);
            _layersOrder.AddToTop(layer);

            return layer.Total;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersAbove = _layersOrder.SelectLayersAbove(graphicObject);
                var layerNode = _layersOrder.ExtractLayerNode(graphicObject);
                _graphicsService.ToCover(layersAbove, layer.Total);
                _layersOrder.AddToTop(layerNode);

                return layer.GetCoveredPartCloneAndCleanIt();
            }
            else
            {
                var layerNode = _layersOrder.ExtractLayerNode(graphicObject);
                _graphicsService.ToCover(_layersOrder.Layers, layer.Total);
                _layersOrder.AddToTop(layerNode);
                layer.SetVisibility(true);

                return layer.Total;
            }
        }

        public IReadOnlyTexture Hide(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersBelow(graphicObject);
                var result = _graphicsService.ToUncover(layersBelow, layer.UncoveredPart);
                layer.Hide();

                return result;
            }
            else
            {
                return new Texture();
            }
        }

        public IReadOnlyTexture Remove(IGraphicObject graphicObject)
        {
            var layer = _layersOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layersOrder.SelectLayersBelow(graphicObject);
                var result = _graphicsService.ToUncover(layersBelow, layer.UncoveredPart);
                _layersOrder.Remove(layer);

                return result;
            }
            else
            {
                _layersOrder.Remove(layer);

                return new Texture();
            }
        }

        public IReadOnlyTexture Clear()
        {
            var result = _graphicsService.GetEmptyPixelTexture(_layersOrder.Layers);
            _layersOrder.Clear();

            return result;
        }
        #endregion
    }
}