using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayerPool
    {
        #region Fields
        private readonly Queue<ScreenLayer> _pool = new Queue<ScreenLayer>();
        #endregion

        #region Properties
        public ScreenLayer GetLayer => _pool.TryDequeue(out ScreenLayer layer) ? layer : new ScreenLayer();
        #endregion

        #region Methods
        public void ReturnToPool(ScreenLayer layer) => _pool.Enqueue(layer);
        #endregion
    }
}
