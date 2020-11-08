using ConsoleEngine.Maths;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Texture
    {
        private readonly Dictionary<Vector2Int, Pixel> _pixels = new Dictionary<Vector2Int, Pixel>();

        public Texture() { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels)
                : this(pixels, Vector2Int.Zero)
        { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels, Vector2Int shift)
        {
            _pixels = new Dictionary<Vector2Int, Pixel>(pixels);
            Shift = shift;
        }

        public Vector2Int Shift { get; set; } = Vector2Int.Zero;
        public IReadOnlyDictionary<Vector2Int, Pixel> Pixels => _pixels;

        #region Operators
        public static bool operator ==(Texture a, Texture b)
        {
            var aNorm = a.Normalize();
            var bNorm = b.Normalize();
            return aNorm.Pixels.Count == bNorm.Pixels.Count && aNorm.Pixels.Except(bNorm.Pixels).Any() == false;
        }

        public static bool operator !=(Texture a, Texture b)
        {
            var aNorm = a.Normalize();
            var bNorm = b.Normalize();
            return aNorm.Pixels.Count != bNorm.Pixels.Count || aNorm.Pixels.Except(bNorm.Pixels).Any();
        }

        public static Texture operator +(Texture text, Vector2Int shift) => new Texture(text.Pixels, text.Shift + shift);
        public static Texture operator +(Texture text, (Vector2Int key, Pixel value) pixel)
        {
            var pixels = new Dictionary<Vector2Int, Pixel>(text.Pixels);
            pixels[pixel.key - text.Shift] = pixels.ContainsKey(pixel.key - text.Shift) ? pixels[pixel.key - text.Shift] + pixel.value : pixel.value;
            return new Texture(pixels, text.Shift);
        }
        public static Texture operator +(Texture major, Texture minor)
        {
            var majNorm = major.Normalize();
            var minNorm = minor.Normalize();
            var pixelSum = new Dictionary<Vector2Int, Pixel>(majNorm.Pixels);

            foreach (var minPixel in minNorm.Pixels)
                pixelSum[minPixel.Key] = pixelSum.ContainsKey(minPixel.Key) ? pixelSum[minPixel.Key] + minPixel.Value : minPixel.Value;

            return new Texture(pixelSum);
        }
        #endregion

        public Texture Normalize()
        {
            var pixels = new Dictionary<Vector2Int, Pixel>();

            foreach (var pixel in Pixels)
                pixels.Add(pixel.Key + Shift, pixel.Value);

            return new Texture(pixels, Vector2Int.Zero);
        }

        public void Clear()
        {
            _pixels.Clear();
            Shift = Vector2Int.Zero;
        }

        public void Set(int x, int y, Pixel pixel) => _pixels[new Vector2Int(x, y)] = pixel;
        public void Set(Vector2Int position, Pixel pixel) => _pixels[position] = pixel;

        public bool Remove(int x, int y) => _pixels.Remove(new Vector2Int(x, y));
        public bool Remove(Vector2Int position) => _pixels.Remove(position);

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
