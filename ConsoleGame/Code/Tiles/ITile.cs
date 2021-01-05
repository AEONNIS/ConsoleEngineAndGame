using ConsoleEngine.DisplaySystem;
using System;

namespace ConsoleGame
{
    public interface ITile
    {
        #region Properties
        public Pixel Presenter { get; init; }
        public bool IsPassable { get; init; }
        #endregion

        #region Methods
        public void Display()
        {
            if (Presenter.BackgroundColor.HasValue)
                Console.BackgroundColor = Presenter.BackgroundColor.Value;
            if (Presenter.Foreground.Color.HasValue)
                Console.ForegroundColor = Presenter.Foreground.Color.Value;

            Console.Write(Presenter.Foreground.Symbol);
        }
        #endregion
    }
}
