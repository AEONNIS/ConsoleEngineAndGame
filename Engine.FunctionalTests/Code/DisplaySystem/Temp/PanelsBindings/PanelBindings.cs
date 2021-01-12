using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class PanelBindings
    {
        #region ReadonlyFileds
        private readonly Panel _panel;
        #endregion

        #region Fields
        private KeyBinding _display;
        private KeyBinding _hide;
        #endregion

        #region Constructors
        public PanelBindings(Panel panel) => _panel = panel;
        #endregion

        #region Properties
        public KeyBinding[] GetBindings => new KeyBinding[] { _display, _hide };
        #endregion

        #region PublicMethods
        public void SetDisplayBinding(in ConsoleKeyInfo keyInfo) => _display = new KeyBinding(keyInfo, () => Screen.Get().Display(_panel));
        public void SetHideBinding(in ConsoleKeyInfo keyInfo) => _hide = new KeyBinding(keyInfo, () => Screen.Get().Hide(_panel));
        #endregion
    }
}
