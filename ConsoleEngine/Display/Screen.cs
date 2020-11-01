using System;

namespace ConsoleEngine.Display
{
    public class Screen
    {
        private Pixel?[,] _pixels;

        public Screen()
               : this(new Pixel?[Console.LargestWindowWidth, Console.LargestWindowHeight])
        { }

        public Screen(Pixel?[,] pixels)
        {
            _pixels = pixels;
        }
    }
}
