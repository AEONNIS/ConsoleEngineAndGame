using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public struct Texture
    {
        private Dictionary<Vector2Int, Pixel> _pixels;

        public Texture(Dictionary<Vector2Int, Pixel> pixels)
        {
            _pixels = pixels;
        }
    }
}
