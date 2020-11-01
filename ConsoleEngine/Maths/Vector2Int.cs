using System;

namespace ConsoleEngine.Maths
{
    public struct Vector2Int
    {
        public static Vector2Int Zero => new Vector2Int(0, 0);

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public void SetCursorPosition() => Console.SetCursorPosition(X, Y);
    }
}
