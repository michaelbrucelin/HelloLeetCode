using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1713
{
    public class Solution1713_2 : Interface1713
    {
        /// <summary>
        /// Trie + 回溯 + DP
        /// 逻辑同Solution1713，将DPF+记忆化搜索改为DP
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public int Respace(string[] dictionary, string sentence)
        {
            int len = sentence.Length;
            Trie trie = new Trie();
            foreach (string word in dictionary) if (word.Length <= len) trie.Add(word);
            bool[,] spans = new bool[len, len];
            Trie ptr;
            for (int i = 0, idx; i < len; i++)
            {
                ptr = trie;
                for (int j = i; j < len; j++)
                {
                    if (ptr.Children[idx = sentence[j] - 'a'] == null) break;
                    ptr = ptr.Children[idx];
                    if (ptr.IsEnd) spans[i, j] = true;
                }
            }

            int[] dp = new int[len + 1];
            Array.Fill(dp, int.MaxValue); dp[0] = 0;
            for (int j = 0; j < len; j++) for (int i = j; i >= 0; i--)
                {
                    dp[j + 1] = Math.Min(dp[j + 1], dp[i] + (spans[i, j] ? 0 : j - i + 1));
                }

            return dp[^1];
        }

        public class Trie
        {
            public Trie()
            {
                Children = new Trie[26];
                IsEnd = false;
            }

            public Trie[] Children;
            public bool IsEnd;

            public void Add(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (int c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }

            public bool Contain(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) return false;
                    ptr = ptr.Children[idx];
                }
                return ptr.IsEnd;
            }
        }
    }
}
