using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>(); // Может его вместе с методами вынести в отдельный класс?
        private readonly Pixel _defaultBackgroundPixel = Pixel.BlackSpace;
        #endregion

        #region PublicMethods
        public bool Contains(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return true;
            }

            return false;
        }

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layerPool.Extract();
            layer.Init(graphicObject);
            Overlap(graphicObject.Texture, _layers);
            _layers.AddFirst(layer);

            return graphicObject.Texture;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layersBefore = SelectLayersBefore(graphicObject);
            var layerNode = ExtractLayerNode(graphicObject);
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

        private ScreenLayer FindLayer(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return layer;
            }

            return null;
        }

        private IEnumerable<ScreenLayer> SelectLayersBefore(IGraphicObject graphicObject) =>
                                            _layers.TakeWhile(layer => layer.Contains(graphicObject) == false && layer.IsVisible);

        private IEnumerable<ScreenLayer> SelectLayersAfter(IGraphicObject graphicObject) =>
                                            _layers.SkipWhile(layer => layer.Contains(graphicObject) && layer.IsVisible).Skip(1);

        private LinkedListNode<ScreenLayer> ExtractLayerNode(IGraphicObject graphicObject)
        {
            LinkedListNode<ScreenLayer> result = null;

            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    result = _layers.Find(layer);
            }

            _layers.Remove(result);
            return result;
        }
        #endregion
    }
}