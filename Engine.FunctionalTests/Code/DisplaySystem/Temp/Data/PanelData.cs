using Engine.DisplaySystem;
using Engine.Maths;

namespace Engine.FunctionalTests.DisplaySystem
{
    public static class PanelData
    {
        public const int Min = 1;
        public const int Max = 10;
        public const string BaseName = "Panel_";
        public const float MinPartFromScreenSize = 0.6f;

        public static Vector2Int MinSize { get; } = Screen.Get.Rectangle.Size * MinPartFromScreenSize;
        public static char[] Symbols { get; } = new char[] { '\u2591', '\u2592', '\u2593', '\u25A0', '\u253C' };
        public static Coloring[] Colorings { get; } = new Coloring[]
        {
                ColoringData.Builder.Black.On.Gray.Build(),
                ColoringData.Builder.Black.On.Blue.Build(),
                ColoringData.Builder.Black.On.Green.Build(),
                ColoringData.Builder.Black.On.Cyan.Build(),
                ColoringData.Builder.Black.On.Red.Build(),
                ColoringData.Builder.Black.On.Magenta.Build(),
                ColoringData.Builder.Black.On.Yellow.Build(),
                ColoringData.Builder.Black.On.White.Build(),
                ColoringData.Builder.White.On.Black.Build(),
                ColoringData.Builder.White.On.DarkBlue.Build(),
                ColoringData.Builder.White.On.DarkGreen.Build(),
                ColoringData.Builder.White.On.DarkCyan.Build(),
                ColoringData.Builder.White.On.DarkRed.Build(),
                ColoringData.Builder.White.On.DarkMagenta.Build(),
                ColoringData.Builder.White.On.DarkYellow.Build(),
                ColoringData.Builder.White.On.DarkGray.Build(),
        };
    }
}
