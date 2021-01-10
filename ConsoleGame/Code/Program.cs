using ConsoleEngine.DisplaySystem;
using System;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Screen screen = Screen.Get();

            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                Display(keyInfo);
            }
        }

        private static void Display(ConsoleKeyInfo keyInfo)
        {
            Console.WriteLine($"{nameof(keyInfo.KeyChar)}: {keyInfo.KeyChar}, {nameof(keyInfo.Key)}: {keyInfo.Key}, {nameof(keyInfo.Modifiers)}: {keyInfo.Modifiers}");
        }
    }

    public class ScreenIntegrationTesting
    {
        #region Fields
        private readonly Screen _sreen = Screen.Get();
        #endregion

        #region PrivateClasses
        private class InputSystem
        {
            #region Constructors
            public InputSystem()
            {
                Turn();
            }
            #endregion

            #region PrivateMethods
            private void Turn()
            {
                while (true)
                {
                    var keyInfo = Console.ReadKey(true);
                }
            }
            #endregion

            #region PrivateStaticClasses
            private static class Keys
            {
                public static ConsoleKeyInfo NumPad1 => new ConsoleKeyInfo('1', ConsoleKey.NumPad1, false, false, false);
                public static ConsoleKeyInfo NumPad2 => new ConsoleKeyInfo('2', ConsoleKey.NumPad2, false, false, false);
                public static ConsoleKeyInfo NumPad3 => new ConsoleKeyInfo('3', ConsoleKey.NumPad3, false, false, false);
                public static ConsoleKeyInfo NumPad4 => new ConsoleKeyInfo('4', ConsoleKey.NumPad4, false, false, false);

                public static ConsoleKeyInfo CtrlNumPad1 => new ConsoleKeyInfo(default, ConsoleKey.NumPad1, false, false, true);
                public static ConsoleKeyInfo CtrlNumPad2 => new ConsoleKeyInfo(default, ConsoleKey.NumPad2, false, false, true);
                public static ConsoleKeyInfo CtrlNumPad3 => new ConsoleKeyInfo(default, ConsoleKey.NumPad3, false, false, true);
                public static ConsoleKeyInfo CtrlNumPad4 => new ConsoleKeyInfo(default, ConsoleKey.NumPad4, false, false, true);

                public static bool Equals(ConsoleKeyInfo keyInfo_1, ConsoleKeyInfo keyInfo_2)
                    => keyInfo_1.Key == keyInfo_2.Key && keyInfo_1.Modifiers == keyInfo_2.Modifiers;
            }
            #endregion
        }
        #endregion
    }
}
