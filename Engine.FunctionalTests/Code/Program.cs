using Engine.FunctionalTests.DisplaySystem;

namespace Engine.FunctionalTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ScreenTester screenTesting = new ScreenTester(5);
            //screenTesting.Run();

            Helper helper = new Helper();
            helper.Run();
        }
    }
}
