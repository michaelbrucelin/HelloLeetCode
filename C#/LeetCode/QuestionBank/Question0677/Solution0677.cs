using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0677
{
    public class Solution0677
    {
    }

    /// <summary>
    /// Trie
    /// </summary>
    public class MapSum : Interface0677
    {
        public MapSum()
        {
            map = new Trie();
        }

        public Trie map;

        public void Insert(string key, int val)
        {
            Trie ptr = map;
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
            Trie ptr = map;
            int idx;
            foreach (char c in prefix)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return 0;
                ptr = ptr.Children[idx];
            }

            int result = ptr.Value;
            dfs(ptr, ref result);
            return result;
        }

        private void dfs(Trie node, ref int sum)
        {
            for (int i = 0; i < 26; i++) if (node.Children[i] != null)
                {
                    sum += node.Children[i].Value;
                    dfs(node.Children[i], ref sum);
                }
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; Value = 0; }
            public Trie[] Children;
            public int Value;
        }
    }
}
