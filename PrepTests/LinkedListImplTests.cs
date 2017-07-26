using NUnit.Framework;
using Preps;

namespace PrepTests
{
    [TestFixture]
    public class LinkedListImplTests
    {
        [Test]
        public void DeleteLastItem()
        {
            var head = new LinkedListNode<int>
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
                            Next = new LinkedListNode<int>
                            {
                                Value = 3,
                                Next = new LinkedListNode<int>
                                {
                                    Value = 2,
                                    Next = new LinkedListNode<int>
                                    {
                                        Value = 3,
                                        Next = new LinkedListNode<int>
                                        {
                                            Value = 6,
                                            Next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var linkedList = new LinkedListImpl<int>(head);
            var result = linkedList.DeleteLastItem();
            Assert.AreEqual(6, result);
            Assert.AreEqual("2 3 3 2 3 2 3", linkedList.Print());
        }

        [Test]
        public void DeleteLastOccurrenceOf()
        {
            var head = new LinkedListNode<int>
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
                            Next = new LinkedListNode<int>
                            {
                                Value = 3,
                                Next = new LinkedListNode<int>
                                {
                                    Value = 2,
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
                        }
                    }
                }
            };

            var linkedList = new LinkedListImpl<int>(head);
            linkedList.DeleteLastOccurrenceOf(3);
            Assert.AreEqual("2 3 3 2 3 2 2", linkedList.Print());
        }

        [Test]
        public void DeleteAllOccurrencesOf()
        {
            var head = new LinkedListNode<int>
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
                            Next = new LinkedListNode<int>
                            {
                                Value = 3,
                                Next = new LinkedListNode<int>
                                {
                                    Value = 2,
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
                        }
                    }
                }
            };

            var linkedList = new LinkedListImpl<int>(head);
            linkedList.DeleteAllOccurrencesOf(3);
            Assert.AreEqual("2 2 2 2", linkedList.Print());
        }

        [Test]
        public void DeleteAllOccurrencesOf_fromRoot()
        {
            var head = new LinkedListNode<int>
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
                            Next = new LinkedListNode<int>
                            {
                                Value = 3,
                                Next = new LinkedListNode<int>
                                {
                                    Value = 2,
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
                        }
                    }
                }
            };

            var linkedList = new LinkedListImpl<int>(head);
            linkedList.DeleteAllOccurrencesOf(2);
            Assert.AreEqual("3 3 3 3", linkedList.Print());
        }

        [Test]
        public void DeleteLastOccurrenceOf_root()
        {
            var head = new LinkedListNode<int>
            {
                Value = 12,
                Next = new LinkedListNode<int>
                {
                    Value = 3,
                    Next = new LinkedListNode<int>
                    {
                        Value = 3,
                        Next = new LinkedListNode<int>
                        {
                            Value = 2,
                            Next = new LinkedListNode<int>
                            {
                                Value = 3,
                                Next = new LinkedListNode<int>
                                {
                                    Value = 2,
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
                        }
                    }
                }
            };

            var linkedList = new LinkedListImpl<int>(head);
            linkedList.DeleteLastOccurrenceOf(12);
            Assert.AreEqual("3 3 2 3 2 3 2", linkedList.Print());
        }

    }
}
