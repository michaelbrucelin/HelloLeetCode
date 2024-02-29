using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2581
{
    public class Solution2581_2 : Interface2581
    {
        /// <summary>
        /// 树的旋转
        /// 将树的根节点由 u 换成 v 后，节点间的父子关系，除了 u 与 v 之外，其余的节点据没有变化
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

            int result, cnt0;
            cnt0 = RootCount(tree, 0, guess);
            result = cnt0 >= k ? 1 : 0;
            Queue<(int parent, int child, int cnt)> queue = new Queue<(int parent, int child, int cnt)>();
            foreach (int child in tree[0]) queue.Enqueue((0, child, cnt0));
            (int parent, int child, int cnt) item; int _cnt;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                _cnt = item.cnt + ((guess[item.parent].Contains(item.child), guess[item.child].Contains(item.parent)) switch
                {
                    (true, true) => 0,
                    (true, false) => -1,
                    (false, true) => 1,
                    (false, false) => 0
                });
                result += _cnt >= k ? 1 : 0;

                foreach (int _child in tree[item.child]) if (_child != item.parent)
                    {
                        queue.Enqueue((item.child, _child, _cnt));
                    }
            }

            return result;
        }

        /// <summary>
        /// 计算以root为根，guess猜对的结果数量
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="root"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        private int RootCount(List<int>[] tree, int root, HashSet<int>[] guess)
        {
            int result = 0;
            Queue<(int u, int v)> queue = new Queue<(int u, int v)>();
            foreach (int v in tree[root]) queue.Enqueue((root, v));
            (int u, int v) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (guess[item.u].Contains(item.v)) result++;
                foreach (int _v in tree[item.v]) if (_v != item.u)
                    {
                        queue.Enqueue((item.v, _v));
                    }
            }

            return result;
        }
    }
}
