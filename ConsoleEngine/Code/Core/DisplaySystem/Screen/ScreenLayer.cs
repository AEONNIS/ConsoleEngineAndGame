namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayer
    {
        private readonly Texture _hiddenPart = new Texture();

        #region Properties
        public IGraphicObject GraphicObject { get; private set; }
        public ITexture HiddenPart => _hiddenPart;
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            _hiddenPart.Clear();
            GraphicObject = graphicObject;
        }

        public void Clear()
        {
            GraphicObject = null;
            _hiddenPart.Clear();
        }

        public void ClearHiddenPart() => _hiddenPart.Clear();

        public void Overlap(ref Texture covering)
        {

        }
        #endregion
    }
}
