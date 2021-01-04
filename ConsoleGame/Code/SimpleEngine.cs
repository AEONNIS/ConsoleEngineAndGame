using System;

namespace ConsoleGame
{
    public class SimpleEngine
    {
        #region Fields
        private readonly SimpleScreen _screen = new SimpleScreen();
        #endregion

        #region PublicMethods
        public void Start()
        {
            Tileset.Wall.Intact.Display();
            Tileset.Door.ClosedHorizontal.Display();
            Tileset.Wall.Intact.Display();
            Console.WriteLine();
            Tileset.Door.ClosedVertical.Display();

            Console.ReadKey();

            //Turn();
        }
        #endregion

        #region PrivateMethods
        private void Turn()
        {
            while (true)
            {

            }
        }
        #endregion
    }
}
