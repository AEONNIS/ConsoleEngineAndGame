using Engine.FunctionalTests.DisplaySystem;

namespace Engine.FunctionalTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ScreenTester screenTester = new ScreenTester();
            screenTester.Run();
        }
    }
}
