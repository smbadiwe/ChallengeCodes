using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public static class Extensions
    {

        public static string PrintList(this int[] arr)
        {
            return string.Join(",", arr);
        }
        public static string PrintList(this LinkedListNode<int> arr)
        {
            var sb = new StringBuilder();
            var curr = arr;
            while (curr != null)
            {
                sb.AppendFormat("{0}", curr.Value);
                if (curr.Next != null)
                {
                    sb.Append(",");
                }
                curr = curr.Next;
            }
            return sb.ToString();
        }
    }
}
