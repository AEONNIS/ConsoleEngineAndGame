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

        public void Display(int x, int y)
        {
            if (BackgroundColor.HasValue)
            {
                Console.BackgroundColor = BackgroundColor.Value;
            }
            else
            {
                ConsoleColor? color = Screen.Get.GetPixel(x, y).BackgroundColor;

                if (color.HasValue)
                    Console.BackgroundColor = color.Value;
                else
                    Console.BackgroundColor = ConsoleColor.Black;
            }

            Foreground.Display(x, y);
        }
        public void Display(Vector2Int position) => Display(position.X, position.Y);

        public override string ToString()
        {
            string backgroundColor = BackgroundColor.HasValue ? BackgroundColor.Value.ToString() : "null";
            return $"{nameof(BackgroundColor)}: {backgroundColor}, {nameof(Foreground)}: ({Foreground})";
        }
    }
}
