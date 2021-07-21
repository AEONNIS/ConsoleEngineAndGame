using System;

using Draft.Game.Map;
using Draft.GameEngine.Configuration;
using Draft.GameEngine.DiskInputOutput.JsonFileCreators;
using Draft.GameEngine.DiskInputOutput.JsonFileLoaders;
using Draft.GameEngine.DisplaySystem;

namespace Draft.GameEngine
{
    public class Engine
    {
        private readonly Config              _config       = null;
        private readonly AllJsonFilesCreator _jsonsCreator = null;
        private readonly AllJsonFilesLoader  _jsonsLoader  = null;

        public Tileset Tileset => _jsonsLoader.Tileset;

        public Engine()
        {
            //CreateConfigFile();
            _config = LoadConfigFile();

            //_jsonsCreator = new AllJsonFilesCreator(_config);
            //_jsonsCreator.CreateAll();

            _jsonsLoader = new AllJsonFilesLoader(_config);
            _jsonsLoader.LoadAll();
        }

        public void Start()
        {
            Turn();
        }

        private void Turn()
        {
            while (true)
            {
                Console.ReadKey();
            }
        }

        private void CreateConfigFile()
        {
            ConfigFileCreator creator = new ConfigFileCreator();
            creator.Create();
        }

        private Config LoadConfigFile()
        {
            ConfigFileLoader loader = new ConfigFileLoader();
            return loader.Load(Config.ConfigFullPath);
        }
    }
}
