namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayer : IContainer<IGraphicObject>, IVisible
    {
        #region Fields
        private readonly Texture _hiddenPart = new Texture();
        #endregion

        #region Properties
        public IGraphicObject GraphicObject { get; private set; }
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

        public void Clear()
        {
            GraphicObject = null;
            _hiddenPart.Clear();
            IsVisible = false;
        }

        public void Overlap(ref Texture covering)
        {

        }
        #endregion
    }
}
