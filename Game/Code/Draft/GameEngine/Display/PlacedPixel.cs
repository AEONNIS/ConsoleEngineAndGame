using System;

using Engine.Maths;

namespace Draft.GameEngine.DisplaySystem
{
    public readonly struct PlacedPixel : IEquatable<PlacedPixel>
    {
        public char       Symbol   { get; init; }
        public Vector2Int Position { get; init; }

        public static bool operator ==(PlacedPixel left, PlacedPixel right) =>  left.Equals(right);

        public static bool operator !=(PlacedPixel left, PlacedPixel right) => !left.Equals(right);

        public override bool Equals(object       obj)   => obj is PlacedPixel pixel && Equals(pixel);
        public          bool Equals(PlacedPixel  other) =>
            Symbol   == other.Symbol &&
            Position == other.Position;

        public override int GetHashCode() => HashCode.Combine(Symbol, Position);
    }
}
