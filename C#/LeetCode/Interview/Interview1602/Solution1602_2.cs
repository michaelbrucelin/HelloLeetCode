using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1602
{
    public class Solution1602_2
    {
    }

    /// <summary>
    /// Trie
    /// </summary>
    public class WordsFrequency_2 : Interface1602
    {
        public WordsFrequency_2(string[] book)
        {
            trie = new Trie();
            foreach (string s in book) Insert(s);
        }

        private Trie trie;

        public int Get(string word)
        {
            return Search(word);
        }

        private void Insert(string s)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in s)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie();
                ptr = ptr.Children[idx];
            }
            if (!ptr.IsEnd) ptr.IsEnd = true;
            ptr.Count++;
        }

        private int Search(string s)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in s)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return 0;
                ptr = ptr.Children[idx];
            }

            return ptr.IsEnd ? ptr.Count : 0;
        }

        class Trie
        {
            public Trie()
            {
                Children = new Trie[26];
                IsEnd = false;
                Count = 0;
            }

            public Trie[] Children;
            public bool IsEnd;
            public int Count;
        }
    }
}
