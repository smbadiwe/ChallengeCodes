using System.Collections.Generic;
using System.Linq;

namespace Preps
{
    public class LinkedListQs
    {
        //public static LinkedListNode<int> MergerSorted(LinkedListNode<int> sortedSet1, LinkedListNode<int> sortedSet2)
        //{
        //    var current1 = sortedSet1;
        //    var current2 = sortedSet2;
        //    while (current1 != null)
        //    {
        //        if (current1.Value > current2.Value)
        //        {

        //        }
        //        else if (current1.Value < current2.Value)
        //        {
        //        }
        //    }
        //}

        /// <summary>
        /// Return true if the linkedlist has cycle, as in, if a node is visited more than once
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool hasCycle(LinkedListNode<int> head)
        {
            if (head == null) return false;

            LinkedListNode<int> slow = head;
            LinkedListNode<int> fast = head.Next;
            //Floyd's cycle-finding algorithm:
            //If a loop exists, then the fast pointer will eventually end up behind the slow pointer. 
            // The fast pointer will then catch up to the slow pointer, detecting the loop. 
            // This will always happen, no matter the size of the loop.
            while (slow != fast)
            {
                if (fast == null || fast.Next == null) return false;

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return true;
        }

        public static LinkedListNode<int> SortListOf0s1sAnd2s(LinkedListNode<int> list)
        {
            int n0 = 0, n1 = 0, n2 = 0;
            var current = list;
            while (current != null)
            {
                switch (current.Value)
                {
                    case 0:
                        n0++;
                        break;
                    case 1:
                        n1++;
                        break;
                    case 2:
                        n2++;
                        break;
                }
                current = current.Next;
            }

            // rebuild
            current = new LinkedListNode<int>(0);
            var temp = current;
            int i = n0;
            while (i > 0)
            {
                temp.Next = new LinkedListNode<int>(0);
                temp = temp.Next;
                i--;
            }
            i = n1;
            while (i > 0)
            {
                temp.Next = new LinkedListNode<int>(1);
                temp = temp.Next;
                i--;
            }
            i = n2;
            while (i > 0)
            {
                temp.Next = new LinkedListNode<int>(2);
                temp = temp.Next;
                i--;
            }
            return current;
        }

        public static LinkedListNode<T> Union<T>(LinkedListNode<T> set1, LinkedListNode<T> set2)
        {
            var table = new HashSet<T>();
            table.Add(set1.Value);
            var current = set1.Next;
            while (current != null)
            {
                table.Add(current.Value);
                current = current.Next;
            }

            // Set 2
            current = set2;
            while (current != null)
            {
                table.Add(current.Value);
                current = current.Next;
            }

            LinkedListNode<T> newHead, next, result = null;
            result = newHead = new LinkedListNode<T>(table.ElementAt(0));
            for (int i = 1; i < table.Count; i++)
            {
                next = new LinkedListNode<T>(table.ElementAt(i));
                newHead.Next = next; // this updates 'result.Next'
                newHead = next;
            }
            return result;
        }

        public static LinkedListNode<T> Intersect<T>(LinkedListNode<T> set1, LinkedListNode<T> set2)
        {
            var table = new HashSet<T>();
            table.Add(set1.Value);
            var current = set1.Next;
            while (current != null)
            {
                table.Add(current.Value);
                current = current.Next;
            }

            // Set 2
            LinkedListNode<T> next, newHead = null, result = null;
            current = set2;
            while (current != null)
            {
                if (table.Contains(current.Value))
                {
                    if (newHead == null)
                    {
                        result = newHead = new LinkedListNode<T>(current.Value);
                    }
                    else
                    {
                        next = new LinkedListNode<T>(current.Value);
                        newHead.Next = next; // this updates 'result.Next'
                        newHead = next;
                    }
                }
                current = current.Next;
            }
            return result;
        }

        public static LinkedListNode<T> GetMiddleNode<T>(LinkedListNode<T> head)
        {
            if (head == null || head.Next == null) return head;

            LinkedListNode<T> fast = head, slow = head;
            // when the number of elements are even, this check is to make sure the
            // lower of the two mid values are returned
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        /// <summary>
        /// Function to reverse the linked list. Note that this function may change the head
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        public static LinkedListNode<T> Reverse<T>(LinkedListNode<T> head)
        {
            if (head == null || head.Next == null) return head;

            LinkedListNode<T> prev = null, next = null;
            LinkedListNode<T> current = head;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        /// <summary>
        /// This method takes O(n) time; and O(1) extra space. If <paramref name="useStack"/> is true, space is O(n).
        /// 1) Get the middle of the linked list.
        /// 2) Reverse the second half of the linked list.
        /// 3) Check if the first half and second half are identical.
        /// 4) Construct the original linked list by reversing the second half again and attaching it back to the first half
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedList"></param>
        /// <param name="useStack"></param>
        /// <returns></returns>
        public static bool IsPalindrome<T>(LinkedListNode<T> linkedList, bool useStack = false)
        {
            if (linkedList == null || linkedList.Next == null) return true;

            if (useStack)
            {
                var stack = new Stack<T>();
                var current = linkedList;
                while (current != null)
                {
                    stack.Push(current.Value);
                    current = current.Next;
                }
                current = linkedList;
                while (current != null)
                {
                    if (current.Value.Equals(stack.Pop()))
                    {
                        current = current.Next;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                var mid = GetMiddleNode(linkedList);
                var second = Reverse(mid.Next);
                LinkedListNode<T> first = linkedList, sechead = second;
                mid.Next = null;
                bool isPal = true;
                while (first != null && second != null)
                {
                    if (first.Value.Equals(second.Value))
                    {
                        first = first.Next;
                        second = second.Next;
                    }
                    else
                    {
                        isPal = false;
                        break;
                    }
                }
                mid.Next = Reverse(sechead);
                return isPal;
            }
        }
    }
}
