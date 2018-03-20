using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public class BucketSort
    {
        // Time-Avg: O(n+k)
        // Time-Worst: O(n^2)
        public void Sort(int[] arr)
        {
            // eg: [3,5,7,4,9]
            // max = 9, min = 3
            // bucket: length = 9-3+1 = 7
            // bucket value: [1,1,1,0,1,0,1]
            // bucket index: [3,4,5,6,7,8,9]
            // get range
            int max = arr[0];
            int min = max;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }

            // do the histogram
            var bucket = new int[max - min + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - min]++;
            }

            // sort;
            int arrayIndex = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] == 0) continue;

                for (int j = 0; j < bucket[i]; j++)
                    arr[arrayIndex++] = min + i;
            }
        }
    }
}
