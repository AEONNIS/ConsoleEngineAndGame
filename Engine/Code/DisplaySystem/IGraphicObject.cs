namespace Engine.DisplaySystem
{
    public interface IGraphicObject
    {
        #region Properties
        public IReadOnlyTexture Texture { get; }
        #endregion
    }
}
