using System;
using System.Collections.Generic;
using System.Linq;

namespace Preps
{
    public class CodeFightsArcade
    {
        /// <summary>
        /// Given a sorted array of integers a, find such an integer x that the value of
        /// abs(a[0] - x) + abs(a[1] - x) + ... + abs(a[a.length - 1] - x)
        /// is the smallest possible(here abs denotes the absolute value).
        /// If there are several possible answers, output the smallest one.
        /// HINT: It's the middle value
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int absoluteValuesSumMinimization(int[] a)
        {
            // Since array is sorted, this will be the middle element
            if (a.Length > 2)
                return a.Length % 2 == 0 ? a[(a.Length / 2) - 1] : a[a.Length / 2];

            return a[0];

            // Even better:
            // return a[(a.Length - 1)/2];
        }

        public static int depositProfit(int deposit, int rate, int threshold)
        {
            int result = 0;
            double amount = deposit;
            while (amount < threshold)
            {
                amount *= (rate + 100) / (double)100;
                result++;
            }
            return result;
        }

        public static string alphabeticShift(string inputString)
        {
            var charArr = new char[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                var ch = inputString[i] + 1;
                if (ch > 'z') ch = 'a';
                charArr[i] = (char)ch;
                //charArr[i] = (char)((inputString[i] - 96) % 26 + 97);
            }
            return new string(charArr);
        }

