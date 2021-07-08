using Engine.DisplaySystem;
using System;

namespace Game
{
    public static class Pixelset
    {
        public static class WallTile
        {
            public static Pixel Intact => new Pixel(null, ConsoleColor.DarkBlue, '\u2588');
            public static Pixel Damaged => new Pixel(null, ConsoleColor.DarkBlue, '\u2593');
            public static Pixel Destroyed => new Pixel(null, ConsoleColor.DarkBlue, '\u2591');

            public static class DoorTile
            {
                public static Pixel OpenHorizontal => new Pixel(null, ConsoleColor.DarkBlue, ' ');
                public static Pixel ClosedHorizontal => new Pixel(null, ConsoleColor.DarkBlue, '\u2550');
                public static Pixel OpenVertical => new Pixel(null, ConsoleColor.DarkBlue, ' ');
                public static Pixel ClosedVertical => new Pixel(null, ConsoleColor.DarkBlue, '\u2551');
            }
        }

        public static class GroundTile
        {
            public static Pixel ConcreteFloor => new Pixel(ConsoleColor.DarkGray, null, ' ');
        }
    }
}
