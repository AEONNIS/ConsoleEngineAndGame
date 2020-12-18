namespace ConsoleEngine
{
    public interface IContainer<O>
    {
        public bool Contains(O obj);
    }
}
