using System;

using ConsoleEngine.Core;

namespace ConsoleEngine.InputSystem
{
    public class InputHandler
    {
        private readonly CEngine        _consoleEngine  = null;
        private          BindingKeysSet _bindingKeysSet = null;

        public InputHandler(CEngine consoleEngine) => _consoleEngine = consoleEngine;

        public void SetBindingKeys(BindingKeysSet bindingKeysSet) => _bindingKeysSet = bindingKeysSet;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                KeyBinding     binding        = FindBinding(consoleKeyInfo);

                if (binding != null)
                    _consoleEngine.AddCommandToCurrentFrame(binding.Command);
            }
        }

        private KeyBinding FindBinding(ConsoleKeyInfo consoleKeyInfo)
        {
            foreach (var binding in _bindingKeysSet.BindingKeys)
            {
                if (binding.KeyInfo.Equals(consoleKeyInfo))
                    return binding;
            }

            return null;
        }
    }
}
