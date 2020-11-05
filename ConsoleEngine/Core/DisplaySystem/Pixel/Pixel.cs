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

        public static Pixel Empty => new Pixel(null, PixelForeground.Empty);
        public static Pixel Black => new Pixel(ConsoleColor.Black, PixelForeground.Black);

        public ConsoleColor? BackgroundColor { get; set; }
        public PixelForeground Foreground { get; set; }

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
