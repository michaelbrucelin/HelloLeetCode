using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3093
{
    public class Solution3093 : Interface3093
    {
        /// <summary>
        /// Trie
        /// </summary>
        /// <param name="wordsContainer"></param>
        /// <param name="wordsQuery"></param>
        /// <returns></returns>
        public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
        {
            Trie trie = new Trie();
            int len = wordsContainer.Length;
            for (int i = 0; i < len; i++) trie.Add(wordsContainer[i], i);

            len = wordsQuery.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[i] = trie.Search(wordsQuery[i]);
            return result;
        }

        public class Trie
        {
            public Trie()
            {
                Children = new Trie[26];
                Length = int.MaxValue;
                Index = -1;
            }

            public Trie[] Children;
            public int Length;
            public int Index;

            public void Add(string s, int id)
            {
                Trie ptr = this;
                int idx, len = s.Length;
                if (len < ptr.Length) { ptr.Index = id; ptr.Length = len; }
                for (int i = len - 1; i >= 0; i--)
                {
                    if (ptr.Children[idx = s[i] - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                    if (len < ptr.Length) { ptr.Index = id; ptr.Length = len; }
                }
            }

            public int Search(string s)
            {
                int result = this.Index;
                Trie ptr = this;
                int idx, len = s.Length;
                for (int i = len - 1; i >= 0; i--)
                {
                    if (ptr.Children[idx = s[i] - 'a'] == null) break;
                    ptr = ptr.Children[idx];
                    result = ptr.Index;
                }

                return result;
            }
        }
    }
}
