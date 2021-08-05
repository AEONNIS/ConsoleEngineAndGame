using System.Collections.Generic;

using ConsoleEngine.InputSystem;

namespace ConsoleEngine.UpdateSystem
{
    public class UpdateHandler
    {
        private readonly List<ICommand> _currentFrameCommands = new List<ICommand>();

        public void AddCommandToCurrentFrame(ICommand command) => _currentFrameCommands.Add(command);

        public void ProcessUpdate()
        {
            foreach (var command in _currentFrameCommands)
                command.Execute();

            _currentFrameCommands.Clear();
        }
    }
}
