using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class KeyData
    {
        private const int NumPad0 = 96;

        public static ConsoleKeyInfo KeyInfo(ConsoleKey key) => new ConsoleKeyInfo(default, key, false, false, false);

        public static ConsoleKeyInfo NumPad(int number) => KeyInfo((ConsoleKey)(NumPad0 + number));

        public static ConsoleKeyInfo[] NumPadsPlusModifiers(ConsoleModifiers modifiers)
        {
            var result = GetNumPads();

            for (int i = 0; i < 10; i++)
            {
                var keyInfo = result[i];
                result[i] = KeyService.KeyInfoPlusModifiers(keyInfo, modifiers);
            }

            return result;
        }

        private static ConsoleKeyInfo[] GetNumPads()
        {
            var result = new ConsoleKeyInfo[10];

            for (int i = 0; i < 10; i++)
                result[i] = NumPad(i);

            return result;
        }

        public static class ScreenTester
        {
            public static ConsoleKeyInfo Backspace { get; } = KeyInfo(ConsoleKey.Backspace);
            public static ConsoleKeyInfo Enter { get; } = KeyInfo(ConsoleKey.Enter);
            public static ConsoleKeyInfo Escape { get; } = KeyInfo(ConsoleKey.Escape);
            public static ConsoleKeyInfo Spacebar { get; } = KeyInfo(ConsoleKey.Spacebar);
            public static ConsoleKeyInfo F1 { get; } = KeyInfo(ConsoleKey.F1);
        }

        public static class Panels
        {
            public static ConsoleKeyInfo[] DisplayOnScreen { get; } = GetNumPads();
            public static ConsoleKeyInfo[] HideFromScreen { get; } = NumPadsPlusModifiers(ConsoleModifiers.Control);
        }
    }
}
