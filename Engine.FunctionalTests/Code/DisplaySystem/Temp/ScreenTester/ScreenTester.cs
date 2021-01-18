using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
    {
        #region Fields
        private int _panelsAmount;
        #endregion

        #region Properties
        public State State { get; private set; } = State.Initial;
        #endregion

        #region Methods
        public void Run()
        {
            DisplayRequestPanelsNumber();
            _panelsAmount = RequestPanelsNumber();
            new PanelsCreator().CreateRandomPanels(_panelsAmount);

            DisplayControlHelp(_panelsAmount);
            InputSystem.Get.KeyPressedInTesting += OnDisplayControlHelpKeyPressed;
            InputSystem.Get.KeyPressedInTesting += OnExitKeyPressed;

            InputSystem.Get.KeyPressedInHelp += OnStartTestingKeyPressed;
            InputSystem.Get.KeyPressedInHelp += OnExitKeyPressed;
            InputSystem.Get.Run(this);
        }
        #endregion

        #region DisplayMessages
        private void DisplayRequestPanelsNumber()
        {
            MessageData.ForPrompts.ConfirmInput.Write(after: "\n");
            MessageData.ForPrompts.DeleteChar.Write(after: "\n\n");
            MessageData.ForNotifications.PanelsWillBeCreated.Write(after: "\n");
            MessageData.ForRequests.PanelsNumber.Write();
        }

        private void DisplayControlHelp(int panelsAmount)
        {
            ConsoleService.Clear(ColoringData.Default);
            State = State.Help;

            MessageData.ForNotifications.Control.Write(after: "\n\n");
            MessageData.ForPrompts.DisplayHelp.Write(after: "\n");
            MessageData.ForPrompts.StartTesting.Write(after: "\n");
            MessageData.ForPrompts.StartOver.Write(after: " ");
            MessageData.ForNotifications.PanelsWillBeCreated.Write(after: "\n");
            MessageData.ForPrompts.Exit.Write(after: "\n\n");
            MessageData.ForNotifications.PanelsCreated(panelsAmount).Write(after: "\n\n");

            for (int i = 0; i < panelsAmount; i++)
                MessageData.ForPrompts.DisplayPanel(i).Write(after: "\n");

            MessageData.Message(ColoringData.Default, "\n").Write();

            for (int i = 0; i < panelsAmount; i++)
                MessageData.ForPrompts.HidePanel(i).Write(after: "\n");
        }
        #endregion

        #region PrivateMethods
        private int RequestPanelsNumber() => ConsoleService.RequestNumber(PanelData.Min, PanelData.Max, MessageData.ForRequests.WrongInput, ColoringData.Default);

        private void OnStartTestingKeyPressed(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ForTester.Enter))
            {
                ConsoleService.Clear(ColoringData.Default);
                State = State.Testing;
            }
        }

        private void OnDisplayControlHelpKeyPressed(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ForTester.F1))
                DisplayControlHelp(_panelsAmount);
        }

        private void OnStartOverKeyPressed(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ForTester.Spacebar))
                ; //Dummy
        }

        private void OnExitKeyPressed(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ForTester.Escape))
                Environment.Exit(0);
        }
        #endregion
    }
}
