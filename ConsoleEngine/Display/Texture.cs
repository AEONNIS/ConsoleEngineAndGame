using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Display
{
    public struct Texture : IDisplayable
    {
        public Texture(Pixel[,] pixels)
        {
            Pixels = pixels;
        }

        public Pixel[,] Pixels { get; private set; }

        public void Display(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Display(Vector2Int position)
        {
            throw new NotImplementedException();
        }
    }
}
