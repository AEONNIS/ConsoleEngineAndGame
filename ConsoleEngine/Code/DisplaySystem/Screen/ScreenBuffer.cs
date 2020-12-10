using System;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region PublicMethods
        public ScreenLayer GetLayer(IGraphicObject graphicObject)
        {
            throw new Exception();
        }

        public void AddToTop(IGraphicObject graphicObject)
        {

        }

        public void RaiseToTop(IGraphicObject graphicObject)
        {

        }

        public void Hide(IGraphicObject graphicObject)
        {

        }

        public void Clear(IGraphicObject graphicObject)
        {

        }
        #endregion

        #region PrivateMethods
        private void OverlapLayers(Texture covering)
        {

        }
        #endregion
    }
}