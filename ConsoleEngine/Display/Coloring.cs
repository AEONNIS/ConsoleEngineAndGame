using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Display
{
    public struct Coloring
    {
        public Coloring(ConsoleColor? background, ConsoleColor? foreground)
        {
            Background = background;
            Foreground = foreground;
        }

        public ConsoleColor? Background { get; private set; }
        public ConsoleColor? Foreground { get; private set; }

        public Coloring Invert() => new Coloring(Foreground, Background);

        public Coloring GetIn(Vector2Int position)
        {

        }

        public void SetColors()
        {
            if (Background != null)
                Console.BackgroundColor = Background.Value;

            if (Foreground != null)
                Console.ForegroundColor = Foreground.Value;
        }
    }
}
