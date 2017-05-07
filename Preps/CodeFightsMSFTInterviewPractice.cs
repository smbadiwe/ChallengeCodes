using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preps
{
    public class CodeFightsMSFTInterviewPractice
    {
        /// <summary>
        /// You have two version strings composed of several non-negative decimal fields that are 
        /// separated by periods ("."). Both strings contain an equal number of numeric fields. 
        /// Return 1 if the first version is higher than the second version, -1 if it is smaller, 
        /// and 0 if the two versions are the same.
        /// The syntax follows the regular semver(semantic versioning) ordering rules:      
        /// 1.0.5 less 1.1.0 less 1.1.5 less 1.1.10 less 1.2.0 less 1.2.2 less 1.2.10 less 1.10.2 less 2.0.0 less 10.0.0
        /// </summary>
        /// <param name="ver1"></param>
        /// <param name="ver2"></param>
        /// <returns></returns>
        public static int higherVersion2(string ver1, string ver2)
        {
            if (ver1 == ver2) return 0;
            var ver1Arr = ver1.Split('.');
            var ver2Arr = ver2.Split('.');
            for (int i = 0; i < ver1Arr.Length; i++)
            {
                // Remove leading zeros
                ver1Arr[i] = ver1Arr[i].TrimStart('0');
                ver2Arr[i] = ver2Arr[i].TrimStart('0');
                if (ver1Arr[i] == "") ver1Arr[i] = "0";
                if (ver2Arr[i] == "") ver2Arr[i] = "0";
                if (ver1Arr[i] != ver2Arr[i])
                {
                    // Compare. Once we see that at any point,
                    // NB: We could have cast to number, but there could be overflow. So we compare character by character
                    if (ver1Arr[i].Length == ver2Arr[i].Length)
                    {
                        for (int j = 0; j < ver2Arr[i].Length; j++)
                        {
                            var c1 = ver1Arr[i][j];
                            var c2 = ver2Arr[i][j];
                            if (c1 < c2) return -1;
                            if (c1 > c2) return 1; // => c1 > c2 hence 1
                        }
                    }
                    else
                    {
                        return (ver1Arr[i].Length > ver2Arr[i].Length) ? 1 : -1;
                    }
                }
            }

            return 0; // equal
        }


        #region Convert integer to english word
        /// <summary>
        /// Convert integer to to its word form.
        /// </summary>
        /// <param name="number">Value between 0 and 2^31 - 1, inclusive</param>
        /// <returns></returns>
        public static string integerToEnglishWords(int number)
        {
            if (number < 20)
            {
                return oneTo19[number];
            }
            oneTo19[0] = "";
            if (number < 100)
            {
                var tens = number / 10;
                var unit = number % 10;
                return string.Format("{0}{1}", tensValues[tens], unit == 0 ? "" : " " + oneTo19[unit]);
            }

            // Get the item in the dictionary that corresponds to the highes form of the number given
            var power = (int)Math.Log10(number);
            KeyValuePair<int, string> theItem = new KeyValuePair<int, string>(0, "");
            foreach (var item in powersOf10)
            {
                if (item.Key == power)
                {
                    theItem = item;
                    break;
                }
                else if (item.Key > power)
                {
                    break;
                }
                theItem = item;
            }

            var dividend = Math.Pow(10, theItem.Key);
            var part = (int)(number / dividend);

            number = (int)(number % dividend);
            string result = "";
            result += string.Format("{0} {1} {2}", integerToEnglishWords(part), theItem.Value, integerToEnglishWords(number));

            return result.Trim();
        } 

        private static readonly string[] oneTo19 = new[] { "Zero", "One", "Two", "Three",
		 "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
        "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
        "Seventeen", "Eighteen", "Nineteen" };

        private static readonly string[] tensValues = new[] { "", "", "Twenty", "Thirty", "Forty",
                "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static readonly Dictionary<int, string> powersOf10 = new Dictionary<int, string>{
                {2, "Hundred"},
                {3, "Thousand"},
                {6, "Million"},
                {9, "Billion"},
                {12, "Trillion"},
                {15, "Quadrillion"},
                {18, "Quintillion"},
                {21, "Sextillion"},
                {24, "Septillion"},
                {27, "Octillion"},
                {30, "Nonillion"},
            };

        #endregion

        /// <summary>
        /// The inversion count for an array indicates how far the array is from being sorted. 
        /// If the array is already sorted, then the inversion count is 0. 
        /// If the array is sorted in reverse order, then the inversion count is the maximum possible value.
        /// 
        /// <para>Two elements of the array a stored at positions i and j form an inversion if a[i] > a[j] and i < j.
        /// http://www.geeksforgeeks.org/counting-inversions/
        /// </para>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int countInversions(int[] a)
        {
            if (a.Length < 2) return 0;

            #region Naive - O(n^2)
            // Naive - O(n^2)
            //int result = 0;
            //for (int i = 0; i < a.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < a.Length; j++)
            //    {
            //        if (a[i] > a[j]) result++;
            //    }
            //}
            //return result; 
            #endregion

            // Merge sort - O(nlogn)
            int m = (a.Length + 1) / 2;
            int[] left = new int[m];
            Array.Copy(a, 0, left, 0, m);
            int[] right = new int[a.Length - m];
            Array.Copy(a, m, right, 0, right.Length);

            return (countInversions(left) + countInversions(right) + merge(a, left, right)) % (1000000000 + 7);
        }

        private static int merge(int[] arr, int[] left, int[] right)
        {
            // i for left, j for right
            int i = 0, j = 0, count = 0;
            while (i < left.Length || j < right.Length)
            {
                if (i == left.Length)
                {
                    arr[i + j] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else
                {
                    arr[i + j] = right[j];
                    count += left.Length - i;
                    j++;
                }
            }
            return count % (1000000000 + 7);
        }

        /// <summary>
        /// Solution is recursive. It writes out the coins used. Repetition NOT allowed.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static string CoinChangeProblem(int[] coins, int sum)
        {
            return CoinChangeProblem(coins, sum, new List<int>());
        }
        private static string CoinChangeProblem(int[] coins, int sum, List<int> partials)
        {
            var target = Sum(partials);
            if (target == sum)
            {
                var sb = new StringBuilder();
                sb.Append("(");
                foreach (var item in partials.OrderBy(x => x))
                {
                    sb.AppendFormat("{0},", item);
                }
                sb.Remove(sb.Length - 1, 1).Append(")");
                return sb.ToString();
            }
            if (target > sum) return "";

            var result = "";
            int i = 1;
            foreach (var coin in coins)
            {
                var rem = new List<int>(coins.Skip(i++)).ToArray();
                var set = new List<int>(partials.Count + 1);
                set.AddRange(partials);
                set.Add(coin);
                result += CoinChangeProblem(rem, sum, set);
            }
            return result;
        }

        private static int Sum(List<int> arr)
        {
            int ans = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                ans += arr[i];
            }
            return ans;
        }

        /// <summary>
        /// Given a value N, if we want to make change for N cents, 
        /// and we have infinite supply of each of S = { S1, S2, .. , Sm} 
        /// valued coins, how many ways can we make the change? The order 
        /// of coins doesn’t matter.
        /// <para>Solution is DP. Returns number of possible combinations</para>
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static long CoinChangeProblemDP(int[] coins, int sum)
        {
            //Time complexity of this function: O(mn)
            //Space Complexity of this function: O(n)

            // table[i] will be storing the number of solutions
            // for value i. We need n+1 rows as the table is
            // constructed in bottom up manner using the base
            // case (n = 0)
            long[] table = new long[sum + 1];
            // Initialize all table values as 0

            // Base case (If given value is 0)
            table[0] = 1;

            // Pick all coins one by one and update the table[]
            // values after the index greater than or equal to
            // the value of the picked coin
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= sum; j++)
                {
                    table[j] += table[j - coins[i]];
                }
            }
            return table[sum];
        }

        /// <summary>
        /// Find the two NON-repeating elements in a given array.
        /// O(1) space; O(n) time.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] findTheNumbers(int[] a)
        {

            int len = a.Length; // >= 2
            int i = 1, x = 0, y = 0;
            // Why we xor the whole array:
            // a xor b !=0 if a!=b. So xor will be non zero hence there will be at least one set bit
            var xorVal = a[0];
            while (i < len)
            {
                xorVal ^= a[i++];
            }
            /* bitwise AND of (a number) AND (it's negative) reveals the rightmost set bit 
             * due to the nature of 2's Complement being an inversion of bits. This effectively represents 'a bit 
             * (of potentially multiple, which bit we use doesn't matter in this context) that exists in 
             * ONE AND ONLY ONE of the non-duplicated numbers
             */
            var setBit = xorVal & ~(xorVal - 1);
            for (i = 0; i < len; i++)
            {
                if ((a[i] & setBit) > 0) // if the value a[i] has the bit, it goes in this bucket
                {
                    x = x ^ a[i]; // XOR of one of it
                }
                else
                {
                    y = y ^ a[i]; // XOR of the other
                }
            }
            var result = new int[2];
            if (x < y)
            {
                result[0] = x;
                result[1] = y;
            }
            else
            {
                result[0] = y;
                result[1] = x;
            }
            return result;
        }


        /// <summary>
        /// Return the number of 1-bit in the given number. AKA: The Hamming Weight of n.
        /// O(k) where k is the number of 1-bit
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int numberOf1Bits(int n)
        {
            if (n == 0) return 0;
            int count = 0;
            while (n > 0)
            {
                // Typical solution
                //if (n % 2 == 1) count++;
                //n /= 2;

                // BIT-wise solution
                n = n & n - 1;
                count++;

            }

            return count;
        }

        /// <summary>
        /// Return true if n is a power of two. 
        /// O(1) Time and Space
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool isPowerOfTwo2(long n)
        {
            // Naive: Use the fact that powers of 2, when conveerted to binary
            // will be of the form: 10... i.e. 1 and 0 -> x zeros.
            //var bin = Convert.ToString(n, 2);
            //return bin.LastIndexOf("1") == 0;

            // Another fact: if n is a power of two, then n & (n - 1) = 0.
            // E.g.: n = 4 => n = '100' and n - 1 = '011'; so the bitwise AND operation will be all 0s.

            if (n == 0) return false;
            return 0 == (n & (n - 1));
        }

        /// <summary>
        /// Given two possibly large numbers as string, return the product as string
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string multiplyTwoStrings(string s1, string s2)
        {
            var n1 = s1.Length;
            var n2 = s2.Length;
            var resultArr = new char[n1 + n2]; // The max possible. We'll trim later
            var num1 = s1.ToCharArray();
            var num2 = s2.ToCharArray();
            int leftShift = 0;
            // Implement the long multiplication algorithm
            for (int i = n2 - 1; i >= 0; i--)
            {
                int carry = 0, k = leftShift;

                for (int j = n1 - 1; j >= 0; j--)
                {
                    // - '0' is how we convert char (the ASCII value) to int (the actual character written)
                    int partialResult = (num1[j] - '0') * (num2[i] - '0') + carry;

                    if (resultArr[k] != default(char))
                    {
                        partialResult += resultArr[k] - '0';
                    }
                    // + '0' is how we convert int (the actual character written) to char  (the ASCII value)
                    resultArr[k++] = Convert.ToChar(partialResult % 10 + '0');
                    carry = partialResult / 10;
                }

                if (carry > 0)
                {
                    resultArr[k] = Convert.ToChar(carry + '0');
                }
                leftShift++;
            }
            Array.Reverse(resultArr);
            return new string(resultArr).Replace(default(char).ToString(), "");
        }

        /// <summary>
        /// Given a UNIX-style directory path, return the simplified version of it
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string simplifyPath(string path)
        {
            var dirs = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();
            foreach (var dir in dirs)
            {
                switch (dir)
                {
                    case ".":
                        break;
                    case "..":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    default:
                        stack.Push(dir);
                        break;
                }
            }
            if (stack.Count == 0) return "/";

            dirs = stack.ToArray();
            Array.Reverse(dirs);
            var result = "/" + string.Join("/", dirs);
            return result;
        }

        /// <summary>
        /// Given a number, return the column title as excel would have had it.
        /// NB: Excel is 1-based, not 0-based
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetExcelColumnTitle(int number)
        {

            string colName = string.Empty;
            int modulo;

            while (number > 0)
            {
                modulo = (number - 1) % 26;
                colName = Convert.ToChar('A' + modulo) + colName;
                number = (number - modulo) / 26;
            }

            return colName;
        }

    }
}
