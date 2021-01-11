using Engine.Maths;

namespace Game
{
    public readonly struct PlacedTile<T> where T : ITile
    {
        #region Constructors
        public PlacedTile(Vector2Int position, T tile)
        {
            Position = position;
            Tile = tile;
        }
        #endregion

        #region Properties
        public Vector2Int Position { get; init; }
        public T Tile { get; init; }
        #endregion
    }
}
