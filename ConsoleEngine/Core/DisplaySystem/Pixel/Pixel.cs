using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct Pixel
    {
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

        public static Pixel Empty => new Pixel(null, PixelForeground.Empty);
        public static Pixel Black => new Pixel(ConsoleColor.Black, PixelForeground.Black);
        public static Pixel Blue => new Pixel(ConsoleColor.Blue, PixelForeground.Blue);
        public static Pixel Green => new Pixel(ConsoleColor.Green, PixelForeground.Green);
        public static Pixel Cyan => new Pixel(ConsoleColor.Cyan, PixelForeground.Cyan);
        public static Pixel Red => new Pixel(ConsoleColor.Red, PixelForeground.Red);
        public static Pixel Yellow => new Pixel(ConsoleColor.Yellow, PixelForeground.Yellow);
        public static Pixel White => new Pixel(ConsoleColor.White, PixelForeground.White);

        public ConsoleColor? BackgroundColor { get; set; }
        public PixelForeground Foreground { get; set; }

        #region Operators
        public static bool operator ==(Pixel a, Pixel b) => a.BackgroundColor == b.BackgroundColor && a.Foreground == b.Foreground;
        public static bool operator !=(Pixel a, Pixel b) => a.BackgroundColor != b.BackgroundColor || a.Foreground != b.Foreground;

        public static Pixel operator +(Pixel major, Pixel minor)
        {
            ConsoleColor? color = major.BackgroundColor == null && minor.BackgroundColor != null ? minor.BackgroundColor : major.BackgroundColor;
            PixelForeground foreground = major.Foreground + minor.Foreground;
            return new Pixel(color, foreground);
        }
        #endregion

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
    }
}
