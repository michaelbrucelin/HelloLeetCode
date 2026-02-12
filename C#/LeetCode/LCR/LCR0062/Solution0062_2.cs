using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0062
{
    public class Solution0062_2
    {
    }

    /// <summary>
    /// 使用数组实现
    /// </summary>
    public class Trie_2 : Interface0062
    {
        public Trie_2()
        {
            Children = new Trie_2[26];
            IsEnd = false;
        }

        public Trie_2[] Children;
        public bool IsEnd;

        public void Insert(string word)
        {
            Trie_2 ptr = this;
            int idx;
            foreach (char c in word)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie_2();
                ptr = ptr.Children[idx];
            }
            ptr.IsEnd = true;
        }

        public bool Search(string word)
        {
            Trie_2 ptr = this;
            int idx;
            foreach (char c in word)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return false;
                ptr = ptr.Children[idx];
            }
            return ptr.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            Trie_2 ptr = this;
            int idx;
            foreach (char c in prefix)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return false;
                ptr = ptr.Children[idx];
            }
            return true;
        }
    }
}
