using System.Collections.Generic;

using ConsoleEngine.Maths;

namespace GameName.GameEngine.DisplaySystem
{
    public class Texture
    {
        private readonly Dictionary<Vector2Int, char> _pixels = null;

        public Texture(char[,] pixels, in Vector2Int screenPositionShift)
        {
            _pixels             = Convert(pixels);
            ScreenPositionShift = screenPositionShift;
        }

        public IReadOnlyDictionary<Vector2Int, char> Pixels => _pixels;
        public Vector2Int                            ScreenPositionShift { get; private set; }
        public char[,]                               View
        {
            get
            {
                Vector2Int max = Vector2Int.GetMax(_pixels.Keys) + ScreenPositionShift;
                char[,] result = new char[max.X, max.Y];

                foreach (var pixel in _pixels)
                    result[pixel.Key.X + ScreenPositionShift.X, pixel.Key.Y + ScreenPositionShift.Y] = pixel.Value;

                return result;
            }
        }

        public void AddOrReplace(char symbol, in Vector2Int position) => _pixels[position - ScreenPositionShift] = symbol;

        private Dictionary<Vector2Int, char> Convert(char[,] pixels)
        {
            Dictionary<Vector2Int, char> result = new Dictionary<Vector2Int, char>(pixels.Length);

            for (int x = 0; x < pixels.GetLength(0); x++)
            {
                for (int y = 0; y < pixels.GetLength(1); y++)
                    result.Add(new Vector2Int(x, y), pixels[x, y]);
            }

            return result;
        }
    }
}
