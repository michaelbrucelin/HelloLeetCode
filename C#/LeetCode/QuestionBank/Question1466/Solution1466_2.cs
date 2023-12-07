using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1466
{
    public class Solution1466_2 : Interface1466
    {
        /// <summary>
        /// DFS
        /// 与Solution1466逻辑相同，只是DFS部分由指针传递改为返回值
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public int MinReorder(int n, int[][] connections)
        {
            List<(int id, bool isout)>[] graph = new List<(int id, bool isout)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int id, bool isout)>();
            foreach (int[] conn in connections)
            {
                graph[conn[0]].Add((conn[1], true)); graph[conn[1]].Add((conn[0], false));
            }

            bool[] visited = new bool[n];
            return dfs(graph, visited, 0);
        }

        private int dfs(List<(int id, bool isout)>[] graph, bool[] visited, int id)
        {
            int result = 0; visited[id] = true;
            foreach (var t in graph[id]) if (!visited[t.id])
                {
                    if (t.isout) result++;
                    result += dfs(graph, visited, t.id);
                }

            return result;
        }
    }
}
