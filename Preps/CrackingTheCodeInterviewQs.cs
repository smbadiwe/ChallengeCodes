using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class CrackingTheCodeInterviewQs
    {
        /// <summary>
        /// Failed test. I don't know why
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        public static void DeleteMiddleNode<T>(LinkedListNode<T> head)
        {
            if (head == null) return;

            LinkedListNode<T> fast = head, mid = head;
            // when the number of elements are even, this check is to make sure the
            // lower of the two mid values are returned
            while (fast != null && fast.Next != null)
            {
                mid = mid.Next;
                fast = fast.Next.Next;
            }
            var next = mid.Next;
            mid.Value = next.Value;
            mid.Next = next.Next;
        }

        /// <summary>
        /// Sorting can be performed with one more stack The idea is to pull an item from the original
        /// stack and push it on the other stack If pushing this item would violate the sort order of the
        /// new stack, we need to remove enough items from it so that it’s possible to push the new
        /// item Since the items we removed are on the original stack, we’re back where we started
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Stack<int> SortStack(Stack<int> s)
        {
            var r = new Stack<int>();
            while (s.Count > 0)
            {
                // pull an item from the original stack
                var temp = s.Pop();
                // If pushing this item would violate the sort order of the new stack...
                // we need to remove enough items from it so that it’s possible to push the new
                // item
                while (r.Count > 0 && r.Peek() > temp)
                {
                    s.Push(r.Pop());
                }
                r.Push(temp);
            }
            return r;
        }
        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row 
        /// and column is set to 0
        /// </summary>
        /// <param name="array"></param>
        public void SetZeros(int[][] array)
        {
            var rowSize = array.Length;
            var colSize = array[0].Length;
            var rowsWithZero = new bool[rowSize];
            var colsWithZero = new bool[colSize];
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if (array[i][j] == 0)
                    {
                        rowsWithZero[i] = true;
                        colsWithZero[j] = true;
                    }
                }
            }
            // A better way
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if (rowsWithZero[i] || colsWithZero[j])
                    {
                        array[i][j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Assumptions: str1 and str2 are lowercase characters a-z.
        /// An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        /// For example, the word anagram can be rearranged into "naga ram".
        /// O(n). Don't use a dictionary; it'll be slower.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool AreAnagrams(string str1, string str2)
        {
            if (str1 == str2) return true;
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2)) return false;
            if (str1.Length != str2.Length) return false;

            var chars = new int[26];
            for (int i = 0; i < str1.Length; i++)
            {
                chars[str1[i] - 'a']++;
                chars[str2[i] - 'a']--;
            }
            return chars.All(x => x == 0);
        }
    }
}
