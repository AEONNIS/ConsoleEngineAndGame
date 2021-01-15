using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
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
            Data.Messages.Initial.Write();
        }

        private void DisplayHintsToConfirmInputAndDeleteChar()
        {
            Data.Messages.Key("Enter").Write();
            Data.Messages.InputConfirmation.Write(before: " - ", after: " ");

            Data.Messages.Key("Backspace").Write();
            Data.Messages.DeleteChar.Write(before: " - ", after: "\n\n");
        }

        private void DisplayControlHelp(int panelsNumber)
        {
            Data.Messages.PanelsNumber(panelsNumber).Write(after: "\n\n");

            for (int i = 0; i < panelsNumber; i++)
            {
                foreach (var message in Data.Messages.KeyInfo(PanelsData.KeysFor.DisplayActions[i]))
                    message.Write();

                Data.Messages.DisplayPanel(i).Write(after: "\n");
            }

            Data.Messages.Empty.Write(after: "\n");

            for (int i = 0; i < panelsNumber; i++)
            {
                foreach (var message in Data.Messages.KeyInfo(PanelsData.KeysFor.HideActions[i]))
                    message.Write();

                Data.Messages.HidePanel(i).Write(after: "\n");
            }

            Data.Messages.Key("F1").Write(before: "\n");
            Data.Messages.DisplayHelp.Write(before: " - ", after: "\n");

            Data.Messages.Key("Enter").Write();
            Data.Messages.StartTesting.Write(before: " - ", after: "\n");

            Data.Messages.Key("Escape").Write();
            Data.Messages.ProgramExit.Write(before: " - ", after: "\n");
        }
        #endregion

        #region PrivateMethods
        private int RequestPanelsNumber()
        {
            Console.CursorVisible = true;
            string input = Console.ReadLine();

            if (CheckNumberInput(input, Data.MinPanels, Data.MaxPanels, out int panelsNumber) is false)
            {
                Data.Messages.WrongInput.Write();
                var cursorPosition = Console.GetCursorPosition();

                do
                {
                    var length = input is not null ? input.Length : 2;
                    ClearLinePart(cursorPosition, length + 1);
                    input = Console.ReadLine();
                }
                while (CheckNumberInput(input, Data.MinPanels, Data.MaxPanels, out panelsNumber) is false);
            }

            Console.CursorVisible = false;

            return panelsNumber;
        }

        private bool CheckNumberInput(string input, int min, int max, out int result) => int.TryParse(input, out result) && min <= result && result <= max;

        private void ClearLinePart((int Left, int Top) startPosition, int length)
        {
            Console.SetCursorPosition(startPosition.Left, startPosition.Top);
            Data.Messages.Space(length).Write();
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
