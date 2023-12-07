using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1466
{
    public class Solution1466_3 : Interface1466
    {
        /// <summary>
        /// BFS
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

            int result = 0, id;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            while (queue.Count > 0)
            {
                id = queue.Dequeue();
                visited[id] = true;
                foreach (var t in graph[id]) if (!visited[t.id])
                    {
                        if (t.isout) result++;
                        queue.Enqueue(t.id);
                    }
            }

            return result;
        }
    }
}
