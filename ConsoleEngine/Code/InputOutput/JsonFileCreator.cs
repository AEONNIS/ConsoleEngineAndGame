using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleEngine.InputOutput
{
    public abstract class JsonFileCreator<T> where T : class
    {
        private readonly JsonSerializerOptions _options = null;

        protected JsonFileCreator(JsonSerializerOptions options) => _options = options;
        protected JsonFileCreator()                              => _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters    = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        protected void CreateFile(string path, T source)
        {
            string resultContent = JsonSerializer.Serialize(source, _options);
            File.WriteAllText(path, resultContent);
        }
    }
}
