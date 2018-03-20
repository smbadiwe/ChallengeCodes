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
    /// Worst: O(n^2)
    /// Space: O(logn)
    /// 
    /// Remarks:
    /// A divide & conquer sort. It's non-stable. 
    /// quicksort exhibits poor performance for inputs that contain many repeated elements.
    /// </summary>
    public class QuickSort
    {
        public void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Lomuto
                int pivot = LomutoPartition(arr, low, high);
                Sort(arr, low, pivot - 1);
                Sort(arr, pivot + 1, high);
                //// Hoare
                //int pivot = HoarePartition(arr, low, high);
                //Sort(arr, low, pivot);
                //Sort(arr, pivot + 1, high);
            }
        }

        /// <summary>
        /// Partitions the specified arr using Lomuto partition scheme.
        /// This scheme is more efficient than Lomuto's partition scheme because it does three times fewer swaps on average, and it creates efficient partitions even when all values are equal.
        /// This scheme degrades to O(n2) when the array is already in order.
        /// he partitioning algorithm guarantees lo ≤ p ≤ h-1 which implies both resulting partitions are non-empty, hence there's no risk of infinite recursion.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <returns></returns>
        private int HoarePartition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1;
            int j = high + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (arr[i] < pivot);

                do
                {
                    j--;
                } while (arr[j] > pivot);

                if (i >= j) return j;

                Swap(arr, i, j);
            }
        }

        /// <summary>
        /// Partitions the specified arr using Lomuto partition scheme.
        /// It considers the last element as pivot 
        /// and moves all smaller element to left of
        /// it and greater elements to right
        /// This scheme degrades to O(n2) when the array is already in order.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <returns></returns>
        private int LomutoPartition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    Swap(arr, i++, j);
                }
            }
            Swap(arr, i, high);
            return i;

            //int pivot = arr[high];
            //int i = low - 1;
            //for (int j = low; j < high; j++)
            //{
            //    if (arr[j] <= pivot)
            //    {
            //        Swap(arr, ++i, j);
            //    }
            //}
            //Swap(arr, ++i, high);
            //return i;
        }

        private void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;
            arr[i] = arr[j] ^ arr[i];
            arr[j] = arr[j] ^ arr[i];
            arr[i] = arr[j] ^ arr[i];
        }

        public LinkedListNode<int> Sort(LinkedListNode<int> head)
        {
            throw new NotImplementedException();
        }

    }
}
