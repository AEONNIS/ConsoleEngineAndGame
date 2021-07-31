using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayersOrder
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region Properties
        public IReadOnlyCollection<ScreenLayer> LayersTopToBottom => _layers;
        #endregion

        #region Methods
        public ScreenLayer GetNewLayer(IGraphics graphicObject)
        {
            var layer = _layerPool.Extract();
            layer.Init(graphicObject);

            return layer;
        }

        public void AddToTop(ScreenLayer layer) => _layers.AddFirst(layer);
        public void AddToTop(LinkedListNode<ScreenLayer> layerNode) => _layers.AddFirst(layerNode);

        public bool Contains(IGraphics graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return true;
            }

            return false;
        }

        public ScreenLayer FindLayer(IGraphics graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return layer;
            }

            return null;
        }

        public LinkedListNode<ScreenLayer> ExtractLayerNode(IGraphics graphicObject)
        {
            LinkedListNode<ScreenLayer> result = null;

            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                {
                    result = _layers.Find(layer);
                    _layers.Remove(result);
                    break;
                }
            }

            return result;
        }

        public IEnumerable<ScreenLayer> SelectLayersTopToBottomAbove(IGraphics graphicObject) =>
                                            _layers.TakeWhile(layer => layer.Contains(graphicObject) == false);

        public IEnumerable<ScreenLayer> SelectLayersTopToBottomBelow(IGraphics graphicObject) =>
                                            _layers.SkipWhile(layer => layer.Contains(graphicObject) == false).Skip(1);

        public void Remove(ScreenLayer layer)
        {
            _layers.Remove(layer);
            layer.Clear();
            _layerPool.Place(layer);
        }

        public void Clear()
        {
            foreach (var layer in _layers)
            {
                layer.Clear();
                _layerPool.Place(layer);
            }

            _layers.Clear();
        }
        #endregion
    }
}
