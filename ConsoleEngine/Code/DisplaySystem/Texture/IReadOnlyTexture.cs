using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public interface IReadOnlyTexture : IEnumerable<KeyValuePair<Vector2Int, Pixel>>, ICloneable<Texture>
    {
        public bool IsEmpty { get; }
        public IEnumerable<Vector2Int> Points { get; }

        public IEnumerable<Vector2Int> GetPointsAfterSubstraction(IReadOnlyTexture texture);
    }
}
