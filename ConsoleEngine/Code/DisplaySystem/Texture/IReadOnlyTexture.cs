using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleEngine.DisplaySystem
{
    public interface IReadOnlyTexture : IEnumerable<KeyValuePair<Vector2Int, Pixel>>, ICloneable<Texture>
    {

    }
}
