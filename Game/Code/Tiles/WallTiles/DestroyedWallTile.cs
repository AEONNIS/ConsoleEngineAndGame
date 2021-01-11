using Engine.DisplaySystem;

namespace Game
{
    public readonly struct DestroyedWallTile : IWallTile
    {
        #region Constructors
        public DestroyedWallTile(Pixel presenter, bool isPassable)
        {
            Presenter = presenter;
            IsPassable = isPassable;
        }
        #endregion

        #region Properties
        public readonly Pixel Presenter { get; init; }
        public readonly bool IsPassable { get; init; }
        #endregion
    }
}
