using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public class RedBlackTreeNode : BinaryTreeNode<int>
    {
        public static RedBlackTreeNode Leaf => new RedBlackTreeNode(int.MinValue) { IsLeaf = true };
        /// <summary>
        /// Gets or sets a value indicating whether this instance is red.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is red; otherwise (if black), <c>false</c>.
        /// </value>
        public bool IsRed { get; set; }
        public bool IsLeaf { get; set; }
        public RedBlackTreeNode(int data) : base(data)
        {

        }

        public new RedBlackTreeNode Left
        {
            get
            {
                return (RedBlackTreeNode)base.Left;
            }
            set
            {
                base.Left = value;
            }
        }

        public new RedBlackTreeNode Right
        {
            get
            {
                return (RedBlackTreeNode)base.Right;
            }
            set
            {
                base.Right = value;
            }
        }

        public RedBlackTreeNode Parent { get; set; }
        public RedBlackTreeNode GrandParent
        {
            get
            {
                if (Parent == null) return null;
                return Parent.Parent;
            }
        }

        public RedBlackTreeNode Sibling
        {
            get
            {
                if (Parent == null) return null;
                if (this == Parent.Left) return Parent.Right;

                return Parent.Left;
            }
        }
        public RedBlackTreeNode Uncle
        {
            get
            {
                if (Parent == null) return null;

                return Parent.Sibling;
            }
        }

        public void RotateLeft()
        {
            var newThis = Right;
            if (newThis.IsLeaf) return;

            Right = newThis.Left;
            newThis.Left = this;
            newThis.Parent = Parent;
            Parent = newThis;
        }
        public void RotateRight()
        {
            var newThis = Left;
            if (newThis.IsLeaf) return;

            Left = newThis.Right;
            newThis.Right = this;
            newThis.Parent = Parent;
            Parent = newThis;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as RedBlackTreeNode;
            if (other == null) return false;

            if (IsLeaf) return other.IsLeaf;

            if (Value != other.Value) return false;

            // we assume all values are unique
            return true; // base.Equals(obj);
        }
    }

    public class RedBlackTree
    {
        public void Insert(RedBlackTreeNode root, int data)
        {
            var node = new RedBlackTreeNode(data);
            // insert new node into the current tree
            InsertRecursive(root, node);
            // repair the tree in case any of the red-black properties have been violated
            RepairTree(node);

            // find the new root to return
            root = node;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            //return root;
        }


        private void InsertRecursive(RedBlackTreeNode root, RedBlackTreeNode node)
        {
            if (root != null)
            {
                // recursively descend the tree until a leaf is found
                if (node.Value < root.Value)
                {
                    if (root.Left != RedBlackTreeNode.Leaf)
                    {
                        InsertRecursive(root.Left, node);
                        return;
                    }
                    else
                        root.Left = node;
                }
                else
                {
                    if (root.Right != RedBlackTreeNode.Leaf)
                    {
                        InsertRecursive(root.Right, node);
                        return;
                    }
                    else
                        root.Right = node;
                }
            }
            // insert new node n
            node.Parent = root;
            node.Left = RedBlackTreeNode.Leaf;
            node.Right = RedBlackTreeNode.Leaf;
            node.IsRed = true;
        }

        private void RepairTree(RedBlackTreeNode n)
        {
            if (n.Parent == null)
            {
                n.IsRed = false; // the root must be black
            }
            else if (n.Parent.IsRed == false) // black
            {
                //insert_case2(n);
            }
            else if (n.Uncle.IsRed)
            {
                /*Case 3: If both the parent P and the uncle U are red, then both of them 
                 * can be repainted black and the grandparent G becomes red to maintain 
                 * property 5 (all paths from any given node to its leaf nodes contain 
                 * the same number of black nodes). Since any path through the parent or 
                 * uncle must pass through the grandparent, the number of black nodes on 
                 * these paths has not changed. However, the grandparent G may now 
                 * violate Property 2 (The root is black) if it is the root or Property 4 
                 * (Both children of every red node are black) if it has a red parent. 
                 * To fix this, the tree's red-black repair procedure is rerun on G.
                 */
                n.Parent.IsRed = false;
                n.Uncle.IsRed = false;
                n.GrandParent.IsRed = true;
                RepairTree(n.GrandParent);
            }
            else
            {
                // step 1
                var p = n.Parent;
                var g = n.GrandParent;
                if (n == g.Left.Right)
                {
                    p.RotateLeft();
                    n = n.Left;
                }
                else if (n == g.Right.Left)
                {
                    p.RotateRight();
                    n = n.Right;
                }

                // step 2
                var p2 = n.Parent;
                var g2 = n.GrandParent;
                if (n == p2.Left)
                {
                    g2.RotateRight();
                }
                else
                {
                    g2.RotateLeft();
                }

                p2.IsRed = false;
                g2.IsRed = true;
            }
        }

        public void Delete(RedBlackTreeNode root, int data)
        {

        }
    }
}
