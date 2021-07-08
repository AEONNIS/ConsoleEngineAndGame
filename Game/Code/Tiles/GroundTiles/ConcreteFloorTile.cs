using Engine.DisplaySystem;

namespace Game
{
    public readonly struct ConcreteFloorTile : IGroundTile
    {
        #region Constructors
        public ConcreteFloorTile(Pixel presenter, bool isPassable)
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
