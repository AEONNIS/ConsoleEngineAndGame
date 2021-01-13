using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class ColoringsData
    {
        public static Coloring Default { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Gray,
        };
        public static Coloring Keys { get; } = new Coloring
        {
            BgColor = ConsoleColor.White,
            FgColor = ConsoleColor.Black,
        };
        public static Coloring Wrong { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Red,
        };
        public static Coloring Request { get; } = new Coloring
        {
            BgColor = ConsoleColor.Black,
            FgColor = ConsoleColor.Green,
        };
    }
}
