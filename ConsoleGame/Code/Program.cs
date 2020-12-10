using ConsoleEngine.Maths;
using System;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                Vector2Int v = new Vector2Int(rnd.Next(0, 3), rnd.Next(0, 3));
                Console.WriteLine($"{v}, {v.GetHashCode()}");
            }

            while (true)
            {

            }
        }
    }
}
