using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.MSFTOnSite
{
    public class MicrosoftPreps
    {
        public struct MaxSubarraySumResult
        {
            public int MaxSum;
            public int From;
            public int To;
            public MaxSubarraySumResult(int max, int from, int to)
            {
                MaxSum = max;
                From = from;
                To = to;
            }
        }
        /// <summary>
        /// Maximum subarray sum problem: Kadane's algorithm
        /// Code returns the sum and can get the fro- and to- indexes.
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <returns>A tuple: (maxSoFar, lo, hi)</returns>
        public static MaxSubarraySumResult MaxSubarraySum(int[] arr)
        {
            //Console.WriteLine("i\tarr[i]\tl_max\tg_max\tfro\tto");
            //Console.WriteLine("-------------------------------------------");
            int maxToHere= arr[0];
            int maxSoFar = maxToHere;
            int lo = 0, hi = 0;
            //Console.WriteLine($"0\t{arr[0]}\t{maxToHere}\t{maxSoFar}\t{lo}\t{hi}");
            for (int i = 1; i < arr.Length; i++)
            {
                //maxToHere = Math.Max(arr[i], maxToHere + arr[i]);
                if (maxToHere <= 0)
                {
                    maxToHere = arr[i];
                    lo = i;
                }
                else
                {
                    maxToHere += arr[i];
                }
                //maxSoFar = Math.Max(maxToHere, maxSoFar);
                if (maxToHere > maxSoFar)
                {
                    maxSoFar = maxToHere;
                    hi = i;
                }
                //lo = Math.Min(lo, hi);
                if (lo > hi)
                {
                    lo = hi;
                }
                //Console.WriteLine($"{i}\t{arr[i]}\t{maxToHere}\t{maxSoFar}\t{lo}\t{hi}");
            }

            Console.WriteLine($"\nMax Sum = {maxSoFar} from {lo} to {hi}\n");
            return new MaxSubarraySumResult(maxSoFar, lo, hi);
        }

        /// <summary>
        /// Given a 2D array, find the maximum sum subarray in it. 
        /// Time Complexity: O(n^3)
        /// </summary>
        /// <param name="a">a.</param>
        public static void MaxSubarraySum(int[][] a)
        {
            int cols = a[0].Length;
            int rows = a.Length;
            MaxSubarraySumResult currentResult;
            int maxSum = int.MinValue;
            int left = 0;
            int top = 0;
            int right = 0;
            int bottom = 0;

            // What is needed to extend kadane algorithm is as follows:

            // 1. Traverse matrix at row level.
            for (int leftCol = 0; leftCol < cols; leftCol++)
            {
                // 2. have a temporary 1-D array and initialize all members as 0.
                int[] tmp = new int[rows];

                // For each row do following:
                for (int rightCol = leftCol; rightCol < cols; rightCol++)
                {
                    // * add value in temporary array for all rows below 
                    // current row (including current row)
                    for (int i = 0; i < rows; i++)
                    {
                        tmp[i] += a[i][rightCol];
                    }

                    // * apply 1-D kadane on temporary array
                    currentResult = MaxSubarraySum(tmp);

                    // * if your current result is greater than current maximum sum...
                    if (currentResult.MaxSum > maxSum)
                    {
                        // ...update.
                        maxSum = currentResult.MaxSum;
                        left = leftCol;
                        top = currentResult.From;
                        right = rightCol;
                        bottom = currentResult.To;
                    }
                }
            }
            Console.WriteLine("MaxSum: " + maxSum +
                              ", range: [(" + left + ", " + top +
                                ")(" + right + ", " + bottom + ")]");
        }

        /// <summary>
        /// Given a set S of n real numbers and another real number x, 
        /// determine whether or not there exist. two elements in S 
        /// whose sum is exactly x.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="sum">The sum.</param>
        /// <returns></returns>
        public static Tuple<int, int> FindTwoElementsWithGivenSum_nlogn(int[] arr, int sum)
        {
            Array.Sort(arr);
            // [1,3,5,7,9], 9
            int i = 0, j = arr.Length - 1;
            while (i < j)
            {
                var added = arr[i] + arr[j];
                if (added == sum)
                    return Tuple.Create(i, j);

                if (added > sum)
                    j--;
                else
                    i++;
            }
            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// Given a set S of n real numbers and another real number x, 
        /// determine whether or not there exist. two elements in S 
        /// whose sum is exactly x.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="sum">The sum.</param>
        /// <returns>The indexes of the two arrays found</returns>
        public static Tuple<int, int> FindTwoElementsWithGivenSum_n(int[] arr, int sum)
        {
            int ind1 = -1, ind2 = -1;

            int val2 = int.MinValue;
            var set = new HashSet<int>(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(sum - arr[i]))
                {
                    if (ind1 == -1)
                    {
                        val2 = sum - arr[i];
                        ind1 = i;
                    }
                    else
                    {
                        if (val2 == arr[i])
                        {
                            ind2 = i;
                        }
                    }

                    if (ind1 > -1 && ind2 > -1)
                        return Tuple.Create(ind1, ind2);
                }
            }
            return Tuple.Create(-1, -1);
        }
    }
}
