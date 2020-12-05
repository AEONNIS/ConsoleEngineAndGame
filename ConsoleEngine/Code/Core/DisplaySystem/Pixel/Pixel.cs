using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct Pixel
    {
        #region StaticProperties
        public static Pixel EmptySpace => new Pixel { BackgroundColor = null, Foreground = PixelForeground.EmptySpace };
        public static Pixel BlackSpace => new Pixel { BackgroundColor = ConsoleColor.Black, Foreground = PixelForeground.BlackSpace };
        public static Pixel DarkBlueSpace => new Pixel { BackgroundColor = ConsoleColor.DarkBlue, Foreground = PixelForeground.DarkBlueSpace };
        public static Pixel DarkGreenSpace => new Pixel { BackgroundColor = ConsoleColor.DarkGreen, Foreground = PixelForeground.DarkGreenSpace };
        public static Pixel DarkCyanSpace => new Pixel { BackgroundColor = ConsoleColor.DarkCyan, Foreground = PixelForeground.DarkCyanSpace };
        public static Pixel DarkRedSpace => new Pixel { BackgroundColor = ConsoleColor.DarkRed, Foreground = PixelForeground.DarkRedSpace };
        public static Pixel DarkMagentaSpace => new Pixel { BackgroundColor = ConsoleColor.DarkMagenta, Foreground = PixelForeground.DarkMagentaSpace };
        public static Pixel DarkYellowSpace => new Pixel { BackgroundColor = ConsoleColor.DarkYellow, Foreground = PixelForeground.DarkYellowSpace };
        public static Pixel GraySpace => new Pixel { BackgroundColor = ConsoleColor.Gray, Foreground = PixelForeground.GraySpace };
        public static Pixel DarkGraySpace => new Pixel { BackgroundColor = ConsoleColor.DarkGray, Foreground = PixelForeground.DarkGraySpace };
        public static Pixel BlueSpace => new Pixel { BackgroundColor = ConsoleColor.Blue, Foreground = PixelForeground.BlueSpace };
        public static Pixel GreenSpace => new Pixel { BackgroundColor = ConsoleColor.Green, Foreground = PixelForeground.GreenSpace };
        public static Pixel CyanSpace => new Pixel { BackgroundColor = ConsoleColor.Cyan, Foreground = PixelForeground.CyanSpace };
        public static Pixel RedSpace => new Pixel { BackgroundColor = ConsoleColor.Red, Foreground = PixelForeground.RedSpace };
        public static Pixel MagentaSpace => new Pixel { BackgroundColor = ConsoleColor.Magenta, Foreground = PixelForeground.MagentaSpace };
        public static Pixel YellowSpace => new Pixel { BackgroundColor = ConsoleColor.Yellow, Foreground = PixelForeground.YellowSpace };
        public static Pixel WhiteSpace => new Pixel { BackgroundColor = ConsoleColor.White, Foreground = PixelForeground.WhiteSpace };
        #endregion

        #region Properties
        public ConsoleColor? BackgroundColor { get; init; }
        public PixelForeground Foreground { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(Pixel a, Pixel b) => a.BackgroundColor == b.BackgroundColor && a.Foreground == b.Foreground;
        public static bool operator !=(Pixel a, Pixel b) => a.BackgroundColor != b.BackgroundColor || a.Foreground != b.Foreground;

        public static Pixel operator +(Pixel minor, Pixel major)
        {
            ConsoleColor? backgroundColor;

            if (minor.BackgroundColor.HasValue && major.BackgroundColor is null)
                backgroundColor = minor.BackgroundColor;
            else
                backgroundColor = major.BackgroundColor;

            PixelForeground foreground = minor.Foreground + major.Foreground;
            return new Pixel { BackgroundColor = backgroundColor, Foreground = foreground };
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
