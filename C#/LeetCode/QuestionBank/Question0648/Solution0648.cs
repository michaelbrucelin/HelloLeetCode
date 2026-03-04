using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0648
{
    public class Solution0648 : Interface0648
    {
        /// <summary>
        /// Trie + API(split string)
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            trie = new Trie();
            foreach (string s in dictionary) Insert(s);

            StringBuilder result = new StringBuilder();
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                result.Append(Search(word)); result.Append(' ');
            }
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        private Trie trie;

        public string Search(string s)
        {
            if (trie.Children[s[0] - 'a'] == null) return s;

            StringBuilder buffer = new StringBuilder();
            Trie ptr = trie;
            int idx;
            foreach (char c in s)
            {
                buffer.Append(c);
                idx = c - 'a';
                if (ptr.Children[idx] == null) return s;
                if (ptr.Children[idx].IsEnd) break;
                ptr = ptr.Children[idx];
            }

            return buffer.ToString();
        }

        public void Insert(string s)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in s)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie();
                ptr = ptr.Children[idx];
            }
            ptr.IsEnd = true;
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; }
            public Trie[] Children;
            public bool IsEnd;
        }
    }
}
