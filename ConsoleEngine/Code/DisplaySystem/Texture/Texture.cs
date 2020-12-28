using ConsoleEngine.Maths;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public class Texture : IReadOnlyTexture
    {
        #region StaticFields
        private static readonly IReadOnlyTexture _empty = new Texture();
        #endregion

        #region Fields
        private readonly Dictionary<Vector2Int, Pixel> _placedPixels = new Dictionary<Vector2Int, Pixel>();
        #endregion

        #region Constructors
        public Texture() { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> placedPixels) => _placedPixels = new Dictionary<Vector2Int, Pixel>(placedPixels);
        public Texture(IEnumerable<Vector2Int> points, Pixel fillingPixel)
        {
            foreach (var point in points)
                _placedPixels.Add(point, fillingPixel);
        }
        #endregion

        #region StaticProperties
        public static ref readonly IReadOnlyTexture Empty => ref _empty;
        #endregion

        #region Properties
        public bool IsEmpty => _placedPixels.Count == 0;

        public IReadOnlyCollection<Vector2Int> Points => _placedPixels.Keys;
        #endregion

        #region StaticMethods
        public static IReadOnlyCollection<Vector2Int> GetAllPoints(IEnumerable<IReadOnlyTexture> textures)
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

        public static Texture SubtractAndGetIntersection(ref Texture minuend, IReadOnlyTexture intersectionSource)
        {
            Texture result = new Texture();

            foreach (var placedPixel in intersectionSource)
            {
                if (minuend.Contains(placedPixel.Key))
                {
                    minuend._placedPixels.Remove(placedPixel.Key);
                    result._placedPixels[placedPixel.Key] = placedPixel.Value;
                }
            }

            return result;
        }
        #endregion

        #region Methods
        public bool Contains(in Vector2Int point) => _placedPixels.ContainsKey(point);

        public Texture AddOrReplace(IReadOnlyTexture texture)
        {
            foreach (var placedPixel in texture)
                _placedPixels[placedPixel.Key] = placedPixel.Value;

            return this;
        }

        public Texture Subtract(IReadOnlyTexture texture)
        {
            foreach (var placedPixel in texture)
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
