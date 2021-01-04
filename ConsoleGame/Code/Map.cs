using ConsoleEngine.DisplaySystem;
using ConsoleEngine.Maths;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Map
    {
        #region Fields
        private readonly List<Room> _rooms = new List<Room>();
        #endregion
    }

    public class Room
    {
        #region Fields
        private readonly Rectangle _transform;
        #endregion
    }

    public class Wall
    {

    }

    public class Door
    {

    }

    public class Floor
    {

    }

    public class Tile
    {
        #region Constructors
        public Tile(Pixel presenter, bool isPassable)
        {
            Presenter = presenter;
            IsPassable = isPassable;
        }
        #endregion

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
