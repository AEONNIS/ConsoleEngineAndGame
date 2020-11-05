using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Screen
    {
        private static readonly Screen _screen = new Screen();
        private readonly ScreenBuffer _activeBuffer;

        private Screen()
        {
            _activeBuffer = new ScreenBuffer(Console.LargestWindowWidth, Console.LargestWindowHeight, Pixel.Black);
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        public static Screen Get() => _screen;

        public static string GetDisplayTitle() => Console.Title;
        public static void SetDisplayTitle(string title) => Console.Title = title;

        public ConsoleColor GetColorFrom(bool foreground, int x, int y)
        {
            var pixel = _activeBuffer.GetPixel(x, y);
            ConsoleColor? color = foreground ? pixel.Foreground.Color : pixel.BackgroundColor;
            return color ?? ConsoleColor.Black;
        }
        public ConsoleColor GetColorFrom(bool foreground, Vector2Int position) => GetColorFrom(foreground, position.X, position.Y);

        public Pixel GetPixel(int x, int y) => _activeBuffer.GetPixel(x, y);
        public Pixel GetPixel(Vector2Int position) => _activeBuffer.GetPixel(position);

        public void Display(Pixel pixel, int x, int y)
        {
            pixel.DisplayInConsole(x, y);
            _activeBuffer.Set(pixel, x, y);
        }
        public void Display(Pixel pixel, Vector2Int position) => Display(pixel, position.X, position.Y);

        public void Display(Texture texture)
        {
            texture.DisplayInConsole();
            _activeBuffer.Set(texture);
        }

        public void Clear()
        {
            _activeBuffer.Clear(Pixel.Black);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
