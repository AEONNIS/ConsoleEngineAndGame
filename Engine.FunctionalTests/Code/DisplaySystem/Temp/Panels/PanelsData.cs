using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class PanelsData
    {
        #region ConstantFields
        public const string BaseName = "Panel_";
        public const float MinPartFromScreenSize = 0.6f;
        #endregion

        #region StaticProperties
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
        #endregion

        #region StaticClasses
        public static class KeysFor
        {
            public static ConsoleKeyInfo[] DisplayActions { get; } = KeysData.NumPadKeys;

            public static ConsoleKeyInfo[] HideActions { get; } = KeysData.ModifiersPlusNumPadKeys(ConsoleModifiers.Control);
        }
        #endregion
    }
}
