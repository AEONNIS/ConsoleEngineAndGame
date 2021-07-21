namespace Draft
{
    public class Program
    {
        private static GameEngine.Engine _engine = null;

        public static void Main(string[] args)
        {
            _engine = new GameEngine.Engine();
            _engine.Start();
        }
    }
}
