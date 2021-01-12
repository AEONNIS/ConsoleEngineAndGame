using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class KeysService
    {
        public static void DisplayPressedKeys()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                Console.WriteLine($"{nameof(keyInfo.KeyChar)}: {keyInfo.KeyChar}, {nameof(keyInfo.Key)}: {keyInfo.Key}, {nameof(keyInfo.Modifiers)}: {keyInfo.Modifiers}");
            }
        }

        public static bool Equals(in ConsoleKeyInfo keyInfoA, in ConsoleKeyInfo keyInfoB)
            => keyInfoA.Key == keyInfoB.Key && keyInfoA.Modifiers == keyInfoB.Modifiers;
    }
}
