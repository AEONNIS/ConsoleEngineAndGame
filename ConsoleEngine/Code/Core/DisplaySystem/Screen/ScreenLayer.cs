namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenLayer
    {
        #region Fields
        private int _order;
        private string _name;
        private ScreenBuffer _buffer;
        #endregion

        #region Properties
        public int Order => _order;
        public string Name => _name;
        public Texture Texture => _buffer.Texture;
        #endregion

        #region Methods
        public void Init(IGraphicObject graphicObject)
        {
            _order = 0;
            _name = graphicObject.Name;
            _buffer.Init(graphicObject.Texture);
        }

        public void Overlap(Texture covering)
        {
            _order++;
            _buffer.Overlap(covering);
        }

        public void ClearBufferDelta() => _buffer.ClearDelta();

        public void Clear()
        {
            _order = -1;
            _name = string.Empty;
            _buffer.Clear();
        }
        #endregion
    }
}
