namespace GameName.Game.Map
{
    public class Tileset
    {
        public Tile[] Tiles { get; init; }

        public override string ToString()
        {
            string result = $"{nameof(Tiles)}:";

            foreach (var tile in Tiles)
                result += $"\n{tile}";

            return result;
        }
    }
}
