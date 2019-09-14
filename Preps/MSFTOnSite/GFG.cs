using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.MSFTOnSite
{
    public class GFG
    {
        /*Given an n x n square matrix, find sum of all sub-squares of size k x k*/
        // A O(n^2) function to find sum of all
        // sub-squares of size k x k in a given
        // square matrix of size n x n
        public static void printSumTricky(int[][] mat, int k)
        {
            int n = mat.Length;
            // k must be smaller than or equal to n
            if (k > n)
                return;

            // 1: PREPROCESSING
            // To store sums of all strips of size k x 1
            int[][] stripSum = new int[n - k + 1][];
            for (int i = 0; i < stripSum.Length; i++)
            {
                stripSum[i] = new int[n];
            }
            // Go column by column
            for (int j = 0; j < n; j++)
            {

                // Calculate sum of first k x 1
                // rectangle in this column
                int sum = 0;
                for (int i = 0; i < k; i++)
                    sum += mat[i][j];
                stripSum[0][j] = sum;

                // Calculate sum of remaining rectangles
                for (int i = 1; i < n - k + 1; i++)
                {
                    sum += (mat[i + k - 1][j] - mat[i - 1][j]);
                    stripSum[i][j] = sum;
                }
            }

            // 2: CALCULATE SUM of Sub-Squares 
            // using stripSum[][]
            for (int i = 0; i < n - k + 1; i++)
            {

                // Calculate and print sum of first 
                // subsquare in this row
                int sum = 0;
                for (int j = 0; j < k; j++)
                    sum += stripSum[i][j];
                Console.Write(sum + " ");

                // Calculate sum of remaining squares 
                // in current row by removing the
                // leftmost strip of previous sub-square 
                // and adding a new strip
                for (int j = 1; j < n - k + 1; j++)
                {
                    sum += (stripSum[i][j + k - 1] - stripSum[i][j - 1]);
                    Console.Write(sum + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
