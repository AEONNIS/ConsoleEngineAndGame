using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct ScrenPixelForeground
    {
        public ScrenPixelForeground(ConsoleColor color, char symbol)
        {
            Color = color;
            Symbol = symbol;
        }

        public ConsoleColor Color { get; set; }
        public char Symbol { get; set; }

        public void Display(int x, int y)
        {
            Console.ForegroundColor = Color;
            DisplaySymbol(x, y);
        }
        public void Display(Vector2Int position) => Display(position.X, position.Y);

        public void DisplaySymbol(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Symbol);
        }
        public void DisplaySymbol(Vector2Int position) => DisplaySymbol(position.X, position.Y);
    }
}
