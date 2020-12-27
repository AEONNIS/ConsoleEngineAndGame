// Нужно пройтись по коду и отобрать, где использовать текстуру только для чтения, а где нет.

using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public interface IReadOnlyTexture : IEnumerable<KeyValuePair<Vector2Int, Pixel>>, ICloneable<Texture>
    {
        public bool IsEmpty { get; }

        public IReadOnlyCollection<Vector2Int> Points { get; }

        bool Contains(in Vector2Int point);

        public IEnumerable<Vector2Int> GetPointsAfterSubstraction(IReadOnlyTexture texture);
    }
}
