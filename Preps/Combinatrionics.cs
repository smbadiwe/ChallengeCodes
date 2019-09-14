using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class Combinatrionics
    {
        /// <summary>
        /// Given a text txt[0..n-1] and a pattern pat[0..m-1], write a function 
        /// search(char pat[], char txt[]) that prints all occurrences of pat[] in txt[]. 
        /// You may assume that n > m.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static List<int> FindPatternsInString(string txt, string pat)
        {
            // The worst case complexity of Naive algorithm is O(m(n-m+1)). 
            int M = pat.Length;
            int N = txt.Length;
            var indexes = new List<int>();
            /* A loop to slide pat one by one */
            for (int i = 0; i <= N - M; i++)
            {
                int j;

                /* For current index i, check for pattern 
                match */
                for (j = 0; j < M; j++)
                    if (txt[i + j] != pat[j])
                        break;

                // if pat[0...M-1] = txt[i, i+1, ...i+M-1]
                if (j == M)
                    indexes.Add(i);
                    //Console.WriteLine("Pattern found at index " + i);
            }

            return indexes;
        }

        //Not working
        public static List<int> FindPatternsInString_KMP(string text, string pattern)
        {
            var indexes = new List<int>();
            // Time complexity of KMP algorithm is O(n) in worst case.
            int j = 0, k = 0;
            int[] table = new int[3];
            int nP = 0; // num of positions
            while (j < text.Length)
            {
                if (pattern[k] == text[j])
                {
                    j++;
                    k++;
                    if (k == pattern.Length)
                    {
                        indexes.Add(j - k);
                        k = table[k];
                    }
                }
                else
                {
                    k = table[k];
                    if (k < 0)
                    {
                        j++;
                        k++;
                    }
                }
            }

            return indexes;
        }

        public static string RemoveDuplicateChars(string str)
        {
            var chars = new bool[256];
            var sb = new StringBuilder();
            foreach (var ch in str)
            {
                if (chars[ch]) continue;

                chars[ch] = true;
                sb.Append(ch);
            }
            return sb.ToString();
        }
        
        public static void PrintLockCombinations(int[][] hints)
        {
            /*
             new vector<int>{1, 2, 3},
             new vector<int>{4, 5},
             new vector<int>{6, 7, 8};
            */
            int nDigits = hints.Length;

            var result = new int[nDigits];
            // do first one
            for (int i = 0; i < nDigits; i++)
            {
                result[i] = hints[i][0];
            }

            var sb = new StringBuilder();
            while (true)
            {
                sb.AppendFormat("{0}\n", string.Join("-", result));

                for (int i = nDigits - 1; i >= -1; i--)
                {
                    if (i == -1)
                    {
                        Console.WriteLine(sb);
                        return;
                    }
                    
                    if ((i == 0 && result[i] == hints[i].Last())
                        || result[i] == hints[i].Last())
                    {
                        // back to beginning
                        result[i] = hints[i].First();
                    }
                    else
                    {
                        // set to the next one
                        for (int j = 0; j < hints[i].Length; j++)
                        {
                            if (hints[i][j] == result[i])
                            {
                                result[i] = hints[i][j + 1];
                                break;
                            }
                        }
                        break;
                    }
                    
                }
            }
        }

        public static void PrintTimesOfDay()
        {
            var sb = new StringBuilder();
            //HH:mm:ss
            var result = new int[3];
            // The first one: 00:00:00
            while (true)
            {
                sb.AppendFormat("{0:D2}:{1:D2}:{2:D2}\n", result[0], result[1], result[2]);
                
                for (int i = 2; i >= -1; i--)
                {
                    if (i == -1)
                    {
                        // return
                        Console.WriteLine(sb);
                        return;
                    }
                    // hr stops at 23; mm and ss resets at 59
                    if ((i == 0 && result[i] == 23) || (result[i] == 59))
                    {
                        result[i] = 0;
                    }
                    else
                    {
                        result[i]++;
                        break;
                    }
                }

            }
        }

        #region Phone Numbers to Words        
        /// <summary>
        /// Prints all the word equivalents of a given phone number.
        /// </summary>
        /// <param name="sevenDigitNumber">The seven digit number.</param>
        public static void PrintWords(string sevenDigitNumber)
        {
            //char[] result = new char[sevenDigitNumber.Length];
            //PrintWords_Recursion(sevenDigitNumber, 0, result);
            PrintWords_Loop(sevenDigitNumber);
        }

        private static void PrintWords_Loop(string sevenDigitNumber)
        {
            var length = sevenDigitNumber.Length;
            char[] result = new char[length];
            // start with the first phone word
            for (int i = 0; i < length; i++)
            {
                result[i] = GetCharKey(sevenDigitNumber[i] - '0', 1);
            }
            
            while (true)
            {
                Console.WriteLine(new string(result));

                // start at end and increment from right to left
                for (int i = length - 1; i >= -1; i--)
                {
                    if (i == -1) return;

                    var currentKey = sevenDigitNumber[i] - '0';
                    // start from high value [3] and deal wiuth 0 and 1 at once
                    if (GetCharKey(currentKey, 3) == result[i]
                        || currentKey == 0 || currentKey == 1)
                    {
                        result[i] = GetCharKey(currentKey, 1); // back to start
                    }
                    else if (GetCharKey(currentKey, 2) == result[i])
                    {
                        result[i] = GetCharKey(currentKey, 3); // move forward
                        break;
                    }
                    else if (GetCharKey(currentKey, 1) == result[i])
                    {
                        result[i] = GetCharKey(currentKey, 2); // move forward
                        break;
                    }
                }
            }
        }
        private static void PrintWords_Recursion(string sevenDigitNumber, int currentDigit, char[] result)
        {
            // INTUITION
            // Changing the letter in position i 
            // causes the letter in position i+1 to cycle through its values.

            /* BASE CASE: Why?
            The frst letter cycles only once. Therefore,
            if you start by cycling the frst letter, this causes multiple cycles of the second letter, which causes
            multiple cycles of the third letter — exactly as desired. After you change the last letter, you can’t
            cycle anything else, so this is a good base case to end the recursion. When the base case occurs, you
            should also print out the word because you’ve just generated the next word in alphabetical order.
            */
            if (sevenDigitNumber.Length == currentDigit)
            {
                Console.WriteLine(new string(result));
                return;
            }
            for (int i = 1; i <= 3; i++)
            {
                var current = sevenDigitNumber[currentDigit] - '0';
                result[currentDigit] = GetCharKey(current, i);
                PrintWords_Recursion(sevenDigitNumber, currentDigit + 1, result);
                // You don’t want to print out any word three times, so you should check for this case 
                // and cycle immediately if you encounter it.
                if (current == 0 || current == 1)
                    return;
            }
        }

        /// <summary>
        /// which takes a telephone key (0–9) and a place of either 1, 2, 3 and returns the
        /// character corresponding to the letter in that position on the specifed key.For
        /// example, GetCharKey(3,2) will return ‘E’ because the telephone key 3 has the
        /// letters “DEF” on it and ‘E’ is the second letter.
        /// </summary>
        /// <param name="telephoneKey">The telephone key.</param>
        /// <param name="place">The place.</param>
        /// <returns></returns>
        private static char GetCharKey(int telephoneKey, int place)
        {
            return keypad[telephoneKey][place - 1];
        }
        private static string[] keypad = new[]
        {
            "000", "111",
            "ABC", "DEF", "GHI",
            "JKL", "MNO", "PRS",
            "TUV", "WXY"
        };
        #endregion

        #region Combination: Subsets of a set of size n. Again, n -> 2^n
        public static IEnumerable<IEnumerable<T>> GetSubsets_Recursive_Linq<T>(IEnumerable<T> source)
        {
            // base case
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

            // get the first element
            var element = source.Take(1);

            // get the subsets of the remaining set
            var haveNots = GetSubsets_Recursive_Linq(source.Skip(1));

            // add element to all the items in the subset gotten above
            var haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
        }

        // O(n*2^n)
        public static List<List<T>> GetSubsets_BitArray<T>(List<T> source)
        {
            int nElements = source.Count;
            int nSubsets = 1 << nElements; // 2^n
            var list = new List<List<T>>(nSubsets);
            for (int i = 0; i < nSubsets; i++)
            {
                var items = new List<T>();
                BitArray b = new BitArray(BitConverter.GetBytes(i));
                for (int bit = 0; bit < nElements; bit++)
                {
                    if (b[bit]) items.Add(source[bit]);
                    //items[bit] = b[bit] ? source[bit] : default(T);
                }
                list.Add(items);
            }
            return list;
        }

        // Write a method to return all subsets of a set
        public static List<List<T>> GetSubsets_Recursive<T>(List<T> source)
        {
            return GetSubsets_Recursive(source, source.Count - 1);
        }

        private static List<List<T>> GetSubsets_Recursive<T>(List<T> set, int index)
        {
            var allSubsets = new List<List<T>>();
            if (index == -1)
            {
                // Base case: empty set
                allSubsets.Add(new List<T>());
            }
            else
            {
                // Generating P(n) for the general case is just a simple generalization:
                // We compute P(n-1), clone the results, and then add a_n to each of these cloned sets. 
                allSubsets = GetSubsets_Recursive(set, index - 1);
                var theRest = new List<List<T>>();
                T item = set[index];
                foreach (var subset in allSubsets)
                {
                    var newSubset = new List<T>(1 + subset.Count);
                    newSubset.AddRange(subset);
                    newSubset.Add(item);

                    theRest.Add(newSubset);
                }
                allSubsets.AddRange(theRest);
            }
            return allSubsets;
        }
        #endregion

        #region String Combinations       
        public static List<string> Combinations(string str)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(str))
            {
                return result;
            }
            Combinations_Prefix("", str, result);
            return result;
        }

        private static void Combinations_Prefix(string prefix, string str, List<string> result)
        {
            int nElements = str.Length;
            int nSubsets = 1 << nElements; //2^n
            for (int i = 0; i < nSubsets; i++)
            {
                var sb = new StringBuilder();
                var b = new BitArray(BitConverter.GetBytes(i));
                for (int bit = 0; bit < nElements; bit++)
                {
                    if (b[bit]) sb.Append(str[bit]);
                }
                result.Add(sb.ToString());
            }
        }

        private static void Combinations(string prefix, string str, List<string> result)
        {
            // excude the empty subset. Optional.
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result.Add(prefix);
            }
            for (int i = 0; i < str.Length; i++)
            {
                Combinations(prefix + str[i], str.Substring(i + 1), result);
            }
        }

        /// <summary>
        /// Print all 2^n combinations of the specified string of length n.
        /// </summary>
        /// <param name="str">The string.</param>
        public static void Combinations_Printed(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine(str);
                return;
            }
            Combinations_Printed("", str);
        }

        private static void Combinations_Printed(string prefix, string str)
        {
            // excude the empty subset. Optional.
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                Console.WriteLine(prefix);
            }
            // for each character in the string
            for (int i = 0; i < str.Length; i++)
            {
                // join it to the prefix and make str start from the index next to i
                Combinations_Printed(prefix + str[i], str.Substring(i + 1));
            }
        }
        #endregion

        #region String Permutation
        public static void Permutations(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine(str);
                return;
            }
            //Permutations(str, 0, str.Length - 1);
            var perms = PermutationsFromStart(str, 0);
            //var perms = PermutationsFromEnd(str, str.Length - 1);
            foreach (var item in perms)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total: " + perms.Count);
        }

        private static ICollection<string> PermutationsFromStart(string str, int index)
        {
            //e.g. abc: => abc bac bca acb cab
            // cab acb abc
            // cba bca bac
            if (index == str.Length - 1)
            {
                return new[] { str[index].ToString() };
            }

            var result = new HashSet<string>();
            char ch = str[index];
            // permute all before ch
            var set = PermutationsFromStart(str, index + 1);
            // for each item in set, 
            foreach (var item in set)
            {
                // add ch to all possible positions
                for (int i = 0; i < str.Length - index; i++)
                {
                    string newWord = InsertCharAt(item, ch, i);
                    result.Add(newWord);
                }
            }

            return result;
        }
        private static ICollection<string> PermutationsFromEnd(string str, int index)
        {
            if (index == 0)
            {
                return new[] { str[0].ToString() };
            }

            var result = new HashSet<string>();
            var item = str[index];

            // We solve for f ( n - 1 ), and then push a_n into every spot in each of these strings. 
            var set1 = PermutationsFromEnd(str, index - 1);
            foreach (var word in set1)
            {
                for (int i = 0; i <= index; i++)
                {
                    var newWord = InsertCharAt(word, item, i);

                    result.Add(newWord);
                }
            }
            return result;
        }

        /// <summary>
        /// Permutations of the specified string. Only works with string with no duplicate characters
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        private static void Permutations(char[] str, int left, int right)
        {
            if (left == right)
            {
                Console.WriteLine(str);
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(str, left, i);
                    Permutations(str, left + 1, right);
                    Swap(str, left, i);
                }
            }
        }

        private static string InsertCharAt(string item, char ch, int i)
        {
            return item.Substring(0, i) + ch + item.Substring(i);
        }

        private static void Swap(char[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        #endregion
    }
}
