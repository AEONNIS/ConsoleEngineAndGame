using ConsoleEngine.DisplaySystem;

namespace ConsoleGame
{
    public readonly struct ClosedVerticalDoorTile : IDoorTile
    {
        #region Constructors
        public ClosedVerticalDoorTile(Pixel presenter, bool isPassable)
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
