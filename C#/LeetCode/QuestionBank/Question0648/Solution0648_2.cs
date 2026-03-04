using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0648
{
    public class Solution0648_2 : Interface0648
    {
        /// <summary>
        /// Trie + 双指针(split string)
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            trie = new Trie();
            foreach (string s in dictionary) Insert(s);

            StringBuilder result = new StringBuilder(), buffer = new StringBuilder();
            int pl = 0, pr = -1, pend, idx, len = sentence.Length;
            bool flag; Trie ptr;
            while (pl < len)
            {
                flag = true; ptr = trie; pend = -1;
                while (++pr < len && sentence[pr] != ' ') if (flag)
                    {
                        if (ptr.Children[idx = sentence[pr] - 'a'] == null) flag = false;
                        else if (ptr.Children[idx].IsEnd) { pend = pr; flag = false; }
                        else ptr = ptr.Children[idx];
                    }
                if (pend != -1) result.Append(sentence[pl..(pend + 1)]); else result.Append(sentence[pl..pr]);
                result.Append(' ');
                pl = pr + 1;
            }
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        private Trie trie;

        public void Insert(string s)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in s)
            {
                if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
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
