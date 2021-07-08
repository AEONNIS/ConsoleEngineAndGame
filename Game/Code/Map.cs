using Engine.Maths;
using System.Collections.Generic;

namespace Game
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
}
