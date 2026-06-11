using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3558
{
    public class Solution3558_2 : Interface3558
    {
        /// <summary>
        /// 组合数学
        /// 逻辑与Solution3558完全一样，注意到 C(n,1) + C(n,3) + C(n,5) + ... 有数学解，即 2^{n-1}
        /// 不考虑数学解，换个角度想一下也可以，总共 n 条边，所有方案数即 2^n 个，其中奇数解与偶数解是配对的，所以奇数解的数量为 2^{n-1}
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

            int result = 1;
            const int MOD = (int)1e9 + 7;
            for (int i = 1; i < cnt; i++) result = (result << 1) % MOD;

            return result;
        }
    }
}
