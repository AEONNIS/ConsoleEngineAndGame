using ConsoleEngine.Maths;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private IGraphicObject _graphicObject;
        private readonly Texture _coveredPart = new Texture();
        #endregion

        #region Properties
        public bool IsVisible { get; private set; }

        public IReadOnlyTexture Total => _graphicObject.Texture;

        public IReadOnlyTexture CoveredPart => _coveredPart;

        public IReadOnlyTexture UncoveredPart => Texture.Subtract(Total, CoveredPart);
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            _graphicObject = graphicObject;
            _coveredPart.Clear();
            IsVisible = true;
        }

        public bool Contains(IGraphicObject graphicObject) => _graphicObject == graphicObject;

        public Pixel? GetPixelIn(in Vector2Int point) => Total.GetPixelIn(point);

        public void SetVisibility(bool visibility) => IsVisible = visibility;

        public IReadOnlyTexture GetCoveredPartCloneAndCleanIt()
        {
            IReadOnlyTexture result = _coveredPart.Clone();
            _coveredPart.Clear();
            return result;
        }

        public void Hide()
        {
            _coveredPart.Clear();
            IsVisible = false;
        }

        public void Clear()
        {
            _graphicObject = null;
            _coveredPart.Clear();
            IsVisible = false;
        }

        public void ToCover(ref Texture covering)
        {
            if (IsVisible)
            {
                var coveredAddition = Texture.SubtractAndGetIntersection(ref covering, Total);
                _coveredPart.AddOrReplace(coveredAddition);
            }
        }

        public IReadOnlyTexture ToUncover(ref Texture covering)
        {
            if (IsVisible)
            {
                var result = Texture.SubtractAndGetIntersection(ref covering, CoveredPart);
                _coveredPart.Subtract(result);

                return result;
            }

            return Texture.Empty;
        }
        #endregion
    }
}
