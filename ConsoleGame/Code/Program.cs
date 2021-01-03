using ConsoleEngine.Maths;
using System;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Room room = new Room(Vector2Int.Zero);
            room.Display();

            Console.ReadKey();
        }

        private static void Turn()
        {
            while (true)
            {
            }
        }
    }

    public class Room
    {
        #region Consts
        private const int _minSideSize = 8;
        private const int _maxSideSize = 8;

        private const int _minDoors = 3;
        private const int _maxDoors = 3;

        private const char _wall = '\u2588';
        private const char _door = '\u2592';
        #endregion

        #region Fields
        private readonly Vector2Int _topLeftPoint;
        private readonly Vector2Int _size;
        private readonly Vector2Int[] _doors;
        #endregion

        #region Constructors
        public Room(Vector2Int topLeftPoint)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            _topLeftPoint = topLeftPoint;
            _size = new Vector2Int(GetRandomSideSize(random), GetRandomSideSize(random));
            _doors = new Vector2Int[random.Next(_minDoors, _maxDoors + 1)];
            WorldSide[] doorSides = new WorldSide[_doors.Length];

            for (int i = 0; i < _doors.Length; i++)
            {
                doorSides[i] = GetDoorSide(random, doorSides);
                _doors[i] = GetRandomDoor(random, doorSides[i]);
            }
        }
        #endregion

        #region PublicMethods
        public void Display()
        {
            Console.SetCursorPosition(_topLeftPoint.X, _topLeftPoint.Y);
            Console.Write(new string(_wall, _size.X));

            Console.SetCursorPosition(_topLeftPoint.X, _topLeftPoint.Y + _size.Y);
            Console.Write(new string(_wall, _size.X));

            for (int i = 1; i < _size.Y; i++)
            {
                Console.SetCursorPosition(_topLeftPoint.X, _topLeftPoint.Y + i);
                Console.Write(_wall);

                Console.SetCursorPosition(_topLeftPoint.X + _size.X - 1, _topLeftPoint.Y + i);
                Console.Write(_wall);
            }

            foreach (var door in _doors)
            {
                Console.SetCursorPosition(_topLeftPoint.X + door.X, _topLeftPoint.Y + door.Y);
                Console.Write(_door);
            }
        }
        #endregion

        #region PrivateMethods
        private int GetRandomSideSize(Random random) => random.Next(_minSideSize, _maxSideSize + 1);

        private WorldSide GetDoorSide(Random random, WorldSide[] doorSides)
        {
            WorldSide result = GetRandomWorldSide(random);

            while (CheckDoorSide(doorSides, result) == false)
                result = GetRandomWorldSide(random);

            return result;
        }

        private WorldSide GetRandomWorldSide(Random random) => (WorldSide)random.Next((int)WorldSide.Top, (int)WorldSide.Right + 1);

        private bool CheckDoorSide(WorldSide[] doorSides, WorldSide doorSide)
        {
            foreach (var side in doorSides)
            {
                if (doorSide == side)
                    return false;
            }

            return true;
        }

        private Vector2Int GetRandomDoor(Random random, WorldSide side)
        {
            if (side == WorldSide.Top)
                return new Vector2Int(random.Next(1, _size.X), 0);
            else if (side == WorldSide.Down)
                return new Vector2Int(random.Next(1, _size.X), _size.Y);
            else if (side == WorldSide.Left)
                return new Vector2Int(0, random.Next(1, _size.Y));
            else
                return new Vector2Int(_size.X, random.Next(1, _size.Y));
        }
        #endregion
    }

    public class Door
    {

    }

    public enum WorldSide { None = -1, Top, Down, Left, Right }
}
