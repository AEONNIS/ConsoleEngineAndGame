using System;

namespace Engine.DisplaySystem
{
    public static class ConsoleColorsSettingService
    {
        #region StaticMethods
        public static void SetConsoleColors(in Pixel original, in Pixel? buffer, in Pixel empty)
        {
            if (buffer.HasValue)
            {
                Console.BackgroundColor = GetColor(original.BackgroundColor, buffer.Value.BackgroundColor, empty.BackgroundColor.Value);
                Console.ForegroundColor = GetColor(original.Foreground.Color, buffer.Value.Foreground.Color, empty.Foreground.Color.Value);
            }
            else
            {
                Console.BackgroundColor = GetColor(original.BackgroundColor, empty.BackgroundColor.Value);
                Console.ForegroundColor = GetColor(original.Foreground.Color, empty.Foreground.Color.Value);
            }
        }

        private static ConsoleColor GetColor(ConsoleColor? original, ConsoleColor? buffer, ConsoleColor empty) => original ?? buffer ?? empty;

        private static ConsoleColor GetColor(ConsoleColor? original, ConsoleColor empty) => original ?? empty;
        #endregion
    }
}
