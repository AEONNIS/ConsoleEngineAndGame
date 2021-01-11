using System;

namespace Engine.InputSystem
{
    public static class KeysService
    {
        public static bool CompareWithoutChar(ConsoleKeyInfo keyA, ConsoleKeyInfo keyB)
        {
            return keyA.Key == keyB.Key && keyA.Modifiers == keyB.Modifiers;
        }
    }
}
