using System;

namespace ConsoleGame
{
    public class Editor
    {
        public Editor()
        {
            Console.Clear();
            Console.WriteLine("Редактор запущен");
        }

        public enum Mode { PixelCreator }

        public static class Keys
        {
            public static ConsoleKeyInfo Start = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, true);

            public static ConsoleKeyInfo PixelCreation = new ConsoleKeyInfo(' ', ConsoleKey.P, false, false, true);
            public static ConsoleKeyInfo PCBackgroundColor = new ConsoleKeyInfo(' ', ConsoleKey.P, false, false, false);
        }
    }
}
