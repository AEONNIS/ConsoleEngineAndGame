using System;

namespace ConsoleEngine.Core
{
    public static partial class Display
    {
        public static partial class Screen
        {
            private static Pixel[,] _pixels;

            static Screen() => Maximize();

            public static void SetSize(int width, int height)
            {
                _pixels = new Pixel[width, height];
                Console.SetBufferSize(width, height);
                Console.SetWindowSize(width, height);
            }

            public static void Maximize() => SetSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            public static Pixel GetPixel(int x, int y) => _pixels[x, y];

        }
    }
}
