namespace ConsoleEngine
{
    public interface IVisible
    {
        public bool IsVisible { get; }

        public void SetVisibility(bool visibility);
    }
}
