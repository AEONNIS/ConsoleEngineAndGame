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
        public event Action<ConsoleKeyInfo> KeyPressedInInitial;
        public event Action<ConsoleKeyInfo> KeyPressedInHelp;
        public event Action<ConsoleKeyInfo> KeyPressedInTesting;
        #endregion

        #region StaticProperties
        public static InputSystem Get => _inputSystem;
        #endregion

        #region Properties
        public State State { get; private set; } = State.Initial;
        #endregion

        #region Methods
        public void Run()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);

                if (State == State.Initial)
                    KeyPressedInInitial?.Invoke(keyInfo);
                else if (State == State.Help)
                    KeyPressedInHelp?.Invoke(keyInfo);
                else
                    KeyPressedInTesting?.Invoke(keyInfo);
            }
        }

        public void SetState(State state) => State = state;
        #endregion
    }
}
