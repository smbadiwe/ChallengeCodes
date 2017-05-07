using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    partial class HackerRank
    {

        /// <summary>
        /// Given N, find the largest Decent Number having N digits.
        /// A Decent Number has the following properties:
        /// <para>Its digits can only be 3's and/or 5's.</para>
        /// <para>The number of 3's it contains is divisible by 5.</para>
        /// <para>The number of 5's it contains is divisible by 3.</para>
        /// <para>If there are more than one such number, we pick the largest one.</para>
        /// </summary>
        /// <param name="n"></param>
        static void LargestDecentNumber(int n)
        {
            string _fives = "555", _threes = "33333";
            if (n < 3)
            {
                Console.WriteLine(-1);
            }
            else if (n % 3 == 0)
            {
                var sb = new StringBuilder();
                for (int i = 1; i <= n / 3; i++)
                {
                    sb.Append(_fives);
                }
                Console.WriteLine(sb);
            }
            else if (n == 5)
            {
                var sb = new StringBuilder();
                for (int i = 1; i <= n / 5; i++)
                {
                    sb.Append(_threes);
                }
                Console.WriteLine(sb);
            }
            // Now we know there are some 5's and some 3's
            else if (n > 7)
            {
                var sb = new StringBuilder();
                int n3s = 3 - n % 3;
                for (int i = 0; i < (n - (5 * n3s)) / 3; i++)
                {
                    sb.Append(_fives);
                }
                for (int i = 0; i < n3s; i++)
                {
                    sb.Append(_threes);
                }
                Console.WriteLine(sb);
            }
            else Console.WriteLine(-1);
        }

        #region Making Anagrams
        /// <summary>
        /// Given two strings, s1 and s2, that may or may not be of the same length, determine the minimum number 
        /// of character deletions required to make  and  anagrams. Any characters can be deleted from either of the strings.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        public static void MakingAnagrams(string s1, string s2)
        {
            int answer = 0;
            s1 = RemoveCharacters(s1, s1.Except(s2), ref answer);
            if (string.IsNullOrWhiteSpace(s1))
            {
                answer += s2.Length;
                Console.WriteLine(answer);
                return;
            }
            s2 = RemoveCharacters(s2, s2.Except(s1), ref answer);
            if (string.IsNullOrWhiteSpace(s2))
            {
                answer += s1.Length;
                Console.WriteLine(answer);
                return;
            }

            if (s1.Equals(s2))
            {
                Console.WriteLine(answer);
                return;
            }
            if (s1.Length == 1)
            {
                answer += s2.Length - 1;
                Console.WriteLine(answer);
                return;
            }
            if (s2.Length == 1)
            {
                answer += s1.Length - 1;
                Console.WriteLine(answer);
                return;
            }

            var common = s1.Intersect(s2);
            var dict = new Dictionary<char, int[]>();
            foreach (var com in common)
            {
                dict.Add(com, new int[2]);
            }
            foreach (var ch in s1)
            {
                dict[ch][0]++;
            }
            foreach (var ch in s2)
            {
                dict[ch][1]++;
            }
            foreach (var item in dict)
            {
                answer += Math.Abs(item.Value[0] - item.Value[1]);
            }
            Console.WriteLine(answer);
        }

        static string RemoveCharacters(string s, IEnumerable<char> characters, ref int numRemoved)
        {
            if (!characters.Any()) return s;

            int len = s.Length;
            char[] newStr = new char[len];
            int newLength = 0; bool flag = true;
            for (int i = 0; i < len; i++)
            {
                char c = s[i];
                flag = true;
                foreach (var charr in characters)
                {
                    if (c == charr)
                    {
                        flag = false;
                        numRemoved++;
                        break;
                    }
                }
                if (flag)
                {
                    newStr[newLength++] = c;
                }
            }
            return new string(newStr, 0, newLength);
        }

        #endregion

        public static void KnightL()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            // your code goes here
            int count;
            int[,] result = new int[n - 1, n - 1];
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    count = BackTrackSearch(n, i, j);
                    result[i - 1, j - 1] = count;
                    if (i != j)
                    {
                        result[j - 1, i - 1] = count;
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write("{0} ", result[i, j]);
                }
                Console.WriteLine();
            }
        }

        static int GetNext(int a, int b, int boundary)
        {
            if (a == b)
            {
                var quot = (double)boundary / a;
                if (quot % 1 == 0) return (int)quot;
                return -1;
            }

            var current = Tuple.Create(0, 0);
            int count = 0;
            var good = Next(current, a, b, boundary, ref count);
            return good ? count : -1;
        }

        static bool Next(Tuple<int, int> current, int a, int b, int boundary, ref int count)
        {
            // in the end, at least one of them must move forward

            var possibilities = new Queue<Tuple<int, int>>();
            int x = current.Item1 + a;
            int y = current.Item2 + b;
            if (x <= boundary && y <= boundary)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            x = current.Item1 - a;
            y = current.Item2 + b;
            if (x >= 0 && y <= boundary)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            x = current.Item1 + a;
            y = current.Item2 - b;
            if (x <= boundary && y >= 0)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            // Movement has to be forward in either x or y, or both
            x = current.Item1 + b;
            y = current.Item2 + a;
            if (x <= boundary && y <= boundary)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            x = current.Item1 - b;
            y = current.Item2 + a;
            if (x >= 0 && y <= boundary)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            x = current.Item1 + b;
            y = current.Item2 - a;
            if (x <= boundary && y >= 0)
            {
                possibilities.Enqueue(Tuple.Create(x, y));
            }
            // Movement has to be forward in either x or y, or both

            if (possibilities.Count == 0)
            { //current is leaf
                var good = current.Item1 == boundary && current.Item2 == boundary;
                if (good)
                {
                    count++;
                    return true;
                }
                return false;
            }
            while (possibilities.Count > 0)
            {
                var succeeds = Next(possibilities.Dequeue(), a, b, boundary, ref count);
                if (succeeds)
                {
                    count++;
                    return true;
                }
            }
            return false;
        }
    }
}
