using Engine.DisplaySystem;
using Engine.Maths;
using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class Panel : IGraphicObject
    {
        #region ReadonlyFields
        private readonly Texture _texture;
        #endregion

        #region Fields
        private ConsoleKeyInfo _displayKey;
        private ConsoleKeyInfo _hideKey;
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

            InputSystem.Get.KeyPressedInTesting += OnKeyPressedInTesting;
        }
        #endregion

        #region Properties
        public IReadOnlyTexture Texture => _texture;
        #endregion

        #region StaticMethods
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

        #region PublicMethods
        public void SetDisplayKey(ConsoleKeyInfo displayKey) => _displayKey = displayKey;

        public void SetHideKey(ConsoleKeyInfo hideKey) => _hideKey = hideKey;
        #endregion

        #region PrivateMethods
        private void OnKeyPressedInTesting(ConsoleKeyInfo keyInfo)
        {
            if (KeyService.EqualsWithoutChar(keyInfo, _displayKey))
                Screen.Get.Display(this);
            if (KeyService.EqualsWithoutChar(keyInfo, _hideKey))
                Screen.Get.Hide(this);
        }
        #endregion
    }
}
