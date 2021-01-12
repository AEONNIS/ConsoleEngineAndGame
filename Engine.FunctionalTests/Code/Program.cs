using Engine.FunctionalTests.DisplaySystem;

namespace Engine.FunctionalTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ScreenTesting screenTesting = new ScreenTesting(5);
            screenTesting.Run();
        }
    }
}
