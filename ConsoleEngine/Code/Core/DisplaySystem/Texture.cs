// MovePixel
// SwapPixels
// RotateRelative(Vector2Int point)
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
        public bool IsEmpty => _pixels.Any() == false;
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

        public Pixel? GetPixel(Vector2Int position) => _pixels.TryGetValue(position, out Pixel pixel) ? pixel : null;
        public Pixel? GetPixel(int x, int y) => GetPixel(new Vector2Int(x, y));

        public Vector2Int GetAlignmentPoint(Angle angle)
        {
            var points = Points;
            var allXs = points.Select(point => point.X);
            var allYs = points.Select(point => point.Y);

            if (angle == Angle.TopRight)
                return new Vector2Int(allXs.Min(), allYs.Min());
            else if (angle == Angle.TopLeft)
                return new Vector2Int(allXs.Max(), allYs.Min());
            else if (angle == Angle.BottomRight)
                return new Vector2Int(allXs.Min(), allYs.Max());
            else
                return new Vector2Int(allXs.Max(), allYs.Max());
        }

        public Texture AlignTo(Vector2Int alignmentPoint, Angle angle)
        {
            Shift = alignmentPoint - GetAlignmentPoint(angle);
            return Normalize();
        }

        public Texture Select(bool inside, Rectangle rectangle)
        {
            var resultPixels = new Dictionary<Vector2Int, Pixel>();

            foreach (var pixel in Pixels)
            {
                if (rectangle.Contains(pixel.Key) == inside)
                    resultPixels.Add(pixel.Key, pixel.Value);
            }

            return new Texture(resultPixels);
        }
        public Texture Select(bool inside, Texture texture)
        {
            var thisNorm = Normalize();
            var points = thisNorm.Points.Intersect(texture.Points);
            var pixels = thisNorm.Pixels.Where(pixel => points.Contains(pixel.Key) == inside);
            return new Texture(pixels);
        }

        public void Set(int x, int y, Pixel pixel) => _pixels[new Vector2Int(x, y)] = pixel;
        public void Set(Vector2Int position, Pixel pixel) => _pixels[position] = pixel;

        public bool IsIntersect(Texture texture)
        {
            var pixels = Pixels;

            foreach (var pixel in texture.Pixels)
            {
                if (pixels.ContainsKey(pixel.Key))
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
        #endregion
    }
}
