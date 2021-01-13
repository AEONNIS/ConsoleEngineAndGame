using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class InputSystem
    {
        #region StaticFields
        private static readonly InputSystem _inputSystem = new InputSystem();
        #endregion

        #region PrivateConstructor
        private InputSystem() { }
        #endregion

        #region Events
        public event Action<ConsoleKeyInfo> KeyPressed;
        #endregion

        #region StaticProperties
        public static InputSystem Get => _inputSystem;
        #endregion

        #region Methods
        public void Run()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                KeyPressed?.Invoke(keyInfo);
            }
        }
        #endregion
    }
}
