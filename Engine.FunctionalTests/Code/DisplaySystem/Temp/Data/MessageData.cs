using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class MessageData
    {
        public static class ForKeys
        {
            public static IMessage Backspace(Coloring coloring) => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(KeyData.ForTester.Backspace.Key) };
            public static IMessage Enter(Coloring coloring) => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(KeyData.ForTester.Enter.Key) };
            public static IMessage Escape(Coloring coloring) => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(KeyData.ForTester.Escape.Key) };
            public static IMessage F1(Coloring coloring) => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(KeyData.ForTester.F1.Key) };
        }

        public static class ForNotifications
        {

        }

        public static class ForPrompts
        {
            public static IMessage ConfirmInput { get; } = new CompositeMessage()
                .Add(ForKeys.Enter(ColoringData.ForKeys.Key_1))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.ConfirmInput });

        }

        public static class ForRequests
        {
            public static IMessage PanelsNumber { get; } = new SimpleMessage { Coloring = ColoringData.ForMessages.RequestMessage, Text = TextData.ForRequests.PanelsNumber };
            public static IMessage WrongInput { get; } = new SimpleMessage { Coloring = ColoringData.ForMessages.WarningMessage, Text = TextData.ForRequests.WrongInput };
        }

        public static SimpleMessage DeleteChar { get; } = new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.DeleteCharPrompt };
        public static CompositeMessage DeleteCharHint { get; } = new CompositeMessage().Add(Key(ColoringData.Key_1, ConsoleKey.Backspace)).Add(DeleteChar);
        public static SimpleMessage DisplayHelp { get; } = new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.DisplayHelpPrompt };
        public static CompositeMessage DisplayHelpHint { get; } = new CompositeMessage().Add(Key(ColoringData.Key_1, ConsoleKey.F1)).Add(DisplayHelp);
        public static SimpleMessage StartTesting { get; } = new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.StartTestingPrompt };
        public static CompositeMessage StartTestingHint { get; } = new CompositeMessage().Add(Key(ColoringData.Key_1, ConsoleKey.Enter)).Add(StartTesting);
        public static SimpleMessage Exit { get; } = new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.Exit };
        public static CompositeMessage ExitHint { get; } = new CompositeMessage().Add(Key(ColoringData.Key_1, ConsoleKey.Escape)).Add(Exit);

        public static IMessage Space(in Coloring coloring, int length) => new SimpleMessage { Coloring = coloring, Text = TextData.Space(length) };
        public static SimpleMessage Key(in Coloring coloring, ConsoleKey key) => new SimpleMessage { Coloring = coloring, Text = TextData.Key(key) };
        public static SimpleMessage Key(in Coloring coloring, string key) => new SimpleMessage { Coloring = coloring, Text = TextData.Key(key) };
        public static SimpleMessage KeySeparator(in Coloring coloring) => new SimpleMessage { Coloring = coloring, Text = TextData.KeySeparator };
        public static CompositeMessage KeyInfo(in Coloring keyColoring, in Coloring separatorColoring, string separator, ConsoleKeyInfo keyInfo)
        {
            var message = new CompositeMessage();

            if (Services.ForKeys.ShiftPressed(keyInfo.Modifiers))
                message.Add(Key(keyColoring, "Shift")).Add(KeySeparator(separatorColoring));
            if (Services.ForKeys.AltPressed(keyInfo.Modifiers))
                message.Add(Key(keyColoring, "Alt")).Add(KeySeparator(separatorColoring));
            if (Services.ForKeys.ControlPressed(keyInfo.Modifiers))
                message.Add(Key(keyColoring, "Control")).Add(KeySeparator(separatorColoring));

            message.Add(Key(keyColoring, keyInfo.Key));

            return message;
        }

        public static SimpleMessage DisplayPanel(int number) => new SimpleMessage
        {
            Coloring = ColoringData.Default,
            Text = $" - Показать/поднять наверх панель {number}.",
        };

        public static SimpleMessage HidePanel(int number) => new SimpleMessage
        {
            Coloring = ColoringData.Default,
            Text = $" - Скрыть с экрана панель {number}.",
        };

        public static SimpleMessage NumPadKey(int number) => new SimpleMessage
        {
            Coloring = ColoringData.Key_1,
            Text = $"[NumPad{number}]",
        };

        public static SimpleMessage PanelsNumber(int number) => new SimpleMessage
        {
            Coloring = ColoringData.RequestMessage,
            Text = $"Создано {number} панелей. Управление для них показано ниже:",
        };
    }
}
