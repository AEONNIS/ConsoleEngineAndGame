namespace ConsoleEngine.Core.DisplaySystem
{
    public class ScreenBuffer
    {
        #region Fields
        private Texture _total;
        private Texture _delta;
        #endregion

        #region Properties   
        public Texture Texture => _delta.IsEmpty ? _total : _delta;
        #endregion

        #region Methods
        public void Init(Texture texture) => _total = new Texture(texture.Pixels);

        public void Overlap(Texture covering) => _delta += _total.Select(true, covering);

        public void ClearDelta() => _delta.Clear();

        public void Clear()
        {
            _total.Clear();
            _delta.Clear();
        }
        #endregion
    }
}
