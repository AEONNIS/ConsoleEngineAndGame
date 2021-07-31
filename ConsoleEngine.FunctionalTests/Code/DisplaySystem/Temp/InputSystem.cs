using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class InputSystem
    {
        #region StaticFields
        private static readonly InputSystem _inputSystem = new InputSystem();
        #endregion

        #region Fields
        private ScreenTester _tester;
        #endregion

        #region PrivateConstructor
        private InputSystem() { }
        #endregion

        #region Events
        public event Action<ConsoleKeyInfo> KeyPressedInHelp;
        public event Action<ConsoleKeyInfo> KeyPressedInTesting;
        #endregion

        #region StaticProperties
        public static InputSystem Get => _inputSystem;
        #endregion

        #region Methods
        public void Run(ScreenTester tester)
        {
            _tester = tester;

            while (true)
            {
                var keyInfo = Console.ReadKey(true);

                if (_tester.State == State.Help)
                    KeyPressedInHelp?.Invoke(keyInfo);
                else if (_tester.State == State.Testing)
                    KeyPressedInTesting?.Invoke(keyInfo);
            }
        }
        #endregion
    }
}
