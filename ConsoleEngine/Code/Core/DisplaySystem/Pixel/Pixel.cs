using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct Pixel
    {
        #region Constructors
        public Pixel(ConsoleColor? backgroundColor, PixelForeground foreground)
        {
            BackgroundColor = backgroundColor;
            Foreground = foreground;
        }
        public Pixel(ConsoleColor? backgroundColor, ConsoleColor? foregroundColor, char foregroundSymbol)
              : this(backgroundColor, new PixelForeground(foregroundColor, foregroundSymbol))
        { }
        public Pixel(ConsoleColor? backgroundColor, ConsoleColor? foregroundColor)
              : this(backgroundColor, new PixelForeground(foregroundColor, ' '))
        { }
        public Pixel(ConsoleColor? commonColor, char foregroundSymbol)
              : this(commonColor, new PixelForeground(commonColor, foregroundSymbol))
        { }
        public Pixel(char foregroundSymbol)
              : this(null, new PixelForeground(null, foregroundSymbol))
        { }
        #endregion

        #region StaticProperties
        public static Pixel Empty => new Pixel(null, PixelForeground.Empty);
        public static Pixel Black => new Pixel(ConsoleColor.Black, PixelForeground.Black);
        public static Pixel DarkBlue => new Pixel(ConsoleColor.DarkBlue, PixelForeground.DarkBlue);
        public static Pixel DarkGreen => new Pixel(ConsoleColor.DarkGreen, PixelForeground.DarkGreen);
        public static Pixel DarkCyan => new Pixel(ConsoleColor.DarkCyan, PixelForeground.DarkCyan);
        public static Pixel DarkRed => new Pixel(ConsoleColor.DarkRed, PixelForeground.DarkRed);
        public static Pixel DarkMagenta => new Pixel(ConsoleColor.DarkMagenta, PixelForeground.DarkMagenta);
        public static Pixel DarkYellow => new Pixel(ConsoleColor.DarkYellow, PixelForeground.DarkYellow);
        public static Pixel Gray => new Pixel(ConsoleColor.Gray, PixelForeground.Gray);
        public static Pixel DarkGray => new Pixel(ConsoleColor.DarkGray, PixelForeground.DarkGray);
        public static Pixel Blue => new Pixel(ConsoleColor.Blue, PixelForeground.Blue);
        public static Pixel Green => new Pixel(ConsoleColor.Green, PixelForeground.Green);
        public static Pixel Cyan => new Pixel(ConsoleColor.Cyan, PixelForeground.Cyan);
        public static Pixel Red => new Pixel(ConsoleColor.Red, PixelForeground.Red);
        public static Pixel Magenta => new Pixel(ConsoleColor.Magenta, PixelForeground.Magenta);
        public static Pixel Yellow => new Pixel(ConsoleColor.Yellow, PixelForeground.Yellow);
        public static Pixel White => new Pixel(ConsoleColor.White, PixelForeground.White);
        #endregion

        #region Properties
        public ConsoleColor? BackgroundColor { get; set; }
        public PixelForeground Foreground { get; set; }
        #endregion

        #region Operators
        public static bool operator ==(Pixel a, Pixel b) => a.BackgroundColor == b.BackgroundColor && a.Foreground == b.Foreground;
        public static bool operator !=(Pixel a, Pixel b) => a.BackgroundColor != b.BackgroundColor || a.Foreground != b.Foreground;

        public static Pixel operator +(Pixel minor, Pixel major)
        {
            ConsoleColor? color = major.BackgroundColor.HasValue && minor.BackgroundColor is not null ? minor.BackgroundColor : major.BackgroundColor;
            PixelForeground foreground = major.Foreground + minor.Foreground;
            return new Pixel(color, foreground);
        }
        #endregion

        #region Methods
        public void DisplayInConsole(int x, int y)
        {
            Console.BackgroundColor = BackgroundColor ?? Screen.Get().GetColorFrom(false, x, y);
            Foreground.DisplayInConsole(x, y);
        }
        public void DisplayInConsole(Vector2Int position) => DisplayInConsole(position.X, position.Y);

        public override string ToString()
        {
            string backgroundColor = BackgroundColor.HasValue ? BackgroundColor.Value.ToString() : "Empty";
            return $"BgC:{backgroundColor}, {Foreground}";
        }
        #endregion
    }
}
