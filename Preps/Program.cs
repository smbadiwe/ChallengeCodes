using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Preps
{
    public struct PErson
    {
        public string name;
        public string number;

    }
    partial class Program
    {
        static int fibDP(int n)
        {
            if (n <= 2) return 1;
            int a = 1, b = 1, result = 0;
            for (int i = 3; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }

        static int fibRecursion(int n)
        {
            if (n <= 2) return 1;
            return fibRecursion(n - 1) + fibRecursion(n - 2);
        }

        static int fibRecursion(int n, int k)
        {
            if (n <= 2) return 1;
            int sum = 0, i = 1;
            while (i <= k)
            {
                sum += fibRecursion(n - i);
                i++;
            }
            return sum;
        }

        //HCK 1
        static string electionWinner(string[] votes)
        {

            if (votes.Length == 1) return votes[0];
            // get the candidates
            var candidates = new HashSet<string>(votes);
            if (candidates.Count == 1) return votes[0];

            // build the tally
            var tally = new Dictionary<string, int>(candidates.Count);
            foreach (var candidate in candidates)
            {
                tally.Add(candidate, 0);
            }
            // apply vote
            foreach (var vote in votes)
            {
                tally[vote]++;
            }


            // get the winner
            int winCount = -1;
            var winners = new List<string>();
            foreach (var winner in tally.OrderByDescending(x => x.Value))
            {
                if (winCount == -1)
                {
                    winCount = winner.Value;
                }
                if (winCount == winner.Value)
                {
                    winners.Add(winner.Key);
                }
                else
                {
                    break;
                }
            }
            if (winners.Count == 1) return winners[0];

            return winners.OrderBy(x => x).Last();
        }

        /// <summary>
        /// A left rotation operation on an array of size  
        /// shifts each of the array's elements  unit to the left. For example, if left rotations 
        /// are performed on array , then the array would become .
        /// Given an array of  integers and a number, , perform  left rotations on the array.
        /// Then print the updated array as a single line of space-separated integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        static void LeftRotateArray(int[] a, int d)
        {
            int n = a.Length;
            int diff = n - d;
            var newArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                newArr[(i + diff) % n] = a[i];
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", newArr[i]);
            }
        }

        static void Main(string[] args)
        {
            int des = 1, i = 0;
            while (i < 9)
            {
                i++;
                des *= 10;
            }
            Console.WriteLine("i = " + i + ". des = " + des);
            //var stack = new StackWithMin();
            //stack.Push(2);
            //stack.Push(22);
            //stack.Push(12);
            //stack.Push(32);
            //stack.Push(42);
            //var sorted = stack.Sort();
            //while (sorted.Count > 0)
            //{
            //    Console.WriteLine(sorted.Pop());
            //}
            //new TowerOfHanoi().MoveDisks(4);
            //var ctci = new CTCI();
            //var input = 4; // "abc"; // new List<int> { 1, 2, 3 };
            //var output = ctci.GetParentheses(input);
            //foreach (var set in output)
            //{
            //    if (set.Length == 0)
            //        Console.WriteLine("{ }");
            //    else
            //    {
            //        Console.Write("{ ");
            //        foreach (var item in set)
            //        {
            //            Console.Write("{0} ", item);
            //        }
            //        Console.WriteLine("}");
            //    }
            //}
            Console.ReadKey();
        }

        static long Factorial(long n)
        {
            return (n < 2) ? 1 : n * Factorial(n - 1);
        }

        static long Factorial2(long n)
        {
            long i = 1, result = 1;
            while (i <= n)
            {
                result *= i;
                i++;
            }
            return result;
        }

        //static BigInteger Factorial3(int n)
        //{
        //    int i = 1;
        //    BigInteger result = 1;
        //    while (i <= n)
        //    {
        //        result *= i;
        //        i++;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Describe and code an algorithm that returns the first duplicate character in a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static char GetFirstDuplicateCharacter(string str)
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
        static void RemoveDuplicates(int[] sortedArray)
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
        static void ReplaceEachWithProduct(int[] nums)
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

        static int Power(int num, int index)
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

        static int CheckLongestPalindrom(string s)
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

        static void PrintMultiplicationTable()
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

        static bool IsMatch(string[] pattern, string[] set)
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

    }

}
