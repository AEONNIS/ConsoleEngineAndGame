using System.Text.Json;

using Draft.Common;
using Draft.Game.Map;

namespace Draft.GameEngine.DiskInputOutput.JsonFileLoaders
{
    public class TilesetFileLoader : JsonFileLoader<Tileset>
    {
        public TilesetFileLoader()                              : base() { }
        public TilesetFileLoader(JsonSerializerOptions options) : base(options) { }
    }
}
