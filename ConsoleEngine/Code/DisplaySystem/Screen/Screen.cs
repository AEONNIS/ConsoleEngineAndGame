using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.DisplaySystem
{
    public class Screen
    {
        #region StaticFields
        private static readonly Screen _screen = new Screen();
        #endregion

        #region Fields
        private readonly ScreenBuffer _buffer;
        private readonly Rectangle _rectangle = new Rectangle(Vector2Int.Zero, new Vector2Int(Console.LargestWindowWidth, Console.LargestWindowHeight));
        private readonly Pixel _emptyPixel = Pixel.BlackSpace;
        #endregion

        #region Constructors
        private Screen()
        {
            _buffer = new ScreenBuffer(_emptyPixel);

            Console.CursorVisible = false;
            Console.SetWindowSize(_rectangle.Size.X, _rectangle.Size.Y);
            Console.SetBufferSize(_rectangle.Size.X, _rectangle.Size.Y);
        }
        #endregion

        #region StaticMethods
        public static Screen Get() => _screen;

        public static string GetDisplayTitle() => Console.Title;
        public static void SetDisplayTitle(string title) => Console.Title = title;
        #endregion

        #region PublicMethods
        public void Display(IGraphicObject graphicObject)
        {
            var texture = _buffer.Contains(graphicObject) ? _buffer.RaiseToTop(graphicObject) : _buffer.AddToTop(graphicObject);
            Display(texture);
        }

        public void Hide(IGraphicObject graphicObject)
        {
            var texture = _buffer.Hide(graphicObject);
            Display(texture);
        }

        public void Remove(IGraphicObject graphicObject)
        {
            var texture = _buffer.Remove(graphicObject);
            Display(texture);
        }

        public void Clear()
        {
            var texture = _buffer.Clear();
            Display(texture);
        }
        #endregion

        #region PrivateMethods
        private void Display(IReadOnlyTexture texture)
        {
            foreach (var placedPixel in texture)
            {
                placedPixel.Key.SetCursorPosition();
                SetConsoleColors(placedPixel.Value);
                Console.Write(placedPixel.Value.Foreground.Symbol);
            }
        }

        private void SetConsoleColors(in Pixel pixel)
        {
            Console.BackgroundColor = pixel.BackgroundColor ?? _emptyPixel.BackgroundColor.Value;
            Console.ForegroundColor = pixel.Foreground.Color ?? _emptyPixel.Foreground.Color.Value;
        }
        #endregion
    }
}
