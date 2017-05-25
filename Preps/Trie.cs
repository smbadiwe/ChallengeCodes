using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps
{
    /// <summary>
    /// See the alternative and maybe better implementation: <see cref="HackerRank.Phone"/>
    /// </summary>
    public class Trie
    {
        private readonly TrieNode<char> _root;

        public Trie()
        {
            _root = new TrieNode<char>('^', 0, null);
        }

        public TrieNode<char> Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        private int GetCount(TrieNode<char> node)
        {
            int result = 0;

            if (node.Value == '$')
            {
                result += 1;
            }
            else
            {
                foreach (TrieNode<char> child in node.Children)
                {
                    if (child.Value == '$')
                    {
                        result += 1;
                    }
                    else
                    {
                        result += GetCount(child);
                    }
                }
            }
            return result;
        }
        
        public int Search(string s)
        {
            var prefix = Prefix(s);
            if (prefix.Depth != s.Length)
                return 0;

            return GetCount(prefix);
        }

        public bool SearchExact(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new TrieNode<char>(s[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }
                
            current.Children.Add(new TrieNode<char>('$', current.Depth + 1, current));
        }

        public void Delete(string s)
        {
            if (SearchExact(s))
            {
                var node = Prefix(s).FindChildNode('$');

                while (node.IsLeaf)
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }
}
