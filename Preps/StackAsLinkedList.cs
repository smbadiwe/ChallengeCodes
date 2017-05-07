using System;

namespace Preps
{
    /// <summary>
    /// Linked-list implementation of stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackAsLinkedList<T>
    {
        private LinkedListNode<T> head;
        public StackAsLinkedList()
        {
            head = null;
        }

        public int Count { get; private set; }
        public T Pop()
        {
            if (head == null || Count <= 0)
            {
                throw new InvalidOperationException();
            }
            var valToPop = head.Value;
            head = head.Next;
            Count--;
            return valToPop;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            return head.Value;
        }

        public void Push(T data)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(data);
            }
            else
            {
                var newHead = new LinkedListNode<T>(data);
                newHead.Next = head;
                head = newHead;
            }
            Count++;
        }
    }
}
