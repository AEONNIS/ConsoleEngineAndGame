using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class SimpleMessage : IMessage
    {
        #region Properties
        public Coloring Coloring { get; init; }
        public string Text { get; init; }
        #endregion

        #region Methods
        public void Write(string before = null, string after = null)
        {
            Coloring.ApplyColors();
            Console.Write($"{before}{Text}{after}");
        }
        #endregion
    }
}
