using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0139
{
    public class Solution0139_2 : Interface0139
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0139，改为DP，有点BFS的味道，就是从 true 的位置向后找全部的 true 的位置，然后看最后的位置是不是 true
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            int maxlen = 0, len = s.Length;
            HashSet<string> set = [];
            foreach (string word in wordDict) { maxlen = Math.Max(maxlen, word.Length); set.Add(word); }
            bool[] memory = new bool[len + 1];
            memory[0] = true;
            for (int i = 0; i <= len && !memory[len]; i++) if (memory[i])
                {
                    for (int j = i + 1; j <= len && j - i <= maxlen; j++) if (set.Contains(s[i..j])) memory[j] = true;
                }

            return memory[len];
        }

        /// <summary>
        /// 逻辑同WordBreak()，将Hash改为Trie
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak2(string s, IList<string> wordDict)
        {
            int len = s.Length;
            Trie trie = new Trie();
            foreach (string word in wordDict) trie.Insert(word);
            bool[] memory = new bool[len + 1];
            memory[0] = true;
            List<int> ends;
            for (int i = 0; i <= len && !memory[len]; i++) if (memory[i])
                {
                    ends = trie.MultiQuery(s, i);
                    foreach (int j in ends) memory[j + 1] = true;
                }

            return memory[len];
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
