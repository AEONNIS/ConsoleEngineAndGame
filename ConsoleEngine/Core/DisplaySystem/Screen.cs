using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public static class Screen
    {
        private static ScreenPixel[,] _buffer;

        static Screen() => Maximize();

        public static void SetSize(int width, int height)
        {
            _buffer = new ScreenPixel[width, height];
            Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);
        }

        public static void Maximize() => SetSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        public static ScreenPixel GetPixel(int x, int y) => _buffer[x, y];
        public static ScreenPixel GetPixel(Vector2Int position) => _buffer[position.X, position.Y];

        public static void Display(ScreenPixel pixel, int x, int y)
        {
            _buffer[x, y] = pixel;
            pixel.Display(x, y);
        }
        public static void Display(ScreenPixel pixel, Vector2Int position) => Display(pixel, position.X, position.Y);

        public static void Clear()
        {
            Array.Clear(_buffer)
        }
    }
}
