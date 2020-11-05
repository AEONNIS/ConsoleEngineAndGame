using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct PixelForeground
    {
        public PixelForeground(ConsoleColor? color, char symbol)
        {
            Color = color;
            Symbol = symbol;
        }

        public static PixelForeground Empty => new PixelForeground(null, ' ');
        public static PixelForeground Black => new PixelForeground(ConsoleColor.Black, ' ');

        public ConsoleColor? Color { get; set; }
        public char Symbol { get; set; }

        public void DisplayInConsole(int x, int y)
        {
            Console.ForegroundColor = Color ?? Screen.Get().GetColorFrom(true, x, y);
            Console.SetCursorPosition(x, y);
            Console.Write(Symbol);
        }
        public void DisplayInConsole(Vector2Int position) => DisplayInConsole(position.X, position.Y);

        public override string ToString()
        {
            string color = Color.HasValue ? Color.Value.ToString() : "Empty";
            return $"FgC:{color}, Smb:'{Symbol}'";
        }
    }
}
