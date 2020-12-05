// Четко разграничить, какие методы меняют текстуру, а какие нет. Это должно быть понятно из самих методов. Плюс можно задокументировать такие методы.

using ConsoleEngine.Maths;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Texture : ICloneable<Texture>
    {
        #region Fields
        private readonly Dictionary<Vector2Int, Pixel> _pixels = new Dictionary<Vector2Int, Pixel>();
        #endregion

        #region Constructors
        public Texture() { }
        public Texture(IEnumerable<KeyValuePair<Vector2Int, Pixel>> pixels) => _pixels = new Dictionary<Vector2Int, Pixel>(pixels);
        #endregion

        #region Properties
        public IReadOnlyDictionary<Vector2Int, Pixel> Pixels => _pixels;
        public IReadOnlyCollection<Vector2Int> Points => _pixels.Keys;
        public bool IsEmpty => _pixels.Any() == false;
        #endregion

        #region Operators
        public static bool operator ==(Texture a, Texture b) => a.Pixels.Count == b.Pixels.Count && a.Pixels.Except(b.Pixels).Any() == false;
        public static bool operator !=(Texture a, Texture b) => a.Pixels.Count != b.Pixels.Count || a.Pixels.Except(b.Pixels).Any();

        public static Texture operator +(Texture minor, Texture major)
        {
            var pixelSum = new Dictionary<Vector2Int, Pixel>(major.Pixels);

            foreach (var minorPixel in minor.Pixels)
                pixelSum[minorPixel.Key] = pixelSum.ContainsKey(minorPixel.Key) ? pixelSum[minorPixel.Key] + minorPixel.Value : minorPixel.Value;

            return new Texture(pixelSum);
        }
        #endregion

        #region Methods
        public void Clear() => _pixels.Clear();

        public Texture Clone() => new Texture(Pixels);

        public override string ToString() => string.Join(", ", _pixels);
        #endregion
    }
}
