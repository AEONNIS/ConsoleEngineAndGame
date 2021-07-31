using System;

namespace ConsoleEngine.DisplaySystem
{
    public readonly struct PixelForeground : IEquatable<PixelForeground>
    {
        #region StaticFields
        private static readonly PixelForeground _emptySpace = new PixelForeground(null, ' ');
        private static readonly PixelForeground _blackSpace = new PixelForeground(ConsoleColor.Black, ' ');
        private static readonly PixelForeground _darkBlueSpace = new PixelForeground(ConsoleColor.DarkBlue, ' ');
        private static readonly PixelForeground _darkGreenSpace = new PixelForeground(ConsoleColor.DarkGreen, ' ');
        private static readonly PixelForeground _darkCyanSpace = new PixelForeground(ConsoleColor.DarkCyan, ' ');
        private static readonly PixelForeground _darkRedSpace = new PixelForeground(ConsoleColor.DarkRed, ' ');
        private static readonly PixelForeground _darkMagentaSpace = new PixelForeground(ConsoleColor.DarkMagenta, ' ');
        private static readonly PixelForeground _darkYellowSpace = new PixelForeground(ConsoleColor.DarkYellow, ' ');
        private static readonly PixelForeground _graySpace = new PixelForeground(ConsoleColor.Gray, ' ');
        private static readonly PixelForeground _darkGraySpace = new PixelForeground(ConsoleColor.DarkGray, ' ');
        private static readonly PixelForeground _blueSpace = new PixelForeground(ConsoleColor.Blue, ' ');
        private static readonly PixelForeground _greenSpace = new PixelForeground(ConsoleColor.Green, ' ');
        private static readonly PixelForeground _cyanSpace = new PixelForeground(ConsoleColor.Cyan, ' ');
        private static readonly PixelForeground _redSpace = new PixelForeground(ConsoleColor.Red, ' ');
        private static readonly PixelForeground _magentaSpace = new PixelForeground(ConsoleColor.Magenta, ' ');
        private static readonly PixelForeground _yellowSpace = new PixelForeground(ConsoleColor.Yellow, ' ');
        private static readonly PixelForeground _whiteSpace = new PixelForeground(ConsoleColor.White, ' ');
        #endregion

        #region Constructors
        public PixelForeground(ConsoleColor? color, char symbol)
        {
            Color = color;
            Symbol = symbol;
        }
        #endregion

        #region StaticProperties
        public static ref readonly PixelForeground EmptySpace => ref _emptySpace;
        public static ref readonly PixelForeground BlackSpace => ref _blackSpace;
        public static ref readonly PixelForeground DarkBlueSpace => ref _darkBlueSpace;
        public static ref readonly PixelForeground DarkGreenSpace => ref _darkGreenSpace;
        public static ref readonly PixelForeground DarkCyanSpace => ref _darkCyanSpace;
        public static ref readonly PixelForeground DarkRedSpace => ref _darkRedSpace;
        public static ref readonly PixelForeground DarkMagentaSpace => ref _darkMagentaSpace;
        public static ref readonly PixelForeground DarkYellowSpace => ref _darkYellowSpace;
        public static ref readonly PixelForeground GraySpace => ref _graySpace;
        public static ref readonly PixelForeground DarkGraySpace => ref _darkGraySpace;
        public static ref readonly PixelForeground BlueSpace => ref _blueSpace;
        public static ref readonly PixelForeground GreenSpace => ref _greenSpace;
        public static ref readonly PixelForeground CyanSpace => ref _cyanSpace;
        public static ref readonly PixelForeground RedSpace => ref _redSpace;
        public static ref readonly PixelForeground MagentaSpace => ref _magentaSpace;
        public static ref readonly PixelForeground YellowSpace => ref _yellowSpace;
        public static ref readonly PixelForeground WhiteSpace => ref _whiteSpace;
        #endregion

        #region Properties
        public readonly ConsoleColor? Color { get; init; }
        public readonly char Symbol { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(in PixelForeground a, in PixelForeground b) => a.Equals(b);
        public static bool operator !=(in PixelForeground a, in PixelForeground b) => a.Equals(b) == false;

        public static PixelForeground operator +(in PixelForeground minor, in PixelForeground major)
        {
            ConsoleColor? color;

            if (minor.Color.HasValue && major.Color is null)
                color = minor.Color;
            else
                color = major.Color;

            return new PixelForeground(color, major.Symbol);
        }
        #endregion

        #region Methods
        public readonly override bool Equals(object obj) => obj is PixelForeground foreground && Equals(foreground);
        public readonly bool Equals(PixelForeground other) => Color == other.Color && Symbol == other.Symbol;

        public readonly override int GetHashCode() => HashCode.Combine(Color, Symbol);

        public readonly override string ToString()
        {
            string color = Color.HasValue ? Color.Value.ToString() : "Empty color";
            return $"{color} '{Symbol}'";
        }
        #endregion
    }
}
