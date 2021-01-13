using Engine.DisplaySystem;
using Engine.Maths;
using System;
using System.Collections.Generic;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class PanelsCreator
    {
        #region Fields
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly Vector2Int _minSize = Screen.Get.Rectangle.Size * PanelsData.MinPartFromScreenSize;
        private readonly List<Pixel> _usedPixels = new List<Pixel>(PanelsData.Fillers.Length);
        #endregion

        #region PublicMethods
        public void CreateRandomPanels(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var name = $"{PanelsData.BaseName}{i}";
                var panel = GetRandomPanelFitIntoScreen(name);
                panel.SetDisplayKey(PanelsData.KeysFor.DisplayActions[i]);
                panel.SetHideKey(PanelsData.KeysFor.HideActions[i]);
            }
        }
        #endregion

        #region PrivateMethods
        private Panel GetRandomPanelFitIntoScreen(string panelName)
            => Panel.CreateRandomPanelIn(Screen.Get.Rectangle, _minSize, GetRandomUnusedPixel(), panelName);

        private Pixel GetRandomUnusedPixel()
        {
            Pixel pixel;

            do
                pixel = GetRandomPixel();
            while (_usedPixels.Contains(pixel) && _usedPixels.Count != PanelsData.Fillers.Length);

            _usedPixels.Add(pixel);

            return pixel;
        }

        private Pixel GetRandomPixel() => PanelsData.Fillers[_random.Next(0, PanelsData.Fillers.Length)];
        #endregion
    }
}
