using System.Collections.Generic;

namespace Preps
{
    public class QueueUsingTwoStacks
    {
        private Stack<int> inStack;
        private Stack<int> outStack;
        public QueueUsingTwoStacks()
        {
            inStack = new Stack<int>();
            outStack = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            inStack.Push(item);
        }

        public int Dequeue()
        {
            if (outStack.Count == 0)
            {
                while (inStack.Count > 0)
                {
                    outStack.Push(inStack.Pop());
                }
            }
            return outStack.Pop();
        }

        public int Peek()
        {
            if (outStack.Count == 0)
            {
                while (inStack.Count > 0)
                {
                    outStack.Push(inStack.Pop());
                }
            }
            return outStack.Peek();
        }
    }
}
