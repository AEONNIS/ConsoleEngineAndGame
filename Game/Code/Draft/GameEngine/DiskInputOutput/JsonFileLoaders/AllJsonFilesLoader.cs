using Draft.Game.Map;
using Draft.GameEngine.Configuration;

namespace Draft.GameEngine.DiskInputOutput.JsonFileLoaders
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
