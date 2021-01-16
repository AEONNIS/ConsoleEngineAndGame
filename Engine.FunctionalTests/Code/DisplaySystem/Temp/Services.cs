using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class Services
    {
        #region Methods
        public static bool CheckNumberInput(string input, int min, int max, out int result) => int.TryParse(input, out result) && min <= result && result <= max;
        #endregion

        #region Classes
        public static class InConsole
        {
            public static void ClearLinePart((int Left, int Top) position, int length)
            {
                Console.SetCursorPosition(position.Left, position.Top);
                Data.Messages.Space(Data.Colorings.Default, length).Write();
                Console.SetCursorPosition(position.Left, position.Top);
            }

            private static void Clear()
            {
                Data.Colorings.Default.ApplyColors();
                Console.Clear();
            }
        }

        public static class Keys
        {
            public static void DisplayPressedKeys()
            {
                while (true)
                {
                    var keyInfo = Console.ReadKey(true);
                    DisplayKey(keyInfo);
                }
            }

            public static void DisplayKey(in ConsoleKeyInfo keyInfo)
                => Console.WriteLine(ToString(keyInfo));

            public static bool EqualsWithoutChar(in ConsoleKeyInfo keyInfoA, in ConsoleKeyInfo keyInfoB)
                => keyInfoA.Key == keyInfoB.Key && keyInfoA.Modifiers == keyInfoB.Modifiers;

            public static bool ShiftPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Shift) != 0;

            public static bool AltPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Alt) != 0;

            public static bool ControlPressed(ConsoleModifiers modifiers) => (modifiers & ConsoleModifiers.Control) != 0;

            public static ConsoleKeyInfo KeyInfoPlusModifiers(in ConsoleKeyInfo keyInfo, ConsoleModifiers modifiers)
                => new ConsoleKeyInfo(keyInfo.KeyChar, keyInfo.Key, ShiftPressed(modifiers), AltPressed(modifiers), ControlPressed(modifiers));

            public static ConsoleKeyInfo[] NumPadsPlusModifiers(ConsoleModifiers modifiers)
            {
                var result = Data.Keys.NumPads;

                for (int i = 0; i < 10; i++)
                {
                    var keyInfo = result[i];
                    result[i] = KeyInfoPlusModifiers(keyInfo, modifiers);
                }

                return result;
            }

            public static string ToString(in ConsoleKeyInfo keyInfo)
                => $"{nameof(keyInfo.KeyChar)}: {keyInfo.KeyChar}, {nameof(keyInfo.Key)}: {keyInfo.Key}, {nameof(keyInfo.Modifiers)}: {keyInfo.Modifiers}";
        }
        #endregion
    }
}
