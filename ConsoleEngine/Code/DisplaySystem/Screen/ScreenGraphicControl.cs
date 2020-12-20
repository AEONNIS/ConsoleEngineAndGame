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
    }
}