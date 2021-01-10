using ConsoleEngine.Maths;
using System;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class Screen
    {
        #region StaticFields
        private static readonly Screen _screen = new Screen();
        #endregion

        #region Fields
        private readonly ScreenBuffer _buffer = new ScreenBuffer();
        private readonly Rectangle _rectangle = new Rectangle(Vector2Int.Zero, new Vector2Int(Console.LargestWindowWidth, Console.LargestWindowHeight));
        private readonly Pixel _empty = Pixel.BlackSpace;
        #endregion

        #region Constructors
        private Screen()
        {
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
            var texture = _buffer.Hide(graphicObject, _empty);
            Display(texture);
        }

        public void Remove(IGraphicObject graphicObject)
        {
            var texture = _buffer.Remove(graphicObject, _empty);
            Display(texture);
        }

        public void Clear()
        {
            var texture = _buffer.Clear(_empty);
            Display(texture);
        }
        #endregion

        #region PrivateMethods
        private void Display(IReadOnlyTexture texture)
        {
            foreach (var placedPixel in texture)
                Display(placedPixel);
        }

        private void Display(KeyValuePair<Vector2Int, Pixel> placedPixel)
        {
            placedPixel.Key.SetCursorPosition();
            SetConsoleColors(placedPixel.Value, placedPixel.Key);
            Console.Write(placedPixel.Value.Foreground.Symbol);
        }

        private void SetConsoleColors(in Pixel original, in Vector2Int point)
        {
            if (original.BackgroundColor.HasValue && original.Foreground.Color.HasValue)
            {
                Console.BackgroundColor = original.BackgroundColor.Value;
                Console.ForegroundColor = original.Foreground.Color.Value;
            }
            else
            {
                Pixel? buffer = _buffer.GetPixelIn(point);
                SetColor(true, original, buffer, _empty);
                SetColor(false, original, buffer, _empty);
            }
        }

        private void SetColor(bool background, in Pixel original, in Pixel? buffer, in Pixel empty)
        {
            if (buffer.HasValue)
            {
                SetColor(true, GetColor(original.BackgroundColor, buffer.Value.BackgroundColor, empty.BackgroundColor));
                SetColor(false, GetColor(original.Foreground.Color, buffer.Value.Foreground.Color, empty.Foreground.Color));
            }
            else
            {
                SetColor(true, GetColor(original.BackgroundColor, empty.BackgroundColor));
                SetColor(false, GetColor(original.Foreground.Color, empty.Foreground.Color));
            }
        }

        private void SetColor(bool background, ConsoleColor color)
        {
            if (background)
                Console.BackgroundColor = color;
            else
                Console.ForegroundColor = color;
        }

        private ConsoleColor GetColor(ConsoleColor? original, ConsoleColor? buffer, ConsoleColor? empty) =>
                                original ?? buffer ?? empty.Value;

        private ConsoleColor GetColor(ConsoleColor? original, ConsoleColor? empty) =>
                                original ?? empty.Value;
        #endregion
    }
}
