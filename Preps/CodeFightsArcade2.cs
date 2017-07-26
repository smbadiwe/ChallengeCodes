using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class CodeFightsArcade2
    {
        #region getShortestPalindrome - using the so-called KMP approach
        public static string getShortestPalindrome(String word)
        {
            return new string(getShortestPalindrome(word.ToCharArray()));
        }

        private static char[] getShortestPalindrome(char[] word)
        {
            int len = word.Length;
            int doublePlusSentinelLen = (len << 1) + 1; // same as len * 2 + 1

            char sentinel = (char)8;
            char[] palindromicBase = new char[doublePlusSentinelLen];

            // Set palindromicBase = reversedWord + sentinel + word
            var koo = new List<char>(doublePlusSentinelLen);
            koo.AddRange(word.Reverse());
            koo.Add(sentinel);
            koo.AddRange(word);
            palindromicBase = koo.ToArray();

            // Compute preprocessed table
            int[] table = new int[doublePlusSentinelLen + 1];
            computeTable(table, doublePlusSentinelLen, palindromicBase);

            // Generate output
            int longestPalindromicSuffix = Math.Min(len, table[doublePlusSentinelLen]);
            int numCharsToAppend = len - longestPalindromicSuffix;
            int shortestPalindromeLen = len + numCharsToAppend;
            char[] shortestPalindrome = new char[shortestPalindromeLen];

            for (int i = 0; i < len; i++)
            {
                shortestPalindrome[i] = word[i];
            }

            for (int i = len, j = 0; i < shortestPalindromeLen; i++, j++)
            {
                shortestPalindrome[i] = word[numCharsToAppend - j - 1];
            }

            return shortestPalindrome;
        }

        private static void computeTable(int[] table, int len, char[] word)
        {
            table[0] = -1;

            for (int i = 0; i < len; ++i)
            {
                int k = table[i];

                while (k >= 0 && word[k] != word[i])
                {
                    k = table[k];
                }

                table[i + 1] = k + 1;
            }
        }

        #endregion
        
        #region getShortestPalindrome - Easy approach
        public static string buildPalindrome(string st)
        {
            //var len = st.Length;
            //var ci = 0;
            //Debug.WriteLine(st);
            //while (st != string.Concat(st.Reverse()))
            //{
            //    st = st.Insert(len, st[ci++].ToString());
            //    Debug.WriteLine(st);
            //}
            //return st;
            
            // Shortest palindrome will be gotten by appending to st the reverse of what is left after
            // the longest suffix of st that is a palindrome has been removed. 
            if (IsPalindrome(st)) return st;

            var lsp = getLSP(st);
            var theRest = st.Substring(0, st.Length - lsp.Length);

            return st + string.Concat(theRest.Reverse());
        }

        // get longest suffix palindrome
        static string getLSP(string st)
        {
            int i = 1;
            while (i < st.Length)
            {
                if (IsPalindrome(st.Substring(i)))
                    return st.Substring(i);

                i++;
            }
            return "";
        }

        static bool IsPalindrome(string s)
        {
            int lo = 0, hi = s.Length - 1;
            while (lo < hi)
            {
                if (s[lo] != s[hi]) return false;
                lo++;
                hi--;
            }
            return true;
        }
        #endregion
    }
}
