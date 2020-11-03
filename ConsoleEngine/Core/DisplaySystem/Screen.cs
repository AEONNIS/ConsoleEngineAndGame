using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public static class Screen // => Singleton
    {
        private static Pixel[,] _buffer;

        public static void Init()
        {
            Console.CursorVisible = false;
            Maximize();
        }

        public static void Maximize() => SetSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        public static void SetSize(int width, int height)
        {
            _buffer = FillBuffer(width, height, Pixel.Black);
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public static Pixel GetPixel(int x, int y) => _buffer[x, y];
        public static Pixel GetPixel(Vector2Int position) => _buffer[position.X, position.Y];

        public static void Display(Pixel pixel, int x, int y)
        {
            _buffer[x, y] = pixel;
            pixel.Display(x, y);
        }
        public static void Display(Pixel pixel, Vector2Int position) => Display(pixel, position.X, position.Y);

        public static void Clear()
        {
            _buffer = FillBuffer(Console.WindowWidth, Console.WindowHeight, Pixel.Black);
            Console.ResetColor();
            Console.Clear();
        }

        private static Pixel[,] FillBuffer(int width, int height, Pixel pixel)
        {
            Pixel[,] buffer = new Pixel[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    buffer[x, y] = pixel;

            return buffer;
        }
    }
}
