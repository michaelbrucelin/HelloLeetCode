using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2101
{
    public class Solution2101 : Interface2101
    {
        /// <summary>
        /// 有向图，BFS求最大连通分量
        /// </summary>
        /// <param name="bombs"></param>
        /// <returns></returns>
        public int MaximumDetonation(int[][] bombs)
        {
            int n = bombs.Length;
            bool[,] graph = new bool[n, n];
            long dist;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    dist = 1L * (bombs[i][0] - bombs[j][0]) * (bombs[i][0] - bombs[j][0])
                         + 1L * (bombs[i][1] - bombs[j][1]) * (bombs[i][1] - bombs[j][1]);
                    if (dist <= 1L * bombs[i][2] * bombs[i][2]) graph[i, j] = true;
                    if (dist <= 1L * bombs[j][2] * bombs[j][2]) graph[j, i] = true;
                }

            int result = 1, _result, vex;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                _result = 0;
                Array.Fill(visited, false);
                queue.Enqueue(i);
                while (queue.Count > 0)
                {
                    if (!visited[vex = queue.Dequeue()])
                    {
                        _result++;
                        visited[vex] = true;
                        for (int j = 0; j < n; j++) if (graph[vex, j]) queue.Enqueue(j);
                    }
                }

                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
