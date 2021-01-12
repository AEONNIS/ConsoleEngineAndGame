using System.Collections.Generic;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class PanelsBindingsCreator
    {
        #region PublicStaticMethods
        public static IEnumerable<KeyBinding> Create(Panel[] panels)
        {
            List<KeyBinding> result = new List<KeyBinding>();

            for (int i = 0; i < panels.Length; i++)
                result.AddRange(CreateFor(panels[i], i));

            return result;
        }
        #endregion

        #region PrivateStatticMethods
        private static IEnumerable<KeyBinding> CreateFor(Panel panel, int index)
        {
            var panelBindings = new PanelBindings(panel);
            panelBindings.SetDisplayBinding(PanelsData.KeysFor.DisplayActions[index]);
            panelBindings.SetHideBinding(PanelsData.KeysFor.HideActions[index]);

            return panelBindings.GetBindings;
        }
        #endregion
    }
}
