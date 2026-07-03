using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3620
{
    public class Solution3620 : Interface3620
    {
        /// <summary>
        /// BFS
        /// 暴力枚举
        /// 
        /// 逻辑没问题，MLE，参考测试用例03
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="online"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindMaxPathScore(int[][] edges, bool[] online, long k)
        {
            int n = online.Length;
            List<(int, int)>[] graph = new List<(int, int)>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) if (online[edge[0]] && online[edge[1]]) graph[edge[0]].Add((edge[1], edge[2]));

            int result = -1;
            // 题目限定 n >= 2 且 无环
            Queue<(int, long, int)> queue = new Queue<(int, long, int)>();  // node, weights, min weight
            queue.Enqueue((0, 0, int.MaxValue));
            int node; long weights; int minw;
            while (queue.Count > 0)
            {
                (node, weights, minw) = queue.Dequeue();
                if (node == n - 1) { result = Math.Max(result, minw); continue; }
                foreach ((int next, int w) in graph[node]) if (weights + w <= k) queue.Enqueue((next, weights + w, Math.Min(minw, w)));
            }

            return result;
        }
    }
}
