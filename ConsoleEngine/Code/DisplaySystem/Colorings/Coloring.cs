using System;

namespace ConsoleEngine.DisplaySystem
{
    public readonly struct Coloring : IEquatable<Coloring>
    {
        #region Properties
        public readonly ConsoleColor BgColor { get; init; }
        public readonly ConsoleColor FgColor { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(in Coloring a, in Coloring b) => a.Equals(b);
        public static bool operator !=(in Coloring a, in Coloring b) => a.Equals(b) == false;
        #endregion

        #region PublicMethods
        public readonly void SetInConsole()
        {
            Console.BackgroundColor = BgColor;
            Console.ForegroundColor = FgColor;
        }

        public readonly override bool Equals(object obj) => obj is Coloring coloring && Equals(coloring);
        public readonly bool Equals(Coloring other) => BgColor == other.BgColor && FgColor == other.FgColor;

        public readonly override int GetHashCode() => HashCode.Combine(BgColor, FgColor);

        public readonly override string ToString() => $"{FgColor} on {BgColor}";
        #endregion
    }
}
