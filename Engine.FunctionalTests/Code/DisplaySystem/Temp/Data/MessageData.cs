using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class MessageData // Может что-то вынести в сервис??
    {
        public static IMessage Space(in Coloring coloring, int length)
            => new SimpleMessage { Coloring = coloring, Text = TextData.Space(length) };

        public static IMessage Message(in Coloring coloring, string text)
            => new SimpleMessage { Coloring = coloring, Text = text };

        public static class Keys
        {
            public static IMessage Key(in Coloring coloring, ConsoleKey key)
                => new SimpleMessage { Coloring = coloring, Text = TextData.Keys.Key(key) };

            public static IMessage Key(in Coloring coloring, string key)
                => new SimpleMessage { Coloring = coloring, Text = TextData.Keys.Key(key) };

            public static IMessage KeySeparator(in Coloring coloring)
                => new SimpleMessage { Coloring = coloring, Text = TextData.Keys.Separator };

            public static IMessage KeyInfo(in Coloring keyColoring, in Coloring separatorColoring, in ConsoleKeyInfo keyInfo)
            {
                var message = new CompositeMessage();

                if (KeyService.ShiftPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.Keys.Shift))
                           .Add(KeySeparator(separatorColoring));

                if (KeyService.AltPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.Keys.Alt))
                           .Add(KeySeparator(separatorColoring));

                if (KeyService.ControlPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.Keys.Control))
                           .Add(KeySeparator(separatorColoring));

                message.Add(Key(keyColoring, keyInfo.Key));

                return message;
            }
        }

        public static class Notifications
        {
            public static IMessage Control { get; }
                = new SimpleMessage { Coloring = ColoringData.Messages.NotificationMessage, Text = TextData.Notifications.Control };

            public static IMessage PanelsWillBeCreated { get; }
                = new SimpleMessage { Coloring = ColoringData.Messages.NotificationMessage, Text = TextData.Notifications.PanelsWillBeCreated };

            public static IMessage PanelsCreated(int amount)
                => new SimpleMessage { Coloring = ColoringData.Messages.NotificationMessage, Text = TextData.Notifications.PanelsCreated(amount) };
        }

        public static class Prompts
        {
            public static IMessage ConfirmInput { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.Enter, KeyData.ScreenTester.Enter.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Enter, Text = TextData.Prompts.ConfirmInput });

            public static IMessage DeleteChar { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.Backspace, KeyData.ScreenTester.Backspace.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Backspace, Text = TextData.Prompts.DeleteChar });

            public static IMessage DisplayHelp { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.F1, KeyData.ScreenTester.F1.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.F1, Text = TextData.Prompts.DisplayHelp });

            public static IMessage StartTesting { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.Enter, KeyData.ScreenTester.Enter.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Enter, Text = TextData.Prompts.StartTesting });

            public static IMessage StartOver { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.Spacebar, KeyData.ScreenTester.Spacebar.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Spacebar, Text = TextData.Prompts.StartOver });

            public static IMessage Exit { get; } = new CompositeMessage()
                .Add(Keys.Key(ColoringData.Keys.Escape, KeyData.ScreenTester.Escape.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Escape, Text = TextData.Prompts.Exit });

            public static IMessage DisplayPanel(int number) => new CompositeMessage()
                .Add(Keys.KeyInfo(ColoringData.Keys.Display, ColoringData.Keys.Separator, KeyData.Panels.DisplayOnScreen[number]))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Display, Text = TextData.Prompts.DisplayPanel(number) });

            public static IMessage HidePanel(int number) => new CompositeMessage()
                .Add(Keys.KeyInfo(ColoringData.Keys.Hide, ColoringData.Keys.Separator, KeyData.Panels.HideFromScreen[number]))
                .Add(new SimpleMessage { Coloring = ColoringData.Messages.Prompts.Hide, Text = TextData.Prompts.HidePanel(number) });
        }

        public static class Requests
        {
            public static IMessage PanelsNumber { get; }
                = new SimpleMessage { Coloring = ColoringData.Messages.RequestMessage, Text = TextData.Requests.PanelsNumber };

            public static IMessage WrongInput { get; }
                = new SimpleMessage { Coloring = ColoringData.Messages.WarningMessage, Text = TextData.Requests.WrongInput };
        }
    }
}
