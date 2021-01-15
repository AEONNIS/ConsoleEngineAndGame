using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class Data
    {
        #region ConstantFields
        public const int MinPanels = 1;
        public const int MaxPanels = 10;
        #endregion

        #region Fields
        private static readonly ColoringBuilder _builder = new ColoringBuilder();
        #endregion

        #region Classes
        public static class Texts
        {
            #region Properties
            public static string Initial => $"Введите количество панелей для теста (от {MinPanels} до {MaxPanels}): ";
            public static string WrongInput => "Неправильный ввод! Пожалуйста, повторите еще раз: ";
            public static string ConfirmInput => ": Подтвердить ввод.";
            public static string DeleteChar => ": Удалить символ.";
            public static string DisplayHelp => ": Показать справку, которую вы сейчас видите.";
            public static string StartTesting => ": Начать тестирование.";
            public static string Exit => ": Выйти из программы.";
            #endregion

            #region Methods
            public static string Space(int length) => new string(' ', length);
            public static string Key(string name) => $"[{name}]";
            public static string NumPadKey(int number) => $"[NumPad{number}]";
            public static string DisplayPanel(int number) => $": Показать/поднять наверх панель {number}.";
            public static string HidePanel(int number) => $": Скрыть с экрана панель {number}.";
            #endregion
        }

        public static class Colorings
        {
            public static Coloring Default => _builder.Gray.On.Black.Build();
            public static Coloring Key => _builder.White.On.Blue.Build();
            public static Coloring Wrong => _builder.Red.On.Black.Build();
            public static Coloring Green => _builder.Green.On.Black.Build();
        }

        public static class Messages
        {
            #region StaticProperties
            public static SimpleMessage Empty { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "",
            };
            public static SimpleMessage Initial { get; } = new SimpleMessage
            {
                Coloring = Colorings.Green,
                Text = $"Введите количество панелей для теста (от {MinPanels} до {MaxPanels}): ",
            };
            public static SimpleMessage WrongInput { get; } = new SimpleMessage
            {
                Coloring = Colorings.Wrong,
                Text = "Неправильный ввод! Пожалуйста, повторите еще раз: ",
            };
            public static SimpleMessage InputConfirmation { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "Подтвердить ввод.",
            };
            public static SimpleMessage DeleteChar { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "Удалить символ.",
            };
            public static SimpleMessage DisplayHelp { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "Показать справку, которую вы сейчас видите.",
            };
            public static SimpleMessage StartTesting { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "Начать тестирование.",
            };
            public static SimpleMessage ProgramExit { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "Выйти из программы.",
            };
            public static SimpleMessage SeparatorPlus { get; } = new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = "+",
            };
            #endregion

            #region Methods
            public static SimpleMessage Space(int length) => new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = new string(' ', length),
            };

            public static SimpleMessage Key(string name) => new SimpleMessage
            {
                Coloring = Colorings.Key,
                Text = $"[{name}]",
            };

            public static SimpleMessage[] KeyInfo(in ConsoleKeyInfo keyInfo)
            {
                var messages = new SimpleMessage[7];

                if (KeysService.ShiftPressed(keyInfo.Modifiers))
                {
                    messages[0] = Key("Shift");
                    messages[1] = SeparatorPlus;
                }
                else
                {
                    messages[0] = Empty;
                    messages[1] = Empty;
                }

                if (KeysService.AltPressed(keyInfo.Modifiers))
                {
                    messages[2] = Key("Alt");
                    messages[3] = SeparatorPlus;
                }
                else
                {
                    messages[2] = Empty;
                    messages[3] = Empty;
                }

                if (KeysService.ControlPressed(keyInfo.Modifiers))
                {
                    messages[4] = Key("Control");
                    messages[5] = SeparatorPlus;
                }
                else
                {
                    messages[4] = Empty;
                    messages[5] = Empty;
                }

                messages[6] = Key($"{keyInfo.Key}");

                return messages;
            }

            public static SimpleMessage DisplayPanel(int number) => new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = $" - Показать/поднять наверх панель {number}.",
            };

            public static SimpleMessage HidePanel(int number) => new SimpleMessage
            {
                Coloring = Colorings.Default,
                Text = $" - Скрыть с экрана панель {number}.",
            };

            public static SimpleMessage NumPadKey(int number) => new SimpleMessage
            {
                Coloring = Colorings.Key,
                Text = $"[NumPad{number}]",
            };

            public static SimpleMessage PanelsNumber(int number) => new SimpleMessage
            {
                Coloring = Colorings.Green,
                Text = $"Создано {number} панелей. Управление для них показано ниже:",
            };
            #endregion
        }
        #endregion
    }
}
