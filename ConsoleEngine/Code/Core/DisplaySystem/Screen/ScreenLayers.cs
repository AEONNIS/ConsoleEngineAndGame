using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayers
    {
        #region Fields
        private readonly Queue<ScreenLayer> _pool = new Queue<ScreenLayer>(); // Сделать generic pool
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region PublicMethods
        public void AddTopLayer(IGraphicObject graphicObject)
        {
            var layer = GetLayerFromPool();
            layer.Init(graphicObject);

        }
        #endregion

        #region PrivateMethods
        private ScreenLayer GetLayerFromPool() => _pool.TryDequeue(out ScreenLayer layer) ? layer : new ScreenLayer();

        private void ReturnLayerToPool(ScreenLayer layer) => _pool.Enqueue(layer);

        private void OverlapLayers(IGraphicObject covered)
        {
            foreach (var layer in _layers)
            {
                var coveringPart=
            }
        }
        #endregion
    }
}