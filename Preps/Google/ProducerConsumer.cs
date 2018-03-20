using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Preps.Google
{
    /// <summary>
    /// Learnt about avoiding busy-wait and controlling access to shared resource(s)
    /// </summary>
    public class ProducerConsumer
    {
        public void Run(int capacity)
        {
            Action<object> produce = b =>
            {
                var buffer = b as Buffer<int>;
                var rand = new Random();
                while (true)
                {
                    int item = rand.Next();
                    buffer.Add(item);
                    Console.WriteLine("Thread {0}: Added {1} to buffer {2}", Thread.CurrentThread.ManagedThreadId, item, buffer.Id);
                }
            };

            Action<object> consume = b =>
            {
                var buffer = b as Buffer<int>;
                while (true)
                {
                    int item = buffer.Remove();
                    Console.WriteLine("Thread {0}: Removed {1} from buffer {2}", Thread.CurrentThread.ManagedThreadId, item, buffer.Id);
                }
            };

            var theBuffer = new Buffer<int>(capacity);

            for (int i = 0; i < 4; i++)
            {
                Task.Factory.StartNew(produce, theBuffer);
                Task.Factory.StartNew(consume, theBuffer);
            }
        }
    }

    public class Buffer<T>
    {
        private Queue<T> buffer;
        private int capacity;
        public string Id { get; private set; }
        public Buffer(int capacity)
        {
            this.buffer = new Queue<T>(capacity);
            this.capacity = capacity;
            Id = $"BUF-{new Random().Next(100, 1000)}";
        }

        public void Add(T item)
        {
            try
            {
                Monitor.Enter(this);
                while (buffer.Count == capacity)
                {
                    Console.WriteLine("Thread {0}: ADD failed: Buffer currently full", Thread.CurrentThread.ManagedThreadId);
                    Monitor.Wait(this);
                }
                buffer.Enqueue(item);
                Monitor.PulseAll(this);
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public T Remove()
        {
            try
            {
                Monitor.Enter(this);
                while (buffer.Count == 0)
                {
                    Console.WriteLine("Thread {0}: REMOVE failed: Buffer currently empty", Thread.CurrentThread.ManagedThreadId);
                    Monitor.Wait(this);
                }
                var item = buffer.Dequeue();
                Monitor.PulseAll(this);
                return item;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        #region These versions are bad due to busy-wait and deadlock concerns

        public void Add_Bad(T item)
        {
            while (true)
            {
                if (buffer.Count < capacity)
                {
                    buffer.Enqueue(item);
                    return;
                }

                Console.WriteLine("Buffer currently full");
            }
        }

        public T Remove_Bad()
        {
            while (true)
            {
                if (buffer.Count > 0)
                {
                    return buffer.Dequeue();
                }

                Console.WriteLine("Buffer currently empty");
            }
        } 
        #endregion
    }

}
