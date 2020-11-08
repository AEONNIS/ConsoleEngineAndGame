using ConsoleEngine.Core.DisplaySystem;
using ConsoleEngine.Maths;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var a = new Texture(new Dictionary<Vector2Int, Pixel>()
            {
                { new Vector2Int(0,1),Pixel.Blue },
                { new Vector2Int(1,0),Pixel.Green },
                { new Vector2Int(2,0),Pixel.Cyan },
            }, Vector2Int.Zero);
            var b = new Texture(new Dictionary<Vector2Int, Pixel>()
            {
                { new Vector2Int(0,1),Pixel.White },
                { new Vector2Int(1,2),Pixel.Red },
                { new Vector2Int(2,2),Pixel.Yellow },
            }, Vector2Int.Down);

            var c = a + b;
            Console.Write(c);
            Screen.Get().Display(c);

            while (true)
            {

            }
        }
    }
}
