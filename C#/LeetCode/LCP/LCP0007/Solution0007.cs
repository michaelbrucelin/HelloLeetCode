using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0007
{
    public class Solution0007 : Interface0007
    {
        /// <summary>
        /// 有向图 + BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relation"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumWays(int n, int[][] relation, int k)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var arr in relation) graph[arr[0]].Add(arr[1]);

            int result = 0, u;
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            for (int _k = 0; _k < k; _k++) for (int i = queue.Count; i > 0; i--)
                {
                    u = queue.Dequeue();
                    foreach (int v in graph[u]) queue.Enqueue(v);
                }
            while (queue.Count > 0) if (queue.Dequeue() == n - 1) result++;

            return result;
        }

        /// <summary>
        /// 逻辑同NumWays()
        /// 这里使用两个字典代替队列，字典中记录了到达该顶点的次数，这样时间复杂度更低
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relation"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumWays2(int n, int[][] relation, int k)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var arr in relation) graph[arr[0]].Add(arr[1]);

            Dictionary<int, int> queue = new Dictionary<int, int> { { 0, 1 } }, _queue = new Dictionary<int, int>();
            for (int _k = 0; _k < k; _k++)
            {
                foreach (var kv in queue) foreach (int v in graph[kv.Key])
                    {
                        _queue.TryAdd(v, 0); _queue[v] += kv.Value;
                    }
                queue = _queue; _queue = new Dictionary<int, int>();
            }

            int result = 0;
            foreach (var kv in queue) if (kv.Key == n - 1) result += kv.Value;

            return result;
        }
    }
}
