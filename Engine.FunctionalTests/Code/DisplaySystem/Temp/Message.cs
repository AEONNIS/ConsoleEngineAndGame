using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public readonly struct Message
    {
        #region Properties
        public readonly Coloring Coloring { get; init; }
        public readonly string Text { get; init; }
        #endregion

        #region PublicMethods
        public readonly void Write(string before = default, string after = default)
        {
            Coloring.SetColors();
            Console.Write($"{before}{Text}{after}");
        }

        public readonly void WriteLine(string before = default, string after = default)
        {
            Coloring.SetColors();
            Console.WriteLine($"{before}{Text}{after}");
        }
        #endregion
    }
}
