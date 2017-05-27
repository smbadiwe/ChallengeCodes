using NUnit.Framework;
using Preps;

namespace PrepTests
{
    [TestFixture]
    public class LinkedListQsTests
    {
        [Test]
        public void Union()
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
                        Next = null
                    }
                }
            };
            var list2 = new LinkedListNode<int>
            {
                Value = 1,
                Next = null
            };
            var union = LinkedListQs.Union(list, list2);
            int count = 0;
            while(union != null)
            {
                count++;
                union = union.Next;
            }
            Assert.AreEqual(count, 4);
        }
        [Test]
        public void Add_1()
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
                        Next = null
                    }
                }
            };
            var list2 = new LinkedListNode<int>
            {
                Value = 1,
                Next = null
            };
            var sum = LinkedListQs.Add(list, list2);
            
            Assert.AreEqual(3, sum.Value);
            Assert.AreEqual(3, sum.Next.Value);
            Assert.AreEqual(4, sum.Next.Next.Value);
        }
        [Test]
        public void Add_2()
        {
            var list = new LinkedListNode<int>
            {
                Value = 9,
                Next = new LinkedListNode<int>
                {
                    Value = 9,
                    Next = new LinkedListNode<int>
                    {
                        Value = 9,
                        Next = null
                    }
                }
            };
            var list2 = new LinkedListNode<int>
            {
                Value = 9,
                Next = new LinkedListNode<int>
                {
                    Value = 9,
                    Next = null
                }
            };
            var sum = LinkedListQs.Add(list, list2);
            
            Assert.AreEqual(8, sum.Value);
            Assert.AreEqual(9, sum.Next.Value);
            Assert.AreEqual(0, sum.Next.Next.Value);
            Assert.AreEqual(1, sum.Next.Next.Next.Value);
        }
        [Test]
        public void Intersect()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 1,
                        Next = null
                    }
                }
            };
            var list2 = new LinkedListNode<int>
            {
                Value = 1,
                Next = null
            };
            var union = LinkedListQs.Intersect(list, list2);
            Assert.AreEqual(union.Value, 1);
            Assert.IsNull(union.Next);
            int count = 0;
            while(union != null)
            {
                count++;
                union = union.Next;
            }
            Assert.AreEqual(count, 1);
        }

        #region IsPalindrome - when we have a linked list node

        [Test]
        public void IsPalindromeTest_OneItem()
        {
            var list = new LinkedListNode<int>
            {
                Value = 2,
                Next = null
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), true);
        }

        [Test]
        public void IsPalindromeTest_Even_No_Of_Items_1()
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
        public void IsPalindromeTest_Even_No_Of_Items_2()
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
                            Value = 4,
                            Next = null
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), false);
        }

        [Test]
        public void IsPalindromeTest_Odd_No_Of_Items_1()
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

        [Test]
        public void IsPalindromeTest_Odd_No_Of_Items_2()
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
                                Value = 4,
                                Next = null
                            }
                        }
                    }
                }
            };
            Assert.AreEqual(LinkedListQs.IsPalindrome(list), false);
        }
        #endregion
        
    }
}
