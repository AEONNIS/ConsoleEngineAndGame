using System;
using System.Diagnostics;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test test = new Test();
            test.Start();

            Console.ReadKey();
        }

        private static void Turn()
        {
            while (true)
            {
            }
        }
    }

    public class Test
    {
        private const int _windowsWidth = 60;
        private const int _defaultInit = 100;

        private long _totalTime = 0;
        private long _totalTimeByIn = 0;

        public Test()
        {
            Console.SetWindowSize(_windowsWidth, Console.LargestWindowHeight);
            Console.BufferWidth = Console.WindowWidth;
        }

        public void Start()
        {
            Reset();

            int coordinates = Init("Coordinates: ");
            int points = Init("Points: ");
            int steps = Init("Steps: ");
            int turns = Init("Turns: ");

            StartTesting(turns, steps, points, coordinates);
            DisplayAverage(turns);
            Turn();
        }

        private void Turn()
        {
            while (true)
            {
                Repeat();
            }
        }

        private int Init(string message)
        {
            int result = _defaultInit; ;
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int res))
                result = res;

            Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
            Console.WriteLine(result);
            return result;
        }

        private void Reset()
        {
            GC.Collect();
            Console.ResetColor();
            Console.Clear();

            _totalTime = 0;
            _totalTimeByIn = 0;
        }

        private void Repeat()
        {
            GC.Collect();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nRepeat? y = yes, another = exit;");

            if (Console.ReadKey().Key == ConsoleKey.Y)
                Start();
            else
                Environment.Exit(0);
        }

        private void DisplayAverage(int turns)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nAverage {nameof(Testing)} Time: {_totalTime / turns}");
            Console.WriteLine($"Average {nameof(TestingByIn)} Time: {_totalTimeByIn / turns}");
        }

        private void StartTesting(int turns, int steps, int points, int coordinates)
        {
            Console.WriteLine();

            for (int i = 0; i < turns; i++)
                TurnTest(steps, points, coordinates);
        }

        private void TurnTest(int steps, int points, int coordinates)
        {
            _totalTime += Testing(steps, points, coordinates);
            _totalTimeByIn += TestingByIn(steps, points, coordinates);
        }

        private long Testing(int steps, int points, int coordinates)
        {
            Testing testing = new Testing(steps, points, coordinates);
            return testing.Start();
        }

        private long TestingByIn(int steps, int points, int coordinates)
        {
            TestingByIn testingByIn = new TestingByIn(steps, points, coordinates);
            return testingByIn.Start();
        }
    }

    public class Testing
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly int _steps;
        private readonly Point[] _points;

        public Testing(int steps, int points, int coordinates)
        {
            _steps = steps;
            _points = new Point[points];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = new Point(coordinates);
        }

        public long Start()
        {
            _timer.Start();

            for (int i = 0; i < _steps; i++)
                Step(_points[Select()]);

            _timer.Stop();
            DisplayResult();

            return _timer.ElapsedTicks;
        }

        private void Step(Point point) => point.Test();

        private int Select() => _random.Next(0, _points.Length);

        private void DisplayResult()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{nameof(Testing)} Time: {_timer.ElapsedTicks}");
        }
    }

    public class TestingByIn
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly int _steps;
        private readonly Point[] _points;

        public TestingByIn(int steps, int points, int coordinates)
        {
            _steps = steps;
            _points = new Point[points];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = new Point(coordinates);
        }

        public long Start()
        {
            _timer.Restart();

            for (int i = 0; i < _steps; i++)
                Step(in _points[Select()]);

            _timer.Stop();
            DisplayResult();

            return _timer.ElapsedTicks;
        }

        private void Step(in Point point) => point.Test();

        private int Select() => _random.Next(0, _points.Length);

        private void DisplayResult()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameof(TestingByIn)} Time: {_timer.ElapsedTicks}");
        }
    }

    public readonly struct Point
    {
        private readonly double[] _coordinates;

        public Point(int coordinates) => _coordinates = new double[coordinates];

        public readonly void Test() { }
    }
}

