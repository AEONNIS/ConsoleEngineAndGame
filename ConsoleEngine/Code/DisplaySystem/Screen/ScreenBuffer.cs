using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>(); // Оптимизировать?
        private readonly Pixel _defaultBackgroundPixel = Pixel.BlackSpace;
        #endregion

        #region PublicMethods
        public bool Contains(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.GraphicObject == graphicObject)
                    return true;
            }

            return false;
        }

        public IReadOnlyTexture AddToTop(IGraphicObject graphicObject)
        {
            var layer = _layerPool.Extract();
            layer.Init(graphicObject);
            Overlap(graphicObject.Texture, _layers);
            _layers.AddFirst(layer); // Оптимизировать, используя LinkedListNode?
            return graphicObject.Texture;
        }

        public IReadOnlyTexture RaiseToTop(IGraphicObject graphicObject)
        {
            var layerNode = ExtractLayerNode(graphicObject, out int index);
        }

        public IReadOnlyTexture Hide(IGraphicObject graphicObject)
        {
            throw new System.Exception();
        }

        public IReadOnlyTexture Remove(IGraphicObject graphicObject)
        {
            throw new System.Exception();
        }

        public IReadOnlyTexture Clear()
        {
            throw new System.Exception();
        }
        #endregion

        #region PrivateMethods
        private void Overlap(IReadOnlyTexture covering, IEnumerable<ScreenLayer> layers)
        {
            var coveringPart = covering.Clone();

            foreach (var layer in layers)
                layer.Overlap(ref coveringPart);
        }

        private IEnumerable<ScreenLayer> SelectLayers(int index) => _layers.Where((layer, number) => number <= index);

        private LinkedListNode<ScreenLayer> ExtractLayerNode(IGraphicObject graphicObject, out int index)
        {
            LinkedListNode<ScreenLayer> result = null;
            index = 0;

            foreach (var layer in _layers)
            {
                if (layer.GraphicObject == graphicObject)
                    result = _layers.Find(layer);

                index++;
            }

            _layers.Remove(result);
            return result;
        }
        #endregion
    }
}