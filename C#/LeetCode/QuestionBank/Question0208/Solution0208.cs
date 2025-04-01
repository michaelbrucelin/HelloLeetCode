using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0208
{
    public class Solution0208
    {
    }

    /// <summary>
    /// 前缀树/字典树
    /// </summary>
    public class Trie : Interface0208
    {
        public Trie()
        {
            this.val = '\0';
            children = new Dictionary<char, Trie>();
        }

        private char val;
        private bool isEnd;
        private Dictionary<char, Trie> children;

        public void Insert(string word)
        {
            Trie ptr = this;
            foreach (char c in word)
            {
                if (!ptr.children.ContainsKey(c)) ptr.children.Add(c, new Trie() { val = c });
                ptr = ptr.children[c];
            }
            ptr.isEnd = true;
        }

        public bool Search(string word)
        {
            Trie ptr = this;
            foreach (char c in word)
            {
                if (!ptr.children.ContainsKey(c)) return false;
                ptr = ptr.children[c];
            }
            return ptr.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            Trie ptr = this;
            foreach (char c in prefix)
            {
                if (!ptr.children.ContainsKey(c)) return false;
                ptr = ptr.children[c];
            }
            return true;
        }
    }
}
