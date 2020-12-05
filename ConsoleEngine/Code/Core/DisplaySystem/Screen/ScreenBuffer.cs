using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion
    }
}