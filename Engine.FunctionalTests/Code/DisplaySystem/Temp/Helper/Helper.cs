using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class Helper
    {
        #region Methods
        public void Run()
        {
            DisplayInitialMessages();
            var panelsNumber = RequestPanelsNumber();
            new PanelsCreator().CreateRandomPanels(panelsNumber);
            ClearConsole();

            DisplayControlHelp(panelsNumber);
        }
        #endregion

        #region DisplayMessages
        private void DisplayInitialMessages()
        {
            DisplayHintsToConfirmInputAndDeleteChar();
            HelperData.Messages.Initial.Write();
        }

        private void DisplayHintsToConfirmInputAndDeleteChar()
        {
            HelperData.Messages.Key("Enter").Write();
            HelperData.Messages.InputConfirmation.Write(before: " - ", after: " ");

            HelperData.Messages.Key("Backspace").Write();
            HelperData.Messages.DeleteChar.WriteLine(before: " - ", after: "\n");
        }

        private void DisplayControlHelp(int panelsNumber)
        {

        }
        #endregion

        #region PrivateMethods
        private int RequestPanelsNumber()
        {
            Console.CursorVisible = true;
            string input = Console.ReadLine();

            if (CheckNumberInput(input, HelperData.MinPanels, HelperData.MaxPanels, out int panelsNumber) is false)
            {
                HelperData.Messages.WrongInput.Write();
                var cursorPosition = Console.GetCursorPosition();

                do
                {
                    var length = input is not null ? input.Length : 2;
                    ClearLinePart(cursorPosition, length + 1);
                    input = Console.ReadLine();
                }
                while (CheckNumberInput(input, HelperData.MinPanels, HelperData.MaxPanels, out panelsNumber) is false);
            }

            Console.CursorVisible = false;

            return panelsNumber;
        }

        private bool CheckNumberInput(string input, int min, int max, out int result) => int.TryParse(input, out result) && min <= result && result <= max;

        private void ClearLinePart((int Left, int Top) startPosition, int length)
        {
            Console.SetCursorPosition(startPosition.Left, startPosition.Top);
            HelperData.Messages.Empty(length).Write();
            Console.SetCursorPosition(startPosition.Left, startPosition.Top);
        }

        private void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }
        #endregion
    }
}
