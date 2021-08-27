using System;
using Xunit;

namespace SWQ.Tests
{
    public class SlidingWindowQueueTests
    {
        [Fact]
        public void CanCreate()
        {
            var queue = new SlidingWindowQueue<int>();
        }

        [Fact]
        public void CanEnqueue()
        {
            var queue = new SlidingWindowQueue<int>();
            
            queue.Enqueue(0);

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void CanSetCapacity()
        {
            var queue = new SlidingWindowQueue<int>(1);
            
            queue.Enqueue(0);
            queue.Enqueue(1);

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void CanSort()
        {
            var queue = new SlidingWindowQueue<M>();

            queue.Enqueue(new M(1));
            queue.Enqueue(new M(2));
            queue.Enqueue(new M(0));

            queue.Sort();

            Assert.Equal(new[] { new M(0), new M(1), new M(2) }, queue.ToArray());
        }

        private class M : IComparable
        {
            public M(int id)
            {
                Id = id;
            }

            public int Id { get; }

            public int CompareTo(object obj)
            {
                return Id.CompareTo(((M)obj).Id);
            }
        }
    }
}
