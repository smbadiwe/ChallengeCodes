

namespace Preps
{
    public static class BinaryTreeQs
    {
        /// <summary>
        /// Flatten A Binary Tree to Linked List (In-place).
        /// Essentially, we're to do a pre-order transversal
        /// </summary>
        /// <returns></returns>
        public static void FlattenToLinkedList(this BinaryTree tree)
        {
            DoFlattenToLinkedList(tree.Root);
        }

        /// <summary>
        /// Each time when we prune a right subtree, we use while-loop to find the right-most leaf 
        /// of the current left subtree, and append the subtree there.
        /// We visit each node at most twice (one for flattening and maybe one for looking for rightmost leaf) 
        /// and then for each node, cut the right tree and append it to its rightmost node. 
        /// Overall, we access each node constant time. So the total running time is O(n) with O(1) space.
        /// </summary>
        /// <param name="root"></param>
        private static void DoFlattenToLinkedList(BinaryTreeNode<int> root)
        {
            var cur = root;
            while (cur != null)
            {
                if (cur.Left != null)
                {
                    // if we need to prune a right subtree
                    if (cur.Right != null)
                    {
                        // we use while-loop to find the right-most leaf
                        // of the current left subtree, and append the subtree there.
                        var next = cur.Left;
                        while (next.Right != null)
                        {
                            next = next.Right;
                        }
                        next.Right = cur.Right;
                    }
                    // Transfer value at the Left and null it
                    cur.Right = cur.Left;
                    cur.Left = null;
                }
                cur = cur.Right;
            }
        }

        /// <summary>
        /// Pre-order transversal. I don't get it, really.
        /// </summary>
        /// <param name="root"></param>
        private static void DoFlattenToLinkedList2(BinaryTreeNode<int> root)
        {
            if (root == null) return;
            
            var left = root.Left;
            var right = root.Right;
            root.Left = null;

            DoFlattenToLinkedList2(left);
            DoFlattenToLinkedList2(right);

            // Take what's on the left to the right
            root.Right = left;
            var current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            current.Right = right;
        }

        /// <summary>
        /// Find the largest BST subtree in a given Binary Tree
        /// </summary>
        /// <returns></returns>
        public static BinaryTree GetLargestBST(this BinaryTree tree)
        {
            return FlattenToLinkedList(tree.Root); //, new Value()
        }

        /// <summary>
        /// Find the largest BST subtree in a given Binary Tree. Naive solutoion
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static BinaryTree FlattenToLinkedList(BinaryTreeNode<int> root)
        {
            var result = new BinaryTree();
            if (root == null)
            {
                return result;
            }

            if (IsBSTUtil(root, int.MinValue, int.MaxValue))
            {
                result.Root = root;
                return result;
            }

            var left = FlattenToLinkedList(root.Left);
            var right = FlattenToLinkedList(root.Right);

            if (left.Root == null && right.Root == null)
            {
                return result;
            }

            if (left.Root == null && right.Root != null)
            {
                result.Root = right.Root;
            }
            else if (left.Root != null && right.Root == null)
            {
                result.Root = left.Root;
            }
            else
            {
                if (left.Root.Value > right.Root.Value)
                {
                    result.Root = left.Root;
                }
                else
                {
                    result.Root = right.Root;
                }
            }
            return result;
        }

