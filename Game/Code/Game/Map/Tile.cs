using System;

namespace GameName.Game.Map
{
    public readonly struct Tile : IEquatable<Tile>
    {
        public char   Symbol            { get; init; }
        public string Name              { get; init; }
        public bool   Passability       { get; init; }
        public bool   LightTransmission { get; init; }

        public static bool operator ==(Tile left, Tile right) =>  left.Equals(right);
        public static bool operator !=(Tile left, Tile right) => !left.Equals(right);

        public override bool Equals(object obj)   => obj is Tile tile && Equals(tile);
        public          bool Equals(Tile   other) =>
            Symbol == other.Symbol &&
            Name   == other.Name;

        public override int GetHashCode() => HashCode.Combine(Symbol, Name);

        public override string ToString() =>
            $"{Symbol} {Name}, {nameof(Passability)}: {Passability}, {nameof(LightTransmission)}: {LightTransmission}";
    }
}
