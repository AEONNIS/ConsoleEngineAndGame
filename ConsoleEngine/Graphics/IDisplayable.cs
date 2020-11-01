using ConsoleEngine.Maths;

namespace ConsoleEngine.Graphics
{
    public interface IDisplayable
    {
        public void Display(int x, int y);
        public void Display(Vector2Int position);
    }
}
