using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Preps
{
    public class General
    {



        public static int[] ReplaceWithGreatestElementFromRight(int[] arr)
        {
            var len = arr.Length;
            int[] result = new int[len];

            int max = arr[len - 1];
            result[len - 1] = -1;
            for (int i = len - 2; i >= 0; i--)
            {
                result[i] = max;
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }

            // NAIVE method
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int item = arr[i];
            //    int max = int.MinValue;
            //    for (int j = i+1; j < arr.Length; j++)
            //    {
            //        if (max < arr[j])
            //        {
            //            max = arr[j];
            //        }
            //    }
            //    result[i] = max;
            //}
            //result[result.Length - 1] = -1;
            return result;
        }

        public static int findMinimum(int[] sortedButRotatedArray)
        {
            //e.g. 3 4 5 6 7 1 2
            int length = sortedButRotatedArray.Length;
            int low = 0, high = length - 1;
            int midIndex = 0;
            while (low < high)
            {
                midIndex = low + (high - low) / 2;
                if (sortedButRotatedArray[low] < sortedButRotatedArray[midIndex])
                {
                    low = midIndex;
                }
                else
                {
                    if (sortedButRotatedArray[midIndex - 1] > sortedButRotatedArray[midIndex])
                        return sortedButRotatedArray[midIndex]; // the pivot

                    high = midIndex;
                }
            }
            // It was never rotated
            return sortedButRotatedArray[0];
        }

        public static BinaryTree ConvertToBinaryTree(int[] sortedArray)
        {
            var tree = new BinaryTree();
            if (sortedArray == null || sortedArray.Length == 0) return tree;

            tree.Root = ConvertToBinaryTree(sortedArray, 0, sortedArray.Length - 1);

            return tree;
        }

        private static BinaryTreeNode<int> ConvertToBinaryTree(int[] sortedArray, int start, int end)
        {
            if (end < start) return null;

            int mid = start + (end - start) / 2;
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(sortedArray[mid]);
            node.Left = ConvertToBinaryTree(sortedArray, start, mid - 1);
            node.Right = ConvertToBinaryTree(sortedArray, mid + 1, end);
            return node;
        }

        #region Alation OTS
        static void FileReadAndSort(string[] args)
        {
            // read the string filename
            string filename = Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
                {
                    throw new IOException(string.Format("File '{0}' does not exist", filename));
                }
                var sourceCodeFileNames = File.ReadAllLines(filename);

                var cppList = new List<string>();
                var cList = new List<string>();
                var csList = new List<string>();
                foreach (var sourceCodeFileName in sourceCodeFileNames)
                {
                    if (sourceCodeFileName.EndsWith(".c"))
                    {
                        cList.Add(sourceCodeFileName);
                    }
                    else if (sourceCodeFileName.EndsWith(".cpp"))
                    {
                        cppList.Add(sourceCodeFileName);
                    }
                    else if (sourceCodeFileName.EndsWith(".cs"))
                    {
                        csList.Add(sourceCodeFileName);
                    }
                }

                // outputs
                using (var file = File.CreateText("c_" + filename))
                {
                    foreach (var cFileName in cList)
                    {
                        file.WriteLine(cFileName);
                    }
                }

                using (var file = File.CreateText("cpp_" + filename))
                {
                    foreach (var cppFileName in cppList)
                    {
                        file.WriteLine(cppFileName);
                    }
                }

                using (var file = File.CreateText("cs_" + filename))
                {
                    foreach (var csFileName in csList)
                    {
                        file.WriteLine(csFileName);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        static int collision(int[] speed, int pos)
        {

            if (speed.Length == 0) return 0; // just one; no collision

            int posSpeed = speed[pos];
            int nCollisions = 0;
            // in front of pos
            for (int i = pos + 1; i < speed.Length; i++)
            {
                if (speed[i] < posSpeed)
                {
                    nCollisions++;
                }
            }

            //those behind pos
            for (int i = 0; i < pos; i++)
            {
                if (speed[i] > posSpeed)
                {
                    nCollisions++;
                }
            }

            return nCollisions;
        }
        static string dnaComplement(string s)
        {

            var result = new char[s.Length];

            // start i from end to effectively reverse s
            for (int index = 0, i = s.Length - 1; i >= 0; i--, index++)
            {
                switch (s[i])
                {
                    case 'A':
                        result[index] = 'T';
                        break;
                    case 'T':
                        result[index] = 'A';
                        break;
                    case 'C':
                        result[index] = 'G';
                        break;
                    case 'G':
                        result[index] = 'C';
                        break;
                    default:
                        throw new ArgumentException("s contains an invalid character.");
                }
            }
            return new string(result);
        } 
        #endregion
    }
}
