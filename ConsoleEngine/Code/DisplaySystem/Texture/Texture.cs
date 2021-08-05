using ConsoleEngine.Maths;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class Texture : IReadOnlyTexture
    {
        #region Fields
        private readonly Dictionary<Vector2Int, Pixel> _placedPixels = new Dictionary<Vector2Int, Pixel>();
        #endregion

        #region Constructors
        public Texture() { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> placedPixels) => _placedPixels = new Dictionary<Vector2Int, Pixel>(placedPixels);
        public Texture(IEnumerable<Vector2Int> uniquePoints, in Pixel filler)
        {
            foreach (var point in uniquePoints)
                _placedPixels.Add(point, filler);
        }
        public Texture(in Rectangle rectangle, in Pixel filler)
        {
            for (int y = rectangle.TopLeftAngle.Y; y <= rectangle.BottomRightAngle.Y; y++)
            {
                for (int x = rectangle.TopLeftAngle.X; x <= rectangle.BottomRightAngle.X; x++)
                    _placedPixels.Add(new Vector2Int(x, y), filler);
            }
        }
        #endregion

        #region StaticProperties
        public static IReadOnlyTexture Empty { get; } = new Texture();
        #endregion

        #region Properties
        public bool IsEmpty => _placedPixels.Count == 0;

        public IReadOnlyCollection<Vector2Int> Points => _placedPixels.Keys;
        #endregion

        #region PublicStaticMethods
        public static IReadOnlyCollection<Vector2Int> GetAllUniquePointsFrom(IEnumerable<IReadOnlyTexture> textures)
        {
            List<Vector2Int> points = new List<Vector2Int>();

            foreach (var texture in textures)
            {
                foreach (var placedPixel in texture)
                {
                    if (points.Contains(placedPixel.Key) == false)
                        points.Add(placedPixel.Key);
                }
            }

            return points;
        }

        public static Texture Subtract(IReadOnlyTexture minuend, IReadOnlyTexture subtrahend)
        {
            Texture result = new Texture();

            foreach (var placedPixel in minuend)
            {
                if (subtrahend.Contains(placedPixel.Key) == false)
                    result._placedPixels[placedPixel.Key] = placedPixel.Value;
            }

            return result;
        }

        public static Texture SubtractAndGetIntersection(Texture minuend, IReadOnlyTexture intersectionSource)
        {
            Texture result = new Texture();

            foreach (var placedPixel in intersectionSource)
            {
                if (minuend._placedPixels.ContainsKey(placedPixel.Key))
                {
                    minuend._placedPixels.Remove(placedPixel.Key);
                    result._placedPixels[placedPixel.Key] = placedPixel.Value;
                }
            }

            return result;
        }
        #endregion

        #region PublicMethods
        public bool Contains(in Vector2Int point) => _placedPixels.ContainsKey(point);

        public Pixel? GetPixelIn(in Vector2Int point) => _placedPixels.TryGetValue(point, out Pixel result) ? result : null;

        // _+   Добавить тесты.
        public Texture AddOrReplace(in Vector2Int position, in Pixel pixel)
        {
            _placedPixels[position] = pixel;

            return this;
        }

        public Texture AddOrReplace(KeyValuePair<Vector2Int, Pixel> placedPixel)
        {
            _placedPixels[placedPixel.Key] = placedPixel.Value;

            return this;
        }
        public Texture AddOrReplace(IReadOnlyTexture additional)
        {
            foreach (var placedPixel in additional)
                _placedPixels[placedPixel.Key] = placedPixel.Value;

            return this;
        }

        public Texture Subtract(IReadOnlyTexture subtrahend)
        {
            foreach (var placedPixel in subtrahend)
                _placedPixels.Remove(placedPixel.Key);

            return this;
        }

        public Texture Clear()
        {
            _placedPixels.Clear();

            return this;
        }

        public Texture Clone() => new Texture(_placedPixels);

        public IEnumerator<KeyValuePair<Vector2Int, Pixel>> GetEnumerator() =>
                    ((IEnumerable<KeyValuePair<Vector2Int, Pixel>>)_placedPixels).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_placedPixels).GetEnumerator();
        #endregion
    }
}
