using ConsoleEngine.DisplaySystem;
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
            List<int> list = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
            }

            Display(list.Where(num => num % 2 == 0));
            Display(list.Where(num => num % 2 == 0).ToList());

            while (true)
            {

            }
        }

        private static void Display(IEnumerable<int> enumerable)
        {
            Console.WriteLine("IEnumerable:");

            foreach (var num in enumerable)
                Console.WriteLine(num);
        }

        private static void Display(List<int> list)
        {
            Console.WriteLine("List:");

            foreach (var num in list)
                Console.WriteLine(num);
        }
    }
}
