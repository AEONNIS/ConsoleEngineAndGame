using ConsoleEngine.Maths;

namespace GameName.GameEngine.DisplaySystem
{
    public class ScreenBuffer
    {
        private readonly Texture _texture = null;

        public ScreenBuffer(int width, int height) => _texture = new Texture(new char[width, height], Vector2Int.Zero);
    }
}
