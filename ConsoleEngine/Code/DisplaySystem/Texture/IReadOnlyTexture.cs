// Нужно пройтись по коду и отобрать, где использовать текстуру только для чтения, а где нет.

using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public interface IReadOnlyTexture : IEnumerable<KeyValuePair<Vector2Int, Pixel>>, ICloneable<Texture>
    {
        #region Properties
        public bool IsEmpty { get; }

        public IReadOnlyCollection<Vector2Int> Points { get; }
        #endregion

        #region Methods
        public bool Contains(in Vector2Int point);
        #endregion
    }
}
