using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0207
{
    public class Solution0207 : Interface0207
    {
        /// <summary>
        /// 暴力枚举
        /// 遍历每一个顶点，每个顶点都BFS找前置顶点，看看能不能找到自身
        /// 
        /// 提交竟然过了，没有TLE
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            foreach (var arr in prerequisites)
            {
                if (graph.ContainsKey(arr[1]) && graph[arr[1]].Contains(arr[0])) return false;
                if (graph.ContainsKey(arr[0])) graph[arr[0]].Add(arr[1]); else graph.Add(arr[0], new HashSet<int>() { arr[1] });
            }

            for (int i = 0; i < numCourses; i++)
                if (HasCircle(graph, i)) return false;

            return true;
        }

        private bool HasCircle(Dictionary<int, HashSet<int>> graph, int start)
        {
            HashSet<int> visited = new HashSet<int>() { start };
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            int vertex; while (queue.Count > 0)
            {
                vertex = queue.Dequeue();
                if (graph.ContainsKey(vertex)) foreach (int next in graph[vertex])
                    {
                        if (next == start) return true;
                        if (!visited.Contains(next))
                        {
                            queue.Enqueue(next); visited.Add(next);
                        }
                    }
            }

            return false;
        }
    }
}
