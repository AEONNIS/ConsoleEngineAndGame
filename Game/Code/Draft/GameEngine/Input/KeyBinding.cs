using System;
using System.Text.Json.Serialization;

namespace Draft.GameEngine.Input
{
    public class KeyBinding
    {
        public KeyInfo KeyInfo { get; init; }
        [JsonIgnore]
        public Action  Action  { get; init; }
    }
}
