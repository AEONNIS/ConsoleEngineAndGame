using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class KeyService
    {
        public static void DisplayPressedKeys()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                DisplayKey(keyInfo);
            }
        }

        public static void DisplayKey(in ConsoleKeyInfo keyInfo) => Console.WriteLine(ToString(keyInfo));

        public static bool EqualsWithoutChar(in ConsoleKeyInfo keyInfoA, in ConsoleKeyInfo keyInfoB)
            => keyInfoA.Key == keyInfoB.Key && keyInfoA.Modifiers == keyInfoB.Modifiers;

        public static bool ShiftPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Shift) != 0;

        public static bool AltPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Alt) != 0;

        public static bool ControlPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Control) != 0;

        public static ConsoleKeyInfo KeyInfoPlusModifiers(in ConsoleKeyInfo keyInfo, ConsoleModifiers modifiers)
            => new ConsoleKeyInfo(keyInfo.KeyChar, keyInfo.Key, ShiftPressed(modifiers), AltPressed(modifiers), ControlPressed(modifiers));

        public static string ToString(in ConsoleKeyInfo keyInfo)
            => $"{nameof(keyInfo.KeyChar)}: {keyInfo.KeyChar}, {nameof(keyInfo.Key)}: {keyInfo.Key}, {nameof(keyInfo.Modifiers)}: {keyInfo.Modifiers}";
    }
}
