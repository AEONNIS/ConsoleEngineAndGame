// + Immutable
// + Copy

using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct Pixel
    {
        #region StaticProperties
        public static Pixel Empty => new Pixel() { BackgroundColor = null, Foreground = PixelForeground.Empty };
        public static Pixel Black => new Pixel() { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.Black };
        public static Pixel DarkBlue => new Pixel() { BackgroundColor = ConsoleColor.DarkBlue, Foreground = PixelForeground.DarkBlue };
        public static Pixel DarkGreen => new Pixel() { BackgroundColor = ConsoleColor.DarkGreen, Foreground = PixelForeground.DarkGreen };
        public static Pixel DarkCyan => new Pixel() { BackgroundColor = ConsoleColor.DarkCyan, Foreground = PixelForeground.DarkCyan };
        public static Pixel DarkRed => new Pixel() { BackgroundColor = ConsoleColor.DarkRed, Foreground = PixelForeground.DarkRed };
        public static Pixel DarkMagenta => new Pixel() { BackgroundColor = ConsoleColor.DarkMagenta, Foreground = PixelForeground.DarkMagenta };
        public static Pixel DarkYellow => new Pixel() { BackgroundColor = ConsoleColor.DarkYellow, Foreground = PixelForeground.DarkYellow };
        public static Pixel Gray => new Pixel() { BackgroundColor = ConsoleColor.Gray, Foreground = PixelForeground.Gray };
        public static Pixel DarkGray => new Pixel() { BackgroundColor = ConsoleColor.DarkGray, Foreground = PixelForeground.DarkGray };
        public static Pixel Blue => new Pixel() { BackgroundColor = ConsoleColor.Blue, Foreground = PixelForeground.Blue };
        public static Pixel Green => new Pixel() { BackgroundColor = ConsoleColor.Green, Foreground = PixelForeground.Green };
        public static Pixel Cyan => new Pixel() { BackgroundColor = ConsoleColor.Cyan, Foreground = PixelForeground.Cyan };
        public static Pixel Red => new Pixel() { BackgroundColor = ConsoleColor.Red, Foreground = PixelForeground.Red };
        public static Pixel Magenta => new Pixel() { BackgroundColor = ConsoleColor.Magenta, Foreground = PixelForeground.Magenta };
        public static Pixel Yellow => new Pixel() { BackgroundColor = ConsoleColor.Yellow, Foreground = PixelForeground.Yellow };
        public static Pixel White => new Pixel() { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.White };
        #endregion

        #region Properties
        public ConsoleColor? BackgroundColor { get; set; }
        public PixelForeground Foreground { get; set; }
        #endregion

        #region Operators
        public static bool operator ==(Pixel a, Pixel b) => a.BackgroundColor == b.BackgroundColor && a.Foreground == b.Foreground;
        public static bool operator !=(Pixel a, Pixel b) => a.BackgroundColor != b.BackgroundColor || a.Foreground != b.Foreground;

        public static Pixel operator +(Pixel minor, Pixel major) // Обдумать что должно происходить и проверить...
        {
            ConsoleColor? color = major.BackgroundColor.HasValue && minor.BackgroundColor is not null ? minor.BackgroundColor : major.BackgroundColor;
            PixelForeground foreground = major.Foreground + minor.Foreground;
            return new Pixel() { BackgroundColor = color, Foreground = foreground };
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string backgroundColor = BackgroundColor.HasValue ? BackgroundColor.Value.ToString() : "Empty";
            return $"BgC:{backgroundColor}, {Foreground}";
        }
        #endregion
    }
}
