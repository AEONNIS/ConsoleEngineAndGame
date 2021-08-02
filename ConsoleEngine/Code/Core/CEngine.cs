using System;

using ConsoleEngine.InputSystem;
using ConsoleEngine.UpdateSystem;

namespace ConsoleEngine.Core
{
    public sealed class CEngine
    {
        private readonly UpdateHandler _updateHandler = null;

        public CEngine()
        {
            InputHandler = new InputHandler(this);
            _updateHandler = new UpdateHandler();
        }

        public InputHandler InputHandler { get; } = null;

        public void AddCommandToCurrentFrame(ICommand command) => _updateHandler.AddCommandToCurrentFrame(command);

        public void Start()
        {
            MainLoop();
        }

        public void Close()
        {
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

        private void Input() => InputHandler.ProcessInput();

        private void Update() => _updateHandler.ProcessUpdate();

        private void Render()
        {
        }

        private void Exit() => Environment.Exit(0);
    }
}
