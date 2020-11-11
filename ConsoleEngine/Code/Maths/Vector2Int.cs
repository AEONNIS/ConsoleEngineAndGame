namespace ConsoleEngine.Maths
{
    public struct Vector2Int
    {
        #region Constructors
        public Vector2Int(int xy)
                   : this(xy, xy)
        { }
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region StaticProperties
        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Right => new Vector2Int(1, 0);
        public static Vector2Int Left => new Vector2Int(-1, 0);
        #endregion

        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Operators
        public static bool operator ==(Vector2Int a, Vector2Int b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2Int a, Vector2Int b) => a.X != b.X || a.Y != b.Y;

        public static bool operator >(Vector2Int a, Vector2Int b) => a.X > b.X && a.Y > b.Y;
        public static bool operator <(Vector2Int a, Vector2Int b) => a.X < b.X && a.Y < b.Y;

        public static bool operator >=(Vector2Int a, Vector2Int b) => a.X >= b.X && a.Y >= b.Y;
        public static bool operator <=(Vector2Int a, Vector2Int b) => a.X <= b.X && a.Y <= b.Y;

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

        #region Methods
        public Vector2Int AddX(int deltaX) => new Vector2Int(X + deltaX, Y);
        public Vector2Int AddY(int deltaY) => new Vector2Int(X, Y + deltaY);

        public override string ToString() => $"({X}, {Y})";
        #endregion
    }
}
