using Draft.GameEngine.Input;
using System.Text.Json.Serialization;

namespace Draft.GameEngine.Configuration
{
    public class Config
    {
        [JsonIgnore]
        public const string ConfigFullPath = "d:/Work/Dev/AEONNIS/ConsoleGameEngine/Game/Assets/Draft/config.json";

        public Paths       FilePaths { get; init; }
        public BindingKeys Keys      { get; init; }

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
