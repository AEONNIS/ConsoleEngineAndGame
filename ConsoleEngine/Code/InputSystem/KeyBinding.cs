namespace ConsoleEngine.InputSystem
{
    public class KeyBinding
    {
        public KeyInfo  KeyInfo { get; init; }
        public ICommand Command { get; init; }
    }
}
