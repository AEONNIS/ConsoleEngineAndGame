using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct PixelForeground
    {
        public PixelForeground(ConsoleColor? color, char symbol)
        {
            Color = color;
            Symbol = symbol;
        }

        public static PixelForeground Empty => new PixelForeground(null, ' ');
        public static PixelForeground Black => new PixelForeground(ConsoleColor.Black, ' ');

        public ConsoleColor? Color { get; set; }
        public char Symbol { get; set; }

        public void Display(int x, int y)
        {
            if (Color.HasValue)
            {
                Console.ForegroundColor = Color.Value;
            }
            else
            {
                ConsoleColor? color = Screen.Get().GetPixel(x, y).Foreground.Color;

                if (color.HasValue)
                    Console.ForegroundColor = color.Value;
                else
                    Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.SetCursorPosition(x, y);
            Console.Write(Symbol);
        }
        public void Display(Vector2Int position) => Display(position.X, position.Y);

        public override string ToString()
        {
            string color = Color.HasValue ? Color.Value.ToString() : "null";
            return $"{nameof(Color)}: {color}, {nameof(Symbol)}: '{Symbol}'";
        }
    }
}
