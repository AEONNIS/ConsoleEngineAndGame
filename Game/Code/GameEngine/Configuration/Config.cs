using System.Text.Json.Serialization;

using ConsoleEngine.InputSystem;

namespace GameName.GameEngine.Configuration
{
    public class Config
    {
        [JsonIgnore]
        public const string ConfigFullPath = "d:/Work/Dev/AEONNIS/ConsoleEngineAndGame/Game/Assets/config.json";

        public Paths        FilePaths   { get; init; }
        public KeyBinding[] BindingKeys { get; init; }

        public class Paths
        {
            public string AssetsAbsolutePath  { get; init; }
            public string TilesetRelativePath { get; init; }
            public string TilesetName         { get; init; }

            [JsonIgnore]
            public string TilesetFullPath => $"{AssetsAbsolutePath}{TilesetRelativePath}{TilesetName}";
        }
    }
}
