using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2452
{
    public class Solution2452_2 : Interface2452
    {
        /// <summary>
        /// Trie + 回溯
        /// 逻辑同Solution2452，将Hash改为Trie
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public IList<string> TwoEditWords(string[] queries, string[] dictionary)
        {
            trie = new Trie();
            foreach (string s in dictionary) trie.Insert(s);

            List<string> result = new List<string>();
            int n = queries[0].Length;
            foreach (string s in queries) if (dfs(s, trie, 0, 2)) result.Add(s);
            return result;

            bool dfs(string s, Trie node, int idx, int cnt)
            {
                if (idx == s.Length) return true;

                int child = s[idx] - 'a';
                if (cnt > 0)
                {
                    for (int i = 0; i < 26; i++) if (i != child && node.Children[i] != null)
                        {
                            if (dfs(s, node.Children[i], idx + 1, cnt - 1)) return true;
                        }
                }
                if (node.Children[child] != null && dfs(s, node.Children[child], idx + 1, cnt)) return true;

                return false;
            }
        }

        private Trie trie;

        public class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; }
            public Trie[] Children;
            public bool IsEnd;

            public void Insert(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }
        }
    }
}
