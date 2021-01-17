using Engine.DisplaySystem;
using System.Collections.Generic;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class PanelsCreator
    {
        #region Fields
        private readonly List<Pixel> _usedPixels = new List<Pixel>();
        #endregion

        #region PublicMethods
        public void CreateRandomPanels(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var name = $"{Data.Panels.BaseName}{i}";
                var panel = GetRandomPanelFitIntoScreen(name);
                panel.SetDisplayKey(Data.Panels.KeysFor.DisplayOnScreen[i]);
                panel.SetHideKey(Data.Panels.KeysFor.HideFromScreen[i]);
            }
        }
        #endregion

        #region PrivateMethods
        private Panel GetRandomPanelFitIntoScreen(string panelName)
            => Panel.CreateRandomPanelIn(Screen.Get.Rectangle, Data.Panels.MinSize, GetRandomUnusedPixel(), panelName);

        private Pixel GetRandomUnusedPixel()
        {
            Pixel pixel;

            do
                pixel = Pixel.CreateRandomFrom(Data.Panels.Colorings, Data.Panels.Symbols);
            while (_usedPixels.Contains(pixel) && _usedPixels.Count != Data.Panels.Symbols.Length * Data.Panels.Colorings.Length);

            _usedPixels.Add(pixel);
            return pixel;
        }
        #endregion
    }
}
