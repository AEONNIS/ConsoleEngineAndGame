using System;

using ConsoleEngine.DisplaySystem;

namespace ConsoleEngine.Core
{
    public class CEngine
    {
        private readonly IGameEngine _gameEngine = null;
        private readonly Screen      _screen     = null;

        public CEngine(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public void Start()
        {
            _gameEngine.Start();

            MainLoop();
        }

        public void Close()
        {
            _gameEngine.Close();

            Exit();
        }

        private void MainLoop()
        {
            while (true)
            {
                Input ();
                Update();
                Render();
            }
        }

        private void Input()
        {
            _gameEngine.Input();
        }

        private void Update()
        {
            _gameEngine.Update();
        }

        private void Render()
        {
            _gameEngine.Render();
        }

        private void Exit() => Environment.Exit(0);
    }
}
