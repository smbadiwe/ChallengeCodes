using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Preps
{
    public class PlayPrograms
    {
        public static long Factorial(long n)
        {
            return (n < 2) ? 1 : n * Factorial(n - 1);
        }

        public static long Factorial2(long n)
        {
            long i = 1, result = 1;
            while (i <= n)
            {
                result *= i;
                i++;
            }
            return result;
        }

        /// <summary>
        /// Describe and code an algorithm that returns the first duplicate character in a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char GetFirstDuplicateCharacter(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                var set = new HashSet<char>();
                foreach (var ch in str)
                {
                    if (set.Add(ch)) continue;

                    return ch;
                }
            }

            return char.MinValue;
        }
        
        /// <summary>
        /// In a given sorted array of integers remove all the duplicates.
        /// </summary>
        /// <param name="sortedArray"></param>
        public static void RemoveDuplicates(int[] sortedArray)
        {
            var result = new List<int>();
            int dupInd;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i > 0)
                {
                    if (sortedArray[i - 1] == sortedArray[i])
                    {
                        dupInd = i;
                        continue;
                    }
                }
                dupInd = -1;
                result.Add(sortedArray[i]);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < result.Count; i++)
            {
                sb.AppendFormat("{0} ", result[i]);
            }
            Console.WriteLine(sb);
        }

        /// <summary>
        /// Given an array of numbers, replace each number with the product of all the
        /// numbers in the array except the number itself *without* using division.
        /// </summary>
        /// <param name="nums"></param>
        public static void ReplaceEachWithProduct(int[] nums)
        {
            //Given an array of numbers, replace each number with the product of all the
            //numbers in the array except the number itself *without* using division.
            var sb = new StringBuilder();
            for (int i = 0; i < nums.Length; i++)
            {
                int product = 1;
                for (int j = 0; j < i; j++)
                {
                    product *= nums[j];
                }
                for (int j = i + 1; j < nums.Length; j++)
                {
                    product *= nums[j];
                }
                sb.AppendFormat("{0} ", product);
            }
            Console.WriteLine(sb);
        }

        public static int Power(int num, int index)
        {
            if (num == 0) return 0;
            if (num == 1) return num;
            if (index == 0) return 1;

            int ans = 1;
            while (index > 0)
            {
                ans *= num;
                index--;
            }
            return ans;
        }

        public static int CheckLongestPalindrom(string s)
        {
            //This is cryptic
            char[] strArray = s.ToArray();
            int left = 0, right = s.Length - 1, count = 1;
            string leftStr = "", rightStr = "";
            while (left < right)
            {
                leftStr += strArray[left];
                rightStr = strArray[right] + rightStr;
                if (leftStr.Equals(rightStr))
                {
                    count += 2;
                    leftStr = rightStr = "";
                }
                left++;
                right--;
            }
            return count;
        }

        public static void PrintMultiplicationTable()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    sb.AppendFormat("{0}\t", i * j);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb);
        }

        public static bool IsMatch(string[] pattern, string[] set)
        {
            if (pattern == null && set == null) return false;
            if ((pattern == null && set != null) || (pattern != null && set == null)) return false;
            if (pattern.Length != set.Length) return false;

            var dict = new Dictionary<string, string>();
            for (int i = 0; i < pattern.Length; i++)
            {
                string str;
                if (dict.TryGetValue(pattern[i], out str))
                {
                    if (str != set[i]) return false;
                }
                else
                {
                    dict[pattern[i]] = set[i];
                }
            }
            return true;
        }

        public static int ReverseNumber(int num)
        {
            bool isNegative = num < 0;
            if (isNegative)
            {
                num = Math.Abs(num);
            }
            int ans = 0;
            while (num > 0)
            {
                ans = ans * 10 + num % 10;
                num /= 10;
            }
            return isNegative ? -ans : ans;
        }
    }

}
