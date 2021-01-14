namespace Engine.FunctionalTests.DisplaySystem
{
    public static class HelperData
    {
        #region ConstantFields
        public const int MinPanels = 1;
        public const int MaxPanels = 10;
        #endregion

        #region StaticClasses
        public static class Messages
        {
            #region StaticProperties
            public static Message Initial { get; } = new Message
            {
                Coloring = ColoringsData.GreenOnBlack,
                Text = $"Введите количество панелей для теста (от {MinPanels} до {MaxPanels}): ",
            };
            public static Message WrongInput { get; } = new Message
            {
                Coloring = ColoringsData.RedOnBlack,
                Text = "Неправильный ввод! Пожалуйста, повторите еще раз: ",
            };
            public static Message PlusSign { get; } = new Message
            {
                Coloring = ColoringsData.GrayOnBlack,
                Text = "+",
            };
            public static Message InputConfirmation { get; } = new Message
            {
                Coloring = ColoringsData.GrayOnBlack,
                Text = "Подтвердить ввод.",
            };
            public static Message DeleteChar { get; } = new Message
            {
                Coloring = ColoringsData.GrayOnBlack,
                Text = "Удалить символ.",
            };
            #endregion

            #region StaticMethods
            public static Message Empty(int length) => new Message
            {
                Coloring = ColoringsData.GrayOnBlack,
                Text = new string(' ', length),
            };

            public static Message Key(string name) => new Message
            {
                Coloring = ColoringsData.BlackOnWhite,
                Text = $"[{name}]",
            };

            public static Message NumPadKey(int number) => new Message
            {
                Coloring = ColoringsData.BlackOnWhite,
                Text = $"[NumPad{number}]",
            };
            #endregion
        }
        #endregion
    }
}
