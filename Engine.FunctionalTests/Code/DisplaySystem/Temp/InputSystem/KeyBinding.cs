using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public readonly struct KeyBinding
    {
        #region Constructors
        public KeyBinding(in ConsoleKeyInfo keyinfo, Action action)
        {
            KeyInfo = keyinfo;
            Action = action;
        }
        #endregion

        #region Properties
        public readonly ConsoleKeyInfo KeyInfo { get; }
        public readonly Action Action { get; }
        #endregion
    }
}
