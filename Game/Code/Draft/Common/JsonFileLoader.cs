using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Draft.Common
{
    public abstract class JsonFileLoader<T> where T : class
    {
        private readonly JsonSerializerOptions _options = null;

        protected JsonFileLoader(JsonSerializerOptions options) => _options = options;
        protected JsonFileLoader()                              => _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        public T Load(string path)
        {
            string content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(content, _options);
        }
    }
}
