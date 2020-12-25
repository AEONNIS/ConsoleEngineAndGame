using ConsoleEngine.Maths;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayersGraphicsService
    {
        #region StaticMethods
        public static void ToCover(IEnumerable<ScreenLayer> layersTopToBottom, IReadOnlyTexture covering)
        {
            if (covering.IsEmpty == false)
            {
                var coveringPart = covering.Clone();

                foreach (var layer in layersTopToBottom)
                {
                    layer.ToCover(ref coveringPart);

                    if (coveringPart.IsEmpty)
                        break;
                }
            }
        }

        public static IReadOnlyTexture ToUncover(IEnumerable<ScreenLayer> layersTopToBottom, IReadOnlyTexture covering, Pixel emptyPixel)
        {
            var result = new Texture();

            if (covering.IsEmpty == false)
            {
                var coveringPart = covering.Clone();

                foreach (var layer in layersTopToBottom)
                {
                    var uncovered = layer.ToUncover(ref coveringPart);
                    result.AddOrReplace(uncovered);

                    if (coveringPart.IsEmpty)
                        break;
                }

                var emptyPart = Texture.CreateFrom(coveringPart.Points, emptyPixel);
                result.AddOrReplace(emptyPart);
            }

            return result;
        }

        public static IReadOnlyTexture GetEmptyTextureFrom(IEnumerable<ScreenLayer> layers, Pixel emptyPixel)
        {
            IEnumerable<IReadOnlyTexture> textures = layers.Select(layer => layer.Total);
            IEnumerable<Vector2Int> points = Texture.GetAllPoints(textures);
            return Texture.CreateFrom(points, emptyPixel);
        }
        #endregion
    }
}