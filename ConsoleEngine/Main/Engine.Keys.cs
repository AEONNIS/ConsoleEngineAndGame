using System;

namespace ConsoleGame.ConsoleEngine
{
    public partial class Engine
    {
        public static class Keys
        {
            public static ConsoleKeyInfo Game = new ConsoleKeyInfo(' ', ConsoleKey.G, false, false, true);
            public static ConsoleKeyInfo Editor = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, true);
            public static ConsoleKeyInfo Exit = new ConsoleKeyInfo(' ', ConsoleKey.Escape, false, false, false);
        }
    }
}
