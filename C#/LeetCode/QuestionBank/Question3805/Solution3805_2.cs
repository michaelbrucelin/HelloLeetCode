using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3805
{
    public class Solution3805_2 : Interface3805
    {
        /// <summary>
        /// Trie
        /// 逻辑同Solution3805，改为Trie try 1 try
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public long CountPairs(string[] words)
        {
            long result = 0;
            Trie trie = new Trie();
            int offset, len = words[0].Length;
            char[] buffer = new char[len];
            foreach (string word in words)
            {
                if (word[0] != 'a')
                {
                    offset = 'a' + 26 - word[0];
                    for (int i = 0; i < len; i++) buffer[i] = (char)((word[i] - 'a' + offset) % 26 + 'a');
                    result += trie.Insert(buffer);
                }
                else
                {
                    result += trie.Insert(word);
                }
            }

            return result;
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; Cnt = 0; }
            public Trie[] Children;
            public int Cnt;

            public int Insert(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                return ptr.Cnt++;
            }

            public int Insert(char[] s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                return ptr.Cnt++;
            }
        }
    }
}
