using System;

namespace ConsoleGame.Editors
{
    public partial class Editor
    {
        public static class Keys
        {
            public static ConsoleKeyInfo Pixel = new ConsoleKeyInfo(' ', ConsoleKey.P, false, false, true);
            public static ConsoleKeyInfo Tile = new ConsoleKeyInfo(' ', ConsoleKey.T, false, false, true);
            public static ConsoleKeyInfo Map = new ConsoleKeyInfo(' ', ConsoleKey.M, false, false, true);
            public static ConsoleKeyInfo Exit = new ConsoleKeyInfo(' ', ConsoleKey.Escape, false, false, false);
        }
    }
}
