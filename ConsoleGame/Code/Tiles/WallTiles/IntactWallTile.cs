using ConsoleEngine.DisplaySystem;

namespace ConsoleGame
{
    public readonly struct IntactWallTile : IWallTile
    {
        #region Constructors
        public IntactWallTile(Pixel presenter, bool isPassable)
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
