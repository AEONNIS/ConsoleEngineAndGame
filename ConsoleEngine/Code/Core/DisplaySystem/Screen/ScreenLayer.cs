﻿namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private string _name;
        private Texture _total;
        private Texture _delta;
        #endregion

        #region Properties
        public string Name => _name;
        public Texture Texture => _delta.IsEmpty ? _total : _delta;
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            _name = graphicObject.Name;
            _total = new Texture(graphicObject.Texture.Pixels);
        }

        public void Overlap(Texture covering) => _delta += _total.Select(true, covering);

        public void ClearDelta() => _delta.Clear();

        public void Clear()
        {
            _name = string.Empty;
            _total.Clear();
            _delta.Clear();
        }
        #endregion
    }
}
