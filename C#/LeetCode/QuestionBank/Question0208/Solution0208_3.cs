using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0208
{
    public class Solution0208_3
    {
    }

    public class Trie_3 : Interface0208
    {
        public Trie_3()
        {
            _trie = new _Trie();
        }

        private _Trie _trie;

        public void Insert(string word)
        {
            _Trie ptr = _trie;
            foreach (char c in word)
            {
                if (!ptr.children.ContainsKey(c)) ptr.children.Add(c, new _Trie());
                ptr = ptr.children[c];
            }
            ptr.IsEnd = true;
        }

        public bool Search(string word)
        {
            _Trie ptr = _trie;
            foreach (char c in word)
            {
                if (!ptr.children.ContainsKey(c)) return false;
                ptr = ptr.children[c];
            }

            return ptr.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            _Trie ptr = _trie;
            foreach (char c in prefix)
            {
                if (!ptr.children.ContainsKey(c)) return false;
                ptr = ptr.children[c];
            }

            return true;
        }

        public class _Trie
        {
            public _Trie() { IsEnd = false; children = new(); }
            public bool IsEnd { get; set; } = false;
            public Dictionary<char, _Trie> children;
        }
    }
}
