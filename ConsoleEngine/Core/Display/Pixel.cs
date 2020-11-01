using System;

namespace ConsoleEngine.Core
{
    public static partial class Display
    {
        public static partial class Screen
        {
            public struct Pixel
            {
                public Pixel(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char symbol)
                {
                    BackgroundColor = backgroundColor;
                    ForegroundColor = foregroundColor;
                    Symbol = symbol;
                }

                public ConsoleColor BackgroundColor { get; set; }
                public ConsoleColor ForegroundColor { get; set; }
                public char Symbol { get; set; }
            }
        }
    }
}
