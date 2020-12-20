namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private IGraphicObject _graphicObject;
        private readonly Texture _hiddenPart = new Texture();
        #endregion

        #region Properties
        public IReadOnlyTexture TotalTexture => _graphicObject.Texture;

        public IReadOnlyTexture VisiblePart
        {
            get
            {
                var result = _graphicObject.Texture.Clone();
                result.Substract(_hiddenPart);
                return result;
            }
        }
        public bool IsVisible { get; private set; }
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            _graphicObject = graphicObject;
            _hiddenPart.Clear();
            IsVisible = true;
        }

        public bool Contains(IGraphicObject graphicObject) => _graphicObject == graphicObject;

        public void SetVisibility(bool visibility) => IsVisible = visibility;

        public IReadOnlyTexture HiddenPartGetCloneAndClear()
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
            _graphicObject = null;
            _hiddenPart.Clear();
            IsVisible = false;
        }

        public void Overlap(ref Texture covering)
        {
            if (IsVisible)
            {

            }
        }

        public IReadOnlyTexture RemoveOverlap(IReadOnlyTexture overlap)
        {
            return null;
        }
        #endregion
    }
}
