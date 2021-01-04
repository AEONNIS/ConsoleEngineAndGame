using ConsoleEngine.DisplaySystem;
using System;

namespace ConsoleGame
{
    public static class Tileset
    {
        #region Classes
        public static class Wall
        {
            #region Properties
            public static Tile Intact { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, '\u2588'), false);
            public static Tile Damaged { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, '\u2593'), false);
            public static Tile Destroyed { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, '\u2591'), true);
            #endregion
        }

        public static class Door
        {
            #region Properties
            public static Tile OpenHorizontal { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, ' '), true);
            public static Tile ClosedHorizontal { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, '\u2550'), false);
            public static Tile OpenVertical { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, ' '), true);
            public static Tile ClosedVertical { get; } = new Tile(new Pixel(null, ConsoleColor.DarkBlue, '\u2551'), false);
            #endregion
        }
        #endregion
    }
}
