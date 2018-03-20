using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public class Misc
    {
        public long combination(int n, int k)
        {
            //if (k == 0) return 1;
            //return (n * combination(n - 1, k - 1)) / k;
            if (n < 0 || k < 0) throw new InvalidOperationException("Invalid arguments");
            if (k == 0) return 1;
            if (n == 0) return 0;
            return combination(n - 1, k - 1) + combination(n - 1, k);
        }

        public int kthLargestElement(int[] arr, int k)
        {
            return kthSmallestElement(arr, arr.Length - k + 1);
        }

        public int kthSmallestElement(int[] arr, int k)
        {
            return kthSmallestElement(arr, k, 0, arr.Length - 1);
        }

        private int kthSmallestElement(int[] arr, int k, int left, int right)
        {
            if (k <= 0 || k > (right-left + 1)) return int.MaxValue;

            // get partition index
            int pivot = partition(arr, left, right);
            // pivot is k, return the element
            if (pivot - left == k - 1)
                return arr[pivot];
            // if pivot is more, go left,
            if (pivot - left > k - 1)
                return kthSmallestElement(arr, k, left, pivot - 1);
            // else go right.
            k  = k - (pivot - left + 1); // adjust for the range
            return kthSmallestElement(arr, k, pivot + 1, right);
        }

        /// <summary>
        /// Partitions the specified arr using Lamuto.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private int partition(int[] arr, int left, int right)
        {
            int p = arr[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= p)
                {
                    // swap
                    Swap(arr, i++, j);
                }
            }
            Swap(arr, i, right);
            return i;
        }

        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
