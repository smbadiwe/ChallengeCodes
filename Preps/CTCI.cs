using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public partial class CTCI
    {
        // Get all valid (i.e., properly opened and closed) combinations of n-pairs of parentheses. 
        public List<string> GetParentheses(int n)
        {
            var list = new List<string>();
            addParen(list, n, n, new char[n * 2], 0);
            return list;
        }

        private void addParen(List<string> list, int leftRem, int rightRem, char[] str, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) return;

            if (leftRem == 0 && rightRem == 0) // => all used up
            {
                list.Add(new string(str));
            }
            else
            {
                // add left is there's still any
                if (leftRem > 0)
                {
                    str[count] = '(';
                    addParen(list, leftRem - 1, rightRem, str, count + 1);
                }

                // add right if expression is valid
                if (rightRem > leftRem)
                {
                    str[count] = ')';
                    addParen(list, leftRem, rightRem - 1, str, count + 1);
                }
            }
        }

        // Write a method to compute all permutations of a string
        public List<string> GetAllPermutationsOfString(string str)
        {
            if (string.IsNullOrEmpty(str)) return new List<string> { str };
            return GetAllPermutationsOfString(str, str.Length - 1);
        }

        private List<string> GetAllPermutationsOfString(string str, int index)
        {
            if (index == 0)
            {
                return new List<string> { str[0].ToString() };
            }

            var result = new List<string>();
            var item = str[index];

            // We solve for f ( n - 1 ), and then push a_n into every spot in each of these strings. 
            var set1 = GetAllPermutationsOfString(str, index - 1);
            foreach (var word in set1)
            {
                for (int i = 0; i <= index; i++)
                {
                    var newWord = insertChatAt(word, item, i);

                    result.Add(newWord);
                }
            }
            return result;
        }

        private string insertChatAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end; 
        }

       
    }
}
