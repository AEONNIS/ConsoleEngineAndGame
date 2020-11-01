using ConsoleEngine.Maths;

namespace ConsoleEngine.Display
{
    public interface IDisplayable
    {
        public void Display(int x, int y);
        public void Display(Vector2Int position);
    }
}
