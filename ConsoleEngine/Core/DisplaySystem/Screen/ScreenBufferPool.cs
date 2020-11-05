using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenBufferPool
    {
        private readonly Stack<ScreenBuffer> _usedBuffers;
        private readonly Stack<ScreenBuffer> _emptyBuffers;
    }
}
