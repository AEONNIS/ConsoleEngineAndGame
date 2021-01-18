using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class TextData
    {
        public static string Space(int length) => new string(' ', length);

        public static class Keys
        {
            public const string Shift = "Shift";
            public const string Alt = "Alt";
            public const string Control = "Control";
            public const string Separator = " + ";

            public static string Key(ConsoleKey key) => $"[{key}]";

            public static string Key(string key) => $"[{key}]";
        }

        public static class Notifications
        {
            public const string Control = "Управление приложением показано ниже:";
            public const string PanelsWillBeCreated = "Для теста будет создано указанное количество случаных по размеру и расцветке панелей.";

            public static string PanelsCreated(int amount) => $"Создана(о) {amount} случайная(ых) по размеру и расцветке панель(ли/лей). Управление для нее(их) показано ниже:";
        }

        public static class Prompts
        {
            public const string ConfirmInput = ": Подтвердить ввод.";
            public const string DeleteChar = ": Удалить символ.";
            public const string DisplayHelp = ": Показать справку, которую вы сейчас видите.";
            public const string StartTesting = ": Начать тестирование.";
            public const string Exit = ": Выйти из программы.";
            public const string StartOver = ": Удалить текущие панели и начать сначала.";

            public static string DisplayPanel(int number) => $": Показать/поднять наверх панель {number}.";

            public static string HidePanel(int number) => $": Скрыть с экрана панель {number}.";
        }

        public static class Requests
        {
            public const string WrongInput = "Неправильный ввод! Пожалуйста, повторите еще раз: ";

            public static string PanelsNumber { get; } = $"Введите количество панелей для теста (от {PanelData.Min} до {PanelData.Max}): ";
        }
    }
}
