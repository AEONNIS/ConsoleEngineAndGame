using ConsoleEngine.Maths;
using System.Collections.Generic;

namespace ConsoleGame
{
    // Доменная модель, генерация комнат и представление модели должны быть четко отделены друг от друга.
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

    public readonly struct Wall
    {
        #region Properties
        public readonly Rectangle Rectangle { get; init; }
        public readonly IWallTile[] Tiles { get; init; }
        #endregion
    }
}
