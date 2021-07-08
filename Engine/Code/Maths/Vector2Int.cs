// Когда значительная часть проекта будет реализована, удалить то, что не используется.

using System;

namespace Engine.Maths
{
    public readonly struct Vector2Int : IEquatable<Vector2Int>
    {
        #region StaticFields
        private static readonly Vector2Int _zero = new Vector2Int(0, 0);
        private static readonly Vector2Int _one = new Vector2Int(1, 1);
        private static readonly Vector2Int _up = new Vector2Int(0, 1);
        private static readonly Vector2Int _down = new Vector2Int(0, -1);
        private static readonly Vector2Int _right = new Vector2Int(1, 0);
        private static readonly Vector2Int _left = new Vector2Int(-1, 0);
        #endregion

        #region Constructors
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region StaticProperties
        public static ref readonly Vector2Int Zero => ref _zero;
        public static ref readonly Vector2Int One => ref _one;
        public static ref readonly Vector2Int Up => ref _up;
        public static ref readonly Vector2Int Down => ref _down;
        public static ref readonly Vector2Int Right => ref _right;
        public static ref readonly Vector2Int Left => ref _left;
        #endregion

        #region Properties
        public readonly int X { get; init; }
        public readonly int Y { get; init; }

        public readonly float Magnitude => MathF.Sqrt(X * X + Y * Y);
        public readonly int SqrMagnitude => X * X + Y * Y;
        #endregion

        #region Operators
        public static bool operator ==(in Vector2Int a, in Vector2Int b) => a.Equals(b);
        public static bool operator !=(in Vector2Int a, in Vector2Int b) => a.Equals(b) == false;

        public static bool operator >(in Vector2Int a, in Vector2Int b) => a.X > b.X && a.Y > b.Y;
        public static bool operator <(in Vector2Int a, in Vector2Int b) => a.X < b.X && a.Y < b.Y;

        public static bool operator >=(in Vector2Int a, in Vector2Int b) => a.X >= b.X && a.Y >= b.Y;
        public static bool operator <=(in Vector2Int a, in Vector2Int b) => a.X <= b.X && a.Y <= b.Y;

        public static Vector2Int operator +(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator +(in Vector2Int v, int i) => new Vector2Int(v.X + i, v.Y + i);
        public static Vector2Int operator +(int i, in Vector2Int v) => new Vector2Int(i + v.X, i + v.Y);

        public static Vector2Int operator -(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator -(in Vector2Int v, int i) => new Vector2Int(v.X - i, v.Y - i);
        public static Vector2Int operator -(int i, in Vector2Int v) => new Vector2Int(i - v.X, i - v.Y);
        public static Vector2Int operator -(in Vector2Int v) => new Vector2Int(-v.X, -v.Y);

        public static Vector2Int operator ++(in Vector2Int v) => new Vector2Int(v.X + 1, v.Y + 1);
        public static Vector2Int operator --(in Vector2Int v) => new Vector2Int(v.X - 1, v.Y - 1);

        public static Vector2Int operator *(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X * b.X, a.Y * b.Y);
        public static Vector2Int operator *(in Vector2Int v, int i) => new Vector2Int(v.X * i, v.Y * i);
        public static Vector2Int operator *(int i, in Vector2Int v) => new Vector2Int(i * v.X, i * v.Y);
        public static Vector2Int operator *(in Vector2Int a, float f) => new Vector2Int((int)(a.X * f), (int)(a.Y * f));
        public static Vector2Int operator *(float f, in Vector2Int a) => new Vector2Int((int)(f * a.X), (int)(f * a.Y));
        #endregion

        #region Methods
        public readonly void SetCursorPosition() => Console.SetCursorPosition(X, Y);

        public readonly Vector2Int AddToX(int deltaX) => new Vector2Int(X + deltaX, Y);
        public readonly Vector2Int AddToY(int deltaY) => new Vector2Int(X, Y + deltaY);

        public readonly float Distance(in Vector2Int v) => (this - v).Magnitude;
        public readonly int SqrDistance(in Vector2Int v) => (this - v).SqrMagnitude;

        public readonly override bool Equals(object obj) => obj is Vector2Int vector && Equals(vector);
        public readonly bool Equals(Vector2Int other) => X == other.X && Y == other.Y;

        public readonly override int GetHashCode() => HashCode.Combine(X, Y);

        public readonly override string ToString() => $"({X}, {Y})";
        #endregion
    }
}
