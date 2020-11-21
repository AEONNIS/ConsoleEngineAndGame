using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayers
    {
        #region Fields
        private readonly ScreenLayerPool _pool = new ScreenLayerPool();
        private readonly List<ScreenLayer> _layers = new List<ScreenLayer>();
        #endregion

        #region Methods
        public void InitLayer(IGraphicObject graphicObject)
        {
            var layer = _pool.GetLayer;
            layer.Init(graphicObject);
            _layers.Add(layer);
        }

        public void Overlap(IGraphicObject covering)
        {

        }


        #endregion
    }
}