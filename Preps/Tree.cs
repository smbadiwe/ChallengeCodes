using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    /*
// The following definitions of Tree and Node are provided.
// Insert and Delete will be methods of class Tree.
*/
    public class Tree
    {
        public class Node
        {
            public int Val { get; set; }
            public Node Left { get; set; }
            public Node Mid { get; set; }
            public Node Right { get; set; }

            public Node(int val)
            {
                Val = val;
            }
            public override string ToString()
            {
                return Val.ToString();
            }
        }

        private Node root;
        
        /* 
         * Please complete this method.
         * Inserts val into the tree. There is no need to rebalance the tree.
         */
        public void Insert(int val)
        {
            var newNode = new Node(val);
            if (root == null)
            {
                root = newNode;
                return;
            }

            Node current = root;
            while (true)
            {
                if (newNode.Val < current.Val)
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        return;
                    }
                    current = current.Left;
                }
                else if (newNode.Val == current.Val)
                {
                    if (current.Mid == null)
                    {
                        current.Mid = newNode;
                        return;
                    }
                    current = current.Mid;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        /* 
         * Please complete this method.
         * Deletes only one instance of val from the tree.
         * If val does not exist in the tree, do nothing.
         * There is no need to rebalance the tree.
         */
        public void Delete(int val)
        {
            if (root == null)
            {
                return;
            }

            Node current = root, prev = null;
            while (true)
            {
                if (val == current.Val)
                {
                    if (current.Mid == null)
                    {
                        prev.Mid = null;
                        return;
                    }
                    prev = current;
                    current = current.Mid;
                }
                else if (val < current.Val)
                {
                    if (current.Left == null)
                    {
                        return;
                    }
                    prev = current;
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        return;
                    }
                    prev = current;
                    current = current.Right;
                }
            }
        }
    }
}

