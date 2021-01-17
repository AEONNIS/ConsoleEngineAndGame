using Engine.DisplaySystem;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class ColoringData
    {
        public static ColoringBuilder Builder { get; } = new ColoringBuilder();

        public static Coloring Default { get; } = Builder.Gray.On.Black.Build();

        public static class ForKeys
        {
            public static Coloring Key_1 { get; } = Builder.White.On.Blue.Build();
            public static Coloring Key_2 { get; } = Builder.White.On.Blue.Build();
            public static Coloring Key_3 { get; } = Builder.White.On.Blue.Build();
        }

        public static class ForMessages
        {
            public static Coloring WarningMessage { get; } = Builder.Red.On.Black.Build();
            public static Coloring RequestMessage { get; } = Builder.Green.On.Black.Build();
            public static Coloring NotificationMessage { get; } = Builder.Blue.On.Black.Build();
        }
    }
}
