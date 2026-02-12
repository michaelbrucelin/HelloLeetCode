using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0062
{
    public class Solution0062
    {
    }

    /// <summary>
    /// 使用字典实现
    /// </summary>
    public class Trie : Interface0062
    {
        public Trie()
        {
            Children = new Dictionary<char, Trie>();
            IsEnd = false;
        }

        public Dictionary<char, Trie> Children;
        public bool IsEnd;

        public void Insert(string word)
        {
            Trie ptr = this;
            foreach (char c in word)
            {
                if (!ptr.Children.ContainsKey(c)) ptr.Children.Add(c, new Trie());
                ptr = ptr.Children[c];
            }
            ptr.IsEnd = true;
        }

        public bool Search(string word)
        {
            Trie ptr = this;
            foreach (char c in word)
            {
                if (!ptr.Children.TryGetValue(c, out Trie trie)) return false;
                ptr = trie;
            }
            return ptr.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            Trie ptr = this;
            foreach (char c in prefix)
            {
                if (!ptr.Children.TryGetValue(c, out Trie trie)) return false;
                ptr = trie;
            }
            return true;
        }
    }
}
