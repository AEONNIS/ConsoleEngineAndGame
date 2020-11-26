using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct PixelForeground
    {
        #region StaticProperties
        public static PixelForeground Empty => new PixelForeground { Color = null, Symbol = ' ' };
        public static PixelForeground Black => new PixelForeground { Color = ConsoleColor.Black, Symbol = ' ' };
        public static PixelForeground DarkBlue => new PixelForeground { Color = ConsoleColor.DarkBlue, Symbol = ' ' };
        public static PixelForeground DarkGreen => new PixelForeground { Color = ConsoleColor.DarkGreen, Symbol = ' ' };
        public static PixelForeground DarkCyan => new PixelForeground { Color = ConsoleColor.DarkCyan, Symbol = ' ' };
        public static PixelForeground DarkRed => new PixelForeground { Color = ConsoleColor.DarkRed, Symbol = ' ' };
        public static PixelForeground DarkMagenta => new PixelForeground { Color = ConsoleColor.DarkMagenta, Symbol = ' ' };
        public static PixelForeground DarkYellow => new PixelForeground { Color = ConsoleColor.DarkYellow, Symbol = ' ' };
        public static PixelForeground Gray => new PixelForeground { Color = ConsoleColor.Gray, Symbol = ' ' };
        public static PixelForeground DarkGray => new PixelForeground { Color = ConsoleColor.DarkGray, Symbol = ' ' };
        public static PixelForeground Blue => new PixelForeground { Color = ConsoleColor.Blue, Symbol = ' ' };
        public static PixelForeground Green => new PixelForeground { Color = ConsoleColor.Green, Symbol = ' ' };
        public static PixelForeground Cyan => new PixelForeground { Color = ConsoleColor.Cyan, Symbol = ' ' };
        public static PixelForeground Red => new PixelForeground { Color = ConsoleColor.Red, Symbol = ' ' };
        public static PixelForeground Magenta => new PixelForeground { Color = ConsoleColor.Magenta, Symbol = ' ' };
        public static PixelForeground Yellow => new PixelForeground { Color = ConsoleColor.Yellow, Symbol = ' ' };
        public static PixelForeground White => new PixelForeground { Color = ConsoleColor.White, Symbol = ' ' };
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
        public PixelForeground GetCopy() => new PixelForeground { Color = this.Color, Symbol = this.Symbol };

        public override string ToString()
        {
            string color = Color.HasValue ? Color.Value.ToString() : "Empty";
            return $"FgC:{color}, Smb:'{Symbol}'";
        }
        #endregion
    }
}
