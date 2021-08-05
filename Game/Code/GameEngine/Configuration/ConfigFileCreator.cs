using System;
using System.Text.Json;

using ConsoleEngine.InputOutput;
using ConsoleEngine.InputSystem;

namespace GameName.GameEngine.Configuration
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
                AssetsAbsolutePath  = "d:/Work/Dev/AEONNIS/ConsoleEngineAndGame/Game/Assets/",
                TilesetRelativePath = "",
                TilesetName         = "tileset.json",
            },

            BindingKeys = new KeyBinding[]
            {
                new KeyBinding
                {
                    CommandId = CommandId.Up,
                    KeyInfo   = new KeyInfo(ConsoleKey.UpArrow,    false, false, false)
                },
                new KeyBinding
                {
                    CommandId = CommandId.Down,
                    KeyInfo   = new KeyInfo(ConsoleKey.DownArrow,  false, false, false)
                },
                new KeyBinding
                {
                    CommandId = CommandId.Left,
                    KeyInfo   = new KeyInfo(ConsoleKey.LeftArrow,  false, false, false)
                },
                new KeyBinding
                {
                    CommandId = CommandId.Right,
                    KeyInfo   = new KeyInfo(ConsoleKey.RightArrow, false, false, false)
                },
            }
        };
    }
}
