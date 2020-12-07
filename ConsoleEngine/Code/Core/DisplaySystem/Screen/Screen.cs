using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.Core.DisplaySystem
{
    public class Screen
    {
        #region StaticFields
        private static readonly Screen _screen = new Screen();
        #endregion

        #region Fields
        private readonly ScreenBuffer _fullBuffer = new ScreenBuffer();
        private readonly Texture _activeBuffer = new Texture();
        #endregion

        #region Constructors
        private Screen()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Rectangle.Size.X, Rectangle.Size.Y);
            Console.SetBufferSize(Rectangle.Size.X, Rectangle.Size.Y);
        }
        #endregion

        #region Properties
        public Rectangle Rectangle { get; private init; } = new Rectangle(Vector2Int.Zero, new Vector2Int(Console.LargestWindowWidth, Console.LargestWindowHeight));
        #endregion

        #region StaticMethods
        public static Screen Get() => _screen;

        public static string GetDisplayTitle() => Console.Title;
        public static void SetDisplayTitle(string title) => Console.Title = title;
        #endregion
    }
}
