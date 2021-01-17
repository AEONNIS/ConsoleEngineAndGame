using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class TextData
    {
        public static string Space(int length) => new string(' ', length);

        public static class ForKeys
        {
            public const string Separator = " + ";

            public static string Key(ConsoleKey key) => $"[{key}]";
            public static string Key(string key) => $"[{key}]";
            public static string NumPadKey(int number) => $"[NumPad{number}]";
        }

        public static class ForNotifications
        {
            public static string CreatedPanelsIn(int amount) => $"Создано {amount} панелей. Управление для них показано ниже:";
        }

        public static class ForPrompts
        {
            public const string ConfirmInput = ": Подтвердить ввод.";
            public const string DeleteChar = ": Удалить символ.";
            public const string DisplayHelp = ": Показать справку, которую вы сейчас видите.";
            public const string StartTesting = ": Начать тестирование.";
            public const string Exit = ": Выйти из программы.";

            public static string DisplayPanel(int number) => $": Показать/поднять наверх панель {number}.";
            public static string HidePanel(int number) => $": Скрыть с экрана панель {number}.";
        }

        public static class ForRequests
        {
            public const string WrongInput = "Неправильный ввод! Пожалуйста, повторите еще раз: ";

            public static string PanelsNumber { get; } = $"Введите количество панелей для теста (от {PanelData.Min} до {PanelData.Max}): ";
        }
    }
}
