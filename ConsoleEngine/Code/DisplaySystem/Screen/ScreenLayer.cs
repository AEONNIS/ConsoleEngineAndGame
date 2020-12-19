namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private readonly Texture _hiddenPart = new Texture();
        #endregion

        #region Properties
        public IGraphicObject GraphicObject { get; private set; }
        public IReadOnlyTexture VisiblePart
        {
            get
            {
                var result = GraphicObject.Texture.Clone();
                result.Substract(_hiddenPart);
                return result;
            }
        }
        public bool IsVisible { get; private set; }
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            GraphicObject = graphicObject;
            _hiddenPart.Clear();
            IsVisible = true;
        }

        public bool Contains(IGraphicObject graphicObject) => GraphicObject == graphicObject;

        public void SetVisibility(bool visibility) => IsVisible = visibility;

        public IReadOnlyTexture HiddenPartGetAndClear()
        {
            IReadOnlyTexture result = _hiddenPart.Clone();
            _hiddenPart.Clear();
            return result;
        }

        public void Hide()
        {
            _hiddenPart.Clear();
            IsVisible = false;
        }

        public void Clear()
        {
            GraphicObject = null;
            _hiddenPart.Clear();
            IsVisible = false;
        }

        public void Overlap(ref Texture covering)
        {

        }

        public IReadOnlyTexture RemoveOverlap(IReadOnlyTexture overlap)
        {
            return null;
        }
        #endregion
    }
}
