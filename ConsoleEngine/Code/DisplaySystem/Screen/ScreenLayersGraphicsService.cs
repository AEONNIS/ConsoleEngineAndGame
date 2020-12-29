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
            if (covering.IsEmpty == false)
            {
                var result = new Texture();
                var coveringPart = covering.Clone();

                foreach (var layer in layersTopToBottom)
                {
                    var uncovered = layer.ToUncover(ref coveringPart);
                    result.AddOrReplace(uncovered);

                    if (coveringPart.IsEmpty)
                        break;
                }

                var emptyPart = new Texture(coveringPart.Points, emptyPixel);
                result.AddOrReplace(emptyPart);

                return result;
            }

            return Texture.Empty;
        }

        public static IReadOnlyTexture GetEmptyTextureFrom(IEnumerable<ScreenLayer> layers, Pixel emptyPixel)
        {
            var textures = layers.Select(layer => layer.Total);
            var points = Texture.GetAllPoints(textures);
            return new Texture(points, emptyPixel);
        }
        #endregion
    }
}