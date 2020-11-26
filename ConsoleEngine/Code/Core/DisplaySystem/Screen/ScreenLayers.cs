using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayers
    {
        #region Fields
        protected readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region PublicMethods
        public void AddTopLayer(IGraphicObject graphicObject)
        {
            var layer = _layerPool.Get();
            layer.Init(graphicObject);
            OverlapLayers(graphicObject.Texture);
            _layers.AddFirst(layer);
        }

        public ScreenLayer GetLayer(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Name == graphicObject.Name)
                    return layer;
            }

            return null;
        }

        public void RaiseToTop(IGraphicObject graphicObject)
        {
            var layer = GetLayer(graphicObject);
            _layers.Remove(layer);
            OverlapLayers(layer.Total);
            _layers.AddFirst(layer);
        }
        #endregion

        #region PrivateMethods
        private void OverlapLayers(Texture covering)
        {
            var coveringPart = new Texture(covering.Pixels);

            foreach (var layer in _layers)
                layer.Overlap(ref coveringPart);
        }
        #endregion
    }
}