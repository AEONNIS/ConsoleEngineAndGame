using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Graphics
{
    public struct Pixel : IDisplayable
    {
        public Pixel(char symbol, AlphaColoring coloring)
        {
            Symbol = symbol;
            Coloring = coloring;
        }

        public Pixel(char symbol, ConsoleColor? background, ConsoleColor foreground)
              : this(symbol, new AlphaColoring(background, foreground))
        { }

        public char Symbol { get; private set; }
        public AlphaColoring Coloring { get; private set; }

        public void Display(int x, int y)
        {

        }

        public void Display(Vector2Int position) => Display(position.X, position.Y);
    }
}
