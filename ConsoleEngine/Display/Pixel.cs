using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Display
{
    public struct Pixel : IDisplayable
    {
        public Pixel(char symbol, Coloring coloring)
        {
            Symbol = symbol;
            Coloring = coloring;
        }

        public Pixel(char symbol, ConsoleColor? background, ConsoleColor foreground)
              : this(symbol, new Coloring(background, foreground))
        { }

        public char Symbol { get; private set; }
        public Coloring Coloring { get; private set; }

        public void Display(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Coloring.SetColors();
            Console.Write(Symbol);
        }

        public void Display(Vector2Int position) => Display(position.X, position.Y);
    }
}
