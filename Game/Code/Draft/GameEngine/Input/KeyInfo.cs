using System;
using System.Text.Json.Serialization;

namespace Draft.GameEngine.Input
{
    public readonly struct KeyInfo : IEquatable<KeyInfo>
    {
        private readonly ConsoleKeyInfo _consoleKeyInfo;

        [JsonConstructor]
        public KeyInfo(ConsoleKey key, bool shift, bool alt, bool control) => _consoleKeyInfo = new ConsoleKeyInfo(default, key, shift, alt, control);

        public ConsoleKey Key     => _consoleKeyInfo.Key;
        public bool       Shift   => (_consoleKeyInfo.Modifiers & ConsoleModifiers.Shift)   != 0;
        public bool       Alt     => (_consoleKeyInfo.Modifiers & ConsoleModifiers.Alt)     != 0;
        public bool       Control => (_consoleKeyInfo.Modifiers & ConsoleModifiers.Control) != 0;

        public static bool operator ==(KeyInfo left, KeyInfo right) =>  left.Equals(right);
        public static bool operator !=(KeyInfo left, KeyInfo right) => !left.Equals(right);

        public override bool Equals(object obj)    => obj is KeyInfo info && Equals(info);
        public          bool Equals(KeyInfo other) =>
            _consoleKeyInfo.Key       == other._consoleKeyInfo.Key &&
            _consoleKeyInfo.Modifiers == other._consoleKeyInfo.Modifiers;

        public override int GetHashCode() => HashCode.Combine(_consoleKeyInfo.Key, _consoleKeyInfo.Modifiers);
    }
}
