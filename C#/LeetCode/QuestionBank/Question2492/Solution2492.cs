using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2492
{
    public class Solution2492 : Interface2492
    {
        /// <summary>
        /// DFS
        /// 参考示例02，可以走回头路，再加上题目限定1与n一定连通，所以本质上就是找出含1的连通分量中的最小路径权重
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int MinScore(int n, int[][] roads)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n + 1];
            for (int i = 1; i <= n; i++) graph[i] = [];
            foreach (int[] road in roads)
            {
                graph[road[0]].Add((road[1], road[2])); graph[road[1]].Add((road[0], road[2]));
            }

            int result = int.MaxValue;
            bool[] visited = new bool[n + 1];
            dfs(0, 1, int.MaxValue);
            return result;

            void dfs(int from, int curr, int distance)
            {
                result = Math.Min(result, distance);
                if (visited[curr]) return;
                visited[curr] = true;
                foreach (var next in graph[curr]) dfs(curr, next.Item1, next.Item2);
            }
        }
    }
}
