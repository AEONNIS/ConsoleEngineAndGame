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
        public bool Contains(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.GraphicObject == graphicObject)
                    return true;
            }

            return false;
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

        public void Remove(IGraphicObject graphicObject)
        {

        }

        public void Clear()
        {

        }
        #endregion

        #region PrivateMethods
        private void OverlapLayers(ref Texture covering)
        {

        }
        #endregion
    }
}