using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class Data
    {
        #region Classes
        public static class Keys
        {
            #region ConstantFields
            private const int NumPad0 = 96;
            #endregion

            #region Properties
            public static ConsoleKeyInfo Backspace => new ConsoleKeyInfo(default, ConsoleKey.Backspace, false, false, false);
            public static ConsoleKeyInfo Enter => new ConsoleKeyInfo(default, ConsoleKey.Enter, false, false, false);
            public static ConsoleKeyInfo Escape => new ConsoleKeyInfo(default, ConsoleKey.Escape, false, false, false);
            public static ConsoleKeyInfo F1 => new ConsoleKeyInfo(default, ConsoleKey.F1, false, false, false);
            public static ConsoleKeyInfo[] NumPads
            {
                get
                {
                    var result = new ConsoleKeyInfo[10];

                    for (int i = 0; i < 10; i++)
                        result[i] = NumPad(i);

                    return result;
                }
            }
            #endregion

            #region Methods
            public static ConsoleKeyInfo NumPad(int number) => new ConsoleKeyInfo(default, (ConsoleKey)(NumPad0 + number), false, false, false);
            #endregion
        }

        public static class Texts
        {
            #region Properties
            public static string RequestPanelsNumber => $"Введите количество панелей для теста (от {Panels.Min} до {Panels.Max}): ";
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
            #region Fields
            private static readonly ColoringBuilder _builder = new ColoringBuilder();
            #endregion

            #region Properties
            public static Coloring Default => _builder.Gray.On.Black.Build();
            public static Coloring Key => _builder.White.On.Blue.Build();
            public static Coloring Wrong => _builder.Red.On.Black.Build();
            public static Coloring BlueOnBlack => _builder.Blue.On.Black.Build();
            public static Coloring CyanOnBlack => _builder.Cyan.On.Black.Build();
            public static Coloring GreenOnBlack => _builder.Green.On.Black.Build();
            #endregion
        }

        public static class Messages
        {
            #region Properties
            public static SimpleMessage RequestPanelsNumber => new SimpleMessage { Coloring = Colorings.GreenOnBlack, Text = Texts.RequestPanelsNumber };
            public static SimpleMessage WrongInput => new SimpleMessage { Coloring = Colorings.Wrong, Text = Texts.WrongInput };
            public static SimpleMessage ConfirmInput => new SimpleMessage { Coloring = Colorings.Default, Text = Texts.ConfirmInput };
            public static CompositeMessage ConfirmInputHint => new CompositeMessage().Add(Key(Colorings.Key, "Enter")).Add(ConfirmInput);
            public static SimpleMessage DeleteChar => new SimpleMessage { Coloring = Colorings.Default, Text = Texts.DeleteChar };
            public static CompositeMessage DeleteCharHint => new CompositeMessage().Add(Key(Colorings.Key, "Backspace")).Add(DeleteChar);
            public static SimpleMessage DisplayHelp => new SimpleMessage { Coloring = Colorings.Default, Text = Texts.DisplayHelp };


            public static SimpleMessage Empty => new SimpleMessage { Coloring = Colorings.Default, Text = "" };
            public static SimpleMessage StartTesting => new SimpleMessage { Coloring = Colorings.Default, Text = "Начать тестирование." };
            public static SimpleMessage ProgramExit => new SimpleMessage { Coloring = Colorings.Default, Text = "Выйти из программы." };
            public static SimpleMessage SeparatorPlus => new SimpleMessage { Coloring = Colorings.Default, Text = "+" };
            #endregion

            #region Methods
            public static SimpleMessage Message(Coloring coloring, string text) => new SimpleMessage { Coloring = coloring, Text = text };
            public static SimpleMessage Space(Coloring coloring, int length) => new SimpleMessage { Coloring = coloring, Text = new string(' ', length) };
            public static SimpleMessage Key(Coloring coloring, string name) => new SimpleMessage { Coloring = coloring, Text = Texts.Key(name) };



            public static SimpleMessage[] KeyInfo(in ConsoleKeyInfo keyInfo)
            {
                var messages = new SimpleMessage[7];

                if (Services.Keys.ShiftPressed(keyInfo.Modifiers))
                {
                    messages[0] = Key(Colorings.Key, "Shift");
                    messages[1] = SeparatorPlus;
                }
                else
                {
                    messages[0] = Empty;
                    messages[1] = Empty;
                }

                if (Services.Keys.AltPressed(keyInfo.Modifiers))
                {
                    messages[2] = Key(Colorings.Key, "Alt");
                    messages[3] = SeparatorPlus;
                }
                else
                {
                    messages[2] = Empty;
                    messages[3] = Empty;
                }

                if (Services.Keys.ControlPressed(keyInfo.Modifiers))
                {
                    messages[4] = Key(Colorings.Key, "Control");
                    messages[5] = SeparatorPlus;
                }
                else
                {
                    messages[4] = Empty;
                    messages[5] = Empty;
                }

                messages[6] = Key(Colorings.Key, $"{keyInfo.Key}");

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
                Coloring = Colorings.GreenOnBlack,
                Text = $"Создано {number} панелей. Управление для них показано ниже:",
            };
            #endregion
        }

        public static class Panels
        {
            #region ConstantFields
            public const int Min = 1;
            public const int Max = 10;
            public const string BaseName = "Panel_";
            public const float MinPartFromScreenSize = 0.6f;
            #endregion

            #region Properties
            public static char[] Symbols => new char[] { '\u2591', '\u2592', '\u2593', '\u25A0', '\u253C' };

            public static Coloring[] Colorings => new Coloring[]
            {
            };

            public static Pixel[] Fillers => new Pixel[]
            {
                new Pixel(ConsoleColor.Blue, ConsoleColor.Black, ' '),
                new Pixel(ConsoleColor.Cyan, ConsoleColor.Black, '!'),
                new Pixel(ConsoleColor.DarkBlue, ConsoleColor.White, '@'),
                new Pixel(ConsoleColor.DarkCyan, ConsoleColor.White, '#'),
                new Pixel(ConsoleColor.DarkGray, ConsoleColor.White, '$'),
                new Pixel(ConsoleColor.DarkGreen, ConsoleColor.White, '%'),
                new Pixel(ConsoleColor.DarkMagenta, ConsoleColor.White, '^'),
                new Pixel(ConsoleColor.DarkRed, ConsoleColor.White, '&'),
                new Pixel(ConsoleColor.DarkYellow, ConsoleColor.White, '*'),
                new Pixel(ConsoleColor.Gray, ConsoleColor.Black, '-'),
                new Pixel(ConsoleColor.Green, ConsoleColor.Black, '+'),
                new Pixel(ConsoleColor.Magenta, ConsoleColor.Black, '='),
                new Pixel(ConsoleColor.Red, ConsoleColor.Black, '~'),
                new Pixel(ConsoleColor.White, ConsoleColor.Black, '/'),
                new Pixel(ConsoleColor.Yellow, ConsoleColor.Black, '\\'),
            };
            #endregion

            #region Classes
            public static class KeysFor
            {
                public static ConsoleKeyInfo[] DisplayOnScreen => Keys.NumPads;

                public static ConsoleKeyInfo[] HideFromScreen => Services.Keys.NumPadsPlusModifiers(ConsoleModifiers.Control);
            }
            #endregion
        }
        #endregion
    }
}
