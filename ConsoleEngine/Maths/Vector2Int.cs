namespace ConsoleEngine.Maths
{
    public struct Vector2Int
    {
        public Vector2Int(int xy)
                   : this(xy, xy)
        { }
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Right => new Vector2Int(1, 0);
        public static Vector2Int Left => new Vector2Int(-1, 0);

        public int X { get; set; }
        public int Y { get; set; }

        #region Operators
        public static bool operator ==(Vector2Int a, Vector2Int b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2Int a, Vector2Int b) => a.X != b.X || a.Y != b.Y;

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator +(Vector2Int a, int i) => new Vector2Int(a.X + i, a.Y + i);
        public static Vector2Int operator +(int i, Vector2Int a) => new Vector2Int(i + a.X, i + a.Y);

        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator -(Vector2Int a, int i) => new Vector2Int(a.X - i, a.Y - i);
        public static Vector2Int operator -(int i, Vector2Int a) => new Vector2Int(i - a.X, i - a.Y);
        public static Vector2Int operator -(Vector2Int a) => new Vector2Int(-a.X, -a.Y);

        public static Vector2Int operator ++(Vector2Int a)
        {
            a.X++;
            a.Y++;
            return a;
        }
        public static Vector2Int operator --(Vector2Int a)
        {
            a.X--;
            a.Y--;
            return a;
        }

        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.X * b.X, a.Y * b.Y);
        public static Vector2Int operator *(Vector2Int a, int i) => new Vector2Int(a.X * i, a.Y * i);
        public static Vector2Int operator *(int i, Vector2Int a) => new Vector2Int(i * a.X, i * a.Y);
        #endregion

        public override string ToString() => $"({X}, {Y})";
    }
}
