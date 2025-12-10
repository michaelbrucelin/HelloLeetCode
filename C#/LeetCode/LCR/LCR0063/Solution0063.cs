using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0063
{
    public class Solution0063 : Interface0063
    {
        /// <summary>
        /// Trie
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            Trie trie = new Trie();
            Trie ptr;
            foreach (string word in dictionary)
            {
                ptr = trie;
                foreach (char c in word)
                {
                    if (ptr.Children == null) ptr.Children = new Trie[26];
                    if (ptr.Children[c - 'a'] == null) ptr.Children[c - 'a'] = new Trie();
                    ptr = ptr.Children[c - 'a'];
                }
                ptr.IsEnd = true;
            }

            StringBuilder result = new StringBuilder();
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                ptr = trie;
                foreach (char c in word)
                {
                    result.Append(c);
                    if (ptr == null || ptr.Children == null || ptr.Children[c - 'a'] == null)
                    {
                        ptr = null;
                    }
                    else
                    {
                        if (ptr.Children[c - 'a'].IsEnd) break;
                        ptr = ptr.Children[c - 'a'];
                    }
                }
                result.Append(' ');
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public class Trie()
        {
            public bool IsEnd;
            public Trie[] Children;
        }
    }
}
