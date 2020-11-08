// MovePixel
// SwapPixels
// Intersection(Rectangle) | operator *
// Intersection(Texture) | operator *
// Удалить лишнее, когда станет понятно, что не используется и не нужно.

using ConsoleEngine.Maths;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Texture
    {
        private readonly Dictionary<Vector2Int, Pixel> _pixels = new Dictionary<Vector2Int, Pixel>();

        #region Constructors
        public Texture() { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels)
                : this(pixels, Vector2Int.Zero)
        { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels, Vector2Int shift)
        {
            _pixels = new Dictionary<Vector2Int, Pixel>(pixels);
            Shift = shift;
        }
        #endregion

        #region Properties
        public Vector2Int Shift { get; set; } = Vector2Int.Zero;
        public IReadOnlyDictionary<Vector2Int, Pixel> Pixels => Normalize()._pixels;
        public IReadOnlyCollection<Vector2Int> Points => Normalize()._pixels.Keys;
        #endregion

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

        public static Texture operator +(Texture texture, KeyValuePair<Vector2Int, Pixel> pixel) => texture + (pixel.Key, pixel.Value);
        public static Texture operator +(Texture texture, (Vector2Int Key, Pixel Value) pixel)
        {
            var pixels = new Dictionary<Vector2Int, Pixel>(texture.Normalize().Pixels);
            pixels[pixel.Key] = pixels.ContainsKey(pixel.Key) ? pixels[pixel.Key] + pixel.Value : pixel.Value;
            return new Texture(pixels);
        }
        public static Texture operator +(Texture major, Texture minor)
        {
            var majorNorm = major.Normalize();
            var minorNorm = minor.Normalize();
            var pixelSum = new Dictionary<Vector2Int, Pixel>(majorNorm.Pixels);

            foreach (var minorPixel in minorNorm.Pixels)
                pixelSum[minorPixel.Key] = pixelSum.ContainsKey(minorPixel.Key) ? pixelSum[minorPixel.Key] + minorPixel.Value : minorPixel.Value;

            return new Texture(pixelSum);
        }

        public static Texture operator -(Texture texture, Vector2Int position)
        {
            var textureNorm = texture.Normalize();
            textureNorm._pixels.Remove(position);
            return textureNorm;
        }
        public static Texture operator -(Texture texture, IEnumerable<Vector2Int> positions)
        {
            var textureNorm = texture.Normalize();

            foreach (var position in positions)
                textureNorm._pixels.Remove(position);

            return textureNorm;
        }
        public static Texture operator -(Texture texture, Pixel pixel)
        {
            var textureNorm = texture.Normalize();

            foreach (var px in textureNorm.Pixels)
            {
                if (px.Value == pixel)
                    textureNorm._pixels.Remove(px.Key);
            }

            return textureNorm;
        }
        public static Texture operator -(Texture texture, IEnumerable<Pixel> pixels)
        {
            var textureNorm = texture.Normalize();

            foreach (var pixel in textureNorm.Pixels)
            {
                if (pixels.Contains(pixel.Value))
                    textureNorm._pixels.Remove(pixel.Key);
            }

            return textureNorm;
        }
        #endregion

        #region Methods
        public void Clear()
        {
            _pixels.Clear();
            Shift = Vector2Int.Zero;
        }

        public Texture Normalize()
        {
            if (Shift != Vector2Int.Zero)
            {
                var pixels = new Dictionary<Vector2Int, Pixel>();

                foreach (var pixel in _pixels)
                    pixels.Add(pixel.Key + Shift, pixel.Value);

                return new Texture(pixels);
            }

            return this;
        }

        public void Set(int x, int y, Pixel pixel) => _pixels[new Vector2Int(x, y)] = pixel;
        public void Set(Vector2Int position, Pixel pixel) => _pixels[position] = pixel;

        public bool IsIntersect(Texture texture)
        {
            var thisNorm = Normalize();
            var textureNorm = texture.Normalize();

            foreach (var pixel in textureNorm.Pixels)
            {
                if (thisNorm.Pixels.ContainsKey(pixel.Key))
                    return true;
            }
            return false;
        }

        public bool IsEmpty() => _pixels.Any() == false;

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
        #endregion
    }
}
