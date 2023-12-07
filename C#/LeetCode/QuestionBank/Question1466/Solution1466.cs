using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1466
{
    public class Solution1466 : Interface1466
    {
        /// <summary>
        /// DFS
        /// 1. 题目要求返回需要变更方向的最小路线数，准确说是返回需要变更方向的路线数，这里没有“最小”这一说
        /// 2. 先把有向图当无向图处理，并记录每条边的方向
        /// 3. 以节点0为根，DFS，每条边都应该“向内”，如果向外，结果+1
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

            int result = 0; bool[] visited = new bool[n];
            dfs(graph, visited, 0, ref result);
            return result;
        }

        private void dfs(List<(int id, bool isout)>[] graph, bool[] visited, int id, ref int result)
        {
            visited[id] = true;
            foreach (var t in graph[id]) if (!visited[t.id])
                {
                    if (t.isout) result++;
                    dfs(graph, visited, t.id, ref result);
                }
        }
    }
}
