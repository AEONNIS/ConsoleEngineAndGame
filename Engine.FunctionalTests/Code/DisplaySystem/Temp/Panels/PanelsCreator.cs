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
                var name = $"{PanelData.BaseName}{i}";
                var panel = GetRandomPanelFitIntoScreen(name);
                panel.SetDisplayKey(KeyData.ForPanels.DisplayOnScreen[i]);
                panel.SetHideKey(KeyData.ForPanels.HideFromScreen[i]);
            }
        }
        #endregion

        #region PrivateMethods
        private Panel GetRandomPanelFitIntoScreen(string panelName)
            => Panel.CreateRandomPanelIn(Screen.Get.Rectangle, PanelData.MinSize, GetRandomUnusedPixel(), panelName);

        private Pixel GetRandomUnusedPixel()
        {
            Pixel pixel;

            do
                pixel = Pixel.CreateRandomFrom(PanelData.Colorings, PanelData.Symbols);
            while (_usedPixels.Contains(pixel) && _usedPixels.Count != PanelData.Symbols.Length * PanelData.Colorings.Length);

            _usedPixels.Add(pixel);
            return pixel;
        }
        #endregion
    }
}
