using System;

namespace ConsoleEngine.Graphics
{
    public struct AlphaColoring
    {
        public AlphaColoring(ConsoleColor? background, ConsoleColor? foreground)
        {
            Background = background;
            Foreground = foreground;
        }

        public ConsoleColor? Background { get; private set; }
        public ConsoleColor? Foreground { get; private set; }

        public AlphaColoring Invert() => new AlphaColoring(Foreground, Background);
    }
}
