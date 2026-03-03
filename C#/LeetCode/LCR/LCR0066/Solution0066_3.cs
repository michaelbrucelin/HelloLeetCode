using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0066
{
    public class Solution0066_3
    {
    }

    /// <summary>
    /// Trie
    /// 逻辑同Solution0066，优化，再插入新值时，直接更新前缀和
    /// </summary>
    public class MapSum_3 : Interface0066
    {
        public MapSum_3()
        {
            trie = new Trie();
            map = new Dictionary<string, int>();
        }

        private Trie trie;
        private Dictionary<string, int> map;

        public void Insert(string key, int val)
        {
            if (map.TryGetValue(key, out int _val)) { map[key] = val; val -= _val; } else map.Add(key, val);

            Trie ptr = trie;
            int idx;
            foreach (char c in key)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie();
                ptr = ptr.Children[idx];
                ptr.Value += val;
            }
        }

        public int Sum(string prefix)
        {
            Trie ptr = trie;
            int idx;
            foreach (char c in prefix)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return 0;
                ptr = ptr.Children[idx];
            }

            return ptr.Value;
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; Value = 0; }
            public Trie[] Children;
            public int Value;
        }
    }
}
