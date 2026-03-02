using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3597
{
    public class Solution3597_2 : Interface3597
    {
        /// <summary>
        /// Trie + 双指针
        /// 逻辑同Solution3597，将Hash改为Trie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> PartitionString(string s)
        {
            if (s.Length == 1) return [s];

            List<string> result = [];
            Trie trie = new Trie();
            int pl = 0, pr = -1, len = s.Length;
            while (pl < len)
            {
                pr = insert(pr);
                if (pr == -1) break;
                result.Add(s[pl..(pr + 1)]);
                pl = pr + 1;
            }

            return result;

            int insert(int p)
            {
                Trie ptr = trie;
                int idx = -1;
                while (++p < len && ptr.Children[idx = s[p] - 'a'] != null) ptr = ptr.Children[idx];
                if (p == len) return -1;
                ptr.Children[idx] = new Trie();
                return p;
            }
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; }
            public Trie[] Children;
        }
    }
}
