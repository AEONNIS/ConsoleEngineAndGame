namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTesting
    {
        #region ReadonlyFields
        private readonly InputSystem _inputSystem;
        private readonly PanelsCreator _panelsCreator = new PanelsCreator();
        #endregion

        #region Constructors
        public ScreenTesting(int panelsAmount)
        {
            var panels = _panelsCreator.CreateRandomPanels(panelsAmount);
            var keyBindings = PanelsBindingsCreator.Create(panels);
            _inputSystem = new InputSystem(keyBindings);
        }
        #endregion

        #region PublicMethods
        public void Run() => _inputSystem.Run();
        #endregion
    }
}
