using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct PixelForeground
    {
        #region Constructors
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
        #endregion

        #region StaticProperties
        public static PixelForeground Empty => new PixelForeground(null, ' ');
        public static PixelForeground Black => new PixelForeground(ConsoleColor.Black, ' ');
        public static PixelForeground DarkBlue => new PixelForeground(ConsoleColor.DarkBlue, ' ');
        public static PixelForeground DarkGreen => new PixelForeground(ConsoleColor.DarkGreen, ' ');
        public static PixelForeground DarkCyan => new PixelForeground(ConsoleColor.DarkCyan, ' ');
        public static PixelForeground DarkRed => new PixelForeground(ConsoleColor.DarkRed, ' ');
        public static PixelForeground DarkMagenta => new PixelForeground(ConsoleColor.DarkMagenta, ' ');
        public static PixelForeground DarkYellow => new PixelForeground(ConsoleColor.DarkYellow, ' ');
        public static PixelForeground Gray => new PixelForeground(ConsoleColor.Gray, ' ');
        public static PixelForeground DarkGray => new PixelForeground(ConsoleColor.DarkGray, ' ');
        public static PixelForeground Blue => new PixelForeground(ConsoleColor.Blue, ' ');
        public static PixelForeground Green => new PixelForeground(ConsoleColor.Green, ' ');
        public static PixelForeground Cyan => new PixelForeground(ConsoleColor.Cyan, ' ');
        public static PixelForeground Red => new PixelForeground(ConsoleColor.Red, ' ');
        public static PixelForeground Magenta => new PixelForeground(ConsoleColor.Magenta, ' ');
        public static PixelForeground Yellow => new PixelForeground(ConsoleColor.Yellow, ' ');
        public static PixelForeground White => new PixelForeground(ConsoleColor.White, ' ');
        #endregion

        #region Properties
        public ConsoleColor? Color { get; set; }
        public char Symbol { get; set; }
        #endregion

        #region Operators
        public static bool operator ==(PixelForeground a, PixelForeground b) => a.Color == b.Color && a.Symbol == b.Symbol;
        public static bool operator !=(PixelForeground a, PixelForeground b) => a.Color != b.Color || a.Symbol != b.Symbol;

        public static PixelForeground operator +(PixelForeground major, PixelForeground minor)
        {
            ConsoleColor? color = major.Color == null && minor.Color != null ? minor.Color : major.Color;
            return new PixelForeground(color, major.Symbol);
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
