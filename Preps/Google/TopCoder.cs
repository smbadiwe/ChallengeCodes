using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    class TopCoder
    {

        public string createString_ABC(int N, int K)
        {
            /*You are given two s: N and K. Lun the dog is interested in strings that satisfy the following conditions:

The string has exactly N characters, each of which is either 'A', 'B' or 'C'.
The string s has exactly K pairs (i, j) (0 <= i < j <= N-1) such that s[i] < s[j].
If there exists a string that satisfies the conditions, find and return any such string. Otherwise, return an empty string.

 
            - N will be between 3 and 30, inclusive.
            - K will be between 0 and N(N-1)/2, inclusive.
             */
            return "";
        }

        //This case is supposed to be failing
        // BBBBABABBBBBBA, BBBBABABBABBBBBBABABBBBBBBBABAABBBAA
        public string canObtain(string initial, string target)
        {
            /*Problem Statement
                One day, Jamie noticed that many English words only use the letters A and B. 
                Examples of such words include "AB" (short for abdominal), "BAA" (the noise a sheep 
                makes), "AA" (a type of lava), and "ABBA" (a Swedish pop sensation).


                Inspired by this observation, Jamie created a simple game. 
                You are given two s: initial and target. The goal of the game is to find a sequence of 
                valid moves that will change initial into target. There are two types of valid moves:

                - Add the letter A to the end of the string.
                - Reverse the string and then add the letter B to the end of the string.
                Return "Possible" (quotes for clarity) if there is a sequence of valid moves that will 
                change initial into target. Otherwise, return "Impossible".
                */

            var isGood = doCanObtain(initial, target);
            return isGood ? "Possible" : "Impossible";
        }

        private bool doCanObtain(string initial, string target)
        {
            while (initial.Length < target.Length && initial != target)
            {
                bool canDo = false;
                // rule 1
                var initial_1 = initial + "A";
                if (target.Contains(initial_1))
                {
                    canDo = true;
                }

                // rule 2
                var initial_2 = Reverse(initial) + "B";
                if (target.Contains(initial_2))
                {
                    if (!canDo)
                    { // only this one is OK
                        initial = initial_2;
                        continue;
                    }

                    // both of them are good. So...
                    return doCanObtain(initial_1, target) || doCanObtain(initial_2, target);
                }

                // rule 2 failed. Check if 1 passed
                if (canDo)
                {
                    initial = initial_1;
                    continue;
                }

                // both failed
                return false;
            }

            return true;
        }
        private string Reverse(string text)
        {
            if (text == null) return null;

            // return string.Join("", text.Reverse());

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public string createString_AB(int N, int K)
        {
            var stringArray = new char[N];
            if (K == 0)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    stringArray[i] = 'B';
                }
                stringArray[N - 1] = 'A';
            }
            else
            {
                var factors = GetTwoFactors(K, N);
                if (factors == null) return "";

                int i = 0;
                for (; i < factors.Item1; i++)
                {
                    stringArray[i] = 'A';
                }
                int j = 0;
                for (; j < factors.Item2; j++)
                {
                    stringArray[i + j] = 'B';
                }
                for (i += j; i < N; i++)
                {
                    stringArray[i] = 'A';
                }
            }

            return new string(stringArray);
        }

        private Tuple<int, int> GetTwoFactors(int n, int maxSum)
        {
            var factors = Enumerable.Range(1, n).Where(x => n % x == 0).ToArray();
            int lo = 0, hi = factors.Length - 1;
            while (lo < hi)
            {
                var lowVal = factors[lo];
                var hiVal = factors[hi];
                if (lowVal * hiVal == n && lowVal + hiVal <= maxSum)
                    return Tuple.Create(lowVal, hiVal);

                lo++;
                hi--;
            }
            return null;
        }

    }
}
