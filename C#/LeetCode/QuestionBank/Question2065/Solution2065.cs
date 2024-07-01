using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2065
{
    public class Solution2065 : Interface2065
    {
        /// <summary>
        /// DFS + 回溯
        /// 无返回值
        /// </summary>
        /// <param name="values"></param>
        /// <param name="edges"></param>
        /// <param name="maxTime"></param>
        /// <returns></returns>
        public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
        {
            int n = values.Length;
            List<(int next, int time)>[] graph = new List<(int next, int time)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int time)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph[edge[1]].Add((edge[0], edge[2]));
            }

            int result = 0;
            bool[] visited = new bool[n];
            dfs(0, 0, maxTime);

            return result;

            void dfs(int position, int point, int maxTime)
            {
                bool bt = false;
                if (!visited[position])
                {
                    point += values[position]; visited[position] = true; bt = true;
                }
                if (position == 0) result = Math.Max(result, point);
                foreach (var info in graph[position])
                {
                    if (info.time <= maxTime) dfs(info.next, point, maxTime - info.time);
                }

                visited[position] = !bt;  // if (bt) visited[position] = false;
            }
        }
    }
}
