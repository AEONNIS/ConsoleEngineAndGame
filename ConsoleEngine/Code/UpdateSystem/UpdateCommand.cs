using System;

using ConsoleEngine.DisplaySystem;

namespace ConsoleEngine.UpdateSystem
{
    public class UpdateCommand
    {
        public UpdateCommandId    Id            { get; init; }
        public IUpdatable         Updatable     { get; init; }
        public Action<IUpdatable> Action        { get; init; }
        public RenderCommand      RenderCommand { get; init; }

        public void Assign()
        {
            // Назначение действия для исполнения в цикле обновления.
        }

        public void Execute()
        {
            Action.Invoke(Updatable);
            RenderCommand.Assign();
        }
    }
}
