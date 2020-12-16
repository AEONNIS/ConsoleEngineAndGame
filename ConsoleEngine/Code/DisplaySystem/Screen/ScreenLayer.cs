namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private readonly Texture _hiddenPart = new Texture();
        #endregion

        #region Properties
        public IGraphicObject GraphicObject { get; private set; }
        public IReadOnlyTexture HiddenPart => _hiddenPart;
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
