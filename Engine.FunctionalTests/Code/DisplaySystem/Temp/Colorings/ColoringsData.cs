using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class ColoringsData
    {
        public static Coloring GrayOnBlack { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Gray,
        };
        public static Coloring BlackOnWhite { get; } = new Coloring
        {
            BgColor = ConsoleColor.White,
            FgColor = ConsoleColor.Black,
        };
        public static Coloring RedOnBlack { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Red,
        };
        public static Coloring GreenOnBlack { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Green,
        };
    }
}
