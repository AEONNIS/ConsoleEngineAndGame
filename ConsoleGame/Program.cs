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
            Screen.Get();
            var texture = new Texture();
            texture.AddOrReplace(1, 2, Pixel.Empty);
            texture.AddOrReplace(1, 2, Pixel.Black);
            Console.Write(texture);

            while (true)
            {

            }
        }
    }
}
