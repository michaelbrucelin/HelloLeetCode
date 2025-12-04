using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1268
{
    public class Solution1268 : Interface1268
    {
        /// <summary>
        /// Trie + 回溯
        /// 使用Trie优化检索，使用回溯找出3个字典树最小的串
        /// 
        /// 没写完，先不写了
        /// </summary>
        /// <param name="products"></param>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Trie trie = new Trie();
            Trie ptr; int pc;
            foreach (string product in products)
            {
                ptr = trie;
                foreach (char c in product)
                {
                    pc = c - 'a';
                    if (trie.Children == null)
                    {
                        trie.Children = new Trie[26]; trie.Children[pc] = new Trie();
                    }
                    else
                    {
                        if (trie.Children[pc] == null) trie.Children[pc] = new Trie();
                    }
                    trie = trie.Children[pc];
                }
                trie.IsEnd = true;
            }

            List<IList<string>> result = [];
            ptr = trie; Trie _ptr;
            StringBuilder buffer = new StringBuilder(), _buffer;
            foreach (char c in searchWord)
            {
                pc = c - 'a';
                ptr = ptr.Children[pc];
                if (ptr == null) { result.Add([]); break; }
                buffer.Append(c);

                List<string> _result = [];


                result.Add(_result);
            }
            for (int i = searchWord.Length - result.Count; i > 0; i--) result.Add([]);

            return result;

            void backtrack(Trie node, List<string> list, StringBuilder sb)
            { 
                
            }
        }

        class Trie
        {
            public bool IsEnd = false;
            public Trie[] Children;
        }
    }
}
