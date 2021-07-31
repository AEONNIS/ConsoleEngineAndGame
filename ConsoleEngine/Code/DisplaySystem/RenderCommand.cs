using System;

namespace ConsoleEngine.DisplaySystem
{
    public class RenderCommand
    {
        public RenderCommandId   Id       { get; init; }
        public IGraphics         Graphics { get; init; }
        public Action<IGraphics> Action   { get; init; }


        public void Assign()
        {
            // Назначение действия для исполнения в цикле рендеринга.
        }

        public void Execute() => Action.Invoke(Graphics);
    }
}
