using System.Text.Json;

using Draft.Common;

namespace Draft.GameEngine.Configuration
{
    public class ConfigFileLoader : JsonFileLoader<Config>
    {
        public ConfigFileLoader()                              : base() { }
        public ConfigFileLoader(JsonSerializerOptions options) : base(options) { }
    }
}
