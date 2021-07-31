using System.Text.Json.Serialization;

using ConsoleEngine.UpdateSystem;

namespace ConsoleEngine.InputSystem
{
    public class Command
    {
        public CommandId     Id            { get; init; }
        [JsonIgnore]
        public UpdateCommand UpdateCommand { get; init; }

        public void Execute() => UpdateCommand.Assign();
    }
}
