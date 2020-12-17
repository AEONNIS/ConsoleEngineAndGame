// Четко разграничить, какие методы меняют текстуру, а какие нет. Это должно быть понятно из самих методов. Плюс можно задокументировать такие методы.

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
        public Texture(in IEnumerable<KeyValuePair<Vector2Int, Pixel>> placedPixels) => _placedPixels = new Dictionary<Vector2Int, Pixel>(placedPixels);
        #endregion

        #region Methods
        public void AddOrReplace(IReadOnlyTexture texture)
        {

        }

        public void Clear() => _placedPixels.Clear();

        public Texture Clone() => new Texture(_placedPixels);

        public IEnumerator<KeyValuePair<Vector2Int, Pixel>> GetEnumerator() =>
                    ((IEnumerable<KeyValuePair<Vector2Int, Pixel>>)_placedPixels).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_placedPixels).GetEnumerator();
        #endregion
    }
}
