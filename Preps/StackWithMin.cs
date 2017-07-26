using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class StackWithMin : Stack<int>
    {
        Stack<int> mins = new Stack<int>();
        public new void Push(int item)
        {
            if (item < Min())
            {
                mins.Push(item);
            }
            base.Push(item);
        }

        public new int Pop()
        {
            var popped = base.Pop();
            var min = Min();
            if (popped == min)
            {
                mins.Pop();
            }
            return popped;
        }

        public int Min()
        {
            if (mins.Count == 0) return int.MaxValue;

            return mins.Peek();
        }

        /// <summary>
        /// Sorts this instance so the biggest is on top
        /// </summary>
        public Stack<int> Sort()
        {
            var s2 = new Stack<int>();

            while (Count > 0)
            {
                var temp = Pop();
                while (s2.Count > 0 && s2.Peek() > temp)
                {
                    Push(s2.Pop());
                }
                s2.Push(temp);
            }
            return s2;
        }
    }
}
