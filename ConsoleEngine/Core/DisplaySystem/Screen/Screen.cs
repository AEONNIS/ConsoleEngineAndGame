using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Screen
    {
        private Pixel[,] _buffer;

        private Screen()
        {
            Console.CursorVisible = false;
            Maximize();
        }

        public static Screen Get { get; } = new Screen();

        public void Maximize() => SetSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        public void SetSize(int width, int height)
        {
            var temp = _buffer;
            _buffer = new Pixel[width, height];
            Array.Copy(temp, _buffer, width * height);
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public Pixel GetPixel(int x, int y) => _buffer[x, y];
        public Pixel GetPixel(Vector2Int position) => _buffer[position.X, position.Y];

        public void Display(Pixel pixel, int x, int y)
        {
            pixel.Display(x, y);
            _buffer[x, y] = pixel;
        }
        public void Display(Pixel pixel, Vector2Int position) => Display(pixel, position.X, position.Y);

        public void Clear()
        {
            _buffer = FillBuffer(Console.WindowWidth, Console.WindowHeight, Pixel.Black);
            Console.ResetColor();
            Console.Clear();
        }

        private Pixel[,] FillBuffer(int width, int height, Pixel pixel)
        {
            Pixel[,] buffer = new Pixel[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    buffer[x, y] = pixel;

            return buffer;
        }
    }
}
