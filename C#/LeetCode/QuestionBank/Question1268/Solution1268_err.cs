using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1268
{
    public class Solution1268_err : Interface1268
    {
        /// <summary>
        /// Trie + 回溯
        /// 优化
        ///   1. 下一轮查找不需要从根开始，从上一次的结果开始即可
        ///   2. Trie中增加一个大顶堆，只保留3个最小的值
        /// 
        /// 思路是对的，但是在遍历的时候，maxpq.dequeue()变更了maxpq，导致第二次遍历时错误了，这个地方需要优化，暂时先不写了
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
            Trie root = trie;
            List<char> buffer = [];
            result[0] = search(0);
            for (int i = 1; i < len; i++)
            {
                if (result[i - 1].Count == 0) result[i] = []; else result[i] = search(i);
            }

            return result;

            List<string> search(int x)
            {
                int idx = searchWord[x] - 'a';
                if (root.Children[idx] == null) { root = null; return []; }
                while (buffer.Count > x) buffer.RemoveAt(buffer.Count - 1);
                buffer.Add(searchWord[x]);
                root = root.Children[idx];

                List<string> result = root.IsEnd ? [searchWord[..(x + 1)]] : [];
                Trie ptr = root;
                backtrack(ptr, result);

                return result;
            }

            void backtrack(Trie ptr, List<string> result)
            {
                Stack<int> stack = new Stack<int>();
                while (ptr.MaxPQ.Count > 0) stack.Push(ptr.MaxPQ.Dequeue());
                int i;
                while (stack.Count > 0 && result.Count < 3)
                {
                    i = stack.Pop();
                    buffer.Add((char)('a' + i));
                    if (ptr.Children[i].IsEnd)
                    {
                        result.Add(new string([.. buffer]));
                        if (result.Count == 3) return;
                    }
                    backtrack(ptr.Children[i], result);
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
                    if (ptr.Children[idx] == null)
                    {
                        ptr.Children[idx] = new Trie();
                        ptr.MaxPQ.Enqueue(idx, idx);
                        // if (ptr.MaxPQ.Count > 3) ptr.Children[ptr.MaxPQ.Dequeue()] = null;
                        if (ptr.MaxPQ.Count > 3) ptr.MaxPQ.Dequeue();
                    }
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }
        }

        class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; MaxPQ = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x)); }
            public Trie[] Children;
            public bool IsEnd;
            public PriorityQueue<int, int> MaxPQ;
        }
    }
}
