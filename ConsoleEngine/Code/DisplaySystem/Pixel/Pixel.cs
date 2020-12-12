using System;

namespace ConsoleEngine.DisplaySystem
{
    public readonly struct Pixel : IEquatable<Pixel>
    {
        #region StaticFields
        private static readonly Pixel _emptySpace = new Pixel(null, PixelForeground.EmptySpace);
        private static readonly Pixel _blackSpace = new Pixel(ConsoleColor.Black, PixelForeground.BlackSpace);
        private static readonly Pixel _darkBlueSpace = new Pixel(ConsoleColor.DarkBlue, PixelForeground.DarkBlueSpace);
        private static readonly Pixel _darkGreenSpace = new Pixel(ConsoleColor.DarkGreen, PixelForeground.DarkGreenSpace);
        private static readonly Pixel _darkCyanSpace = new Pixel(ConsoleColor.DarkCyan, PixelForeground.DarkCyanSpace);
        private static readonly Pixel _darkRedSpace = new Pixel(ConsoleColor.DarkRed, PixelForeground.DarkRedSpace);
        private static readonly Pixel _darkMagentaSpace = new Pixel(ConsoleColor.DarkMagenta, PixelForeground.DarkMagentaSpace);
        private static readonly Pixel _darkYellowSpace = new Pixel(ConsoleColor.DarkYellow, PixelForeground.DarkYellowSpace);
        private static readonly Pixel _graySpace = new Pixel(ConsoleColor.Gray, PixelForeground.GraySpace);
        private static readonly Pixel _darkGraySpace = new Pixel(ConsoleColor.DarkGray, PixelForeground.DarkGraySpace);
        private static readonly Pixel _blueSpace = new Pixel(ConsoleColor.Blue, PixelForeground.BlueSpace);
        private static readonly Pixel _greenSpace = new Pixel(ConsoleColor.Green, PixelForeground.GreenSpace);
        private static readonly Pixel _cyanSpace = new Pixel(ConsoleColor.Cyan, PixelForeground.CyanSpace);
        private static readonly Pixel _redSpace = new Pixel(ConsoleColor.Red, PixelForeground.RedSpace);
        private static readonly Pixel _magentaSpace = new Pixel(ConsoleColor.Magenta, PixelForeground.MagentaSpace);
        private static readonly Pixel _yellowSpace = new Pixel(ConsoleColor.Yellow, PixelForeground.YellowSpace);
        private static readonly Pixel _whiteSpace = new Pixel(ConsoleColor.White, PixelForeground.WhiteSpace);
        #endregion

        #region Constructors
        public Pixel(ConsoleColor? backgroundColor, in PixelForeground foreground)
        {
            BackgroundColor = backgroundColor;
            Foreground = foreground;
        }
        public Pixel(ConsoleColor? backgroundColor, ConsoleColor? foregroundColor, char symbol) :
               this(backgroundColor, new PixelForeground(foregroundColor, symbol))
        { }
        #endregion

        #region StaticProperties
        public static ref readonly Pixel EmptySpace => ref _emptySpace;
        public static ref readonly Pixel BlackSpace => ref _blackSpace;
        public static ref readonly Pixel DarkBlueSpace => ref _darkBlueSpace;
        public static ref readonly Pixel DarkGreenSpace => ref _darkGreenSpace;
        public static ref readonly Pixel DarkCyanSpace => ref _darkCyanSpace;
        public static ref readonly Pixel DarkRedSpace => ref _darkRedSpace;
        public static ref readonly Pixel DarkMagentaSpace => ref _darkMagentaSpace;
        public static ref readonly Pixel DarkYellowSpace => ref _darkYellowSpace;
        public static ref readonly Pixel GraySpace => ref _graySpace;
        public static ref readonly Pixel DarkGraySpace => ref _darkGraySpace;
        public static ref readonly Pixel BlueSpace => ref _blueSpace;
        public static ref readonly Pixel GreenSpace => ref _greenSpace;
        public static ref readonly Pixel CyanSpace => ref _cyanSpace;
        public static ref readonly Pixel RedSpace => ref _redSpace;
        public static ref readonly Pixel MagentaSpace => ref _magentaSpace;
        public static ref readonly Pixel YellowSpace => ref _yellowSpace;
        public static ref readonly Pixel WhiteSpace => ref _whiteSpace;
        #endregion

        #region Properties
        public readonly ConsoleColor? BackgroundColor { get; init; }
        public readonly PixelForeground Foreground { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(in Pixel a, in Pixel b) => a.Equals(b);
        public static bool operator !=(in Pixel a, in Pixel b) => a.Equals(b) == false;

        public static Pixel operator +(in Pixel minor, in Pixel major)
        {
            ConsoleColor? backgroundColor;

            if (minor.BackgroundColor.HasValue && major.BackgroundColor is null)
                backgroundColor = minor.BackgroundColor;
            else
                backgroundColor = major.BackgroundColor;

            PixelForeground foreground = minor.Foreground + major.Foreground;
            return new Pixel(backgroundColor, foreground);
        }
        #endregion

        #region Methods
        public readonly override bool Equals(object obj) => obj is Pixel pixel && Equals(pixel);
        public readonly bool Equals(Pixel other) => BackgroundColor == other.BackgroundColor && Foreground.Equals(other.Foreground);

        public readonly override int GetHashCode() => HashCode.Combine(BackgroundColor, Foreground);

        public readonly override string ToString()
        {
            string backgroundColor = BackgroundColor.HasValue ? BackgroundColor.Value.ToString() : "Empty";
            return $"BgC:{backgroundColor}, {Foreground}";
        }
        #endregion
    }
}
