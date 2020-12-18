using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly List<ScreenLayer, IGraphicObject> _layers = new List<ScreenLayer, IGraphicObject>();
        private readonly Pixel _defaultBackgroundPixel = Pixel.BlackSpace;
        #endregion

        #region PublicMethods
        public bool Contains(IGraphicObject graphicObject) => _layers.Contains(graphicObject);

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layerPool.Extract();
            layer.Init(graphicObject);
            Overlap(graphicObject.Texture, _layers.AllCollection);
            _layers.AddFirst(layer);

            return graphicObject.Texture;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layersBefore = _layers.SelectItemsBefore(graphicObject);
            var layerNode = _layers.ExtractItemNode(graphicObject);
            Overlap(graphicObject.Texture, layersBefore);
            layerNode.Value.SetVisibility(true);
            _layers.AddFirst(layerNode);

            return layerNode.Value.HiddenPartGetAndClear();
        }

        public IReadOnlyTexture Hide(IGraphicObject graphicObject)
        {
            // Нужны операции с текстурами, прописать их...
            return null;
        }

        public IReadOnlyTexture Remove(IGraphicObject graphicObject)
        {
            return null;
        }

        public IReadOnlyTexture Clear()
        {
            // Слои вернуть в пул.
            return null;
        }
        #endregion

        #region PrivateMethods
        private void Overlap(IReadOnlyTexture covering, IEnumerable<ScreenLayer> layers)
        {
            var coveringPart = covering.Clone();

            foreach (var layer in layers)
                layer.Overlap(ref coveringPart);
        }
        #endregion
    }
}