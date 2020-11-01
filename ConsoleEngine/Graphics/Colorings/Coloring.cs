using System;

namespace ConsoleEngine.Graphics
{
    public struct Coloring
    {
        public Coloring(ConsoleColor background, ConsoleColor foreground)
        {
            Background = background;
            Foreground = foreground;
        }

        public ConsoleColor Background { get; private set; }
        public ConsoleColor Foreground { get; private set; }

        public Coloring Invert() => new Coloring(Foreground, Background);
    }
}
