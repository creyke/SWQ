using System;
using System.Collections.Generic;
using System.Linq;

namespace SWQ
{
    public class SlidingWindowQueue<T>
        where T : IComparable
    {
        private readonly int capacity = -1;
        private List<QueueItem> list;

        public int Count => list.Count;

        public SlidingWindowQueue()
        {
            list = new List<QueueItem>();
        }

        public SlidingWindowQueue(int capacity)
        {
            this.capacity = capacity;
            list = new List<QueueItem>(capacity);
        }

        public void Enqueue(T item)
        {
            if (list.Count == capacity)
            {
                list.RemoveAt(0);
            }

            list.Add(new QueueItem(item));
        }

        public void Sort()
        {
            list = new List<QueueItem>(list.OrderBy(x => x));
        }

        public T[] ToArray()
        {
            return list.Select(x => x.Item).ToArray();
        }

        private class QueueItem : IComparable
        {
            public QueueItem(T item)
            {
                Item = item;
            }

            public T Item { get; set; }

            public int CompareTo(object obj)
            {
                return Item.CompareTo(((QueueItem)obj).Item);
            }
        }
    }
}
