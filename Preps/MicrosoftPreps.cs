using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class MicrosoftPreps
    {
        /// <summary>
        /// Given a set S of n real numbers and another real number x, 
        /// determine whether or not there exist. two elements in S 
        /// whose sum is exactly x.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="sum">The sum.</param>
        /// <returns></returns>
        public static Tuple<int, int> FindTwoElementsWithGivenSum_nlogn(int[] arr, int sum)
        {
            Array.Sort(arr);

            int i = 0, j = arr.Length - 1;
            while (i < j)
            {
                var added = arr[i] + arr[j];
                if (added == sum)
                    return Tuple.Create(i, j);

                if (added > sum)
                    j--;
                else
                    j++;
            }
            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// Given a set S of n real numbers and another real number x, 
        /// determine whether or not there exist. two elements in S 
        /// whose sum is exactly x.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="sum">The sum.</param>
        /// <returns></returns>
        public static Tuple<int, int> FindTwoElementsWithGivenSum_n(int[] arr, int sum)
        {
            int ind1 = -1, ind2 = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (sum == arr[i] * 2)
                {
                    if (ind1 == -1)
                        ind1 = i;
                    else if (ind2 == -1)
                        ind2 = i;

                    if (ind1 > -1 && ind2 > -1)
                        break;
                }
            }

            if (ind1 > -1 && ind2 > -1)
                return Tuple.Create(ind1, ind2);
            
            ind1 = -1;
            ind2 = -1;
            var set = new HashSet<int>(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (sum == arr[i] * 2)
                    continue;

                if (set.Contains(sum - arr[i]))
                {
                    if (ind1 == -1)
                        ind1 = i;
                    else if (ind2 == -1)
                        ind2 = i;

                if (ind1 > -1 && ind2 > -1)
                    return Tuple.Create(ind1, ind2);
                }
            }
            return Tuple.Create(-1, -1);
        }
    }
}
