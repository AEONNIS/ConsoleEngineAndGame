using ConsoleEngine.Core.DisplaySystem;
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
            Display.Init("Test");

            Pixel pixel00 = Screen.GetPixel(0, 0);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            pixel00.Display(0, 0);

            while (true)
            {

            }
        }
    }
}
