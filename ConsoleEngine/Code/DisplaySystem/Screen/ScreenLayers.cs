using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayers
    {
        #region Fields
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region Properties
        public IReadOnlyCollection<ScreenLayer> Layers => _layers;
        #endregion

        #region Methods
        public bool Contains(IGraphicObject graphicObject)
        {
            foreach (var item in _layers)
            {
                if (item.Contains(graphicObject))
                    return true;
            }

            return false;
        }

        public void AddFirst(ScreenLayer layer) => _layers.AddFirst(layer);
        public void AddFirst(LinkedListNode<ScreenLayer> layerNode) => _layers.AddFirst(layerNode);

        public ScreenLayer FindLayer(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return layer;
            }

            return null;
        }

        public IEnumerable<ScreenLayer> SelectLayersBefore(IGraphicObject graphicObject) =>
                                            _layers.TakeWhile(layer => layer.Contains(graphicObject) == false && layer.IsVisible);

        public IEnumerable<ScreenLayer> SelectLayersAfter(IGraphicObject graphicObject) =>
                                            _layers.SkipWhile(layer => layer.Contains(graphicObject) && layer.IsVisible).Skip(1);

        public LinkedListNode<ScreenLayer> ExtractLayerNode(IGraphicObject graphicObject)
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
