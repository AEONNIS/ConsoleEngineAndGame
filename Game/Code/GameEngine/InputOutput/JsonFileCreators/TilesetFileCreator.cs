using System.Text.Json;

using ConsoleEngine.InputOutput;

using GameName.Game.Map;
using GameName.GameEngine.Configuration;

namespace GameName.GameEngine.InputOutput.JsonFileCreators
{
    public class TilesetFileCreator : JsonFileCreator<Tileset>
    {
        private readonly Config _config = null;

        public TilesetFileCreator(Config config)                                : base()        => _config = config;
        public TilesetFileCreator(JsonSerializerOptions options, Config config) : base(options) => _config = config;

        public void Create() => CreateFile(_config.FilePaths.TilesetFullPath, CreateTilset());

        private Tileset CreateTilset() => new Tileset
        {
            Tiles = new Tile[]
            {
                new Tile { Symbol = '·', Name = "ground",         Passability = true,  LightTransmission = true  },
                new Tile { Symbol = '█', Name = "wall",           Passability = false, LightTransmission = false },
                new Tile { Symbol = '▓', Name = "closedWallDoor", Passability = false, LightTransmission = false },
                new Tile { Symbol = '░', Name = "openedWallDoor", Passability = true,  LightTransmission = true  },
                new Tile { Symbol = '#', Name = "grid",           Passability = false, LightTransmission = true  },
                new Tile { Symbol = '+', Name = "closedGridDoor", Passability = false, LightTransmission = true  },
                new Tile { Symbol = ':', Name = "openedGridDoor", Passability = true,  LightTransmission = true  },
            }
        };
    }
}
