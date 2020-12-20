// Четко разграничить, какие методы меняют текстуру, а какие нет. Это должно быть понятно из самих методов. Плюс можно задокументировать такие методы.

/* ОПЕРАЦИИ С ТЕКСТУРАМИ
 * Добавление новой текстуры с заменой общих пикселей на пиксели добавляемой текстуры.
 * Вычитание из одной текстуры другой.
 * Нахождение области пересечения.
 * Нахождение оставшихся точек (только Vector2Int) после вычитания одной текстуры из другой.
 * Создание новой текстуры на основе точек и заданного пикселя (все точки будут содержать этот пиксель).
 */

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
        public Texture(IEnumerable<Vector2Int> points, Pixel fillPixel)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Properties
        public bool IsEmpty => _placedPixels.Count == 0;

        public IEnumerable<Vector2Int> Points => throw new System.NotImplementedException();
        #endregion

        #region Methods
        public void AddOrReplace(IReadOnlyTexture texture)
        {

        }

        public void Substract(IReadOnlyTexture texture)
        {

        }

        public void Intersect(IReadOnlyTexture texture)
        {

        }

        public IEnumerable<Vector2Int> GetPointsAfterSubstraction(IReadOnlyTexture texture)
        {
            throw new System.NotImplementedException();
        }

        public void Clear() => _placedPixels.Clear();

        public Texture Clone() => new Texture(_placedPixels);

        public IEnumerator<KeyValuePair<Vector2Int, Pixel>> GetEnumerator() =>
                    ((IEnumerable<KeyValuePair<Vector2Int, Pixel>>)_placedPixels).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_placedPixels).GetEnumerator();
        #endregion
    }
}
