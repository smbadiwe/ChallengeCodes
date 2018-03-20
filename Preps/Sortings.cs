using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public static class Sortings
    {
        /// <summary>
        /// Start at the beginning of an array and swap the frst two elements if the frst is bigger than
        /// the second Go to the next pair, etc, continuously making sweeps of the array until sorted
        /// <para>O(n^2)</para>
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        // Swap - in-place
                        arr[j - 1] = arr[j] - arr[j - 1];
                        arr[j] = arr[j] - arr[j - 1];
                        arr[j - 1] = arr[j] + arr[j - 1];
                    }
                }
            }
        }

        /// <summary>
        /// The selection sort works as follows: you look through the entire array for the 
        /// smallest element, once you find it you swap it (the smallest element) with the 
        /// first element of the array. Then you look for the smallest element in the remaining 
        /// array (an array without the first element) and swap it with the second element.
        /// <para>O(n^2)</para>
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // find min:
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex]) minIndex = j;
                }

                // move min forward by swapping
                // Swap - in-place
                if (i != minIndex)
                {
                    arr[i] = arr[minIndex] - arr[i];
                    arr[minIndex] = arr[minIndex] - arr[i];
                    arr[i] = arr[minIndex] + arr[i];
                }
            }
        }

        /// <summary>
        /// <para>O(nlogn)</para>
        /// Merge-sort is based on the divide-and-conquer paradigm. It involves the following three steps:
        /// * Divide the array into two(or more) subarrays
        /// * Sort each subarray(Conquer)
        /// * Merge them into one(in a smart way!)
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            // temp array for the merge
            var temp = new int[arr.Length];
            MergeSort(arr, temp, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, temp, left, mid);
                MergeSort(arr, temp, mid + 1, right);
                Merge(arr, temp, left, mid + 1, right);
            }
        }

        private static void Merge(int[] a, int[] tmp, int left, int right, int rightEnd)
        {
            int leftEnd = right - 1;
            int k = left;
            int num = rightEnd - left + 1;

            while (left <= leftEnd && right <= rightEnd)
                if (a[left] <= a[right])
                    tmp[k++] = a[left++];
                else
                    tmp[k++] = a[right++];


            while (left <= leftEnd)    // Copy rest of first half
                tmp[k++] = a[left++];

            while (right <= rightEnd)  // Copy rest of right half
                tmp[k++] = a[right++];

            // Copy tmp back
            for (int i = 0; i < num; i++, rightEnd--)
                a[rightEnd] = tmp[rightEnd];
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = Partition(arr, left, right);
                QuickSort(arr, left, mid - 1);
                QuickSort(arr, mid + 1, right);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    Swap(arr, ++i, j);
                }
            }
            Swap(arr, ++i, high);
            return i;
        }

        public static void HeapSort(int[] arr)
        {
            var heap = new PriorityHeap(arr.Length);
            foreach (var item in arr)
            {
                heap.Add(item);
            }
        }

        private static void Heapify(int[] arr)
        {

        }
        private static void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;
            arr[i] = arr[j] ^ arr[i];
            arr[j] = arr[j] ^ arr[i];
            arr[i] = arr[j] ^ arr[i];
            //or do - - + on the RHS of the above three lines
        }
    }
}
