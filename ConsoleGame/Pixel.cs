using System;

namespace ConsoleGame
{
    public class Pixel
    {
        public char Char { get; private set; }
        public ConsoleColor BGColor { get; private set; }
        public ConsoleColor FGColor { get; private set; }
    }

    public class PixelCreator
    {
        public PixelCreator()
        {
            Console.Clear();
            Console.WriteLine("Создание нового пикселя");
        }
    }
}
