using GameName.Game.Map;
using GameName.GameEngine.Configuration;

namespace GameName.GameEngine.InputOutput.JsonFileLoaders
{
    public class AllJsonFilesLoader
    {
        private readonly Config _config = null;

        public AllJsonFilesLoader(Config config) => _config = config;

        public Tileset Tileset { get; private set; }

        public void LoadAll()
        {
            LoadTileset();
        }

        public void LoadTileset()
        {
            TilesetFileLoader loader = new TilesetFileLoader();
            Tileset                  = loader.Load(_config.FilePaths.TilesetFullPath);
        }
    }
}
