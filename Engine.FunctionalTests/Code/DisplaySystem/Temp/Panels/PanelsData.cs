using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class PanelsData
    {
        public static string BaseName { get; } = "Panel_";

        public static float MinPartFromScreenSize { get; } = 0.6f;

        public static Pixel[] Fillers { get; } = new Pixel[]
        {
            new Pixel(ConsoleColor.Blue, ConsoleColor.Black, ' '),
            new Pixel(ConsoleColor.Cyan, ConsoleColor.Black, '!'),
            new Pixel(ConsoleColor.DarkBlue, ConsoleColor.White, '@'),
            new Pixel(ConsoleColor.DarkCyan, ConsoleColor.White, '#'),
            new Pixel(ConsoleColor.DarkGray, ConsoleColor.White, '$'),
            new Pixel(ConsoleColor.DarkGreen, ConsoleColor.White, '%'),
            new Pixel(ConsoleColor.DarkMagenta, ConsoleColor.White, '^'),
            new Pixel(ConsoleColor.DarkRed, ConsoleColor.White, '&'),
            new Pixel(ConsoleColor.DarkYellow, ConsoleColor.White, '*'),
            new Pixel(ConsoleColor.Gray, ConsoleColor.Black, '-'),
            new Pixel(ConsoleColor.Green, ConsoleColor.Black, '+'),
            new Pixel(ConsoleColor.Magenta, ConsoleColor.Black, '='),
            new Pixel(ConsoleColor.Red, ConsoleColor.Black, '~'),
            new Pixel(ConsoleColor.White, ConsoleColor.Black, '/'),
            new Pixel(ConsoleColor.Yellow, ConsoleColor.Black, '\\'),
        };

        public static class KeysFor
        {
            public static ConsoleKeyInfo[] DisplayActions { get; } = new ConsoleKeyInfo[]
            {
                KeysData.NumPad.NP0,
                KeysData.NumPad.NP1,
                KeysData.NumPad.NP2,
                KeysData.NumPad.NP3,
                KeysData.NumPad.NP4,
                KeysData.NumPad.NP5,
                KeysData.NumPad.NP6,
                KeysData.NumPad.NP7,
                KeysData.NumPad.NP8,
                KeysData.NumPad.NP9,
            };

            public static ConsoleKeyInfo[] HideActions { get; } = new ConsoleKeyInfo[]
            {
                KeysData.NumPad.Control.NP0,
                KeysData.NumPad.Control.NP1,
                KeysData.NumPad.Control.NP2,
                KeysData.NumPad.Control.NP3,
                KeysData.NumPad.Control.NP4,
                KeysData.NumPad.Control.NP5,
                KeysData.NumPad.Control.NP6,
                KeysData.NumPad.Control.NP7,
                KeysData.NumPad.Control.NP8,
                KeysData.NumPad.Control.NP9,
            };
        }
    }
}
