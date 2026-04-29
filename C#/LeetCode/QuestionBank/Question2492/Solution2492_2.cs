using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2492
{
    public class Solution2492_2 : Interface2492
    {
        /// <summary>
        /// BFS
        /// 逻辑同Solution2492，将DFS改为BFS
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
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((0, 1, int.MaxValue));
            int from, curr, distance;
            while (queue.Count > 0)
            {
                (from, curr, distance) = queue.Dequeue();
                result = Math.Min(result, distance);
                if (visited[curr]) continue;
                visited[curr] = true;
                foreach (var next in graph[curr]) queue.Enqueue((curr, next.Item1, next.Item2));
            }

            return result;
        }
    }
}
