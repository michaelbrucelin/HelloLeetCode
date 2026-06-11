using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3558
{
    public class Solution3558_3 : Interface3558
    {
        /// <summary>
        /// 组合数学
        /// 逻辑与Solution3558_2完全一样，使用快速幂的方式优化速度
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int AssignEdgeWeights(int[][] edges)
        {
            int n = edges.Length + 1;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (int[] e in edges) { graph[e[0] - 1].Add(e[1] - 1); graph[e[1] - 1].Add(e[0] - 1); }

            int cnt = -1;                         // 根到最深叶子节点间的边的数量
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                cnt++;
                for (int i = queue.Count, j; i > 0; i--)
                {
                    j = queue.Dequeue();
                    visited[j] = true;
                    foreach (int next in graph[j]) if (!visited[next]) queue.Enqueue(next);
                }
            }

            long result = 1, pow = 2; cnt--;
            const int MOD = (int)1e9 + 7;
            while (cnt > 0)
            {
                if ((cnt & 1) != 0) result = result * pow % MOD;
                pow = pow * pow % MOD;
                cnt >>= 1;
            }

            return (int)result;
        }
    }
}
