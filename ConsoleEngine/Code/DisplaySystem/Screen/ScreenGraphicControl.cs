using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenGraphicControl
    {
        #region Fields
        private readonly Pixel _emptyPixel;
        #endregion

        #region Constructors
        public ScreenGraphicControl(in Pixel emptyPixel) => _emptyPixel = emptyPixel;
        #endregion

        #region Methods
        public void Overlap(IReadOnlyTexture covering, IEnumerable<ScreenLayer> layers)
        {
            var coveringPart = covering.Clone();

            foreach (var layer in layers)
            {
                layer.Overlap(ref coveringPart);

                if (coveringPart.IsEmpty)
                    break;
            }
        }

        public IReadOnlyTexture RemoveOverlap(IReadOnlyTexture overlap, IEnumerable<ScreenLayer> layers)
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