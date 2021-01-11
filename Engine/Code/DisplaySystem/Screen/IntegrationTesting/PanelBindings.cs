using System;

namespace Engine.DisplaySystem.IntegrationTesting
{
    public class PanelBindings
    {
        #region Fields
        private readonly KeyBinding _display;
        private readonly KeyBinding _hide;
        #endregion

        #region Constructors
        public PanelBindings(Panel panel, ConsoleKeyInfo displayKey, ConsoleKeyInfo hideKey)
        {
            _display = new KeyBinding { Key = displayKey, Action = panel.Display };
            _hide = new KeyBinding { Key = hideKey, Action = panel.Hide };
        }
        #endregion

        #region PublicMethods
        public void Invoke(ConsoleKeyInfo keyInfo)
        {
            if (InputSystem.Keys.Equals(keyInfo, _display.Key))
                _display.Action?.Invoke();
            if (InputSystem.Keys.Equals(keyInfo, _hide.Key))
                _hide.Action?.Invoke();
        }
        #endregion
    }

    public class KeyBinding
    {
        public ConsoleKeyInfo Key { get; init; }
        public Action Action { get; init; }
    }
}
