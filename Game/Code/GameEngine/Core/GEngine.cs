using System;

using ConsoleEngine.Core;

using GameName.Game.Map;
using GameName.GameEngine.Configuration;
using GameName.GameEngine.InputOutput.JsonFileCreators;
using GameName.GameEngine.InputOutput.JsonFileLoaders;

namespace GameName.GameEngine.Core
{
    public class GEngine : IGameEngine
    {
        private readonly Config              _config       = null;
        private readonly AllJsonFilesCreator _jsonsCreator = null;
        private readonly AllJsonFilesLoader  _jsonsLoader  = null;

        public Tileset Tileset => _jsonsLoader.Tileset;

        public GEngine()
        {
            //CreateConfigFile();
            _config = LoadConfigFile();

            //_jsonsCreator = new AllJsonFilesCreator(_config);
            //_jsonsCreator.CreateAll();

            //_jsonsLoader = new AllJsonFilesLoader(_config);
            //_jsonsLoader.LoadAll();
        }

        public void Start()
        {
        }

        public ConsoleKeyInfo Input()
        {
            return default;
        }

        public void Update()
        {
        }

        public void Render()
        {
        }

        public void Close()
        {
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
