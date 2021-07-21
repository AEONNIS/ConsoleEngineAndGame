using System;
using System.Text.Json;

using Draft.Common;
using Draft.GameEngine.Input;

namespace Draft.GameEngine.Configuration
{
    public class ConfigFileCreator : JsonFileCreator<Config>
    {
        public ConfigFileCreator()                              : base() { }
        public ConfigFileCreator(JsonSerializerOptions options) : base(options) { }

        public void Create() => CreateFile(Config.ConfigFullPath, CreateConfig());

        private Config CreateConfig() => new Config
        {
            FilePaths = new Config.Paths
            {
                AssetsAbsolutePath  = "d:/Work/Dev/AEONNIS/ConsoleGameEngine/Game/Assets/Draft/",
                TilesetRelativePath = "",
                TilesetName         = "tileset.json",
            },

            Keys = new BindingKeys
            {
                Enter = new KeyBinding { KeyInfo = new KeyInfo(ConsoleKey.Enter,      false, false, false) },
                Up    = new KeyBinding { KeyInfo = new KeyInfo(ConsoleKey.UpArrow,    false, false, false) },
                Down  = new KeyBinding { KeyInfo = new KeyInfo(ConsoleKey.DownArrow,  false, false, false) },
                Left  = new KeyBinding { KeyInfo = new KeyInfo(ConsoleKey.LeftArrow,  false, false, false) },
                Right = new KeyBinding { KeyInfo = new KeyInfo(ConsoleKey.RightArrow, false, false, false) },
            }
        };
    }
}
