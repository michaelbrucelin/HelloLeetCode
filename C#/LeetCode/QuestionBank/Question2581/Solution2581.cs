using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2581
{
    public class Solution2581 : Interface2581
    {
        /// <summary>
        /// 暴力枚举
        /// 用List<int>[]表示树，用HashSet<int>[]表示猜测的树，暴力枚举解一下，大概率会TLE，这里只是写着玩的
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="guesses"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int RootCount(int[][] edges, int[][] guesses, int k)
        {
            int n = edges.Length + 1;
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }
            HashSet<int>[] guess = new HashSet<int>[n];
            for (int i = 0; i < n; i++) guess[i] = new HashSet<int>();
            foreach (var edge in guesses)
            {
                guess[edge[0]].Add(edge[1]);
            }

            int result = 0;
            for (int i = 0; i < n; i++) if (Verify(tree, i, guess, k)) result++;

            return result;
        }

        private bool Verify(List<int>[] tree, int root, HashSet<int>[] guess, int k)
        {
            int _k = 0;
            Queue<(int u, int v)> queue = new Queue<(int u, int v)>();
            foreach (int v in tree[root]) queue.Enqueue((root, v));
            (int u, int v) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (guess[item.u].Contains(item.v))
                {
                    _k++; if (_k >= k) return true;
                }
                foreach (int _v in tree[item.v]) if (_v != item.u)
                    {
                        queue.Enqueue((item.v, _v));
                    }
            }

            return false;
        }
    }
}
