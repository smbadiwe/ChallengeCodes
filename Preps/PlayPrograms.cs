using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Preps
{
    public class PlayPrograms
    {
        public static void SwapInPlace(int[] arr, int i, int j, bool useBits = true)
        {
            if (useBits)
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
            else
            {
                arr[i] = arr[j] - arr[i];
                arr[j] = arr[j] - arr[i];
                arr[i] = arr[i] + arr[j];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="withoutArithmeticOperators"></param>
        /// <returns>The sum of <paramref name="n1"/> and <paramref name="n2"/></returns>
        public static int Add(int n1, int n2, bool withoutArithmeticOperators = true)
        {
            if (withoutArithmeticOperators)
            {
                if (n1 == 0) return n2;
                if (n2 == 0) return n1;
                // If I add two binary numbers together but forget to carry, bit[i] will be 0 if bit[i]
                // in a and b are both 0 or both 1 This is an XOR
                int s = n1 ^ n2;
                // If I add two numbers together but only carry, I will have a 1 in bit[i] if 
                // bit[i-1] in a and b are both 1’s This is an AND, shifted
                int c = (n1 & n2) << 1;
                return Add(s, c);
            }
            string n1Str = n1.ToString();
            string n2Str = n2.ToString();
            int n1Length = n1Str.Length;
            int n2Length = n2Str.Length;

            string result = "";
            int sum = 0, carry = 0;
            // as long as there's a digit in one or both the strings
            while (n1Length > 0 || n2Length > 0) 
            {
                sum = carry;
                if (n1Length > 0)
                {
                    sum += (n1Str[n1Length - 1] - '0'); // add the number at this position
                    n1Length--; //move leftward one step
                }
                if (n2Length > 0)
                {
                    sum += (n2Str[n2Length - 1] - '0'); // add the number at this position
                    n2Length--; // move leftward one step
                }

                carry = sum / 10; // what we're carrying
                sum = sum % 10; // the rest
                // prepend the column sum to the final answer
                result = sum + result;
            }
            // if there's still something left from carrying stuffs forward
            if (carry > 0)
            {
                result = carry + result;
            }
            return int.Parse(result);
        }


        public static int integerValueOfRomanNumeral(string s)
        {
            var map = new Dictionary<char, int[]>(); // value[0] is val of roman xter; [1] is max repetitions
            map['I'] = new[] { 1, 3 };
            map['V'] = new[] { 5, 1 };
            map['X'] = new[] { 10, 3 };
            map['L'] = new[] { 50, 1 };
            map['C'] = new[] { 100, 3 };
            map['D'] = new[] { 500, 1 };
            map['M'] = new[] { 1000, 0 }; // 0 => infinite
            if (s.Length == 1) return map[s[0]][0];

            foreach (var item in map)
            {
                if (item.Key == 'M')
                { // infinite
                    continue;
                }
                // exclude stuffs like IIII etc
                if (s.Contains(item.Key.ToString().PadLeft(item.Value[1] + 1, item.Key)))
                {
                    return -1;
                }
            }
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int val = map[s[i]][0];
                if ((i + 1) < s.Length)
                {
                    int next = map[s[i + 1]][0];
                    if (val >= next)
                    {
                        // Value of current symbol is greater or equal to the next symbol
                        result += val;
                    }
                    else
                    {
                        // Value of current symbol is less than the next symbol
                        // Now check for invalid matches
                        if (s[i + 1] == 'X' && s[i] != 'I')
                            return -1;
                        if ((s[i + 1] == 'C' || s[i + 1] == 'L') && s[i] != 'X')
                            return -1;
                        if ((s[i + 1] == 'D' || s[i + 1] == 'M') && s[i] != 'C')
                            return -1;
                        result += (next - val);
                        i++;
                    }
                }
                else
                {
                    result += val;
                    i++;
                }
            }

            // handle false positives, like XLX returning 50 where L is 50
            foreach (var item in map)
            {
                if (item.Value[0] == result)
                    return -1;
            }
            return result;
        }

        public static int GCD(int a, int b)
        {
            //if (b == 0) return a;
            //return GCD(b, a % b);

            int r;
            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        public static bool isPrime(int number)
        {
            #region Easy to understand
            //if (number == 1) return false;
            //if (number == 2) return true;

            //var boundary = (int)Math.Floor(Math.Sqrt(number));

            //int i = 3;
            //while (i <= boundary)
            //{
            //    if (number % i == 0)
            //        return false;

            //    i += 2;
            //}

            //return true; 
            #endregion

            var i5 = "i".PadLeft(5, 'i');
            if (number == 1) return false;
            if (number == 2 || number == 3 || number == 5) return true;
            if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            // You can do even less work by observing that at this point, all primes 
            // other than 2 and 3 leave a remainder of either 1 or 5 when divided by 6.
            int i = 6;
            while (i <= boundary)
            {
                if (number % (i + 1) == 0 || number % (i + 5) == 0)
                    return false;

                i += 6;
            }

            return true;
        }

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
