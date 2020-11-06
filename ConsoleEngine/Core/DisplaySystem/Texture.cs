using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Texture
    {
        private readonly Dictionary<Vector2Int, Pixel> _pixels = new Dictionary<Vector2Int, Pixel>();

        public Texture() { }
        public Texture(IDictionary<Vector2Int, Pixel> pixels)
                : this(pixels, Vector2Int.Zero)
        { }
        public Texture(IDictionary<Vector2Int, Pixel> pixels, Vector2Int shift)
        {
            _pixels = new Dictionary<Vector2Int, Pixel>(pixels);
            Shift = shift;
        }

        public Vector2Int Shift { get; set; } = Vector2Int.Zero;
        public IReadOnlyDictionary<Vector2Int, Pixel> Pixels => _pixels;

        #region Operators
        public static bool operator ==(Texture a, Texture b)
        {
            if (a.Shift == b.Shift &&
                )

        }
        #endregion

        public void Clear()
        {
            _pixels.Clear();
            Shift = Vector2Int.Zero;
        }

        public void AddOrReplace(int x, int y, Pixel pixel) => _pixels[new Vector2Int(x, y)] = pixel;
        public void AddOrReplace(Vector2Int position, Pixel pixel) => _pixels[position] = pixel;

        public void AddNotReplace(Texture texture)
        {
            foreach (var pixel in texture.Pixels)
                _pixels.TryAdd(pixel.Key, pixel.Value);
        }

        public bool RemoveIfExists(int x, int y) => _pixels.Remove(new Vector2Int(x, y));
        public bool RemoveIfExists(Vector2Int position) => _pixels.Remove(position);

        public void RemoveIfExists(Texture texture)
        {
            foreach (var pixel in texture.Pixels)
                _pixels.Remove(pixel.Key);
        }

        public bool Intersect(Texture texture)
        {
            foreach (var pixel in texture.Pixels)
            {
                if (_pixels.ContainsKey(pixel.Key))
                    return true;
            }
            return false;
        }

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
