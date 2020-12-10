namespace ConsoleEngine.Maths
{
    public struct Rectangle
    {
        #region Constructors
        public Rectangle(Vector2Int topLeftAngle, Vector2Int size)
        {
            TopLeftAngle = topLeftAngle;
            Size = size;
        }
        #endregion

        #region Properties
        public Vector2Int Size { get; set; }
        public Vector2Int TopLeftAngle { get; set; }
        public Vector2Int TopRightAngle => TopLeftAngle.AddToX(Size.X - 1);
        public Vector2Int BottomLeftAngle => TopLeftAngle.AddToY(Size.Y - 1);
        public Vector2Int BottomRightAngle => TopLeftAngle + Size - 1;
        #endregion

        #region Operators
        public static bool operator ==(Rectangle a, Rectangle b) => a.Size == b.Size && a.TopLeftAngle == b.TopLeftAngle;
        public static bool operator !=(Rectangle a, Rectangle b) => a.Size != b.Size || a.TopLeftAngle != b.TopLeftAngle;
        #endregion

        #region Methods
        public bool Contains(Vector2Int point) => TopLeftAngle >= point && BottomRightAngle <= point;

        public override string ToString() => $"Sz:{Size}, TLA:{TopLeftAngle}";
        #endregion
    }
}
