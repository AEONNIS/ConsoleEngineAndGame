using ConsoleEngine.Core;

using GameName.GameEngine.Core;

namespace GameName
{
    public class Program
    {
        private static CEngine _cEngine = null;
        private static GEngine _gEngine = null;

        public static void Main(string[] args)
        {
            _gEngine = new GEngine();
            _cEngine = new CEngine(_gEngine);

            _cEngine.Start();
        }
    }
}
