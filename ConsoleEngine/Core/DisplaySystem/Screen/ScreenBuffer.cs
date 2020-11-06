using ConsoleEngine.Maths;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenBuffer
    {
        //private readonly Texture _buffer;
        private Pixel[,] _buffer;

        public ScreenBuffer(int width, int height, Pixel fillingPixel)
        {
            _buffer = CreateBuffer(width, height, fillingPixel);
        }
        public ScreenBuffer(Vector2Int size, Pixel fillingPixel)
                     : this(size.X, size.Y, fillingPixel)
        { }

        public Pixel GetPixel(int x, int y) => _buffer[x, y];
        public Pixel GetPixel(Vector2Int position) => _buffer[position.X, position.Y];

        public void Set(Pixel pixel, int x, int y) => _buffer[x, y] = pixel;
        public void Set(Pixel pixel, Vector2Int position) => _buffer[position.X, position.Y] = pixel;

        public void Set(Texture texture)
        {
            foreach (var pixel in texture.Pixels)
                Set(pixel.Value, pixel.Key + texture.Shift);
        }

        public void Clear(Pixel fillingPixel) => Fill(ref _buffer, fillingPixel);

        private Pixel[,] CreateBuffer(int width, int height, Pixel fillingPixel)
        {
            Pixel[,] buffer = new Pixel[width, height];
            Fill(ref buffer, fillingPixel);
            return buffer;
        }

        private void Fill(ref Pixel[,] buffer, Pixel fillingPixel)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
                for (int y = 0; y < buffer.GetLength(1); y++)
                    buffer[x, y] = fillingPixel;
        }
    }
}
