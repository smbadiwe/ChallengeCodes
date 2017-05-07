using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    class CodeFightsSkillTest
    {
        public static long totalOnes(int k)
        {
            long count = 0;
            while (k > 0)
            {
                count = count + 1;
                k = k & (k - 1);
            }
            // Naive. Fails when number gets large
            //for (int i = 1; i <= k; i++)
            //{
            //    var bin = Convert.ToString(i, 2);
            //    count += bin.Count(x => x == '1');
            //}
            return count;
        }


        /// <summary>
        /// The change-making problem addresses the following question: 
        /// how can a given amount of money be made with the least number 
        /// of coins of given denominations? It is a knapsack type problem, 
        /// and has applications wider than just currency.
        /// 
        /// Solution using DP
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static int Chemicals(int totalAmount, int[] containers)
        {
            int m = containers.Length;
            // store[i] will be storing the minimum number of containers
            // required for i value.  So store[V] will have result
            int[] store = new int[totalAmount + 1];

            // Base case (If totalAmount is 0)
            store[0] = 0;

            // Initialize all store values as Infinite
            for (int i = 1; i <= totalAmount; i++)
            {
                store[i] = int.MaxValue;
            }
            // Compute minimum containers required for all
            // values from 1 to totalAmount
            for (int i = 1; i <= totalAmount; i++)
            {
                // Go through all containers smaller than i
                for (int j = 0; j < m; j++)
                {
                    if (containers[j] <= i)
                    {
                        int count = store[i - containers[j]];
                        if (count != int.MaxValue && count + 1 < store[i])
                        {
                            store[i] = count + 1;
                        }
                    }
                }
            }
            return store[totalAmount] == int.MaxValue ? -1 : store[totalAmount];
        }

        /// <summary>
        /// TODO: Revisit https://codefights.com/interview/TPxvfH3RYn2SatY8C/topics/hashstores/description
        /// Given an array of integers a, 
        /// find the number of pairs of numbers ai and aj, where i ≠ j, 
        /// such that the sum of ai + ajis also present in a.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int pairsSum(int[] a)
        {
            int len = a.Length;
            if (len == 1) return 0;

            Array.Sort(a);
            int sum, count = 0;

            for (int i = 1; i < len; i++)
            {
                sum = a[i];
                int left = 0, right = i;
                while (left < right)
                {
                    bool reset = false;
                    if (right - left == 1)
                    {
                        reset = true;
                    }
                    if (sum == a[left] + a[right])
                    {
                        count++;
                    }
                    left++;
                    if (reset)
                    {
                        left = 0;
                        right--;
                    }
                }
                //for (int j = 0; j < i; j++)
                //{
                //    for (int k = j + 1; k <= i; k++)
                //    {
                //        if (sum == a[j] + a[k])
                //        {
                //            count++;
                //        }
                //    }
                //}
            }

            return count;
        }

        string decodeString2(string s)
        {

            while (s != (s = System.Text.RegularExpressions.Regex.Replace(s, @"([0-9]*)\[([a-z]*)\]", m => string.Join(m.Groups[2].Value, new string[int.Parse(m.Groups[1].Value) + 1])))) ;
            return s;
        }
        public static string decodeString(string s)
        {
            string res = "";
            if (string.IsNullOrWhiteSpace(s)) return res;

            Stack<int> multipliers = new Stack<int>();
            Stack<string> results = new Stack<string>();
            int i = 0;
            while (i < s.Length)
            {
                if (char.IsDigit(s[i]))
                {
                    int count = 0;
                    while (char.IsDigit(s[i]))
                    {
                        count = 10 * count + (s[i] - '0');
                        i++;
                    }
                    multipliers.Push(count);
                }
                else if (s[i] == '[')
                {
                    results.Push(res);
                    res = "";
                    i++;
                }
                else if (s[i] == ']')
                {
                    StringBuilder temp = new StringBuilder(results.Pop());
                    int repeatTimes = multipliers.Pop();
                    for (int j = 0; j < repeatTimes; j++)
                    {
                        temp.Append(res);
                    }
                    res = temp.ToString();
                    i++;
                }
                else
                {
                    res += s[i++];
                }
            }
            return res;
        }

        /// <summary>
        /// TODO: Still failing https://codefights.com/interview/eLcCSQkH9Bd7A6Mep/topics/stacks/description
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
            if (a.Length == 1) return new[] { -1 };

            Stack<int> s = new Stack<int>(a.Length);
            s.Push(a[0]);

            int next = -1, popped = -1;
            var result = new List<int>(a.Length);
            for (int i = 1; i < a.Length; i++)
            {
                next = a[i];
                bool pushNext = false;
                if (s.Count > 0)
                {
                    popped = s.Pop();
                    while (popped < next)
                    {
                        pushNext = true;
                        result.Add(next);
                        if (s.Count == 0)
                        {
                            break;
                        }
                        popped = s.Pop();
                    }

                    if (next < popped)
                    {
                        s.Push(popped);
                    }
                }
                if (pushNext)
                {
                    s.Push(next);
                }
                //else
                //{
                //    result.Add(-1);
                //}
            }
            while (s.Count > 0)
            {
                s.Pop();
                result.Add(-1);
            }
            return result.ToArray();
        }


        #region minimumOnStack - O(operations.Length) time
        /// <summary>
        /// Implement a modified stack that, in addition to using push and pop operations, 
        /// allows you to find the current minimum element in the stack by using a min operation.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static int[] minimumOnStack(string[] operations)
        {
            var results = new List<int>();
            LinkedList<int> wer = new LinkedList<int>();

            var stack = new MyStack();
            foreach (var query in operations)
            {
                switch (query)
                {
                    case "min":
                        results.Add(stack.MinValue);
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                    default: //push
                        var split = query.Split(' ');
                        if (split.Length == 2 && split[0] == "push")
                        {
                            int data;
                            if (int.TryParse(split[1], out data))
                            {
                                stack.Push(data);
                            }
                        }
                        break;
                }
            }
            return results.ToArray();
        }

        class MyStack
        {
            private LinkedList<int> _stack;
            private int _count;
            public MyStack()
            {
                _stack = new LinkedList<int>();
                _count = 0;
            }
            public int MinValue { get; set; }

            public void Push(int data)
            {
                if (_count == 0)
                {
                    MinValue = data;
                    _stack.AddFirst(data);
                }
                else
                {
                    if (data >= MinValue)
                    {
                        _stack.AddFirst(data);
                    }
                    else
                    {
                        _stack.AddFirst((2 * data - MinValue));
                        MinValue = data;
                    }
                }
                _count++;
            }

            public void Pop()
            {
                var item = _stack.First.Value;
                _stack.RemoveFirst();
                _count--;
                if (_count == 1)
                {
                    MinValue = _stack.First.Value;
                }
                else
                {
                    if (item < MinValue)
                    {
                        MinValue = 2 * MinValue - item;
                    }
                }
            }
        }

        #endregion

        #region sumSubsets
        /// <summary>
        /// Failed at the task. Revisit later - https://codefights.com/interview/kEgA4DXcfXuriqGru
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[][] sumSubsets(int[] arr, int num)
        {
            var emptyVal = new int[1][];
            emptyVal[0] = new int[0];
            if (num == 0 || arr.Length == 0)
            {
                return emptyVal;
            }
            int arrLength = arr.Length;
            var results = new HashSet<IList<int>>(new EqComparer());
            for (int h = 0; h < arrLength; h++)
            {
                int arrVal = arr[h];
                // since the array is sorted
                if (arrVal > num)
                {
                    break;
                }
                if (arrVal == num)
                {
                    results.Add(new[] { arrVal });
                    break;
                }

                List<int> partialList = new List<int>();
                partialList.Add(arrVal);
                int partialSum = arrVal;
                for (int i = h + 1; i < arrLength; i++)
                {
                    int val = arr[i];
                    // since the array is sorted
                    if (partialSum + val < num)
                    {
                        partialSum += val;
                        partialList.Add(val);
                    }
                    else if (partialSum + val == num)
                    {
                        partialSum += val;
                        partialList.Add(val);
                        results.Add(new List<int>(partialList));
                        partialList.Clear();
                        //partialSum = arrVal;
                    }
                    else // if partialSum > num
                    {
                        int sumAgain = val;
                        var newParticular = new List<int>();
                        foreach (var item in partialList)
                        {
                            if (sumAgain + item <= num)
                            {
                                sumAgain += item;
                                newParticular.Add(item);
                                if (sumAgain == num)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (newParticular.Count > 0)
                        {
                            newParticular.Add(val);
                            if (sumAgain == num)
                            {
                                results.Add(newParticular);
                                //partialSum = arrVal;
                            }
                        }
                    }
                    partialSum = arrVal;
                }

                if (partialList.Count > 0 && partialSum == num)
                {
                    results.Add(partialList);
                }
            }

            if (results.Count == 0) return emptyVal;
            var toReturn = new int[results.Count][];
            int r = 0;
            foreach (var item in results)
            {
                toReturn[r] = item.ToArray();
                r++;
            }
            return toReturn;
        }

        class EqComparer : EqualityComparer<IList<int>>
        {
            public override bool Equals(IList<int> x, IList<int> y)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] != y[i]) return false;
                }
                return true;
            }

            public override int GetHashCode(IList<int> obj)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < obj.Count; i++)
                {
                    sb.Append(obj[i]);
                }
                return sb.GetHashCode();
            }
        }

        #endregion

        /*Given two words, beginWord and endWord, and a wordList of approved words, find the length of the 
         * shortest transformation sequence from beginWord to endWord such that:
            Only one letter can be changed at a time
            Each transformed word must exist in the wordList.
        Return the length of the shortest transformation sequence, or 0 if no such transformation sequence exists.
        */
        private static int wordLadder(string beginWord, string endWord, string[] wordList)
        {
            List<string> dict = new List<string>(wordList);
            Queue<string> wordSearch = new Queue<string>();
            Queue<int> lengthCount = new Queue<int>();
            wordSearch.Enqueue(beginWord);
            lengthCount.Enqueue(1);
            while (wordSearch.Count > 0)
            {
                string analyzing = wordSearch.Dequeue();
                int curCount = lengthCount.Dequeue();
                if (analyzing.Equals(endWord))
                {
                    return curCount;
                }
                for (int j = 0; j < analyzing.Length; j++)
                {
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        char[] possibleMatch = analyzing.ToArray();
                        possibleMatch[j] = i;
                        String checkMatch = new String(possibleMatch);
                        if (dict.Contains(checkMatch))
                        {
                            dict.Remove(checkMatch);
                            lengthCount.Enqueue(curCount + 1);
                            wordSearch.Enqueue(checkMatch);
                        }
                    }
                }
            }
            return 0;
        }

        public static int countVisibleTowerPairs(int[] position, int[] height)
        {
            var kvp = new Dictionary<int, int>(position.Length);
            for (int i = 0; i < position.Length; i++)
            {
                kvp.Add(position[i], height[i]);
            }
            int count = 0; ;
            var set = kvp.OrderBy(x => x.Key).ToArray();
            for (int i = 0; i < set.Length - 1; i++)
            {
                count += 1; // for the nearest neighbor : j = i+1
                for (int j = i + 2; j < set.Length; j++)
                {
                    //TODO: the math
                    int x_diff = set[j].Key - set[i].Key;
                    int y_diff = set[j].Value - set[i].Value;
                    bool isGood = true;
                    for (int k = i + 1; k < j; k++)
                    {
                        int x_sm = set[k].Key - set[i].Key;
                        int y_sm = set[k].Value - set[i].Value;

                        if ((double)y_sm > ((double)(x_sm * y_diff) / x_diff))
                        {
                            isGood = false;
                            break;
                        }
                    }
                    if (isGood)
                    {
                        count += 1;
                    }
                }

            }

            return count;
        }

        /*
         * In the popular Minesweeper game you have a board with some mines and those 
         * cells that don't contain a mine have a number in it that indicates the total 
         * number of mines in the neighboring cells. Starting off with some arrangement 
         * of mines we want to create a Minesweeper game setup.
         */
        int[][] minesweeper(bool[][] matrix)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            int[][] result = new int[x][];
            for (int ix = 0; ix < x; ix++)
            {
                result[ix] = new int[y];
            }

            //Middle cells
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int cellVal = 0;
                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        if (k < 0) continue;
                        if (k >= x) break;
                        for (int m = j - 1; m <= j + 1; m++)
                        {
                            if (m < 0) continue;
                            if (m >= y) break;
                            if ((k == i && m == j) == false)
                            {
                                if (matrix[k][m])
                                {
                                    cellVal += 1;
                                }
                            }
                        }
                    }

                    result[i][j] = cellVal;
                }

            }
            return result;
        }

        /*
         Digit root of some positive integer is defined as the sum of all of its digits.
            You are given an array of integers. Sort it in such a way that if a comes before b 
            then the digit root of a is less than or equal to the digit root of b. If two 
            numbers have the same digit root, the smaller one (in the regular sense) should 
            come first. 
            For example 4 and 13 have the same digit root, however 4 < 13 thus 4 comes before 13 
            in any digitRoot sorting where both are present.
        */
        public static int[] digitRootSort(int[] a)
        {

            if (a == null || a.Length == 0) return null;
            if (a.Length == 1) return new[] { digitRoot(a[0]) };

            //I've assumed array values are distinct
            int[] results = new int[a.Length];
            Dictionary<int, int> dRoots = new Dictionary<int, int>(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                dRoots.Add(a[i], digitRoot(a[i]));
                results[i] = -1;
            }

            int j = 0, prevVal = 0, prevKey = 0;
            bool didDouble = false;
            var set = dRoots.OrderBy(x => x.Value);
            foreach (var item in set)
            {
                if (j > 0)
                {
                    if (didDouble)
                    {
                        if (results[j] == -1)
                        {
                            results[j] = item.Key;
                        }
                        didDouble = false;
                    }
                    else if (prevVal == item.Value)
                    {
                        if (prevKey < item.Key)
                        {
                            if (results[j - 1] == -1)
                            {
                                results[j - 1] = prevKey;
                            }
                            results[j] = item.Key;
                        }
                        else
                        {
                            if (results[j - 1] == -1)
                            {
                                results[j - 1] = item.Key;
                            }
                            results[j] = prevKey;
                        }
                        didDouble = true;
                    }
                    else
                    {
                        if (results[j - 1] == -1)
                        {
                            results[j - 1] = prevKey;
                        }
                    }
                }
                j++;
                prevKey = item.Key;
                prevVal = item.Value;
            }

            return results;
        }

        static int digitRoot(int numV)
        {
            if (numV < 10) return numV;

            int root = 0;

            while (numV > 0)
            {
                root += numV % 10;
                numV /= 10;
            }
            return root;
        }

    }
}
