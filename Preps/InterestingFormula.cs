using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    partial class ProgramOld // class InterestingFormula
    {
        /// <summary>
        /// Returns the <paramref name="n"/>-th Catalan Number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int CatalanNumber(int n)
        {
            int coeff = BinomialCoefficient(2 * n, n);
            return coeff / (n + 1);
        }

        static int BinomialCoefficient(int n, int k)
        {
            int res = 1;

            // Since C(n, k) = C(n, n-k)
            if (k > n - k) k = n - k;

            // Calculate value of [n * (n-1) *---* (n-k+1)] / [k * (k-1) *----* 1]
            for (int i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }

    }
}
