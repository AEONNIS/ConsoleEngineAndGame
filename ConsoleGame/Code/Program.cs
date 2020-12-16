using ConsoleEngine.DisplaySystem;
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
            Screen.SetDisplayTitle("Console Game");
            Console.WriteLine(Screen.GetDisplayTitle());
            Screen screen = Screen.Get();

            while (true)
            {

            }
        }
    }
}
