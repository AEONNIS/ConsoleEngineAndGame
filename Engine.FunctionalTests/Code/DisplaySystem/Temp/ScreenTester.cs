namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
    {
        #region Fields
        private readonly PanelsCreator _panelsCreator = new PanelsCreator();
        #endregion

        #region Constructors
        public ScreenTester() => _panelsCreator.CreateRandomPanels(5);
        #endregion

        #region Methods
        public void Run() => InputSystem.Get.Run();
        #endregion
    }
}
