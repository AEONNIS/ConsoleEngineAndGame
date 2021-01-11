using System;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem.IntegrationTesting
{
    // _!   Вынести отдельно от продуктового кода.
    public class ScreenIntegrationTesting
    {
        #region Fields
        private readonly Screen _sreen = Screen.Get();

        private readonly Pixel _panel_1_pixel = Pixel.WhiteSpace;
        private readonly Pixel _panel_2_pixel = Pixel.BlueSpace;
        private readonly Pixel _panel_3_pixel = Pixel.GreenSpace;
        private readonly Pixel _panel_4_pixel = Pixel.RedSpace;
        #endregion

        #region PublicMethods
        public void Run()
        {
            InputSystem inputSystem = new InputSystem(CreatePanelsBindngs());
            inputSystem.Turn();
        }
        #endregion

        #region PrivateMethods
        public IEnumerable<PanelBindings> CreatePanelsBindngs()
        {
            List<PanelBindings> result = new List<PanelBindings>();

            result.Add(CreateBindingsForRandomPanel(_panel_1_pixel, InputSystem.Keys.NumPad1, InputSystem.Keys.Ctrl_NumPad1));
            result.Add(CreateBindingsForRandomPanel(_panel_2_pixel, InputSystem.Keys.NumPad2, InputSystem.Keys.Ctrl_NumPad2));
            result.Add(CreateBindingsForRandomPanel(_panel_3_pixel, InputSystem.Keys.NumPad3, InputSystem.Keys.Ctrl_NumPad3));
            result.Add(CreateBindingsForRandomPanel(_panel_4_pixel, InputSystem.Keys.NumPad4, InputSystem.Keys.Ctrl_NumPad4));

            return result;
        }

        public PanelBindings CreateBindingsForRandomPanel(in Pixel filling, in ConsoleKeyInfo displayKey, in ConsoleKeyInfo hideKey)
            => new PanelBindings(CreateRandomPanelInScreen(filling), displayKey, hideKey);

        public Panel CreateRandomPanelInScreen(in Pixel filling) => Panel.CreateRandomPanelIn(_sreen.Rectangle, filling);
        #endregion
    }
}
