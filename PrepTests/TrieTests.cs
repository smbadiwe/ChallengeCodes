using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Preps;

namespace PrepTests
{
    [TestFixture]
    public class TrieTests
    {
        [Test]
        public void TestTries()
        {
            var trie = new Trie();
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
    }
}
