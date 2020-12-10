using System;

namespace ConsoleEngine.DisplaySystem
{
    public struct PixelForeground
    {
        #region StaticProperties
        public static PixelForeground EmptySpace => new PixelForeground { Color = null, Symbol = ' ' };
        public static PixelForeground BlackSpace => new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' };
        public static PixelForeground DarkBlueSpace => new PixelForeground { Color = ConsoleColor.DarkBlue, Symbol = ' ' };
        public static PixelForeground DarkGreenSpace => new PixelForeground { Color = ConsoleColor.DarkGreen, Symbol = ' ' };
        public static PixelForeground DarkCyanSpace => new PixelForeground { Color = ConsoleColor.DarkCyan, Symbol = ' ' };
        public static PixelForeground DarkRedSpace => new PixelForeground { Color = ConsoleColor.DarkRed, Symbol = ' ' };
        public static PixelForeground DarkMagentaSpace => new PixelForeground { Color = ConsoleColor.DarkMagenta, Symbol = ' ' };
        public static PixelForeground DarkYellowSpace => new PixelForeground { Color = ConsoleColor.DarkYellow, Symbol = ' ' };
        public static PixelForeground GraySpace => new PixelForeground { Color = ConsoleColor.Gray, Symbol = ' ' };
        public static PixelForeground DarkGraySpace => new PixelForeground { Color = ConsoleColor.DarkGray, Symbol = ' ' };
        public static PixelForeground BlueSpace => new PixelForeground { Color = ConsoleColor.Blue, Symbol = ' ' };
        public static PixelForeground GreenSpace => new PixelForeground { Color = ConsoleColor.Green, Symbol = ' ' };
        public static PixelForeground CyanSpace => new PixelForeground { Color = ConsoleColor.Cyan, Symbol = ' ' };
        public static PixelForeground RedSpace => new PixelForeground { Color = ConsoleColor.Red, Symbol = ' ' };
        public static PixelForeground MagentaSpace => new PixelForeground { Color = ConsoleColor.Magenta, Symbol = ' ' };
        public static PixelForeground YellowSpace => new PixelForeground { Color = ConsoleColor.Yellow, Symbol = ' ' };
        public static PixelForeground WhiteSpace => new PixelForeground { Color = ConsoleColor.White, Symbol = ' ' };
        #endregion

        #region Properties
        public ConsoleColor? Color { get; init; }
        public char Symbol { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(PixelForeground a, PixelForeground b) => a.Color == b.Color && a.Symbol == b.Symbol;
        public static bool operator !=(PixelForeground a, PixelForeground b) => a.Color != b.Color || a.Symbol != b.Symbol;

        public static PixelForeground operator +(PixelForeground minor, PixelForeground major)
        {
            ConsoleColor? color;

            if (minor.Color.HasValue && major.Color is null)
                color = minor.Color;
            else
                color = major.Color;

            return new PixelForeground { Color = color, Symbol = major.Symbol };
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string color = Color.HasValue ? Color.Value.ToString() : "Empty";
            return $"FgC:{color}, Smb:'{Symbol}'";
        }
        #endregion
    }
}
