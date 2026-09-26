using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807_6 : Interface1807
    {
        /// <summary>
        /// Trie
        /// </summary>
        /// <param name="s"></param>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            Trie trie = new Trie();
            foreach (IList<string> item in knowledge) trie.Add(item[0], item[1]);

            StringBuilder result = new StringBuilder();
            int pl = 0, pr, len = s.Length;
            while (pl < len)
            {
                while (pl < len && s[pl] != '(') result.Append(s[pl++]);
                if (pl == len) break;
                pr = ++pl;
                while (s[pr] != ')') pr++;           // 题目限定一定有 )
                result.Append(trie.Get(s[pl..pr]));
                pl = pr + 1;
            }

            return result.ToString();
        }

        public class Trie
        {
            public Trie()
            {
                children = new Trie[26];
                value = "?";
            }

            private Trie[] children;
            private string value;

            public void Add(string key, string val)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in key)
                {
                    if (ptr.children[idx = c - 'a'] == null) ptr.children[idx] = new Trie();
                    ptr = ptr.children[idx];
                }
                ptr.value = val;
            }

            public string Get(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.children[idx = c - 'a'] == null) return "?";
                    ptr = ptr.children[idx];
                }
                return ptr.value;
            }
        }
    }
}
