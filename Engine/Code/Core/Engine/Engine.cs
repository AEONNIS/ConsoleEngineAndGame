using Engine.Editors;
using Engine.InputSystem;
using System;

namespace Engine.Core
{
    public partial class Engine
    {
        public const string AssetsPath = "d:/Work/Dev/ConsoleGame/ConsoleEngine/Assets/";
        private const string _coreTitle = "Engine.Core";
        private readonly Editor _editor;
        private Mode _currentMode;

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

        public void SetMode(Mode mode)
        {
            _currentMode = mode;

            if (mode == Mode.Main)
            {
                Console.Title = _coreTitle;
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

            if (KeysService.CompareWithoutChar(key, Keys.Game))
                SetMode(Mode.Game);
            else if (KeysService.CompareWithoutChar(key, Keys.Editor))
                SetMode(Mode.Editor);
            else if (KeysService.CompareWithoutChar(key, Keys.Exit))
                SetMode(Mode.Exit);
        }
    }
}
