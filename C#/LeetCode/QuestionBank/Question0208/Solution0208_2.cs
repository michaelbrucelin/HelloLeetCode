using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0208
{
    public class Solution0208_2
    {
    }

    /// <summary>
    /// 与Solution0208相同，只是将字典改为数组试一下时间复杂度
    /// 结论，数组就是比字典快很多
    /// </summary>
    public class Trie_2 : Interface0208
    {
        public Trie_2()
        {
            children = new Trie_2[26];
        }

        private bool isEnd;
        private Trie_2[] children;

        public void Insert(string word)
        {
            Trie_2 ptr = this;
            foreach (char c in word)
            {
                ptr.children[c - 'a'] ??= new Trie_2() { val = c };
                ptr = ptr.children[c - 'a'];
            }
            ptr.isEnd = true;
        }

        public bool Search(string word)
        {
            Trie_2 ptr = this;
            foreach (char c in word)
            {
                if (ptr.children[c - 'a'] == null) return false;
                ptr = ptr.children[c - 'a'];
            }
            return ptr.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            Trie_2 ptr = this;
            foreach (char c in prefix)
            {
                if (ptr.children[c - 'a'] == null) return false;
                ptr = ptr.children[c - 'a'];
            }
            return true;
        }
    }
}
