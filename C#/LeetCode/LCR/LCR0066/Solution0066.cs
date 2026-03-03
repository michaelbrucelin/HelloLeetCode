using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0066
{
    public class Solution0066
    {
    }

    /// <summary>
    /// Trie
    /// </summary>
    public class MapSum : Interface0066
    {
        public MapSum()
        {
            trie = new Trie();
        }

        private Trie trie;

        public void Insert(string key, int val)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in key)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie();
                ptr = ptr.Children[idx];
            }
            ptr.Value = val;
        }

        public int Sum(string prefix)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in prefix)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return 0;
                ptr = ptr.Children[idx];
            }

            return Sum(ptr);
        }

        private int Sum(Trie root)
        {
            int sum = root.Value;
            for (int i = 0; i < 26; i++) if (root.Children[i] != null) sum += Sum(root.Children[i]);

            return sum;
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; Value = 0; }
            public Trie[] Children;
            public int Value;
        }
    }
}
