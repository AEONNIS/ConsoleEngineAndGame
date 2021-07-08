namespace Engine.FunctionalTests.DisplaySystem
{
    public interface IMessage
    {
        public void Write(string before = null, string after = null);
    }
}