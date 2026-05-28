using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3558
{
    public class Solution3558 : Interface3558
    {
        /// <summary>
        /// 组合数学
        /// 假设根到最深层有n条边，结果就是 C(n,1) + C(n,3) + C(n,5) + ...
        /// 
        /// 逻辑没问题，TLE，参考测试用例04, 05，主要慢在了BigInteger的运算上
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int AssignEdgeWeights(int[][] edges)
        {
            int n = edges.Length + 1;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (int[] e in edges) { graph[e[0] - 1].Add(e[1] - 1); graph[e[1] - 1].Add(e[0] - 1); }

            int cnt = -1;
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

            // long result = cnt, _result = cnt;
            // Int128 result = cnt, _result = cnt;
            BigInteger result = cnt, _result = cnt;
            const int MOD = (int)1e9 + 7;
            for (int i = 3; i <= cnt; i += 2)
            {
                _result = _result * (cnt - i + 2) * (cnt - i + 1) / (i - 1) / i;
                result = (result + _result) % MOD;
            }

            return (int)result;
        }
    }
}
