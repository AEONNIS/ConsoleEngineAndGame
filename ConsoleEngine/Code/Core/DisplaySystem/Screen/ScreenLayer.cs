namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayer
    {
        #region Properties
        public IGraphicObject GraphicObject { get; private set; }
        public Texture Delta { get; private set; }
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject) => GraphicObject = graphicObject;

        public void ClearDelta() => Delta.Clear();

        public void Clear() => GraphicObject = null;
        #endregion
    }
}
