using System;
using System.Text.Json.Serialization;

namespace ConsoleEngine.InputSystem
{
    public interface ICommand
    {
        public int    Id     { get; init; }
        public string Name   { get; init; }
        [JsonIgnore]
        public Action Action { get; init; }

        public void Execute() => Action.Invoke();
    }
}
