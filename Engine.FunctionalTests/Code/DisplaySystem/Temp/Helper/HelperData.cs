namespace Engine.FunctionalTests.DisplaySystem
{
    public static class HelperData
    {
        public static class Messages
        {
            public static Message Initial { get; } = new Message
            {
                Coloring = ColoringsData.Request,
                Text = "Введите количество панелей для теста (от 1 до 10): ",
            };
            public static Message WrongInput { get; } = new Message
            {
                Coloring = ColoringsData.Wrong,
                Text = "Неправильный ввод! Пожалуйста, повторите еще раз...",
            };
            public static Message PlusSign { get; } = new Message
            {
                Coloring = ColoringsData.Default,
                Text = "+",
            };
            public static Message InputConfirmation { get; } = new Message
            {
                Coloring = ColoringsData.Default,
                Text = "Подтвердить ввод.",
            };
            public static Message DeleteChar { get; } = new Message
            {
                Coloring = ColoringsData.Default,
                Text = "Удалить символ.",
            };

            public static class Keys
            {
                public static Message Enter { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[Enter]",
                };
                public static Message Escape { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[Escape]",
                };
                public static Message Backspace { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[Backspace]",
                };
                public static Message F1 { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[F1]",
                };
                public static Message Shift { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[Shift]",
                };
                public static Message Control { get; } = new Message
                {
                    Coloring = ColoringsData.Keys,
                    Text = "[Control]",
                };

                public static class NumPad
                {
                    public static Message NP0 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[0]",
                    };
                    public static Message NP1 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[1]",
                    };
                    public static Message NP2 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[2]",
                    };
                    public static Message NP3 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[3]",
                    };
                    public static Message NP4 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[4]",
                    };
                    public static Message NP5 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[5]",
                    };
                    public static Message NP6 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[6]",
                    };
                    public static Message NP7 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[7]",
                    };
                    public static Message NP8 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[8]",
                    };
                    public static Message NP9 { get; } = new Message
                    {
                        Coloring = ColoringsData.Keys,
                        Text = "[9]",
                    };
                }
            }
        }

    }
}
