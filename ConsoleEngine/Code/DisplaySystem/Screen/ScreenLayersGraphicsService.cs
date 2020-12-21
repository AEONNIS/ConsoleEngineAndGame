using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayersGraphicsService
    {
        #region Fields
        private readonly Pixel _emptyPixel;
        #endregion

        #region Constructors
        public ScreenLayersGraphicsService(in Pixel emptyPixel) => _emptyPixel = emptyPixel;
        #endregion

        #region Methods
        public void ToCover(IEnumerable<ScreenLayer> layers, IReadOnlyTexture covering)
        {
            var coveringPart = covering.Clone();

            foreach (var layer in layers)
            {
                layer.ToCover(ref coveringPart);

                if (coveringPart.IsEmpty)
                    break;
            }
        }

        public IReadOnlyTexture ToUncover(IEnumerable<ScreenLayer> layers, IReadOnlyTexture covering)
        {
            return null;
        }

        public IReadOnlyTexture GetEmptyPixelTexture(IEnumerable<ScreenLayer> layers)
        {
            return null;
        }
        #endregion
    }
}