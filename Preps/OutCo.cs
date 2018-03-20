using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class OutCo
    {
        /// <summary>
        /// commonCharacters(str1, str2, str3) - 
        /// Given three strings of the same length, 
        /// return a string of all the common characters in all three strings
        /// Example: abcde, dafge, dageb -> dae
        /// Space complexity: O(N)
        /// Time complexity: O(N)
        /// </summary>
        /// <param name="str1">STR1.</param>
        /// <param name="str2">STR2.</param>
        /// <param name="str3">STR3.</param>
        /// <returns></returns>
        public static string commonCharacters(string str1, string str2, string str3)
        {
            if (string.IsNullOrEmpty(str1)) return "";

            int maxChars = 26;
            int inputLength = str1.Length;
            int[] arr1 = new int[maxChars];
            int[] arr2 = new int[maxChars];
            int[] arr3 = new int[maxChars];

            for (int i = 0; i < inputLength; i++)
            {
                arr1[str1[i] - 'a'] += 1;
                arr2[str2[i] - 'a'] += 1;
                arr3[str3[i] - 'a'] += 1;
            }

            var result = new StringBuilder();
            for (int i = 0; i < maxChars; i++)
            {
                if (arr1[i] == 0 || arr2[i] == 0 || arr3[i] == 0)
                    continue;

                int min = GetMin(arr1[i], arr2[i], arr3[i]);
                while (min > 0)
                {
                    result.Append((char)('a' + i));
                    min--;
                }
            }

            return result.ToString();
        }

        public static bool canBePalindrome(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            var dict = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch] += 1;
                }
                else
                {
                    dict[ch] = 1;
                }
            }

            if (str.Length % 2 == 0)
            {
                foreach (var count in dict)
                {
                    if (count.Value % 2 != 0) return false;
                }
                return true;
            }

            int nOdd = 0;
            foreach (var count in dict)
            {
                if (count.Value % 2 != 0)
                    nOdd++;
            }
            return nOdd == 1;
        }

        private static int GetMin(int n1, int n2, int n3)
        {
            return Math.Min(n1, Math.Min(n2, n3));
        }
    }
}
