using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class Codility
    {
        /// <summary>
        /// A zero-indexed array A consisting of N integers is given. An equilibrium index of this array is any integer P such that 0 ≤ P < N and the sum of elements of lower indices is equal to the sum of elements of higher indices, i.e. 
        /// A[0] + A[1] + ... + A[P−1] = A[P + 1] + ... + A[N−2] + A[N−1].
        /// Sum of zero elements is assumed to be equal to 0. This can happen if P = 0 or if P = N−1.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int GetEquilibriumIndex(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0) return -1;
            int len = A.Length;

            if (len == 1) return 0;

            checked
            {
                long sum = 0;
                for (int i = 0; i < len; i++)
                {
                    sum += A[i];
                }

                // Sum of zero elements is assumed to be equal to 0.This can happen if P = 0 or if P = N−1.
                if (sum - A[0] == 0) return 0;
                if (sum - A[len - 1] == 0) return len - 1;

                long firstHalf = 0;
                for (int i = 0; i < len - 2; i++)
                {
                    firstHalf += A[i];
                    if (firstHalf == (sum - firstHalf - A[i + 1]))
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }
    }
}
