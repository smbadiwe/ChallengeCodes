using NUnit.Framework;
using Preps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepTests
{
    [TestFixture]
    public class StackAsLinkedListTests
    {
        [Test]
        public void TestStack_LinkedList_Impl()
        {
            var stack = new StackAsLinkedList<int>();
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            Assert.AreEqual(stack.Count, 3);
            var val = stack.Peek();
            Assert.AreEqual(val, 7);
            val = stack.Pop();
            Assert.AreEqual(val, 7);
            Assert.AreEqual(stack.Count, 2);
            val = stack.Pop();
            Assert.AreEqual(val, 6);
            val = stack.Pop();
            Assert.AreEqual(val, 5);
            Assert.Throws<InvalidOperationException>(() => { stack.Pop(); });
        }
    }
}
