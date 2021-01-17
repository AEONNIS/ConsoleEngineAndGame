using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class ConsoleService
    {
        public static bool CheckNumberInString(string input, int min, int max, out int result) => int.TryParse(input, out result) && min <= result && result <= max;

        public static int RequestNumber(int min, int max, IMessage wrongInput, in Coloring defaultColoring)
        {
            Console.CursorVisible = true;
            string input = Console.ReadLine();

            if (CheckNumberInString(input, min, max, out int result) is false)
            {
                wrongInput.Write();
                var cursorPosition = Console.GetCursorPosition();

                do
                {
                    var length = input is not null ? input.Length : 1;
                    ClearLinePart(cursorPosition, defaultColoring, length + 1);
                    input = Console.ReadLine();
                }
                while (CheckNumberInString(input, min, max, out result) is false);
            }

            Console.CursorVisible = false;
            return result;
        }

        public static void ClearLinePart((int Left, int Top) position, in Coloring defaultColoring, int length)
        {
            Console.SetCursorPosition(position.Left, position.Top);
            MessageData.Space(defaultColoring, length).Write();
            Console.SetCursorPosition(position.Left, position.Top);
        }
        public static void Clear(in Coloring deafultColoring)
        {
            deafultColoring.SetInConsole();
            Console.Clear();
        }
    }
}