        /// <summary>
        /// Optimized solutoion; but tricky
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static int largestBSTUtil(BinaryTreeNode<int> node, BinaryTree.Value info)
        {
            /* Base Case */
            if (node == null)
            {
                info.IsBST = true; // An empty tree is BST
                return 0;    // Size of the BST is 0
            }

            int min = int.MaxValue;

            /* A flag variable for left subtree property
             i.e., max(root->left) < root->data */
            bool left_flag = false;

            /* A flag variable for right subtree property
             i.e., min(root->right) > root->data */
            bool right_flag = false;

            int ls, rs; // To store sizes of left and right subtrees

            /* Following tasks are done by recursive call for left subtree
             a) Get the maximum value in left subtree (Stored in *max_ref)
             b) Check whether Left Subtree is BST or not (Stored in *is_bst_ref)
             c) Get the size of maximum size BST in left subtree (updates *max_size) */
            info.Max = int.MinValue;
            ls = largestBSTUtil(node.Left, info);
            if (info.IsBST == true && node.Value > info.Max)
            {
                left_flag = true;
            }

            /* Before updating *min_ref, store the min value in left subtree. So that we
             have the correct minimum value for this subtree */
            min = info.Min;

            /* The following recursive call does similar (similar to left subtree) 
             task for right subtree */
            info.Min = int.MaxValue;
            rs = largestBSTUtil(node.Right, info);
            if (info.IsBST == true && node.Value < info.Min)
            {
                right_flag = true;
            }

            // Update min and max values for the parent recursive calls
            if (min < info.Min)
            {
                info.Min = min;
            }
            if (node.Value < info.Min) // For leaf nodes
            {
                info.Min = node.Value;
            }
            if (node.Value > info.Max)
            {
                info.Max = node.Value;
            }

            /* If both left and right subtrees are BST. And left and right
             subtree properties hold for this node, then this tree is BST.
             So return the size of this tree */
            if (left_flag && right_flag)
            {
                if (ls + rs + 1 > info.MaxSize)
                {
                    info.MaxSize = ls + rs + 1;
                }
                return ls + rs + 1;
            }
            else
            {
                //Since this subtree is not BST, set is_bst flag for parent calls
                info.IsBST = false;
                return 0;
            }
        }

        public static BinaryTreeNode<int> BSTGetMinimum(this BinaryTree tree)
        {
            if (tree.Root == null) return null;

            return BSTGetMinimum(tree.Root);
        }

        public static BinaryTreeNode<int> BSTGetMaximum(this BinaryTree tree)
        {
            if (tree.Root == null) return null;

            return BSTGetMaximum(tree.Root);
        }

        private static BinaryTreeNode<int> BSTGetMinimum(BinaryTreeNode<int> node)
        {
            BinaryTreeNode<int> min = node;
            while (min.Left != null)
            {
                min = min.Left;
            }
            return min;
        }

        private static BinaryTreeNode<int> BSTGetMaximum(BinaryTreeNode<int> node)
        {
            BinaryTreeNode<int> min = node;
            while (min.Right != null)
            {
                min = min.Right;
            }
            return min;
        }

        /// <summary>
        /// Using in-order traversal
        /// </summary>
        /// <returns></returns>
        public static bool IsBST2(this BinaryTree tree)
        {
            if (tree.Root == null) return true;
            return InOrderTraversal(tree.Root, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsBST(this BinaryTree tree)
        {
            if (tree.Root == null) return true;

            return IsBSTUtil(tree.Root, int.MinValue, int.MaxValue);
        }

        /// <summary>
        /// Review this view
        /// </summary>
        /// <param name="node"></param>
        /// <param name="prev"></param>
        /// <returns></returns>
        private static bool InOrderTraversal(BinaryTreeNode<int> node, BinaryTreeNode<int> prev)
        {
            //This uses inorder traversal
            if (node != null)
            {
                if (!InOrderTraversal(node.Left, prev)) return false;

                // allows only distinct values node
                if (prev != null && node.Value <= prev.Value) return false;
                prev = node;

                return InOrderTraversal(node.Right, prev);
            }
            return true;
        }

        private static bool IsBSTUtil(BinaryTreeNode<int> node, int min, int max)
        {
            if (node == null) return true;

            // The left subtree of a node contains only nodes with keys less than the node’s key.
            // The right subtree of a node contains only nodes with keys greater than the node’s key.
            if (node.Value < min || node.Value > max) return false;

            // Both the left and right subtrees must also be binary search trees.
            return IsBSTUtil(node.Left, min, node.Value) && IsBSTUtil(node.Right, node.Value, max);
        }

    }
}
