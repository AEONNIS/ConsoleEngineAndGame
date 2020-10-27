using System;

namespace ConsoleGame
{
    public static class Keys
    {
        public static bool CompareWithoutChar(ConsoleKeyInfo keyA, ConsoleKeyInfo keyB)
        {
            return keyA.Key == keyB.Key && keyA.Modifiers == keyB.Modifiers;
        }
    }
}
