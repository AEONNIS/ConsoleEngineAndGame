﻿using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public static class ScreenLayersGraphicsService
    {
        #region StaticMethods
        public static void ToCover(IEnumerable<ScreenLayer> layersTopToBottom, IReadOnlyTexture covering)
        {
            if (covering.IsEmpty == false)
            {
                var coveringPart = covering.Clone();

                foreach (var layer in layersTopToBottom)
                {
                    layer.ToCover(coveringPart);

                    if (coveringPart.IsEmpty)
                        break;
                }
            }
        }

        public static IReadOnlyTexture ToUncover(IEnumerable<ScreenLayer> layersTopToBottom, IReadOnlyTexture covering, in Pixel empty)
        {
            if (covering.IsEmpty == false)
            {
                var result = new Texture();
                var coveringPart = covering.Clone();

                foreach (var layer in layersTopToBottom)
                {
                    var uncovered = layer.ToUncover(coveringPart);
                    result.AddOrReplace(uncovered);

                    if (coveringPart.IsEmpty)
                        break;
                }

                var emptyPart = new Texture(coveringPart.Points, empty);
                result.AddOrReplace(emptyPart);

                return result;
            }

            return Texture.Empty;
        }

        public static IReadOnlyTexture GetEmptyTextureFrom(IEnumerable<ScreenLayer> layers, in Pixel empty)
        {
            var textures = layers.Select(layer => layer.UncoveredPart);
            var points = Texture.GetAllUniquePointsFrom(textures);
            return new Texture(points, empty);
        }
        #endregion
    }
}