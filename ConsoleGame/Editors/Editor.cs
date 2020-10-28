using ConsoleGame.EngineSystems;
using System;

namespace ConsoleGame.Editors
{
    public partial class Editor
    {
        private const string _mainTitle = "Engine.Editor";
        private readonly Engine _engine;
        private Mode _currentMode;

        #region Base
        public Editor(Engine engine)
        {
            _engine = engine;
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
            _engine.SetMode(Engine.Mode.Main);
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
            else if (mode == Mode.Pixel)
            {

            }
        }

        private void CheckInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Pixel))
                SetMode(Mode.Pixel);
            else if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Tile))
                SetMode(Mode.Tile);
            else if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Map))
                SetMode(Mode.Map);
            else if (ConsoleGame.Keys.CompareWithoutChar(key, Keys.Exit))
                SetMode(Mode.Exit);

        }
    }
}
