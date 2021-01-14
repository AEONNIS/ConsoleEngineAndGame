namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
    {
        #region Constructors
        public ScreenTester() => new Helper().Run();
        #endregion

        #region Methods
        public void Run() => InputSystem.Get.Run();
        #endregion
    }
}
