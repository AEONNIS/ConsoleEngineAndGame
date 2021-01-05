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
