using System;

namespace ConsoleEngine.Core
{
    public interface IGameEngine
    {
        public void           Start();

        public ConsoleKeyInfo Input();

        public void           Update();

        public void           Render();

        public void           Close();
    }
}
