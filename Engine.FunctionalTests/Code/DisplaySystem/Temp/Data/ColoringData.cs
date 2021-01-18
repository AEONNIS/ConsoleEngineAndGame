using Engine.DisplaySystem;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class ColoringData
    {
        public static ColoringBuilder Builder { get; } = new ColoringBuilder();

        public static Coloring Default { get; } = Builder.Gray.On.Black.Build();

        public static class Keys
        {
            public static Coloring Backspace { get; } = Builder.Black.On.Gray.Build();
            public static Coloring Enter { get; } = Builder.White.On.DarkBlue.Build();
            public static Coloring Escape { get; } = Builder.White.On.DarkRed.Build();
            public static Coloring Spacebar { get; } = Builder.Black.On.White.Build();
            public static Coloring F1 { get; } = Builder.DarkBlue.On.White.Build();
            public static Coloring Separator { get; } = Builder.Gray.On.Black.Build();
            public static Coloring Display { get; } = Builder.White.On.Blue.Build();
            public static Coloring Hide { get; } = Builder.Black.On.Gray.Build();
        }

        public static class Messages
        {
            public static Coloring WarningMessage { get; } = Builder.Red.On.Black.Build();
            public static Coloring RequestMessage { get; } = Builder.Green.On.Black.Build();
            public static Coloring NotificationMessage { get; } = Builder.White.On.Black.Build();

            public static class Prompts
            {
                public static Coloring Backspace { get; } = Builder.Gray.On.Black.Build();
                public static Coloring Enter { get; } = Builder.Blue.On.Black.Build();
                public static Coloring Escape { get; } = Builder.DarkRed.On.Black.Build();
                public static Coloring Spacebar { get; } = Builder.White.On.Black.Build();
                public static Coloring F1 { get; } = Builder.White.On.Black.Build();
                public static Coloring Display { get; } = Builder.Blue.On.Black.Build();
                public static Coloring Hide { get; } = Builder.Gray.On.Black.Build();
            }
        }
    }
}
