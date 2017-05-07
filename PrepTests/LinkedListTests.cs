using Preps;
using NUnit.Framework;

namespace PrepTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void SortListOf0s1sAnd2s_Test()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 2,
                    Next = new LinkedListNode<int>
                    {
                        Value = 1,
                        Next = new LinkedListNode<int>
                        {
                            Value = 0,
                            Next = null
                        }
                    }
                }
            };
            var result = LinkedListQs.SortListOf0s1sAnd2s(list);
            Assert.AreEqual(result.Value, 0);
        }

        #region GetMiddleNode
        [Test]
        public void GetMiddleNode_one_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = null
            };
            var mid = LinkedListQs.GetMiddleNode(list);
            Assert.AreEqual(mid.Value, 2);
            Assert.IsNull(mid.Next);
        }

        [Test]
        public void GetMiddleNode_even_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = null
                        }
                    }
                }
            };
            var mid = LinkedListQs.GetMiddleNode(list);
            Assert.AreEqual(mid.Value, 3);
            Assert.IsNotNull(mid.Next);
            Assert.AreEqual(mid.Next.Value, 4);
        }

        [Test]
        public void GetMiddleNode_just_two_items()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = null
                }
            };
            var mid = LinkedListQs.GetMiddleNode(list);
            Assert.AreEqual(mid.Value, 2);
            Assert.IsNotNull(mid.Next);
            Assert.AreEqual(mid.Next.Value, 3);
        }

        [Test]
        public void GetMiddleNode_odd_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = new LinkedListNode<int>
                            {
                                Value = 6,
                                Next = null
                            }
                        }
                    }
                }
            };
            var mid = LinkedListQs.GetMiddleNode(list);
            Assert.AreEqual(mid.Value, 4);
            Assert.IsNotNull(mid.Next);
            Assert.AreEqual(mid.Next.Value, 5);
        }
        #endregion

        #region Reverse

        [Test]
        public void Reverse_one_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = null
            };
            list = LinkedListQs.Reverse(list);
            Assert.AreEqual(list.Value, 2);
            Assert.IsNull(list.Next);
        }

        [Test]
        public void Reverse_even_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = null
                        }
                    }
                }
            };
            list = LinkedListQs.Reverse(list);
            Assert.AreEqual(list.Value, 5);
            Assert.IsNotNull(list.Next);
            Assert.AreEqual(list.Next.Value, 4);
        }

        [Test]
        public void Reverse_just_two_items()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = null
                }
            };
            list = LinkedListQs.Reverse(list);
            Assert.AreEqual(list.Value, 3);
            Assert.IsNotNull(list.Next);
            Assert.AreEqual(list.Next.Value, 2);
        }

        [Test]
        public void Reverse_odd_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = new LinkedListNode<int>
                            {
                                Value = 6,
                                Next = null
                            }
                        }
                    }
                }
            };
            list = LinkedListQs.Reverse(list);
            Assert.AreEqual(list.Value, 6);
            Assert.IsNotNull(list.Next);
            Assert.AreEqual(list.Next.Value, 5);
        }
        #endregion

        #region IsPalindrome
        [Test]
        public void IsPalindrome_one_item()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = null
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), true);
        }

        [Test]
        public void IsPalindrome_even_item_N()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = null
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), false);
        }

        [Test]
        public void IsPalindrome_even_item_Y()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 3,
                        Next = new LinkedListNode<int>
                        {
                            Value = 2,
                            Next = null
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), true);
        }

        [Test]
        public void IsPalindrome_just_two_items_N()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = null
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), false);
        }

        [Test]
        public void IsPalindrome_just_two_items_Y()
        {
            var list = new LinkedListNode<int>
            {
                Value = 3,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = null
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), true);
        }

        [Test]
        public void IsPalindrome_odd_item_N()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 5,
                            Next = new LinkedListNode<int>
                            {
                                Value = 6,
                                Next = null
                            }
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), false);
        }

        [Test]
        public void IsPalindrome_odd_item_Y()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 4,
                        Next = new LinkedListNode<int>
                        {
                            Value = 3,
                            Next = new LinkedListNode<int>
                            {
                                Value = 2,
                                Next = null
                            }
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), true);
        }
        #endregion
    }
}
