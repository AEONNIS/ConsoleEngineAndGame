using System;
using System.Collections.Generic;

namespace Engine.DisplaySystem.IntegrationTesting
{
    public class InputSystem
    {
        #region Fields
        private readonly List<PanelBindings> _panelsBindings;
        #endregion

        #region Constructors
        public InputSystem(IEnumerable<PanelBindings> panelsBindings) => _panelsBindings = (List<PanelBindings>)panelsBindings;
        #endregion

        #region PublicStaticMethods
        public static void DisplayPressedKeys()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                Console.WriteLine($"{nameof(keyInfo.KeyChar)}: {keyInfo.KeyChar}, {nameof(keyInfo.Key)}: {keyInfo.Key}, {nameof(keyInfo.Modifiers)}: {keyInfo.Modifiers}");
            }
        }
        #endregion

        #region PublicMethods
        public void Turn()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);

                foreach (var panelBindings in _panelsBindings)
                    panelBindings.Invoke(keyInfo);
            }
        }
        #endregion

        #region PublicStaticClasses
        public static class Keys
        {
            public static ConsoleKeyInfo NumPad1 => new ConsoleKeyInfo(default, ConsoleKey.NumPad1, false, false, false);
            public static ConsoleKeyInfo NumPad2 => new ConsoleKeyInfo(default, ConsoleKey.NumPad2, false, false, false);
            public static ConsoleKeyInfo NumPad3 => new ConsoleKeyInfo(default, ConsoleKey.NumPad3, false, false, false);
            public static ConsoleKeyInfo NumPad4 => new ConsoleKeyInfo(default, ConsoleKey.NumPad4, false, false, false);

            public static ConsoleKeyInfo Shift_NumPad1 => new ConsoleKeyInfo(default, ConsoleKey.NumPad1, true, false, true);
            public static ConsoleKeyInfo Shift_NumPad2 => new ConsoleKeyInfo(default, ConsoleKey.NumPad2, true, false, true);
            public static ConsoleKeyInfo Shift_NumPad3 => new ConsoleKeyInfo(default, ConsoleKey.NumPad3, true, false, true);
            public static ConsoleKeyInfo Shift_NumPad4 => new ConsoleKeyInfo(default, ConsoleKey.NumPad4, true, false, true);

            public static ConsoleKeyInfo Ctrl_NumPad1 => new ConsoleKeyInfo(default, ConsoleKey.NumPad1, false, false, true);
            public static ConsoleKeyInfo Ctrl_NumPad2 => new ConsoleKeyInfo(default, ConsoleKey.NumPad2, false, false, true);
            public static ConsoleKeyInfo Ctrl_NumPad3 => new ConsoleKeyInfo(default, ConsoleKey.NumPad3, false, false, true);
            public static ConsoleKeyInfo Ctrl_NumPad4 => new ConsoleKeyInfo(default, ConsoleKey.NumPad4, false, false, true);

            public static bool Equals(ConsoleKeyInfo keyInfo_1, ConsoleKeyInfo keyInfo_2)
                => keyInfo_1.Key == keyInfo_2.Key && keyInfo_1.Modifiers == keyInfo_2.Modifiers;
        }
        #endregion
    }
}
