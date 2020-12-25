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
        #region StaticFields
        private static readonly IReadOnlyTexture _empty = new Texture();
        #endregion

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

        #region StaticProperties
        public static ref readonly IReadOnlyTexture Empty => ref _empty;
        #endregion

        #region Properties
        public bool IsEmpty => _placedPixels.Count == 0;

        public IEnumerable<Vector2Int> Points => throw new System.NotImplementedException();
        #endregion

        #region StaticMethods
        public static IEnumerable<Vector2Int> GetIntersectionPoints(IReadOnlyTexture a, IReadOnlyTexture b)
        {
            return null;
        }

        public static IEnumerable<Vector2Int> GetAllPoints(IEnumerable<IReadOnlyTexture> textures)
        {
            return null;
        }

        public static IReadOnlyTexture CreateFrom(IEnumerable<Vector2Int> points, Pixel fillingPixel)
        {
            return null;
        }

        public static IReadOnlyTexture IntersectAndSubstract(IReadOnlyTexture unchangeable, ref Texture changeable)
        {
            // В одном цикле находить общие точки и вычитать их из одной текстуры, которая меняется,
            // а из другой текстуры отбирать пиксели с общими координатами и из них создавать новую текстуру.

            return null;
        }
        #endregion

        #region Methods
        public void AddOrReplace(IReadOnlyTexture texture) // М.б. сделать возврат самой себя после изменения?
        {

        }

        public void Subtract(IReadOnlyTexture texture) // М.б. сделать возврат самой себя после изменения?
        {

        }

        public void Intersect(IReadOnlyTexture texture) // М.б. сделать возврат самой себя после изменения?
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
