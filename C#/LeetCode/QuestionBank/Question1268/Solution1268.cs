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
        /// TODO
        ///   1. Trie增加Childcnt属性，记录有几个孩子，用于剪枝？
        ///   2. 下一轮查找不需要从根开始，从上一次的结果开始即可
        /// </summary>
        /// <param name="products"></param>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Trie trie = new Trie();
            foreach (string s in products) insert(s);

            int len = searchWord.Length;
            List<string>[] result = new List<string>[len];
            result[0] = search(0);
            for (int i = 1; i < len; i++)
            {
                if (result[i - 1].Count == 0) result[i] = []; else result[i] = search(i);
            }

            return result;

            List<string> search(int x)
            {
                Trie ptr = trie;
                int idx;
                List<char> buffer = [];
                for (int i = 0; i <= x; i++)
                {
                    idx = searchWord[i] - 'a';
                    if (ptr.Children[idx] == null) return [];
                    buffer.Add(searchWord[i]);
                    ptr = ptr.Children[idx];
                }

                List<string> result = ptr.IsEnd ? [searchWord] : [];
                backtrack(ptr, buffer, result);
                return result;
            }

            void backtrack(Trie ptr, List<char> buffer, List<string> result)
            {
                for (int i = 0; i < 26 && result.Count < 3; i++) if (ptr.Children[i] != null)
                    {
                        buffer.Add((char)('a' + i));
                        if (ptr.Children[i].IsEnd)
                        {
                            result.Add(new string([.. buffer]));
                            if (result.Count == 3) return;
                        }
                        backtrack(ptr.Children[i], buffer, result);
                        buffer.RemoveAt(buffer.Count - 1);
                    }
            }

            void insert(string s)
            {
                Trie ptr = trie;
                int idx;
                foreach (char c in s)
                {
                    idx = c - 'a';
                    if (ptr.Children[idx] == null) { ptr.Children[idx] = new Trie(); }
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }
        }

        class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; }
            public Trie[] Children;
            public bool IsEnd;
        }
    }
}
