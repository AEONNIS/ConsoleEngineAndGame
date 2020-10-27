using System;

namespace ConsoleGame
{
    public class Engine
    {
        private const string _assetsPath = "d:/Work/Dev/ConsoleGame/ConsoleGame/Assets/Editor/";
        private Mode _currentMode;
        private Editor _editor;

        public Engine()
        {
            Tune();
            StartCycle();
        }

        public enum Mode { Game, Editor }

        private void Tune()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }

        private void StartCycle()
        {
            while (true)
            {
                CheckInput();
            }
        }

        private void StartMode(Mode mode)
        {
            if (mode == Mode.Editor)
            {
                _currentMode = mode;
                _editor = new Editor();
            }
        }

        private void CheckInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (Keys.CompareWithoutChar(key, Editor.Keys.Start))
                StartMode(Mode.Editor);
        }
    }
}
