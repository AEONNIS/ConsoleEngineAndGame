using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public static class Display // => Singleton
    {
        public static string Title
        {
            get => Console.Title;
            set => Console.Title = value;
        }

        public static void Init(string title)
        {
            Screen.Init();
            Title = title;
        }
    }
}
