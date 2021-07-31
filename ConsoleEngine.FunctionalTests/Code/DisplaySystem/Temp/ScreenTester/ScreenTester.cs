// Добавить запрос на выход из программы.
// Исправить ошибку (в самом движке) при попытке скрыть панель, которая еще не отрисовывалась!
// Screen.Clear() - работает очень долго при увеличении количества слоев. Почему?
// Сделать сортировку текстуры для вывода на экран всегда слева направо и сверху вниз.

using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
    {
        #region Fields
        private readonly PanelsBuilder _panelsBuilder = new PanelsBuilder();
        private int _panelsAmount;
        #endregion

        #region Properties
        public State State { get; private set; }
        #endregion

        #region Methods
        public void Run()
        {
            Init();
            Help();
            SubscribeToInputSystem();
            InputSystem.Get.Run(this);
        }
        #endregion

        #region States
        private void Init()
        {
            State = State.Initial;
            DisplayRequestForPanelsAmount();
            _panelsAmount = ToRequestPanelsAmount();
            _panelsBuilder.BuildRandomPanels(_panelsAmount);
        }

        private void Help()
        {
            State = State.Help;
            DisplayControlHelp(_panelsAmount);
        }

        private void StartTesting()
        {
            State = State.Testing;
            ConsoleService.Clear(ColoringData.Default);
        }

        private void Reset()
        {
            _panelsBuilder.Reset();
            _panelsAmount = 0;
            Screen.Get.Clear();
            GC.Collect();
        }

        private void StartOver()
        {
            Reset();
            Init();
            Help();
        }
        #endregion

        #region DisplayMessages
        private void DisplayRequestForPanelsAmount()
        {
            ConsoleService.Clear(ColoringData.Default);
            MessageData.Prompts.ConfirmInput.Write(after: "\n");
            MessageData.Prompts.DeleteChar.Write(after: "\n\n");
            MessageData.Notifications.PanelsWillBeCreated.Write(after: "\n\n");
            MessageData.Requests.PanelsNumber.Write();
        }
        private void DisplayControlHelp(int panelsAmount)
        {
            ConsoleService.Clear(ColoringData.Default);
            MessageData.Notifications.Control.Write(after: "\n\n");
            MessageData.Prompts.DisplayHelp.Write(after: "\n");
            MessageData.Prompts.StartTesting.Write(after: "\n");
            MessageData.Prompts.StartOver.Write(after: "\n");
            MessageData.Prompts.Exit.Write(after: "\n\n");
            MessageData.Notifications.PanelsCreated(panelsAmount).Write(after: "\n\n");

            for (int i = 0; i < panelsAmount; i++)
                MessageData.Prompts.DisplayPanel(i).Write(after: "\n");

            MessageData.Message(ColoringData.Default, "\n").Write();

            for (int i = 0; i < panelsAmount; i++)
                MessageData.Prompts.HidePanel(i).Write(after: "\n");
        }
        #endregion

        private int ToRequestPanelsAmount() => ConsoleService.ToRequestAmount(PanelData.Min, PanelData.Max, MessageData.Requests.WrongInput, ColoringData.Default);

        private void SubscribeToInputSystem()
        {
            InputSystem.Get.KeyPressedInHelp += CheckPressedKeyToStartTesting;
            InputSystem.Get.KeyPressedInHelp += CheckPressedKeyToExit;
            InputSystem.Get.KeyPressedInHelp += CheckPressedKeyToStartOver;
            InputSystem.Get.KeyPressedInTesting += CheckPressedKeyToHelp;
            InputSystem.Get.KeyPressedInTesting += CheckPressedKeyToExit;
            InputSystem.Get.KeyPressedInTesting += CheckPressedKeyToStartOver;
        }

        #region CheckingPressedKeys
        private void CheckPressedKeyToStartTesting(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ScreenTester.Enter))
                StartTesting();
        }

        private void CheckPressedKeyToExit(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ScreenTester.Escape))
                Environment.Exit(0);
        }

        private void CheckPressedKeyToHelp(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ScreenTester.F1))
                Help();
        }

        private void CheckPressedKeyToStartOver(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, KeyData.ScreenTester.Spacebar))
                StartOver();
        }
        #endregion
    }
}
