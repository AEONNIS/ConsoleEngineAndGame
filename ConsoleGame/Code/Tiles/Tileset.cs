namespace ConsoleGame
{
    public static class Tileset
    {
        public static class WallTile
        {
            public static IntactWallTile Intact => new IntactWallTile(Pixelset.WallTile.Intact, false);
            public static DamagedWallTile Damaged => new DamagedWallTile(Pixelset.WallTile.Damaged, false);
            public static DestroyedWallTile Destroyed => new DestroyedWallTile(Pixelset.WallTile.Destroyed, true);

            public static class DoorTile
            {
                public static OpenHorizontalDoorTile OpenHorizontal => new OpenHorizontalDoorTile(Pixelset.WallTile.DoorTile.OpenHorizontal, true);
                public static ClosedHorizontalDoorTile ClosedHorizontal => new ClosedHorizontalDoorTile(Pixelset.WallTile.DoorTile.ClosedHorizontal, false);
                public static OpenVerticalDoorTile OpenVertical => new OpenVerticalDoorTile(Pixelset.WallTile.DoorTile.OpenVertical, true);
                public static ClosedVerticalDoorTile ClosedVertical => new ClosedVerticalDoorTile(Pixelset.WallTile.DoorTile.ClosedVertical, false);
            }
        }

        public static class GroundTile
        {
            public static ConcreteFloorTile ConcreteFloor => new ConcreteFloorTile(Pixelset.GroundTile.ConcreteFloor, true);
        }
    }
}
