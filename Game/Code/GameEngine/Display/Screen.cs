using System;

namespace GameName.GameEngine.DisplaySystem
{
    public class Screen
    {
        private readonly ScreenBuffer _buffer = null;

        public Screen()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.CursorVisible = false;
            _buffer               = new ScreenBuffer(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        public void Display(IGraphics graphics)
        {
            
        }
    }
}
