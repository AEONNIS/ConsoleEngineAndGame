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

        #region Methods
        public bool Contains(IGraphicObject graphicObject) => _layerOrder.Contains(graphicObject);

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layerOrder.GetNewLayer(graphicObject);
            _graphicControl.Overlap(layer.TotalTexture, _layerOrder.Layers);
            _layerOrder.AddToTop(layer);

            return layer.TotalTexture;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layer = _layerOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersAbove = _layerOrder.SelectLayersAbove(graphicObject);
                var layerNode = _layerOrder.ExtractLayerNode(graphicObject);
                _graphicControl.Overlap(layer.TotalTexture, layersAbove);
                _layerOrder.AddToTop(layerNode);

                return layer.HiddenPartGetCloneAndClear();
            }
            else
            {
                var layerNode = _layerOrder.ExtractLayerNode(graphicObject);
                _graphicControl.Overlap(layer.TotalTexture, _layerOrder.Layers);
                _layerOrder.AddToTop(layerNode);
                layer.SetVisibility(true);

                return layer.TotalTexture;
            }
        }

        public IReadOnlyTexture Hide(IGraphicObject graphicObject)
        {
            var layer = _layerOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layerOrder.SelectLayersBelow(graphicObject);
                var result = _graphicControl.RemoveOverlap(layer.VisiblePart, layersBelow);
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
            var layer = _layerOrder.FindLayer(graphicObject);

            if (layer.IsVisible)
            {
                var layersBelow = _layerOrder.SelectLayersBelow(graphicObject);
                var result = _graphicControl.RemoveOverlap(layer.VisiblePart, layersBelow);
                _layerOrder.Remove(layer);

                return result;
            }
            else
            {
                _layerOrder.Remove(layer);

                return new Texture();
            }
        }

        public IReadOnlyTexture Clear()
        {
            var result = _graphicControl.GetEmptyPixelTexture(_layerOrder.Layers);
            _layerOrder.Clear();
            return result;
        }
        #endregion
    }
}