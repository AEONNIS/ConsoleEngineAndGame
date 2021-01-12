using Engine.DisplaySystem;
using Engine.Maths;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class Panel : IGraphicObject
    {
        #region Fields
        private readonly Texture _texture;
        #endregion

        #region Constructors
        public Panel(in Rectangle rectangle, in Pixel filler, string name)
        {
            _texture = new Texture(rectangle, filler);

            for (int i = 0; i < name.Length; i++)
            {
                var position = rectangle.TopLeftAngle.AddToX(i);
                var pixel = new Pixel(filler.BackgroundColor, filler.Foreground.Color, name[i]);
                _texture.AddOrReplace(position, pixel);
            }
        }
        #endregion

        #region Properties
        public IReadOnlyTexture Texture => _texture;
        #endregion

        #region PublicStaticMethods
        public static Panel CreateRandomPanelIn(in Rectangle limiter, in Vector2Int minSize, in Pixel filler, string name)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var size = new Vector2Int(random.Next(minSize.X, limiter.Size.X + 1), random.Next(minSize.Y, limiter.Size.Y + 1));
            var topLeftAngle = new Vector2Int(random.Next(limiter.TopLeftAngle.X, limiter.TopRightAngle.X - size.X + 1),
                                              random.Next(limiter.TopLeftAngle.Y, limiter.BottomLeftAngle.Y - size.Y + 1));
            var rectangle = new Rectangle(topLeftAngle, size);

            return new Panel(rectangle, filler, name);
        }
        #endregion
    }
}
