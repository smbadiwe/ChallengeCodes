using System.Collections.Generic;

namespace Preps
{
    public class QueueUsingOneStack
    {
        private Stack<int> inStack;
        public QueueUsingOneStack()
        {
            inStack = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            if (inStack.Count > 0)
            {
                   var top = inStack.Pop();
                Enqueue(item);
                inStack.Push(top);
            }
            else
            {
                inStack.Push(item);
            }
        }

        public int Dequeue()
        {
            return inStack.Pop();
        }

        public int Peek()
        {
            return inStack.Peek();
        }
    }
}
