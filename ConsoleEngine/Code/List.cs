using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine
{
    public class List<I, O> where I : class, IContainer<O>, IVisible
    {
        #region Fields
        private readonly LinkedList<I> _list = new LinkedList<I>();
        #endregion

        #region Properties
        public IReadOnlyCollection<I> AllCollection => _list;
        #endregion

        #region Methods
        public bool Contains(O obj)
        {
            foreach (var item in _list)
            {
                if (item.Contains(obj))
                    return true;
            }

            return false;
        }

        public void AddFirst(I item) => _list.AddFirst(item);
        public void AddFirst(LinkedListNode<I> itemNode) => _list.AddFirst(itemNode);

        public I FindItem(O obj)
        {
            foreach (var item in _list)
            {
                if (item.Contains(obj))
                    return item;
            }

            return null;
        }

        public IEnumerable<I> SelectItemsBefore(O obj) => _list.TakeWhile(item => item.Contains(obj) == false && item.IsVisible);

        public IEnumerable<I> SelectItemsAfter(O obj) => _list.SkipWhile(item => item.Contains(obj) && item.IsVisible).Skip(1);

        public LinkedListNode<I> ExtractItemNode(O obj)
        {
            LinkedListNode<I> result = null;

            foreach (var item in _list)
            {
                if (item.Contains(obj))
                    result = _list.Find(item);
            }

            _list.Remove(result);
            return result;
        }
        #endregion
    }
}
