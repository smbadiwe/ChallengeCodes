using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    /// <summary>
    /// Programming Basics
    /// </summary>
    class CodeFightsSkillTest2
    {
        //public static string solution(int A, int B, int C, int D)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //    string time = "";
        //    int max = -1;
        //    var numArray = new[] { A, B, C, D };
        //    int ind = -1;

        //    // first digit
        //    for (int i = 0; i < numArray.Length; i++)
        //    {
        //        int num = numArray[i];
        //        if (num > 2) continue;
        //        if (num > max)
        //        {
        //            max = num;
        //            ind = i;
        //        }
        //    }
        //    if (max == -1) return "NOT POSSIBLE";
        //    time += max;
        //    numArray[i] = -2; // effectively discounting it
        //    max = -1;

        //    // 2nd digit
        //    for (int i = 0; i < numArray.Length; i++)
        //    {
        //        int num = numArray[i];
        //        if (num > 3) continue;
        //        if (num > max)
        //        {
        //            max = num;
        //        }
        //    }
        //    if (max == -1) return "NOT POSSIBLE";
        //    time += max + ":";
        //    numArray[i] = -2; // effectively discounting it
        //    max = -1;

        //    // 3rd digit
        //    for (int i = 0; i < numArray.Length; i++)
        //    {
        //        int num = numArray[i];
        //        if (num > 5) continue;
        //        if (num > max)
        //        {
        //            max = num;
        //        }
        //    }
        //    if (max == -1) return "NOT POSSIBLE";
        //    time += max;
        //    numArray[i] = -2; // effectively discounting it
        //    max = -1;

        //    // 4th digit
        //    for (i = 0; i < numArray.Length; i++)
        //    {
        //        int num = numArray[i];
        //        if (num > -1)
        //        {
        //            max = num;
        //            break;
        //        }
        //    }
        //    time += max;

        //    return time;
        //}

        public static int CssStringToColor(string colorString)
        {
            // good string must start with #
            if (string.IsNullOrWhiteSpace(colorString) || colorString[0] != '#')
            {
                throw new ArgumentException("Error! Invalid value.");
            }

            // without the #, good string must have length = 3 or 6
            int trueLength = colorString.Length - 1;
            if ((trueLength == 3 || trueLength == 6) == false)
            {
                throw new ArgumentException("Error! Invalid value.");
            }

            colorString = colorString.ToUpperInvariant();
            for (int i = 1; i <= trueLength; i++)
            { //i=1 due to the #
                char ch = colorString[i];
                // check for invalid characters. Hex should only have 0-9A-F
                // 0 - 9 => 48 - 57 in ASCII
                // A - F => 65 - 70 in ASCII
                if (ch < '0' || ch > 'F')
                {
                    throw new ArgumentException("Error! One or more character is an invalid hex character");
                }
                if (ch > '9' && ch < 'A')
                {
                    throw new ArgumentException("Error! One or more character is an invalid hex character");
                }
            }

            // if trueLength is 3, promote to 6
            string newString = "";
            if (trueLength == 3)
            {
                for (int i = 1; i <= trueLength; i++)
                {  // Remember the # in the string?
                    newString += colorString[i];
                    newString += colorString[i];
                }
            }
            else
            {
                newString = colorString.Substring(1);
            }

            // Now, convert hex string to decimal
            string fullBinary = "";
            for (int i = 0; i < newString.Length; i += 2)
            {
                var oneColorHex = string.Join("", newString[i], newString[i + 1]);
                var hexToDec = Convert.ToInt32(oneColorHex, 16);
                var binaryVal = Convert.ToString(hexToDec, 2).PadLeft(8, '0');
                fullBinary = binaryVal + fullBinary;
            }

            return Convert.ToInt32(fullBinary, 2);
        }


        #region Recursively remove all adjacent duplicates
        /// <summary>
        /// Given a string, recursively remove adjacent duplicate characters from string. 
        /// The output string should not have any adjacent duplicates
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string removeDuplicateAdjacent(string s)
        {
            var charArr = new char[s.Length + 1];
            for (int i = 0; i < s.Length; i++)
            {
                charArr[i] = s[i];
            }
            return removeDuplicate(charArr, 0, 0);
        }

        private static string removeDuplicate(char[] s, int i, int j)
        {
            while (s[j] != '\0')
            {
                if (s[j] == s[j + 1])
                {
                    while (s[j] == s[j + 1])
                    {
                        j++;
                    }
                    j++;
                }
                else
                {
                    s[i++] = s[j++];
                }
            }

            s[i] = '\0';
            if (duplicatesExist(s))
            {
                return removeDuplicate(s, 0, 0);
            }

            var sb = new StringBuilder();
            int ind = 0;
            while (s[ind] != '\0')
            {
                sb.Append(s[ind]);
                ind++;
            }
            return sb.ToString();
        }

        private static bool duplicatesExist(char[] s)
        {
            int j = 0;
            while (s[j] != '\0')
            {
                if (s[j] == s[j + 1])
                {
                    return true;
                }
                j++;
            }
            return false;
        }

        #endregion

        #region Matrix elements in spiral order
        /// <summary>
        /// Given a rectangular matrix, return all of the elements of the matrix in spiral order
        /// right -> down -> left -> up
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        int[] matrixElementsInSpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0) return new int[0];

            string currentDirection = "Right";
            int xIndex = 0;
            int yIndex = 0;
            int leftLimit = 0;
            int rightLimit = matrix[0].Length - 1;
            int upLimit = 0;
            int downLimit = matrix.Length - 1;
            int counter = 0;
            int totalElements = matrix.Length * matrix[0].Length;
            int[] spiralArray = new int[totalElements];

            while (counter < totalElements)
            {
                spiralArray[counter] = matrix[yIndex][xIndex];

                switch (currentDirection)
                {
                    case "Right":
                        if (xIndex < rightLimit)
                            xIndex++;
                        else
                        {
                            currentDirection = "Down";
                            yIndex++;
                            upLimit++;
                        }
                        break;
                    case "Left":
                        if (xIndex > leftLimit)
                            xIndex--;
                        else
                        {
                            currentDirection = "Up";
                            yIndex--;
                            downLimit--;
                        }
                        break;
                    case "Up":
                        if (yIndex > upLimit)
                            yIndex--;
                        else
                        {
                            currentDirection = "Right";
                            xIndex++;
                            leftLimit++;
                        }
                        break;
                    case "Down":
                        if (yIndex < downLimit)
                            yIndex++;
                        else
                        {
                            currentDirection = "Left";
                            xIndex--;
                            rightLimit--;
                        }
                        break;
                    default:
                        break;
                }
                counter++;
            }

            return spiralArray;
        }

        /// <summary>
        /// Given a rectangular matrix, return all of the elements of the matrix in spiral order
        /// right -> down -> left -> up
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[] matrixElementsInSpiralOrder2(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new int[0];
            }
            int m = matrix.Length;
            int n = matrix[0].Length;

            var result = new int[m * n];
            int currResultIndex = 0;
            int left = 0;
            int right = n - 1;
            int top = 0;
            int bottom = m - 1;

            while (currResultIndex < m * n)
            {
                for (int j = left; j <= right; j++)
                {
                    result[currResultIndex] = matrix[top][j];
                    currResultIndex++;
                }
                top++;

                for (int i = top; i <= bottom; i++)
                {
                    result[currResultIndex] = matrix[i][right];
                    currResultIndex++;
                }
                right--;

                //prevent duplicate row
                if (bottom < top) break;

                for (int j = right; j >= left; j--)
                {
                    result[currResultIndex] = matrix[bottom][j];
                    currResultIndex++;
                }
                bottom--;

                // prevent duplicate column
                if (right < left) break;

                for (int i = bottom; i >= top; i--)
                {
                    result[currResultIndex] = matrix[i][left];
                    currResultIndex++;
                }
                left++;
            }

            return result;
        }

        /// <summary>
        /// Given a rectangular matrix, return all of the elements of the matrix in spiral order
        /// down -> right -> up -> left
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[] matrixElementsInSpiralOrder3(int[][] matrix)
        {
            if (matrix.Length == 0) return new int[0];

            // Set initial direction
            int dx = 1, dy = 0;
            // Set the starting point before the first matrix cell
            int x = -1, y = 0;
            // Set the first side length and the next side length
            int xLen = matrix.Length, yLen = matrix[0].Length;

            var result = new int[xLen * yLen];
            int sideCounter = xLen, currResultIndex = 0;
            // While both of the run lengths are non-zero
            while (xLen > 0 && yLen > 0)
            {
                if (sideCounter > 0)
                {
                    // traverse the side while counter is > 0
                    sideCounter--;
                    x += dx;
                    y += dy;
                    result[currResultIndex] = matrix[x][y];
                    currResultIndex++;
                }
                else
                {
                    // switch direction when the counter is 0
                    // Switch the direction -> rotates the sequence (1,0) (0,1) (-1,0) (0,-1)
                    int tmp = dx;
                    dx = -dy;
                    dy = tmp;
                    // Reduce the next run length with one and switch dimensions
                    tmp = xLen;
                    xLen = yLen - 1;
                    yLen = tmp;
                    // Reset the side run counter
                    sideCounter = xLen;
                }
            }

            return result;
        }
        #endregion

        /// <summary>
        /// You are given an n x n 2D matrix that represents an image. 
        /// Rotate the image by 90 degrees (clockwise).
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[][] rotateImage(int[][] a)
        {
            int n = a.Length;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = a[i][j];
                    a[i][j] = a[n - 1 - j][i];
                    a[n - 1 - j][i] = a[n - 1 - i][n - 1 - j];
                    a[n - 1 - i][n - 1 - j] = a[j][n - 1 - i];
                    a[j][n - 1 - i] = temp;
                }
            }
            return a;
        }

        /// <summary>
        /// You are given an m x n 2D matrix that represents an image. 
        /// Rotate the image by 90 degrees (clockwise).
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[][] rotateImage2(int[][] a)
        {
            int rows = a.Length;
            int cols = a[0].Length;
            int[][] newArr = new int[cols][];
            for (int i = 0; i < cols; i++)
            {
                newArr[i] = new int[rows];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newArr[j][rows - i - 1] = a[i][j];
                }
            }
            return newArr;
        }


        /// <summary>
        /// Given a column title as it would appear in an Excel spreadsheet,
        /// return its corresponding column number. Column names and numbers 
        /// follow a consistent pattern
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        int excelSheetColumnNumber(string s)
        {
            int result = 0;

            foreach (char c in s)
            {
                result = 26 * result + (c - 'A' + 1);
            }

            return result;
        }

        /// <summary>
        /// Given a sorted int array in which the range of elements is 
        /// in the inclusive range [l, r], return its missing inner ranges.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static string[] innerRanges(int[] nums, int l, int r)
        {
            int len = nums.Length;
            var ranges = new List<string>();
            long prev = (long)l - 1;
            for (int i = 0; i <= len; i++)
            {
                long curr = (i == len) ? (long)r + 1 : nums[i];
                if (curr - prev >= 2) // another way of saying (curr - 1 >= prev + 1)
                {
                    var range = (curr - prev == 2) ? (prev + 1).ToString() : ((prev + 1) + "->" + (curr - 1));
                    ranges.Add(range);
                }
                prev = curr;
            }
            return ranges.ToArray();
        }



        /// <summary>
        /// Equilibrium position in an array is a position at which the sum 
        /// of elements before it is equal to the sum of elements after it. 
        /// Given an array arr, your task is to determine at which position 
        /// equilibrium first occurs in the array. If there is no equilibrium 
        /// position, the answer should be -1.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int equilibriumPoint(int[] arr)
        {

            if (arr.Length == 1) return 1;

            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }

            int partialSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (partialSum == (sum - partialSum - arr[i]))
                {
                    return i + 1;
                }
                partialSum += arr[i];
            }
            return -1;
        }

        public int reverseint(int x)
        {

            int result = 0;
            bool negative = false;
            if (x < 0)
            {
                negative = true;
                x = -1 * x;
            }
            while (x > 0)
            {
                result = result * 10 + x % 10;
                x /= 10;
            }
            return negative ? -1 * result : result;
        }

        public int missingNumber(int[] arr)
        {

            int len = arr.Length;
            int total = len * (len + 1) / 2;
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            return total - sum;
        }

    }
}
