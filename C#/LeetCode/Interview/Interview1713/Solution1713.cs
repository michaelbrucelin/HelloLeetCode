using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1713
{
    public class Solution1713 : Interface1713
    {
        /// <summary>
        ///  Trie + 回溯
        ///  1. 将dictionary中的词汇放到Trie中，注意如果词汇长度大于sentence的长度，丢弃
        ///  2. 找出sentence中所有词汇的区间
        ///  3. 基于2的结果DFS，回溯，BFS都可以找出结果
        ///  
        /// 没写完，稍后再写
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public int Respace(string[] dictionary, string sentence)
        {
            int len = sentence.Length;
            Trie trie = new Trie();
            foreach (string word in dictionary) if (word.Length <= len) trie.Add(word);

            throw new NotImplementedException();
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
