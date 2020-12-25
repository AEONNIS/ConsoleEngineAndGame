using ConsoleEngine.DisplaySystem;
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
            LinkedList<int> numbers = new LinkedList<int>();

            for (int i = 10; i >= 0; i--)
                numbers.AddFirst(i);

            Console.WriteLine("All numbers ascending");
            Print(numbers);

            Console.WriteLine("\n\nAll numbers descending");
            Print(numbers.OrderByDescending(num => num));

            Console.WriteLine("\n\nNumbers above 5 ascending");
            Print(SelectNumbersAbove(numbers, 5));

            Console.WriteLine("\n\nNumbers above 5 descending");
            Print(SelectNumbersAbove(numbers, 5).OrderByDescending(num => num));

            Console.WriteLine("\n\nNumbers below 5 ascending");
            Print(SelectNumbersBelow(numbers, 5));

            Console.WriteLine("\n\nNumbers below 5 descending");
            Print(SelectNumbersBelow(numbers, 5).OrderByDescending(num => num));

            while (true)
            {

            }
        }

        public static IEnumerable<int> SelectNumbersAbove(LinkedList<int> numbers, int number) =>
                                            numbers.TakeWhile(num => num != number);

        public static IEnumerable<int> SelectNumbersBelow(LinkedList<int> numbers, int number) =>
                                            numbers.SkipWhile(num => num != number).Skip(1);

        public static void Print(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
                Console.Write($"{number} ");
        }
    }
}
