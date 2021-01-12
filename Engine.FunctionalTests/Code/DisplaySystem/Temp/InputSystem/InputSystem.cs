using System;
using System.Collections.Generic;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class InputSystem
    {
        #region Fields
        private readonly List<KeyBinding> _keyBindings;
        #endregion

        #region Constructors
        public InputSystem(IEnumerable<KeyBinding> keyBindings) => _keyBindings = new List<KeyBinding>(keyBindings);
        #endregion

        #region PublicMethods
        public void Run() => Update();
        #endregion

        #region PrivateMethods
        private void Update()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                InvokeAllBindedActions(keyInfo);
            }
        }

        private void InvokeAllBindedActions(in ConsoleKeyInfo keyInfo)
        {
            foreach (var keyBinding in _keyBindings)
            {
                if (KeysService.Equals(keyInfo, keyBinding.KeyInfo))
                    keyBinding.Action?.Invoke();
            }
        }
        #endregion
    }
}
