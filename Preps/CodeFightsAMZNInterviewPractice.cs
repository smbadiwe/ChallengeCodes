using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public static class CodeFightsAMZNInterviewPractice
    {
        #region Subset sum (Partition Problem)
        /// <summary>
        /// O(2^n) time
        /// Given an array of numbers arr, determine whether arr
        /// can be divided into two subsets for which the sum of elements in both subsets is the same.
        /// </summary>
        /// <param name="arr">3 ≤ arr.length ≤ 100; 0 ≤ arr[i] ≤ 1000</param>
        /// <returns></returns>
        public static bool subsetSum(int[] arr)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }

            // first test: sum must be even
            if (sum % 2 != 0) return false;

            return isSubsetSum(arr, arr.Length, sum / 2);
        }

        private static bool isSubsetSum(int[] arr, int n, int sum)
        {
            // Base Cases
            if (sum == 0) return true;
            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum, then ignore it
            if (arr[n - 1] > sum)
                return isSubsetSum(arr, n - 1, sum);

            /* else, check if sum can be obtained by any of 
               the following
               (a) including the last element
               (b) excluding the last element
            */
            return isSubsetSum(arr, n - 1, sum) ||
                   isSubsetSum(arr, n - 1, sum - arr[n - 1]);
        }
        /// <summary>
        /// O(n*sum) time and space
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool subsetSum_DP(int[] arr)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }

            // first test: sum must be even
            if (sum % 2 != 0) return false;

            int n = arr.Length;
            bool[][] grid = new bool[sum / 2 + 1][];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = new bool[n + 1];

            // initialize top row as true
            for (int i = 0; i <= n; i++)
                grid[0][i] = true;

            // initialize leftmost column, except part[0][0], as false

            // Fill the partition table in botton up manner 
            //RULE: part[i][j] = true if a subset of {arr[0], arr[1], ..arr[j-1]} has sum equal to i;
            // as in, if either p(i, j − 1) is True or if p(i − xj, j − 1) is True.
            // Otherwise, false.
            for (int i = 1; i <= sum / 2; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    grid[i][j] = grid[i][j - 1];
                    if (i >= arr[j - 1])
                    {
                        grid[i][j] = grid[i][j] || grid[i - arr[j - 1]][j - 1];
                    }
                }
            }

            return grid[sum / 2][n];
        } 
        #endregion

        public static string[] pressingButtons(string buttons)
        {
            var numToChars = new Dictionary<char, string>
        {
            {'2', "abc" },{'3', "def" },{'4', "ghi" },{'5', "jkl" },
            {'6', "mno" },{'7', "pqrs" },{'8', "tuv" },{'9', "wxyz" },
        };
            var res = new List<string>();
            res.Add("");
            var preres = new List<string>();
            for (int i = 0; i < buttons.Length; i++)
            {
                foreach (var str in res)
                {
                    var letters = numToChars[buttons[i]];

                    for (int j = 0; j < letters.Length; j++)
                        preres.Add(str + letters[j]);
                }
                res = preres;
                preres = new List<string>();
            }
            return res.ToArray();
        }

        /// <summary>
        /// O(n) time. O(1) space
        /// You're given an unsorted array arr of positive integers and a number s. Your task is 
        /// to find a contiguous subarray that has a sum equal to s, and return an array containing 
        /// the two integers that represent its inclusive bounds. If there are several possible answers, 
        /// return the one with the smallest left bound. If there are no answers, return [-1].
        /// Your answer should be 1-based, making the first position of the array 1 instead of 0.
        /// </summary>
        /// <param name="s">1 ≤ s ≤ 10^9</param>
        /// <param name="arr">3 ≤ arr.length ≤ 10^5; 1 ≤ arr[i] ≤ 10^4</param>
        /// <returns></returns>
        public static int[] findSubarrayBySum(int s, int[] arr)
        {
            #region O(n ^ 2) - naive solution
            //int tempSum;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] == s) return new[] { i + 1, i + 1 };
            //    tempSum = arr[i];
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        tempSum += arr[j];
            //        if (tempSum == s) return new[] { i + 1, j + 1 };

            //        if (tempSum > s) break;
            //    } 
            //}
            #endregion

            /* Initialize tempSum as value of first element and starting point as 0 */
            int tempSum = arr[0], start = 0;

            /* Add elements one by one to tempSum and if the tempSum exceeds the
               sum, then remove starting element */
            for (int i = 1; i <= arr.Length; i++)
            {
                // If tempSum exceeds the sum, then remove the starting elements
                while (tempSum > s && start < i - 1)
                {
                    tempSum -= arr[start];
                    start++;
                }

                // If tempSum becomes equal to sum, then return true
                if (tempSum == s)
                {
                    return new[] { start + 1, i };
                }

                // Add this element to tempSum
                if (i < arr.Length)
                {
                    tempSum += arr[i];
                }
            }
            return new[] { -1 };
        }

        /// <summary>
        /// O(n) time. O(n) space
        /// You're given an unsorted array arr of positive integers and a number s. Your task is 
        /// to find a contiguous subarray that has a sum equal to s, and return an array containing 
        /// the two integers that represent its inclusive bounds. If there are several possible answers, 
        /// return the one with the smallest left bound. If there are no answers, return [-1].
        /// Your answer should be 1-based, making the first position of the array 1 instead of 0.
        /// </summary>
        /// <param name="s">-10^9 ≤ s ≤ 10^9</param>
        /// <param name="arr">3 ≤ arr.length ≤ 10^5; 1 ≤ arr[i] ≤ 10^4</param>
        /// <returns></returns>
        public static int[] findSubarrayBySum_NegativesAllowed(int s, int[] arr)
        {
            var map = new Dictionary<int, int>(); // <currSum, index>
                                                  // Maintains sum of elements so far
            int tempSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                // Add this element to tempSum
                tempSum += arr[i];

                // If tempSum becomes equal to s, then return true
                if (tempSum == s)
                {
                    return new[] { 1, i + 1 };
                }

                // If (tempSum - s) already exists in map we have found a subarray with target sum s
                if (map.ContainsKey(tempSum - s))
                {
                    return new[] { map[tempSum - s] + 2, i + 1 };
                }

                map[tempSum] = i;
            }
            return new[] { -1 };
        }

        #region Boolean parenthesization
        /// <summary>
        /// O(n^3) time. O(n^2) space.
        /// Given a boolean expression with the symbols T and F, and operations &, | and ^;
        /// Count the number of ways that you can parenthesize the expression so that the expression evaluates to true, and return this answer modulo 1003.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int booleanParenthesization(string expression)
        {
            var symb = new List<bool>();
            var ops = new List<char>();
            foreach (var ch in expression)
            {
                switch (ch)
                {
                    case 'T':
                        symb.Add(true);
                        break;
                    case 'F':
                        symb.Add(false);
                        break;
                    case '&':
                    case '|':
                    case '^':
                        ops.Add(ch);
                        break;
                }
            }

            return booleanParenthesization(symb.ToArray(), ops.ToArray());
        }

        private static int booleanParenthesization(bool[] boolValues, char[] operators)
        {
            int[,] trueTable = new int[boolValues.Length, boolValues.Length];
            int[,] falseTable = new int[boolValues.Length, boolValues.Length];
            for (int j = 0; j < boolValues.Length; j++)
            {
                for (int i = j; i >= 0; i--)
                {
                    if (i == j)
                    {
                        trueTable[i, j] = boolValues[i] ? 1 : 0;
                        falseTable[i, j] = boolValues[i] ? 0 : 1;
                    }
                    else
                    {
                        int trueSum = 0;
                        int falseSum = 0;
                        for (int k = i; k < j; k++)
                        {
                            int total1 = trueTable[i, k] + falseTable[i, k];
                            int total2 = trueTable[k + 1, j] + falseTable[k + 1, j];
                            switch (operators[k])
                            {
                                case '|':
                                    {
                                        int or = falseTable[i, k] * falseTable[k + 1, j];
                                        falseSum += or;
                                        or = total1 * total2 - or;
                                        trueSum += or;
                                    }
                                    break;
                                case '&':
                                    {
                                        int and = trueTable[i, k] * trueTable[k + 1, j];
                                        trueSum += and;
                                        and = total1 * total2 - and;
                                        falseSum += and;
                                    }
                                    break;
                                case '^':
                                    {
                                        int xor = trueTable[i, k] * falseTable[k + 1, j] + falseTable[i, k] * trueTable[k + 1, j];
                                        trueSum += xor;
                                        xor = total1 * total2 - xor;
                                        falseSum += xor;
                                    }
                                    break;
                            }
                        }
                        trueTable[i, j] = trueSum % 1003;
                        falseTable[i, j] = falseSum % 1003;
                    }
                }
            }
            return trueTable[0, boolValues.Length - 1] % 1003;
        }

        #endregion

        #region find a string's potential permutations in lexicographical order.
        /// <summary>
        /// O(n x n!) time
        /// Given a string s, find all its potential permutations. The output should be sorted in lexicographical order.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] stringPermutations(string s)
        {
            var str = s.ToCharArray();
            int size = s.Length;
            // Sort in increasing order
            Array.Sort(str);
            var list = new List<string>();
            // Add the first guy

            // get permutations one by one
            while (true)
            {
                list.Add(new string(str));

                // Find the rightmost character which is smaller than its next
                // character. Let us call it 'first char'
                int i;
                for (i = size - 2; i >= 0; i--)
                {
                    if (str[i] < str[i + 1]) break;
                }

                // If there is no such chracter, all are sorted in decreasing order,
                // means we just got the last permutation and we are done.
                if (i == -1) break;

                // Find the ceil of 'first char' in right of first character.
                // Ceil of a character is the smallest character greater than it
                int ceilIndex = findCeil(str, str[i], i + 1, size - 1);

                // Swap first and second characters
                swap(str, i, ceilIndex);

                // reverse the string on right of 'first char'
                int l = i + 1, h = size - 1;
                while (l < h)
                {
                    swap(str, l, h);
                    l++;
                    h--;
                }
            }

            return list.ToArray();
        }

        // This function finds the index of the smallest character
        // which is greater than 'first' and is present in str[l..h]
        private static int findCeil(char[] str, char first, int l, int h)
        {
            // initialize index of ceiling element
            int ceilIndex = l;

            // Now iterate through rest of the elements and find
            // the smallest character greater than 'first'
            for (int i = l + 1; i <= h; i++)
                if (str[i] > first && str[i] < str[ceilIndex])
                    ceilIndex = i;

            return ceilIndex;
        }

        private static void swap(char[] str, int i, int j)
        {
            var temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        #endregion

        /// <summary>
        /// O(n) time. and O(1) space
        /// Given a string s, find and return the first instance of a non-repeating character in it. If there is no such character, return '_'.
        /// </summary>
        /// <param name="s">lowercase english letters</param>
        /// <returns></returns>
        public static char firstNotRepeatingCharacter(string s)
        {
            var dict = new Dictionary<char, int>(26); //a - z
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict[s[i]] = 1;
                }
            }
            foreach (var item in dict)
            {
                if (item.Value == 1) return item.Key;
            }
            return '_';
        }

        #region longest Increasing Subsequence (LIS)

        /// <summary>
        /// O(nlogn) - http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
        /// Given a sequence of numbers in an array, find the length of its longest increasing subsequence (LIS).
        /// The longest increasing subsequence is a subsequence of a given sequence in which the subsequence's elements are in strictly increasing order, and in which the subsequence is as long as possible. This subsequence is not necessarily contiguous or unique.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int longestIncreasingSubsequence(int[] sequence)
        {
            var tail = new int[sequence.Length];
            int length = 1; // always points empty slot in tail

            tail[0] = sequence[0];
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < tail[0])
                    // new smallest value
                    tail[0] = sequence[i];
                else if (sequence[i] > tail[length - 1])
                    // v[i] extends largest subsequence
                    tail[length++] = sequence[i];
                else
                    // v[i] will become end candidate of an existing subsequence or
                    // Throw away larger elements in all LIS, to make room for upcoming grater elements than v[i]
                    // (and also, v[i] would have already appeared in one of LIS, identify the location and replace it)
                    tail[CeilIndex(tail, -1, length - 1, sequence[i])] = sequence[i];
            }

            return length;
        }

        // Binary search (note boundaries in the caller)
        private static int CeilIndex(int[] v, int left, int right, int key)
        {
            while (right - left > 1)
            {
                int m = left + (right - left) / 2;
                if (v[m] >= key)
                    right = m;
                else
                    left = m;
            }

            return right;
        }

        /// <summary>
        /// O(n^2) - Dynamic Programming method
        /// http://www.geeksforgeeks.org/dynamic-programming-set-3-longest-increasing-subsequence/
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int longestIncreasingSubsequence_DP(int[] sequence)
        {
            int[] L = new int[sequence.Length];


            // Compute optimized LIS values in bottom up manner
            for (int i = 0; i < sequence.Length; i++)
            {
                L[i] = 1; // Initialize LIS values 
                for (int j = 0; j < i; j++)
                {
                    // if current is bigger than previous and ...
                    if (sequence[i] > sequence[j] && L[i] < L[j] + 1)
                    {
                        L[i] = L[j] + 1;
                    }
                }
            }
            // pick the max
            return L.Max();
        }

        #endregion

        /// <summary>
        /// O(n^2) time:
        /// Given an array of integers a, find the number of pairs of numbers ai and aj, 
        /// where i ≠ j, such that the sum of ai + aj is also present in a.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int pairsSum(int[] a)
        {
            int len = a.Length, count = 0;
            var set = new HashSet<int>(a);
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (set.Contains(a[i] + a[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// O(n^2)
        /// You have an array a composed of exactly n elements. Given a number x, determine 
        /// whether or not a contains three elements for which the sum is exactly x.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool tripletSum(int x, int[] a)
        {
            int left, right, length = a.Length;
            Array.Sort(a);
            // Now fix the first element one by one and find the other two elements
            for (int i = 0; i < length - 2; i++)
            {
                // To find the other two elements, start two index
                // variables from two corners of the array and move
                // them toward each other
                left = i + 1; // index of the first element in the remaining elements
                right = length - 1; // index of the last element
                while (left < right)
                {
                    if (a[i] + a[left] + a[right] == x)
                        return true;

                    if (a[i] + a[left] + a[right] < x)
                        left++;
                    else
                        right--;
                }
            }
            // If we reach here, then no triplet was found
            return false;
        }

        /// <summary>
        /// O(n^2) time. Brute seearch
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] nextLarger_Brute(int[] a)
        {
            int[] result = new int[a.Length];
            result[a.Length - 1] = -1;
            for (int i = 0; i < a.Length - 1; i++)
            {
                result[i] = -1;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] > a[i])
                    {
                        result[i] = a[j];
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// O(n)
        /// Given an array a composed of distinct elements, find the next larger 
        /// element for each element of the array in the order in which they appear 
        /// in the array, and return the results as a new array of the same length. 
        /// If an element does not have a larger element to its right, put -1 in 
        /// the appropriate cell of the result array.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] nextLarger(int[] a)
        {
            var stack = new Stack<int>();
            var result = new int[a.Length];
            for (int i = a.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && a[i] > stack.Peek())
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[i] = -1;
                }
                else
                {
                    result[i] = stack.Peek();
                }

                stack.Push(a[i]);
            }
            return result;
        }

    }
}
