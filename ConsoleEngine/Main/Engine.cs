using ConsoleGame.Editors;
using System;

namespace ConsoleGame.ConsoleEngine
{
    public partial class Engine
    {
        public const string AssetsPath = "d:/Work/Dev/ConsoleGame/ConsoleGame/Assets/Editor/";
        private const string _mainTitle = "Engine.Main";
        private readonly Editor _editor;
        private Mode _currentMode;

        #region Base
        public Engine()
        {
            _editor = new Editor(this);

            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }

        public void Start()
        {
            SetMode(Mode.Main);

            while (_currentMode != Mode.Exit)
                CheckInput();

            Exit();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
        #endregion

        public void SetMode(Mode mode)
        {
            _currentMode = mode;

            if (mode == Mode.Main)
            {
                Console.Title = _mainTitle;
                Console.ResetColor();
                Console.Clear();
            }
            else if (mode == Mode.Editor)
            {
                _editor.Start();
            }
        }

        private void CheckInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Game))
                SetMode(Mode.Game);
            else if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Editor))
                SetMode(Mode.Editor);
            else if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Exit))
                SetMode(Mode.Exit);
        }
    }
}
