using NUnit.Framework;
using Preps;

namespace PrepTests
{
    [TestFixture]
    public class BinaryTreeQsTests
    {
        [Test]
        public void FlattenToLinkedList()
        {
            var tree = new BinaryTree();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(5);
            tree.Root.Left.Left = new BinaryTreeNode<int>(3);
            tree.Root.Left.Right = new BinaryTreeNode<int>(4);
            tree.Root.Right.Right = new BinaryTreeNode<int>(6);
            tree.FlattenToLinkedList();
            var temp = tree.Root.Right;

            while (temp != null)
            {
                Assert.IsNull(temp.Left);
                temp = temp.Right;
            }
        }
    }
}
