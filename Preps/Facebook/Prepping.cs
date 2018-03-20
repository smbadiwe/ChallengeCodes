using System;
using System.Collections.Generic;
using System.Linq;

namespace Preps.Facebook
{
    public class Prepping
    {
        /// <summary>
        /// Write a function that returns whether two words are exactly "one edit" away.
        /// An edit is:
        /// - Inserting one character anywhere in the word(including at the beginning and end)
        /// - Removing one character
        /// - Replacing one character
        /// </summary>
        /// <param name="s1">The s1.</param>
        /// <param name="s2">The s2.</param>
        /// <returns></returns>
        public static bool OneEditApart(string s1, string s2)
        {
            /*Examples:
                OneEditApart("cat", "cat") = false 
                OneEditApart("cat", "dog") = false 
                OneEditApart("cat", "cats") = true
                OneEditApart("cat", "cut") = true
                OneEditApart("cat", "cast") = true
                OneEditApart("cat", "at") = true
                OneEditApart("cat", "act") = false*/
            if (string.IsNullOrEmpty(s1))
                return !string.IsNullOrEmpty(s2) && s2.Length == 1;
            if (string.IsNullOrEmpty(s2))
                return !string.IsNullOrEmpty(s1) && s1.Length == 1;

            // ensure s2 length is greater
            if (s1.Length > s2.Length)
            {
                var t = s1;
                s1 = s2;
                s2 = t;
            }
            var lengthDiff =  s2.Length - s1.Length;
            if (lengthDiff > 1) return false;

            int editCount = 0;
            for (int i = 0, j = 0; i < s1.Length; i++, j++)
            {
                if (s1[i] != s2[j])
                {
                    if (editCount == 1) return false;

                    editCount = 1;
                    if (lengthDiff > 0)
                        j++;
                }
            }
            
            return (editCount == 1 || lengthDiff == 1);
        }

        public static void print_look_and_say_seq(int count = 0)
        {
            string val = "1";
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(val);
                val = output_val(val);
            }
        }

