using Engine.Maths;
using System;

namespace Game
{
    public readonly struct Wall
    {
        #region Constructors
        private Wall(in Rectangle rectangle, PlacedTile<IWallTile>[] placedWallTiles, PlacedTile<IDoorTile>[] placedDoorTiles)
        {
            Rectangle = rectangle;
            PlacedWallTiles = placedWallTiles;
            PlacedDoorTiles = placedDoorTiles;
        }
        #endregion

        #region Properties
        public readonly Rectangle Rectangle { get; }
        public readonly PlacedTile<IWallTile>[] PlacedWallTiles { get; }
        public readonly PlacedTile<IDoorTile>[] PlacedDoorTiles { get; }
        #endregion

        #region StaticMethods
        public static Wall CreateHorizontal(Vector2Int leftEdgePosition, int length, int[] doorsXCoordinates)
        {
            PlacedTile<IWallTile>[] placedWallTiles = new PlacedTile<IWallTile>[length];

            for (int i = 0; i < length; i++)
            {
                Vector2Int position = leftEdgePosition.AddToX(i);
                IWallTile tile = Array.Exists(doorsXCoordinates, x => x == i) ? Tileset.WallTile.DoorTile.ClosedHorizontal : Tileset.WallTile.Intact;
                placedWallTiles[i] = new PlacedTile<IWallTile>(position, tile);
            }

            return new Wall(); //new Wall(new Rectangle(leftEdgePosition, new Vector2Int(length, 1)), placedWallTiles);
        }

        public static Wall CreateVertical(Vector2Int topEdgePosition, int height, int[] doorsYCoordinates)
        {
            PlacedTile<IWallTile>[] placedWallTiles = new PlacedTile<IWallTile>[height];

            for (int i = 0; i < height; i++)
            {
                Vector2Int position = topEdgePosition.AddToY(i);
                IWallTile tile = Array.Exists(doorsYCoordinates, y => y == i) ? Tileset.WallTile.DoorTile.ClosedVertical : Tileset.WallTile.Intact;
                placedWallTiles[i] = new PlacedTile<IWallTile>(position, tile);
            }

            return new Wall(); //new Wall(new Rectangle(topEdgePosition, new Vector2Int(1, height)), placedWallTiles);
        }
        #endregion

        #region Methods

        #endregion
    }
}
