using NUnit.Framework;
using Preps;
using System;

namespace PrepTests
{
    [TestFixture]
    public class QueueAsLinkedListTests
    {
        [Test]
        public void TestQueue_LinkedList_Impl()
        {
            var queue = new QueueAsLinkedList<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            Assert.AreEqual(queue.Count, 3);
            var val = queue.Dequeue();
            Assert.AreEqual(val, 5);
            Assert.AreEqual(queue.Count, 2);
            val = queue.Dequeue();
            Assert.AreEqual(val, 6);
            val = queue.Dequeue();
            Assert.AreEqual(val, 7);
            Assert.Throws<InvalidOperationException>(() => { queue.Dequeue(); });
        }
    }
}