        private static string output_val(string input)
        {
            if (input.Length == 1)
            {
                return $"1{input}";
            }

            var result = "";
            var cur = input[0];
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (cur != input[i])
                {
                    result += $"{count}{cur}";
                    count = 1;
                    cur = input[i];
                }
                else
                {
                    count++;
                }
            }
            result += $"{count}{cur}";
            return result;
        }

        //public static int[][] Spiral(int n)
        //{
        //    var result = new int[n][];
        //    for (int i = 0; i < n; i++)
        //    {
        //        result[i] = new int[n];
        //    }

        //    int bound = n - 1, current = 1, end = n*n, currentDir = 0;
        //    int i = 0, j = 0;
        //    while (current <= end)
        //    {
        //        if (IsInvalid(result, i, j))
        //        {
        //            // Change direction
        //        }

        //        // Advance
        //        result[i][j] = current;
        //        current++;
        //    }

        //    return result;
        //}

        private static bool IsInvalid(int[][] result, int i, int j)
        {
            int n = result.Length;
            return (i < 0 || j < 0 || i >= n || j >= n || result[i][j] != 0);
        }

        #region Spiral - by predetermining sequence
        public static int[][] Spiral_BySequence(int n)
        {
            var sequence = GetSequence(n);
            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            Tuple<int, int> start = Tuple.Create(0, 0);
            int direction = 0, currentDigit = 1;
            for (int i = 0; i < sequence.Length; i++)
            {
                start = Move(result, start, sequence[i], direction % 4, ref currentDigit);
                direction++;
            }

            return result;
        }

        private static Tuple<int, int> Move(int[][] result, Tuple<int, int> start, int nSteps,
            int direction, ref int current)
        {
            int i = start.Item1, j = start.Item2;
            switch (direction)
            {
                case 0: // Right
                    for (int s = 0; s < nSteps; s++)
                    {
                        result[i][j] = current++;
                        j++;
                    }
                    // Next
                    i++;
                    j--;
                    break;
                case 1: // Down
                    for (int s = 0; s < nSteps; s++)
                    {
                        result[i][j] = current++;
                        i++;
                    }
                    // Next
                    i--;
                    j--;
                    break;
                case 2: // Left
                    for (int s = 0; s < nSteps; s++)
                    {
                        result[i][j] = current++;
                        j--;
                    }
                    // Next
                    i--;
                    j++;
                    break;
                case 3: // Up
                    for (int s = 0; s < nSteps; s++)
                    {
                        result[i][j] = current++;
                        i--;
                    }
                    // Next
                    j++;
                    i++;
                    break;
            }

            return Tuple.Create(i, j);
        }

        private static int[] GetSequence(int n)
        {
            int sequenceCount = 2 * n - 1;
            int[] sequence = new int[sequenceCount];
            sequence[0] = n;
            int cnt = 1, next = n - 1, r = 0;
            while (cnt < sequenceCount)
            {
                sequence[cnt] = next;
                if (r == 1)
                {
                    r = 0;
                    next--;
                }
                else
                {
                    r++;
                }
                cnt++;
            }
            return sequence;
        }

        #endregion

        public class Person
        {
            public int Birth { get; set; }
            public int Death { get; set; }
        }

        #region Approach 2: Build a table of birth-death diff

        public static int GetYearWithMostAlive_Solution2(Person[] people)
        {
            Dictionary<int, int> table = BuildTable(people);
            int maxPop = GetMaxPop(table);
            return maxPop;
        }

        private static Dictionary<int, int> BuildTable(Person[] people)
        {
            int[] birthYears = GetBirthYears(people);
            int[] deathYears = GetDeathYears(people);

            var birthYearsSet = new HashSet<int>(birthYears).ToArray();
            var deathYearsSet = new HashSet<int>(deathYears).ToArray();
            Array.Sort(birthYearsSet);
            Array.Sort(deathYearsSet);
            Dictionary<int, int> table = new Dictionary<int, int>();

            int b = 0, d = 0;
            while (b < birthYearsSet.Length)
            {
                var currBirth = birthYearsSet[b];
                var currDeath = deathYearsSet[d];
                if (currBirth < currDeath)
                {
                    table[currBirth] = GetCount(birthYears, currBirth);
                    b++;
                }
                else if (currBirth == currDeath)
                {
                    table[currBirth] = GetCount(birthYears, currBirth) - GetCount(deathYears, currDeath);
                    b++;
                    d++;
                }
                else
                {
                    table[currDeath] = -1 * GetCount(deathYears, currDeath);
                    d++;
                }
            }

            return table;
        }

        private static int GetCount(int[] deathYears, int currDeath)
        {
            int lo = 0, hi = deathYears.Length - 1;
            int count = 0, found = -1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (deathYears[mid] > currDeath)
                {
                    hi = (hi == mid) ? mid - 1 : mid;
                }
                else if (deathYears[mid] < currDeath)
                {
                    lo = (lo == mid) ? mid + 1 : mid;
                }
                else
                {
                    found = mid;
                    break;
                }
            }
            if (found > -1)
            {
                // from found, go backwards
                for (int i = found; i >= 0; i--)
                {
                    if (deathYears[i] == currDeath)
                        count++;
                    else break;
                }
                // from found, go forward
                for (int i = found + 1; i < deathYears.Length; i++)
                {
                    if (deathYears[i] == currDeath)
                        count++;
                    else break;
                }
            }

            return count;
        }

        private static int GetMaxPop(Dictionary<int, int> table)
        {
            int maxYear = 0, maxPop = 0, count = 0;
            foreach (var item in table)
            {
                count += item.Value;
                if (count > maxPop)
                {
                    maxPop = count;
                    maxYear = item.Key;
                }
            }
            return maxYear;
        }


        private static int[] GetDeathYears(Person[] people)
        {
            return people.Select(x => x.Death).ToArray();
        }

        private static int[] GetBirthYears(Person[] people)
        {
            return people.Select(x => x.Birth).ToArray();
        }

        #endregion

        #region Approach 1: 

        public static int GetYearWithMostAlive_Solution1(Person[] people)
        {
            int[] birthYears = GetBirthYearsSorted(people);
            int[] deathYears = GetDeathYearsSorted(people);
            Dictionary<int, int> birthsByYear = GetBirthsByYear(people);
            Dictionary<int, int> deathsByYear = GetDeathsByYear(people);

            Dictionary<int, int> totalPop = new Dictionary<int, int>();

            totalPop[birthYears[0]] = birthsByYear[birthYears[0]];
            int nextDeathYearIndex = 0, deathLowerBound = 0;
            for (int i = 1; i < birthYears.Length; i++)
            {
                while (birthYears[i] > deathYears[nextDeathYearIndex])
                {
                    nextDeathYearIndex++;
                }

                int pop = totalPop[birthYears[i - 1]] + birthsByYear[birthYears[i]];
                pop -= GetDeathsSoFar(deathYears, deathsByYear, deathLowerBound, nextDeathYearIndex);
                totalPop[birthYears[i]] = pop;
                deathLowerBound = nextDeathYearIndex;
            }
            return GetMaxPopYear(totalPop);
        }

        private static int GetDeathsSoFar(int[] deathYears, Dictionary<int, int> deathsByYear,
            int deathLowerBound, int nextDeathYearIndex)
        {
            int pop = 0;
            //B 75 80 84 90 92 94
            //D 76 80 82 85 95
            for (int i = deathLowerBound; i < nextDeathYearIndex; i++)
            {
                pop += deathsByYear[deathYears[i]];
            }

            return pop;
        }

        private static int[] GetDeathYearsSorted(Person[] people)
        {
            return people.Select(x => x.Death).OrderBy(x => x).ToArray();
        }

        private static int[] GetBirthYearsSorted(Person[] people)
        {
            return people.Select(x => x.Birth).OrderBy(x => x).ToArray();
        }

        private static Dictionary<int, int> GetDeathsByYear(Person[] people)
        {
            var table = new Dictionary<int, int>();
            foreach (var p in people)
            {
                if (table.ContainsKey(p.Death))
                {
                    table[p.Death]++;
                }
                else
                {
                    table[p.Death] = 1;
                }
            }
            return table;
        }

        private static Dictionary<int, int> GetBirthsByYear(Person[] people)
        {
            var table = new Dictionary<int, int>();
            foreach (var p in people)
            {
                if (table.ContainsKey(p.Birth))
                {
                    table[p.Birth]++;
                }
                else
                {
                    table[p.Birth] = 1;
                }
            }
            return table;
        }

        private static int GetMaxPopYear(Dictionary<int, int> totalPop)
        {
            int maxYear = -1, maxVal = -1;
            foreach (var item in totalPop)
            {
                if (item.Value > maxVal)
                {
                    maxVal = item.Value;
                    maxYear = item.Key;
                }
            }
            return maxYear;
        }
        #endregion
    }
}
