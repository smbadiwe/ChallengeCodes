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
        public LinkedListNode()
        {

        }
        public LinkedListNode(T data) : base(data)
        {

        }
        public LinkedListNode<T> Next
        {
            get
            {
                if (Neighbors == null) return null;

                return (LinkedListNode<T>)Neighbors[0];
            }
            set
            {
                if (Neighbors == null) Neighbors = new NodeList<T>(1);

                Neighbors[0] = value;
            }
        }

        public override string ToString()
        {
            return $"{Value}. Next? {Next != null}";
        }
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            Neighbors = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (Neighbors == null) return null;

                return (BinaryTreeNode<T>)Neighbors[0];
            }
            set
            {
                if (Neighbors == null) Neighbors = new NodeList<T>(2);

                Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (Neighbors == null) return null;

                return (BinaryTreeNode<T>)Neighbors[1];
            }
            set
            {
                if (Neighbors == null) Neighbors = new NodeList<T>(2);

                Neighbors[1] = value;
            }
        }
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
        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            Value = data;
            Neighbors = neighbors;
        }

        public T Value { get; set; }

        protected NodeList<T> Neighbors { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
