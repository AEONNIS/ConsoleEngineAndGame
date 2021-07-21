// Когда значительная часть проекта будет реализована, удалить то, что не используется.

using System;
using System.Collections.Generic;

namespace Engine.Maths
{
    public readonly struct Vector2Int : IEquatable<Vector2Int>
    {
        private static readonly Vector2Int _zero  = new Vector2Int( 0,  0);
        private static readonly Vector2Int _one   = new Vector2Int( 1,  1);
        private static readonly Vector2Int _up    = new Vector2Int( 0,  1);
        private static readonly Vector2Int _down  = new Vector2Int( 0, -1);
        private static readonly Vector2Int _right = new Vector2Int( 1,  0);
        private static readonly Vector2Int _left  = new Vector2Int(-1,  0);

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static ref readonly Vector2Int Zero  => ref _zero;
        public static ref readonly Vector2Int One   => ref _one;
        public static ref readonly Vector2Int Up    => ref _up;
        public static ref readonly Vector2Int Down  => ref _down;
        public static ref readonly Vector2Int Right => ref _right;
        public static ref readonly Vector2Int Left  => ref _left;

        public int X { get; init; }
        public int Y { get; init; }

        public float Magnitude    => MathF.Sqrt(X * X + Y * Y);
        public int   SqrMagnitude => X * X + Y * Y;

        public static bool operator ==(in Vector2Int a, in Vector2Int b) =>  a.Equals(b);
        public static bool operator !=(in Vector2Int a, in Vector2Int b) => !a.Equals(b);

        public static bool operator >(in Vector2Int a, in Vector2Int b) => a.X > b.X && a.Y > b.Y;
        public static bool operator <(in Vector2Int a, in Vector2Int b) => a.X < b.X && a.Y < b.Y;

        public static bool operator >=(in Vector2Int a, in Vector2Int b) => a.X >= b.X && a.Y >= b.Y;
        public static bool operator <=(in Vector2Int a, in Vector2Int b) => a.X <= b.X && a.Y <= b.Y;

        public static Vector2Int operator +(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator +(in Vector2Int v,    int        i) => new Vector2Int(v.X + i,   v.Y + i);
        public static Vector2Int operator +(   int        i, in Vector2Int v) => new Vector2Int(i   + v.X, i   + v.Y);

        public static Vector2Int operator -(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator -(in Vector2Int v,    int        i) => new Vector2Int(v.X - i,   v.Y - i);
        public static Vector2Int operator -(   int        i, in Vector2Int v) => new Vector2Int(i   - v.X, i   - v.Y);
        public static Vector2Int operator -(in Vector2Int v)                  => new Vector2Int(-v.X,      -v.Y);

        public static Vector2Int operator ++(in Vector2Int v) => new Vector2Int(v.X + 1, v.Y + 1);
        public static Vector2Int operator --(in Vector2Int v) => new Vector2Int(v.X - 1, v.Y - 1);

        public static Vector2Int operator *(in Vector2Int a, in Vector2Int b) => new Vector2Int(a.X * b.X, a.Y * b.Y);
        public static Vector2Int operator *(in Vector2Int v,    int        i) => new Vector2Int(v.X * i,   v.Y * i);
        public static Vector2Int operator *(   int        i, in Vector2Int v) => new Vector2Int(i   * v.X, i   * v.Y);
        public static Vector2Int operator *(in Vector2Int a,    float      f) => new Vector2Int((int)(a.X * f),   (int)(a.Y * f));
        public static Vector2Int operator *(   float      f, in Vector2Int a) => new Vector2Int((int)(f   * a.X), (int)(f   * a.Y));

        public static int MinX(Vector2Int a, Vector2Int b) => a.X <= b.X ? a.X : b.X;
        public static int MaxX(Vector2Int a, Vector2Int b) => a.X >= b.X ? a.X : b.X;

        public static int MinY(Vector2Int a, Vector2Int b) => a.Y <= b.Y ? a.Y : b.Y;
        public static int MaxY(Vector2Int a, Vector2Int b) => a.Y >= b.Y ? a.Y : b.Y;

        public static Vector2Int GetMin(Vector2Int a, Vector2Int b) => new Vector2Int(MinX(a, b), MinY(a, b));
        public static Vector2Int GetMax(Vector2Int a, Vector2Int b) => new Vector2Int(MaxX(a, b), MaxY(a, b));

        public static int MinX(IEnumerable<Vector2Int> vectors)
        {
            int minX = int.MaxValue;

            foreach (var vector in vectors)
            {
                if (minX > vector.X)
                    minX = vector.X;
            }

            return minX;
        }
        public static int MaxX(IEnumerable<Vector2Int> vectors)
        {
            int maxX = int.MinValue;

            foreach (var vector in vectors)
            {
                if (maxX < vector.X)
                    maxX = vector.X;
            }

            return maxX;
        }

        public static int MinY(IEnumerable<Vector2Int> vectors)
        {
            int minY = int.MaxValue;

            foreach (var vector in vectors)
            {
                if (minY > vector.Y)
                    minY = vector.Y;
            }

            return minY;
        }
        public static int MaxY(IEnumerable<Vector2Int> vectors)
        {
            int maxY = int.MinValue;

            foreach (var vector in vectors)
            {
                if (maxY < vector.Y)
                    maxY = vector.Y;
            }

            return maxY;
        }

        public static Vector2Int GetMin(IEnumerable<Vector2Int> vectors) => new Vector2Int(MinX(vectors), MinY(vectors));
        public static Vector2Int GetMax(IEnumerable<Vector2Int> vectors) => new Vector2Int(MaxX(vectors), MaxY(vectors));

        public void SetCursorPosition() => Console.SetCursorPosition(X, Y);

        public Vector2Int AddToX(int deltaX) => new Vector2Int(X + deltaX, Y);
        public Vector2Int AddToY(int deltaY) => new Vector2Int(X,          Y + deltaY);

        public float Distance   (in Vector2Int v) => (this - v).Magnitude;
        public int   SqrDistance(in Vector2Int v) => (this - v).SqrMagnitude;

        public override bool Equals(object     obj)   => obj is Vector2Int vector && Equals(vector);
        public          bool Equals(Vector2Int other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"({X}, {Y})";
    }
}
