using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    public class BinaryTree : BinaryTree<int>
    {
        public class Value
        {
            public int MaxSize; // for size of largest BST
            public bool IsBST;
            public int Min;  // For minimum value in right subtree
            public int Max;  // For maximum value in left subtree
            public Value(int maxSize = 0)
            {
                MaxSize = maxSize;
                IsBST = false;
                Min = int.MinValue;
                Max = int.MaxValue;
            }
        }
        public override string ToString()
        {
            return Root == null ? "{}" : Root.ToString();
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTree()
        {
            Root = null;
        }

        public virtual void Clear()
        {
            Root = null;
        }

        public BinaryTreeNode<T> Root { get; set; }
    }

    /// <summary>
    /// Singly-linked
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode() : base(default(T))
        {

        }
        public LinkedListNode(T data) : base(data)
        {

        }
        public LinkedListNode<T> Next
        {
            get
            {
                if (Children == null || Children.Count == 0) return null;

                return (LinkedListNode<T>)Children[0];
            }
            set
            {
                if (Children == null) Children = new NodeList<T>(1);

                Children.Add(value);
            }
        }

        public override string ToString()
        {
            return $"{Value}. Next? {Next != null}";
        }
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode(T data) : base(data) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right) : base(data)
        {
            Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            Children = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (Children == null) return null;

                return (BinaryTreeNode<T>)Children[0];
            }
            set
            {
                if (Children == null) Children = new NodeList<T>(2);

                Children[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (Children == null) return null;

                return (BinaryTreeNode<T>)Children[1];
            }
            set
            {
                if (Children == null) Children = new NodeList<T>(2);

                Children[1] = value;
            }
        }
    }

    public class TrieNode<T> : Node<T>
    {
        #region For Trie's sake
        public TrieNode(T value, int depth, TrieNode<T> parent) : base(value)
        {
            Value = value;
            Children = new NodeList<T>();
            Depth = depth;
            Parent = parent;
        }

        public new NodeList<T> Children
        {
            get { return base.Children; }
            set { base.Children = value; }
        }

        public int Depth { get; set; }
        public TrieNode<T> Parent { get; set; }
        public bool IsLeaf
        {
           get { return Children.Count == 0; }
        }

        public virtual TrieNode<T> FindChildNode(T c)
        {
            return Children.FindByValue(c) as TrieNode<T>;
        }

        public void DeleteChildNode(T c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value.Equals(c))
                    Children.RemoveAt(i);
        }

        #endregion
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Value = data;
            Children = new NodeList<T>();
        }

        public T Value { get; set; }

        protected NodeList<T> Children { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
