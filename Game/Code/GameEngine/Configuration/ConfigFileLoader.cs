using System.Text.Json;

using ConsoleEngine.InputOutput;

namespace GameName.GameEngine.Configuration
{
    public class ConfigFileLoader : JsonFileLoader<Config>
    {
        public ConfigFileLoader()                              : base() { }
        public ConfigFileLoader(JsonSerializerOptions options) : base(options) { }
    }
}
