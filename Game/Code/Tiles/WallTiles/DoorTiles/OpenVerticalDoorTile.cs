using Engine.DisplaySystem;

namespace Game
{
    public readonly struct OpenVerticalDoorTile : IDoorTile
    {
        #region Constructors
        public OpenVerticalDoorTile(Pixel presenter, bool isPassable)
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
