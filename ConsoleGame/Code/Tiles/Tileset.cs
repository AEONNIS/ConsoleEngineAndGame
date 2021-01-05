namespace ConsoleGame
{
    public static class Tileset
    {
        public static class WallTile
        {
            public static ITile Intact => new IntactWallTile(Pixelset.WallTile.Intact, false);
            public static ITile Damaged => new DamagedWallTile(Pixelset.WallTile.Damaged, false);
            public static ITile Destroyed => new DestroyedWallTile(Pixelset.WallTile.Destroyed, true);

            public static class DoorTile
            {
                public static ITile OpenHorizontal => new OpenHorizontalDoorTile(Pixelset.WallTile.DoorTile.OpenHorizontal, true);
                public static ITile ClosedHorizontal => new ClosedHorizontalDoorTile(Pixelset.WallTile.DoorTile.ClosedHorizontal, false);
                public static ITile OpenVertical => new OpenVerticalDoorTile(Pixelset.WallTile.DoorTile.OpenVertical, true);
                public static ITile ClosedVertical => new ClosedVerticalDoorTile(Pixelset.WallTile.DoorTile.ClosedVertical, false);
            }
        }

        public static class GroundTile
        {
            public static ITile ConcreteFloor => new ConcreteFloorTile(Pixelset.GroundTile.ConcreteFloor, true);
        }
    }
}
