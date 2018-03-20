using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    /// <summary>
    /// Best: O(nlogn)
    /// Avg: O(nlogn)
    /// Worst: O(nlogn)
    /// Space: O(n)
    /// 
    /// Remarks:
    /// This is a stable sort
    /// </summary>
    public class MergeSort
    {
        ///// <summary>
        ///// Sorts the specified list. We assume singly-linked list
        ///// </summary>
        ///// <param name="list">The list.</param>
        //public void Sort(LinkedList<int> list)
        //{
        //    Sort(list);
        //}

        /// <summary>
        /// Sorts the specified head. We assume singly-linked list
        /// </summary>
        /// <param name="head">The head.</param>
        public LinkedListNode<int> Sort(LinkedListNode<int> head)
        {
            if (head == null || head.Next == null) return head;
            
            // get middle node
            var midNode = GetMiddleNode(head);

            // split list into two
            var rightList = midNode.Next;
            midNode.Next = null;
            
            var firstHalf = Sort(head);
            var secondHalf = Sort(rightList);
            return MergeSortedLinkedList(firstHalf, secondHalf);
        }

        private LinkedListNode<int> MergeSortedLinkedList(LinkedListNode<int> first, LinkedListNode<int> second)
        {
            if (first == null) return second;
            if (second == null) return first;

            // We would be always adding nodes from the second list to the first one
            // If second node head data is less than first one exchange it
            if (second.Value < first.Value)
            {
                var t = first;
                first = second;
                second = t;
            }
            var head = first; //Assign head to first node
                              //We need to assign head to first because first will continuosly be changing and so we want to store the beginning of list in head.
            while ((first.Next != null) && (second != null))
            {
                if (first.Value < second.Value)
                {
                    first = first.Next; // Iterate over the first node
                }
                else
                {
                    var n = first.Next;
                    var t = second.Next;
                    first.Next = second;
                    second.Next = n;
                    first = first.Next;
                    second = t;
                }
            }
            if (second != null && first.Next == null) // Means there are still some elements in second
            {
                first.Next = second;
            }
            return head;

            // Recursive solution that did not make sense to me

            //LinkedListNode<int> result = null;
            ///* Pick either first or second, and recur */
            //if (first.Value > second.Value)
            //{
            //    result = second;
            //    result.Next = MergeSortedLinkedList(first, second.Next);
            //}
            //else
            //{
            //    result = first;
            //    result.Next = MergeSortedLinkedList(first.Next, second);
            //}
            //return result;
        }

        public LinkedListNode<int> GetMiddleNode(LinkedListNode<int> head)
        {
            if (head == null || head.Next == null) return head;

            LinkedListNode<int> fast = head, slow = head;
            // when the number of elements are even, this check is to make sure the
            // lower of the two mid values are returned
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                if (fast != null) // this check is very important
                {
                    slow = slow.Next;
                }
            }
            return slow;
        }

        public void Sort(int[] arr)
        {
            if (arr == null || arr.Length < 2) return;
            var temp = new int[arr.Length];
            Sort(arr, temp, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int[] temp, int low, int high)
        {
            if (low < high)
            {
                var mid = low + (high - low) / 2;
                Sort(arr, temp, 0, mid);
                Console.WriteLine("Sort 1 - Arr: {0}.", arr.PrintList());
                Console.WriteLine("Sort 1 - Temp: {0}.", temp.PrintList());
                Sort(arr, temp, mid + 1, high);
                Console.WriteLine("Sort 2 - Arr: {0}.", arr.PrintList());
                Console.WriteLine("Sort 2 - Temp: {0}.", temp.PrintList());
                Merge(arr, temp, low, mid + 1, high);
                Console.WriteLine("Merge - Arr: {0}.", arr.PrintList());
                Console.WriteLine("Merge - Temp: {0}.", temp.PrintList());
            }
        }

        private void Merge(int[] arr, int[] temp, int lBegin, int rBegin, int rEnd)
        {
            int lEnd = rBegin - 1;
            int currentLength = rEnd - lBegin + 1;
            int k = lBegin;

            // Merge the temp arrays
            while (lBegin <= lEnd && rBegin <= rEnd)
            {
                if (arr[lBegin] <= arr[rBegin])
                {
                    temp[k++] = arr[lBegin++];
                }
                else
                {
                    temp[k++] = arr[rBegin++];
                }
            }

            // Copy rest of first half
            while (lBegin <= lEnd)
            {
                temp[k++] = arr[lBegin++];
            }

            // Copy rest of right half
            while (rBegin <= rEnd)
            {
                temp[k++] = arr[rBegin++];
            }

            // Copy temp back to arr
            for (int i = 0; i < currentLength; i++, rEnd--)
            {
                arr[rEnd] = temp[rEnd];
            }
        }
    }
}
