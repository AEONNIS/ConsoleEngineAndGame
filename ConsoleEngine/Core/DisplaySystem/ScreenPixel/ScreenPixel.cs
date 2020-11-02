using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct ScreenPixel
    {
        public ScreenPixel(ConsoleColor backgroundColor, ScrenPixelForeground foreground)
        {
            BackgroundColor = backgroundColor;
            Foreground = foreground;
        }
        public ScreenPixel(ConsoleColor backgroundColor, ConsoleColor foregroundColor, char foregroundSymbol)
                    : this(backgroundColor, new ScrenPixelForeground(foregroundColor, foregroundSymbol))
        { }

        public ConsoleColor BackgroundColor { get; set; }
        public ScrenPixelForeground Foreground { get; set; }

        public void Display(int x, int y)
        {
            Console.BackgroundColor = BackgroundColor;
            Foreground.Display(x, y);
        }
        public void Display(Vector2Int position) => Display(position.X, position.Y);
    }
}
