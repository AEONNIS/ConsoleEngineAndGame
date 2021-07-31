using System.Collections.Generic;

namespace ConsoleEngine
{
    public class Pool<T> where T : new()
    {
        #region Fields
        private readonly Queue<T> _pool = new Queue<T>();
        #endregion

        #region Methods
        public T Extract() => _pool.TryDequeue(out T result) ? result : new T();

        public void Place(T obj) => _pool.Enqueue(obj);
        #endregion
    }
}
