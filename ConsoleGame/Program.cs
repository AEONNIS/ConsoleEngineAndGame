using ConsoleEngine.Core.DisplaySystem;
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
            PixelForeground pf1 = new PixelForeground(null, '-');
            PixelForeground pf2 = new PixelForeground(null, '-');
            Console.WriteLine(pf1 == pf2);

            while (true)
            {

            }
        }
    }
}
