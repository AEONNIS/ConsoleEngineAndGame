using System;

namespace ConsoleEngine.Input
{
    public static class KeysService
    {
        public static bool CompareWithoutChar(ConsoleKeyInfo keyA, ConsoleKeyInfo keyB)
        {
            return keyA.Key == keyB.Key && keyA.Modifiers == keyB.Modifiers;
        }
    }
}
