using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0211
{
    public class Solution0211
    {
    }

    public class WordDictionary : Interface0211
    {
        public WordDictionary()
        {
            trie = new Trie();
        }

        private Trie trie;

        public void AddWord(string word)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in word)
            {
                if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                ptr = ptr.Children[idx];
            }
            ptr.IsEnd = true;
        }

        public bool Search(string word)
        {
            return Search(word, 0, trie);
        }

        private static bool Search(string word, int p, Trie node)
        {
            if (word[p] != '.')
            {
                Trie child;
                if ((child = node.Children[word[p] - 'a']) == null) return false;
                return p == word.Length - 1 ? child.IsEnd : Search(word, p + 1, child);
            }
            else
            {
                if (p == word.Length - 1)
                {
                    foreach (Trie child in node.Children) if (child != null && child.IsEnd) return true;
                    return false;
                }
                else
                {
                    foreach (Trie child in node.Children) if (child != null && Search(word, p + 1, child)) return true;
                    return false;
                }
            }
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; }
            public Trie[] Children;
            public bool IsEnd;
        }
    }
}
