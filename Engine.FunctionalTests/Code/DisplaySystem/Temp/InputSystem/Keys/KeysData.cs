using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class KeysData
    {
        #region ConstantFields
        private const int NumPad0 = 96;
        #endregion

        #region StaticProperties
        public static ConsoleKeyInfo Backspace { get; } = new ConsoleKeyInfo(default, ConsoleKey.Backspace, false, false, false);
        public static ConsoleKeyInfo Enter { get; } = new ConsoleKeyInfo(default, ConsoleKey.Enter, false, false, false);
        public static ConsoleKeyInfo Escape { get; } = new ConsoleKeyInfo(default, ConsoleKey.Escape, false, false, false);
        public static ConsoleKeyInfo F1 { get; } = new ConsoleKeyInfo(default, ConsoleKey.F1, false, false, false);
        public static ConsoleKeyInfo[] NumPadKeys { get; } = GetNumPadKeys();
        #endregion

        #region PublicStaticMethods
        public static ConsoleKeyInfo NumPadKey(int number) => new ConsoleKeyInfo(default, (ConsoleKey)(NumPad0 + number), false, false, false);

        public static ConsoleKeyInfo[] ModifiersPlusNumPadKeys(ConsoleModifiers modifiers)
        {
            var result = GetNumPadKeys();

            for (int i = 0; i < 10; i++)
            {
                var keyInfo = result[i];
                result[i] = KeysService.ModifiersPlusKeyInfo(modifiers, keyInfo);
            }

            return result;
        }
        #endregion

        #region PrivateStaticMethods
        private static ConsoleKeyInfo[] GetNumPadKeys()
        {
            var result = new ConsoleKeyInfo[10];

            for (int i = 0; i < 10; i++)
                result[i] = NumPadKey(i);

            return result;
        }
        #endregion
    }
}
