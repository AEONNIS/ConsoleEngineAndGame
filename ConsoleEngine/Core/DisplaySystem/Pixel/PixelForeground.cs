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
        public PixelForeground(char symbol)
                        : this(null, symbol)
        { }
        public PixelForeground(ConsoleColor? color)
                        : this(color, ' ')
        { }

        public static PixelForeground Empty => new PixelForeground(null, ' ');
        public static PixelForeground Black => new PixelForeground(ConsoleColor.Black, ' ');
        public static PixelForeground Blue => new PixelForeground(ConsoleColor.Blue, ' ');
        public static PixelForeground Green => new PixelForeground(ConsoleColor.Green, ' ');
        public static PixelForeground Cyan => new PixelForeground(ConsoleColor.Cyan, ' ');
        public static PixelForeground Red => new PixelForeground(ConsoleColor.Red, ' ');
        public static PixelForeground Yellow => new PixelForeground(ConsoleColor.Yellow, ' ');
        public static PixelForeground White => new PixelForeground(ConsoleColor.White, ' ');

        public ConsoleColor? Color { get; set; }
        public char Symbol { get; set; }

        #region Operators
        public static bool operator ==(PixelForeground a, PixelForeground b) => a.Color == b.Color && a.Symbol == b.Symbol;
        public static bool operator !=(PixelForeground a, PixelForeground b) => a.Color != b.Color || a.Symbol != b.Symbol;

        public static PixelForeground operator +(PixelForeground major, PixelForeground minor)
        {
            ConsoleColor? color = major.Color == null && minor.Color != null ? minor.Color : major.Color;
            return new PixelForeground(color, major.Symbol);
        }
        #endregion

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
