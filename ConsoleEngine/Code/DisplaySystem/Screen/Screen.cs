using ConsoleEngine.Maths;
using System;

namespace ConsoleEngine.DisplaySystem
{
    public class Screen
    {
        #region StaticFields
        private static readonly Screen _screen = new Screen();
        #endregion

        #region Fields
        private readonly ScreenBuffer _fullBuffer = new ScreenBuffer();
        private readonly Texture _activeBuffer = new Texture();
        private readonly Rectangle _rectangle = new Rectangle(Vector2Int.Zero, new Vector2Int(Console.LargestWindowWidth, Console.LargestWindowHeight));
        #endregion

        #region Constructors
        private Screen()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(_rectangle.Size.X, _rectangle.Size.Y);
            Console.SetBufferSize(_rectangle.Size.X, _rectangle.Size.Y);
        }
        #endregion

        #region StaticMethods
        public static Screen Get() => _screen;

        public static string GetDisplayTitle() => Console.Title;
        public static void SetDisplayTitle(string title) => Console.Title = title;
        #endregion

        #region Methods
        public void Display(IGraphicObject graphicObject)
        {
            if (_fullBuffer.Contains(graphicObject))
                _fullBuffer.RaiseToTop(graphicObject);
            else
                _fullBuffer.AddToTop(graphicObject);

            _activeBuffer.AddOrReplace(graphicObject.Texture);
        }

        public void Hide(IGraphicObject graphicObject)
        {

        }

        public void Remove(IGraphicObject graphicObject)
        {

        }

        public void Clear()
        {

        }
        #endregion
    }
}