        public static int[][] minesweeper(bool[][] matrix)
        {

            int[][] result = new int[matrix.Length][];

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    result[i] = new int[matrix[i].Length];
            //}

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    for (int m = i - 1; m <= i + 1; m++)
                    {
                        if (m < 0) continue;
                        if (m >= matrix.Length) break;
                        for (int n = j - 1; n <= j + 1; n++)
                        {
                            if (n < 0) continue;
                            if (n >= matrix[m].Length) break;

                            if (m == i && n == j) continue;
                            if (matrix[m][n] == true)
                            {
                                result[i][j]++;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static int[][] boxBlur(int[][] image)
        {
            int[][] result = new int[image.Length - 2][];
            for (int i = 1; i < image.Length - 1; i++)
            {
                result[i - 1] = new int[image[i].Length - 2];
            }

            for (int i = 1; i < image.Length - 1; i++)
            {
                for (int j = 1; j < image[i].Length - 1; j++)
                {
                    int sum = 0;
                    for (int m = i - 1; m <= i + 1; m++)
                    {
                        for (int n = j - 1; n <= j + 1; n++)
                        {
                            sum += image[m][n];
                        }
                    }
                    int el = sum / 9;
                    result[i - 1][j - 1] = el;
                }
            }
            return result;
        }


        /// <summary>
        ///<para>You are given an array of integers representing coordinates of obstacles situated on a straight line.
        /// Assume that you are jumping from the point with coordinate 0 to the right.You are allowed only to make jumps of the same length represented by some integer.
        /// Find the minimal length of the jump enough to avoid all the obstacles.</para> 
        ///<para> This problem could have been worded a bit more clearly. 
        /// Instead of focusing on "number of jumps" and "minimum jump size", we are really looking for 
        /// the minimum number D that is not a divisor of any number in inputArray.</para>
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static int avoidObstacles(int[] inputArray)
        {
            Array.Sort(inputArray);
            int result = 2;
            int endIndex = inputArray.Length - 1; // or more

            while (true)
            {
                foreach (var item in inputArray)
                {
                    if (item % result == 0)
                        break;
                    if (item == inputArray[endIndex])
                        return result;
                }
                result++;
            }
        }


        /// <summary>
        /// Two arrays are called similar if one can be obtained from another 
        /// by swapping at most one pair of elements in one of the arrays.
        /// Given two arrays, check whether they are similar.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool areSimilar(int[] A, int[] B)
        {
            bool flag = true;
            int index = 0, x = -1, y = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    flag = false;
                    index++;
                    if (x == -1)
                    {
                        x = i;
                    }
                    else
                    {
                        y = i;
                    }
                }
            }
            if (flag == true) return true;
            if (index != 2) return false;
            if (index == 2)
            {
                return (A[x] == B[y] && A[y] == B[x]);
            }
            return false;
        }

        public static string[] addBorder(string[] picture)
        {

            var yLength = picture.Length;
            var xLength = picture[0].Length;
            var newWidth = xLength + 2;
            var newHeight = yLength + 2;
            var result = new string[newHeight];
            for (int i = 0; i < newHeight; i++)
            {
                var ch = new char[newWidth];
                ch[0] = ch[newWidth - 1] = '*';
                if (i == 0 || i == newHeight - 1)
                {
                    for (int j = 1; j < newWidth - 1; j++)
                    {
                        ch[j] = '*';
                    }
                }
                else
                {
                    for (int j = 1; j < newWidth - 1; j++)
                    {

                        ch[j] = picture[i - 1][j - 1];
                    }
                }
                result[i] = new string(ch);
            }
            return result;
        }

        #region Reverse Parentheses in a string
        /// <summary>
        /// You have a string s that consists of English letters, punctuation marks, 
        /// whitespace characters, and brackets. It is guaranteed that the parentheses 
        /// in s form a regular bracket sequence.
        /// Your task is to reverse the strings contained in each pair of matching parentheses, 
        /// starting from the innermost pair.The results string should not contain any parentheses.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string reverseParentheses(string s)
        {
            if (s.IndexOf(')') == -1) return s;
            return reverse(s);
        }

        private static string swap(string s)
        {
            var ch = s.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }

        private static string reverse(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    int catcher = 0;
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j] == '(')
                        {
                            catcher++;
                        }
                        else if (s[j] == ')')
                        {
                            if (catcher > 0)
                            {
                                catcher--;
                            }
                            else
                            {
                                return s.Substring(0, i)
                                         + swap(reverse(s.Substring(i + 1, j - i - 1)))
                                         + reverse(s.Substring(j + 1));
                            }
                        }
                    }
                }
            }

            return s;
        }
        #endregion

        /// <summary>
        /// True if the sum of first half of the digits equals the second.
        /// The number of digits of n is guaranteed to be even.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        bool isLucky(int n)
        {
            int length = (int)Math.Log10(n) + 1; //integer part + 1
            int sum1 = 0, sum2 = 0;

            // last half
            for (int i = 1; i <= length / 2; i++)
            {
                sum1 += n % 10;
                n /= 10;
            }

            // first half
            while (n != 0)
            {
                sum2 += n % 10;
                n /= 10;
            }

            return sum1 == sum2;
        }

        #region Given two strings, find the number of common characters between them.
        /// <summary>
        /// Given two strings, find the number of common characters between them.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int commonCharacterCount(string s1, string s2)
        {
            var common = s1.Intersect(s1);
            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();
            foreach (var item in common)
            {
                dict1.Add(item, 0);
                dict2.Add(item, 0);
            }
            foreach (var item in s1)
            {
                if (dict1.ContainsKey(item))
                {
                    dict1[item]++;
                }
            }
            foreach (var item in s2)
            {
                if (dict2.ContainsKey(item))
                {
                    dict2[item]++;
                }
            }
            int total = 0;
            foreach (var item in common)
            {
                total += Math.Min(dict1[item], dict2[item]);
            }
            return total;
        }

        #endregion

        public static bool almostIncreasingSequence(int[] sequence)
        {
            bool found = false;
            int prev = 0, prev2 = 0; // prev2 came before prev

            for (int i = 0; i < sequence.Length; i++)
            {
                int t = sequence[i];
                bool remove = false;

                if (i > 0)
                {
                    if (prev.CompareTo(t) >= 0)
                    {
                        if (found)
                        {
                            return false;
                        }

                        // So, which one do we delete? If the element before the previous
                        // one is in sequence with the current element, delete the previous
                        // element. If it's out of sequence with the current element, delete
                        // the current element. If we don't have a previous previous element,
                        // delete the previous one.
                        if (i > 1 && prev2.CompareTo(t) >= 0)
                        {
                            remove = true;
                        }

                        found = true;
                    }
                }
                if (!found)
                {
                    prev2 = prev;
                }
                if (!remove)
                {
                    prev = t;
                }
            }

            return true;
        }

    }
}
