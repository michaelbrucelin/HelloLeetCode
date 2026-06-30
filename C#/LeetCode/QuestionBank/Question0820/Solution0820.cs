using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0820
{
    public class Solution0820 : Interface0820
    {
        /// <summary>
        /// Trie
        /// words按照字符串长度降序排列，每个字符串降序插入Trie中即可
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MinimumLengthEncoding2(string[] words)
        {
            if (words.Length == 1) return words[0].Length + 1;
            Array.Sort(words, (x, y) => y.Length - x.Length);

            int result = 0, len = words.Length;
            Trie trie = new Trie();
            for (int i = 0; i < len; i++) if (trie.Insert(words[i])) result += words[i].Length + 1;

            return result;
        }

        /// <summary>
        /// 逻辑同MinimumLengthEncoding()，改为计数排序
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MinimumLengthEncoding(string[] words)
        {
            if (words.Length == 1) return words[0].Length + 1;

            int result = 0, len = words.Length;
            List<int>[] order = new List<int>[8];
            for (int i = 1; i < 8; i++) order[i] = [];
            for (int i = 0; i < len; i++) order[words[i].Length].Add(i);

            Trie trie = new Trie();
            for (int i = 7; i > 0; i--) foreach (int j in order[i]) if (trie.Insert(words[j])) result += i + 1;

            return result;
        }

        public class Trie
        {
            public Trie()
            {
                Children = new Trie[26];
            }

            private Trie[] Children;

            public bool Insert(string s)
            {
                bool flag = false;
                Trie ptr = this;
                int idx;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    idx = s[i] - 'a';
                    if (ptr.Children[idx] == null)
                    {
                        ptr.Children[idx] = new Trie();
                        flag = true;
                    }
                    ptr = ptr.Children[idx];
                }

                return flag;
            }
        }
    }
}
