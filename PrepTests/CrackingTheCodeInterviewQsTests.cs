using NUnit.Framework;
using Preps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepTests
{
    [TestFixture]
    public class CrackingTheCodeInterviewQsTests
    {
        [Test]
        public void AreAnagram_Test()
        {
            string str1, str2;
            bool result;

            str1 = "aeerwf";
            str2 = "aefwre";
            result = CrackingTheCodeInterviewQs.AreAnagrams(str1, str2);
            Assert.IsTrue(result);

            str1 = "";
            str2 = "";
            result = CrackingTheCodeInterviewQs.AreAnagrams(str1, str2);
            Assert.IsTrue(result);

        }
        [Test]
        public void DeleteMiddleNode_Test()
        {
            var list = new Preps.LinkedListNode<int>
            {
                Value = 2,
                Next = new Preps.LinkedListNode<int>
                {
                    Value = 3,
                    Next = new Preps.LinkedListNode<int>
                    {
                        Value = 1,
                        Next = null
                    }
                }
            };
            CrackingTheCodeInterviewQs.DeleteMiddleNode(list);
            Assert.IsNotNull(list.Next);
            Assert.AreEqual(1, list.Next.Value);
            Assert.IsNull(list.Next.Next);
            
        }
    }
}
