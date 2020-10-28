using ConsoleGame.EngineSystems;

namespace ConsoleGame
{
    public class Program
    {
        private static readonly Engine _engine = new Engine();

        public static void Main(string[] args)
        {
            _engine.Start();
        }
    }
}
