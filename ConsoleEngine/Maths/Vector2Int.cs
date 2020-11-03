namespace ConsoleEngine.Maths
{
    public struct Vector2Int
    {
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public static bool operator ==(Vector2Int a, Vector2Int b) => a.X == b.X && a.Y == b.Y;

        public static bool operator !=(Vector2Int a, Vector2Int b) => a.X != b.X || a.Y != b.Y;
    }
}
