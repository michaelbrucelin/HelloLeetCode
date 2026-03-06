using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0065
{
    public class Solution0065 : Interface0065
    {
        /// <summary>
        /// Trie
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MinimumLengthEncoding(string[] words)
        {
            trie = new Trie();
            foreach (string word in words) trie.ReverseInsert(word);

            int result = 0;
            dfs(trie);
            return result;

            void dfs(Trie node)
            {
                if (node.IsEnd)
                {
                    bool flag = true;
                    for (int i = 0; i < 26; i++) if (node.Children[i] != null) { dfs(node.Children[i]); flag = false; }
                    if (flag) result += node.Depth;
                }
                else
                {
                    for (int i = 0; i < 26; i++) if (node.Children[i] != null) dfs(node.Children[i]);
                }
            }
        }

        private Trie trie;

        public class Trie
        {
            public Trie() { Children = new Trie[26]; Depth = 1; IsEnd = false; }
            public Trie(int depth) { Children = new Trie[26]; Depth = depth; IsEnd = false; }
            public Trie[] Children;
            public int Depth;
            public bool IsEnd;

            public void ReverseInsert(string s)
            {
                Trie ptr = this;
                int idx;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (ptr.Children[idx = s[i] - 'a'] == null) ptr.Children[idx] = new Trie(ptr.Depth + 1);
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }
        }
    }
}
