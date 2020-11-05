using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Texture
    {
        private readonly Dictionary<Vector2Int, Pixel> _pixels = new Dictionary<Vector2Int, Pixel>();

        public Texture() { }
        public Texture(Dictionary<Vector2Int, Pixel> pixels)
                : this(pixels, Vector2Int.Zero)
        { }
        public Texture(Dictionary<Vector2Int, Pixel> pixels, Vector2Int shift)
        {
            _pixels = pixels;
            Shift = shift;
        }

        public Vector2Int Shift { get; set; } = Vector2Int.Zero;
        public IReadOnlyDictionary<Vector2Int, Pixel> Pixels => _pixels;

        public void AddOrReplace(int x, int y, Pixel pixel) => _pixels[new Vector2Int(x, y)] = pixel;
        public void AddOrReplace(Vector2Int position, Pixel pixel) => _pixels[position] = pixel;

        public bool RemoveIfExists(int x, int y) => _pixels.Remove(new Vector2Int(x, y));
        public bool RemoveIfExists(Vector2Int position) => _pixels.Remove(position);

        public void DisplayInConsole()
        {
            foreach (var pixel in _pixels)
                pixel.Value.DisplayInConsole(pixel.Key + Shift);
        }

        public override string ToString()
        {
            string result = string.Join(", ", _pixels);
            result += $", Shf:{Shift}";
            return result;
        }
    }
}
