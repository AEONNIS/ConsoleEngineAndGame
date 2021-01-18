using Engine.DisplaySystem;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class MessageData
    {
        public static IMessage Space(in Coloring coloring, int length)
            => new SimpleMessage { Coloring = coloring, Text = TextData.Space(length) };

        public static IMessage Message(in Coloring coloring, string text)
            => new SimpleMessage { Coloring = coloring, Text = text };

        public static class ForKeys
        {
            public static IMessage Key(in Coloring coloring, ConsoleKey key)
                => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(key) };

            public static IMessage Key(in Coloring coloring, string key)
                => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Key(key) };

            public static IMessage KeySeparator(in Coloring coloring)
                => new SimpleMessage { Coloring = coloring, Text = TextData.ForKeys.Separator };

            public static IMessage KeyInfo(in Coloring keyColoring, in Coloring separatorColoring, in ConsoleKeyInfo keyInfo)
            {
                var message = new CompositeMessage();

                if (KeyService.ShiftPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.ForKeys.Shift))
                           .Add(KeySeparator(separatorColoring));

                if (KeyService.AltPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.ForKeys.Alt))
                           .Add(KeySeparator(separatorColoring));

                if (KeyService.ControlPressed(keyInfo.Modifiers))
                    message.Add(Key(keyColoring, TextData.ForKeys.Control))
                           .Add(KeySeparator(separatorColoring));

                message.Add(Key(keyColoring, keyInfo.Key));

                return message;
            }
        }

        public static class ForNotifications
        {
            public static IMessage Control { get; }
                = new SimpleMessage { Coloring = ColoringData.ForMessages.NotificationMessage, Text = TextData.ForNotifications.Control };

            public static IMessage PanelsWillBeCreated { get; }
                = new SimpleMessage { Coloring = ColoringData.ForMessages.NotificationMessage, Text = TextData.ForNotifications.PanelsWillBeCreated };

            public static IMessage PanelsCreated(int amount)
                => new SimpleMessage { Coloring = ColoringData.ForMessages.NotificationMessage, Text = TextData.ForNotifications.PanelsCreated(amount) };
        }

        public static class ForPrompts
        {
            public static IMessage ConfirmInput { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.Enter.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.ConfirmInput });

            public static IMessage DeleteChar { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.Backspace.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.DeleteChar });

            public static IMessage DisplayHelp { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.F1.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.DisplayHelp });

            public static IMessage StartTesting { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.Enter.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.StartTesting });

            public static IMessage StartOver { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.Spacebar.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.StartOver });

            public static IMessage Exit { get; } = new CompositeMessage()
                .Add(ForKeys.Key(ColoringData.ForKeys.Key_1, KeyData.ForTester.Escape.Key))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.Exit });

            public static IMessage DisplayPanel(int number) => new CompositeMessage()
                .Add(ForKeys.KeyInfo(ColoringData.ForKeys.Key_1, ColoringData.ForKeys.Separator, KeyData.ForPanels.DisplayOnScreen[number]))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.DisplayPanel(number) });

            public static IMessage HidePanel(int number) => new CompositeMessage()
                .Add(ForKeys.KeyInfo(ColoringData.ForKeys.Key_1, ColoringData.ForKeys.Separator, KeyData.ForPanels.HideFromScreen[number]))
                .Add(new SimpleMessage { Coloring = ColoringData.Default, Text = TextData.ForPrompts.HidePanel(number) });
        }

        public static class ForRequests
        {
            public static IMessage PanelsNumber { get; }
                = new SimpleMessage { Coloring = ColoringData.ForMessages.RequestMessage, Text = TextData.ForRequests.PanelsNumber };

            public static IMessage WrongInput { get; }
                = new SimpleMessage { Coloring = ColoringData.ForMessages.WarningMessage, Text = TextData.ForRequests.WrongInput };
        }
    }
}
