using Engine.Maths;
using System;

namespace Engine.DisplaySystem.IntegrationTesting
{
    public class Panel : IGraphicObject
    {
        #region Fields
        private readonly Texture _texture;
        #endregion

        #region Constructors
        public Panel(in Rectangle rectangle, in Pixel filling) => _texture = new Texture(rectangle, filling);
        #endregion

        #region Properties
        public IReadOnlyTexture Texture => _texture;
        #endregion

        #region PublicStaticMethods
        public static Panel CreateRandomPanelIn(in Rectangle limiter, in Pixel filling)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var size = new Vector2Int(random.Next(1, limiter.Size.X), random.Next(1, limiter.Size.Y));
            var topLeftAngle = new Vector2Int(random.Next(limiter.TopLeftAngle.X, limiter.TopRightAngle.X - size.X),
                                              random.Next(limiter.TopLeftAngle.Y, limiter.BottomLeftAngle.Y - size.Y));
            var rectangle = new Rectangle(topLeftAngle, size);

            return new Panel(rectangle, filling);
        }
        #endregion

        #region PublicMethods
        public void Display() => Screen.Get().Display(this);

        public void Hide() => Screen.Get().Hide(this);
        #endregion
    }
}
