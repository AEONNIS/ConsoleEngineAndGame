using System.Text.Json;

using ConsoleEngine.InputOutput;

using GameName.Game.Map;

namespace GameName.GameEngine.InputOutput.JsonFileLoaders
{
    public class TilesetFileLoader : JsonFileLoader<Tileset>
    {
        public TilesetFileLoader()                              : base() { }
        public TilesetFileLoader(JsonSerializerOptions options) : base(options) { }
    }
}
