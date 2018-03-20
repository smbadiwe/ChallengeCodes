using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public class Qns
    {

        public void PrintAllCombinations(int[][] hints)
        {
            /*
             new vector<int>{1, 2, 3},
             new vector<int>{4, 5},
             new vector<int>{6, 7, 8} };
            */
            var sb = new List<string>();
            // for each vector
            for (int i = 0; i < hints.Length - 1; i++)
            {
                for (int j = 0; j < hints[i].Length; j++)
                {
                    var sublist = PrintCombinations(hints, hints[i][j] + "", i + 1);
                    if (sublist != null)
                        sb.AddRange(sublist);
                }
            }
            var set = new HashSet<string>(sb);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTotal: {0}", set.Count);
        }

        List<string> PrintCombinations(int[][] hints, string prefix, int currentVector)
        {
            int nVectors = hints.Length;
            if (currentVector >= nVectors - 1) return null;
            var sb = new List<string>();

            // for each vector
            for (int i = currentVector; i < nVectors - 1; i++)
            {
                // for each item in vector
                for (int j = 0; j < hints[i].Length; j++)
                {
                    var prefix2 = prefix + hints[i][j];
                    if (i == nVectors - 1)
                    {
                        if (prefix2.Length == nVectors)
                        {
                            sb.Add(prefix2);
                        }
                    }
                    else
                    {
                        for (int k = 0; k < hints[i + 1].Length; k++)
                        {
                            var sublist = PrintCombinations(hints, prefix2, i + 1);
                            if (sublist != null)
                            {
                                var options = sublist
                                                    .Select(x => string.Format("{0}{1}{2}", prefix2, x, hints[i + 1][k]))
                                                    .Where(it => it.Length == nVectors);
                                sb.AddRange(options);
                            }
                            else
                            {
                                sb.Add(string.Format("{0}{1}", prefix2, hints[i + 1][k]));
                            }
                        }
                    }
                }
            }
            return sb;
        }

        public void PrintCombinations_D(int[][] hints)
        {
            /*new vector<int>{1, 2, 3},
         new vector<int>{4, 5},
         new vector<int>{6, 7, 8} };
        */
            var sb = new StringBuilder();
            // for each vector
            for (int i = 0; i < hints.Length - 1; i++)
            {
                for (int j = 0; j < hints[i].Length; j++)
                {
                    var prefix = hints[i][j] + "";
                    sb.Append(PrintCombinations_D(hints, prefix, i + 1))
                        .AppendLine();
                }
            }
            var splitted = sb.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var set = new HashSet<string>(splitted);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTotal: {0}", set.Count);
        }

        string PrintCombinations_D(int[][] hints, string prefix, int currentVector)
        {
            int nVectors = hints.Length;
            //if (currentVector >= nVectors - 1) return "";
            var sb = new StringBuilder();

            // for each vector
            for (int i = currentVector; i < nVectors; i++)
            {
                // for each item in vector
                for (int j = 0; j < hints[i].Length; j++)
                {
                    var prefix2 = prefix + hints[i][j];
                    // if this is last vector
                    if (i == nVectors - 1)
                    {
                        if (prefix2.Length == nVectors)
                        {
                            sb.AppendFormat(prefix2).AppendLine();
                        }
                    }
                    else
                    {
                        for (int k = 0; k < hints[i + 1].Length; k++)
                        {
                            string option = string.Format("{0}{1}{2}", prefix2, PrintCombinations_D(hints, prefix2, i + 1), hints[i + 1][k]);

                            var spl = option.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var it in spl)
                            {
                                if (it.Length == nVectors)
                                {
                                    sb.AppendFormat(it).AppendLine();
                                }
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public int GetNearest(int[] arr, int target)
        {
            return GetNearest(arr, target, 0, arr.Length - 1);
        }
        // [0,2,4,5,8,9,11],7 => 6
        public int GetNearest(int[] arr, int target, int low, int high)
        {
            if (high == low) return arr[low];
            int mid = low + (high - low) / 2; //0 + (1-0)/2 = 0
            int val = arr[mid]; //5
            if (val == target) return target;

            int diff = Math.Abs(target - val); //7-5 = 2

            int diffBefore = int.MaxValue;
            int diffAfter = int.MaxValue;
            if (mid > 0)
            {
                diffBefore = Math.Abs(target - arr[mid - 1]); //7-4 = 3
                if (diffBefore == 0) return arr[mid - 1];
            }
            if (mid < arr.Length - 1)
            {
                diffAfter = Math.Abs(target - arr[mid + 1]); //7-8 = 1
                if (diffAfter == 0) return arr[mid + 1];
            }
            if (diff <= diffBefore && diff <= diffAfter)
            {
                return val;
            }
            if (diff > diffBefore)
            {
                return GetNearest(arr, target, low, mid - 1);
            }
            if (diff > diffAfter)
            {
                return GetNearest(arr, target, mid + 1, high);
            }// [1,3,5],4 => 3

            return val;
        }

    }
}
