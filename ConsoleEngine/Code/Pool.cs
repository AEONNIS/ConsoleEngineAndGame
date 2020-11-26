using System.Collections.Generic;

namespace ConsoleEngine.Core
{
    public class Pool<T> where T : new()
    {
        #region Fields
        private readonly Queue<T> _pool = new Queue<T>();
        #endregion

        #region Methods
        public T Get() => _pool.TryDequeue(out T result) ? result : new T();

        public void Return(T obj) => _pool.Enqueue(obj);
        #endregion
    }
}
