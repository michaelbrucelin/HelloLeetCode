using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0140
{
    public class Solution0140_3 : Interface0140
    {
        /// <summary>
        /// Trie + DFS + 记忆化搜索
        /// 与Solution0140_2相比，理论上更废内存，速度上也更快，写写试试
        /// 记忆化搜索如果记录字符串列表结果，就太消耗内存了，这里记录插入空格的位置
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            int len = s.Length;
            Trie trie = new Trie();
            foreach (string word in wordDict) trie.Insert(word);
            List<List<int>>[] memory = new List<List<int>>[len];
            dfs(0);

            List<string> result = [];
            StringBuilder buffer = new StringBuilder();
            foreach (List<int> ids in memory[0])
            {
                buffer.Clear();
                buffer.Append(s, 0, ids[0] + 1);
                for (int i = 1; i < ids.Count; i++)
                {
                    buffer.Append(' '); buffer.Append(s, ids[i - 1] + 1, ids[i] - ids[i - 1]);
                }
                result.Add(buffer.ToString());
            }
            return result;

            List<List<int>> dfs(int l)
            {
                if (l >= len) return [];
                if (memory[l] != null) return memory[l];

                List<int> list = trie.MultiQuery(s, l);
                if (list.Count == 0) { memory[l] = []; return []; }

                memory[l] = [];
                foreach (int r in list)
                {
                    if (r == len - 1)
                    {
                        memory[l].Add([r]);
                    }
                    else
                    {
                        List<List<int>> nexts = dfs(r + 1);
                        foreach (List<int> next in nexts) memory[l].Add([r, .. next]);
                    }
                }

                return memory[l];
            }
        }

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

            public List<int> MultiQuery(string s, int start)
            {
                List<int> result = [];
                Trie ptr = this;
                int idx, len = s.Length;
                for (int i = start; i < len; i++)
                {
                    if (ptr.Children[idx = s[i] - 'a'] == null) break;
                    ptr = ptr.Children[idx];
                    if (ptr.IsEnd) result.Add(i);
                }

                return result;
            }
        }
    }
}
