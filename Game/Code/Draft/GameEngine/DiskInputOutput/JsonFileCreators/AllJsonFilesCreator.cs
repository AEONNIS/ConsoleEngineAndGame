using Draft.GameEngine.Configuration;

namespace Draft.GameEngine.DiskInputOutput.JsonFileCreators
{
    public class AllJsonFilesCreator
    {
        private readonly Config _config = null;

        public AllJsonFilesCreator(Config config) => _config = config;

        public void CreateAll()
        {
            CreateTileset();
        }

        public void CreateTileset()
        {
            TilesetFileCreator creator = new TilesetFileCreator(_config);
            creator.Create();
        }
    }
}
