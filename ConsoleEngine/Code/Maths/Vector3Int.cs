using System;
using System.Collections.Generic;

namespace ConsoleEngine.Maths
{
    public readonly struct Vector3Int : IEquatable<Vector3Int>
    {
        private static readonly Vector3Int _zero = new Vector3Int(0, 0, 0);
        private static readonly Vector3Int _one  = new Vector3Int(1, 1, 1);

        public Vector3Int(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static ref readonly Vector3Int Zero => ref _zero;
        public static ref readonly Vector3Int One  => ref _one;

        public int X { get; init; }
        public int Y { get; init; }
        public int Z { get; init; }

        public float Magnitude    => MathF.Sqrt(X * X + Y * Y + Z * Z);
        public int   SqrMagnitude => X * X + Y * Y + Z * Z;

        public static bool operator ==(in Vector3Int a, in Vector3Int b) =>  a.Equals(b);
        public static bool operator !=(in Vector3Int a, in Vector3Int b) => !a.Equals(b);

        public static bool operator >(in Vector3Int a, in Vector3Int b) => a.X > b.X &&
                                                                           a.Y > b.Y &&
                                                                           a.Z > b.Z;
        public static bool operator <(in Vector3Int a, in Vector3Int b) => a.X < b.X &&
                                                                           a.Y < b.Y &&
                                                                           a.Z < b.Z;

        public static bool operator >=(in Vector3Int a, in Vector3Int b) => a.X >= b.X &&
                                                                            a.Y >= b.Y &&
                                                                            a.Z >= b.Z;
        public static bool operator <=(in Vector3Int a, in Vector3Int b) => a.X <= b.X &&
                                                                            a.Y <= b.Y &&
                                                                            a.Z <= b.Z;

        public static Vector3Int operator +(in Vector3Int a, in Vector3Int b) => new Vector3Int(a.X + b.X,
                                                                                                a.Y + b.Y,
                                                                                                a.Z + b.Z);
        public static Vector3Int operator +(in Vector3Int v,    int        i) => new Vector3Int(v.X + i,
                                                                                                v.Y + i,
                                                                                                v.Z + i);
        public static Vector3Int operator +(   int        i, in Vector3Int v) => new Vector3Int(i + v.X,
                                                                                                i + v.Y,
                                                                                                i + v.Z);

        public static Vector3Int operator -(in Vector3Int a, in Vector3Int b) => new Vector3Int(a.X - b.X,
                                                                                                a.Y - b.Y,
                                                                                                a.Z - b.Z);
        public static Vector3Int operator -(in Vector3Int v,    int        i) => new Vector3Int(v.X - i,
                                                                                                v.Y - i,
                                                                                                v.Z - i);
        public static Vector3Int operator -(   int        i, in Vector3Int v) => new Vector3Int(i - v.X,
                                                                                                i - v.Y,
                                                                                                i - v.Z);
        public static Vector3Int operator -(in Vector3Int v)                  => new Vector3Int(-v.X,
                                                                                                -v.Y,
                                                                                                -v.Z);

        public static Vector3Int operator ++(in Vector3Int v) => new Vector3Int(v.X + 1,
                                                                                v.Y + 1,
                                                                                v.Z + 1);
        public static Vector3Int operator --(in Vector3Int v) => new Vector3Int(v.X - 1,
                                                                                v.Y - 1,
                                                                                v.Z - 1);

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

        public override bool Equals(object     obj)   => obj is Vector3Int vector && Equals(vector);
        public          bool Equals(Vector3Int other) =>
            X == other.X &&
            Y == other.Y &&
            Z == other.Z;

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public override string ToString() => $"({X}, {Y}, {Z})";
    }
}
