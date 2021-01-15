using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public readonly struct Coloring
    {
        #region Properties
        public readonly ConsoleColor BgColor { get; init; }
        public readonly ConsoleColor FgColor { get; init; }
        #endregion

        #region PublicMethods
        public readonly void ApplyColors()
        {
            Console.BackgroundColor = BgColor;
            Console.ForegroundColor = FgColor;
        }
        #endregion
    }
}
