using NUnit.Framework;
using Preps;

namespace PrepTests
{
  [TestFixture]
    public class HackerRankTests
    {
        [Test]
        public void TestContacts()
        {
            var trie = new HackerRank.Phone();
            trie.Insert("arm");
            trie.Insert("armed");
            trie.Insert("armour");
            trie.Insert("arc");
            trie.Insert("arcane");
            trie.Insert("arch");
            trie.Insert("jazz");
            trie.Insert("jaws");
            int result;
            result = trie.Search("hac");
            Assert.AreEqual(0, result);
            result = trie.Search("ar");
            Assert.AreEqual(6, result);
            result = trie.Search("arm");
            Assert.AreEqual(3, result);
            result = trie.Search("arc");
            Assert.AreEqual(3, result);
            result = trie.Search("ja");
            Assert.AreEqual(2, result);

        }
        [Test]
        public void MergeSort_Test()
        {
            var input = new []{ 1, 3, 6, 2, 8 };
            var result = HackerRank.MergeSort(input);
            Assert.AreEqual(3, input[2]);
            Assert.AreEqual(2, result);
            input = new[] { 2, 1, 3, 1, 2 };
            result = HackerRank.MergeSort(input);
            Assert.AreEqual(1, input[0]);
            Assert.AreEqual(1, input[1]);
            Assert.AreEqual(4, result);
        }
    }
}
