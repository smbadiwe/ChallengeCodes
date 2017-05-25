using System;

namespace Preps
{
    /// <summary>
    /// Linked-list implementation of queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueUsingLinkedList<T>
    {
        private LinkedListNode<T> head;
        public QueueUsingLinkedList()
        {
            head = null;
        }

        public int Count { get; private set; }
        public void Enqueue(T data)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(data);
            }
            else
            {
                var next = new LinkedListNode<T>(data);
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = next;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (head == null || Count <= 0)
            {
                throw new InvalidOperationException();
            }
            var val = head.Value;
            head = head.Next;
            Count--;
            return val;
        }
    }
}
