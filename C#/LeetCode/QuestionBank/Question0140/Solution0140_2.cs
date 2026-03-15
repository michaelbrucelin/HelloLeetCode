using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0140
{
    public class Solution0140_2 : Interface0140
    {
        /// <summary>
        /// Trie + 回溯 + 记忆化搜索
        /// 逻辑同Solution0140，这里将Hash改为Trie
        /// 这里的记忆化记得是无效的位置，没有记有效位置的结果，记录有效位置的结果也可以，但是那样需要使用DFS，而不是回溯，这里就不写了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            List<string> result = [];
            int len = s.Length;
            Trie trie = new Trie();
            foreach (string word in wordDict) trie.Insert(word);
            StringBuilder buffer = new();
            bool[] badpos = new bool[len];
            backtrack(0);

            return result;

            void backtrack(int l)
            {
                if (l >= len || badpos[l]) return;
                List<int> list = trie.MultiQuery(s, l);
                if (list.Count == 0) { badpos[l] = true; return; }

                int backcnt = result.Count;
                foreach (int r in list)
                {
                    int backlen = buffer.Length;
                    buffer.Append(s, l, r - l + 1);
                    if (r == len - 1)
                    {
                        result.Add(buffer.ToString());
                    }
                    else
                    {
                        buffer.Append(' ');
                        backtrack(r + 1);
                    }
                    buffer.Length = backlen;
                }
                if (result.Count == backcnt) badpos[l] = true;
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
