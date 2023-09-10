using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0207
{
    public class Solution0207_2 : Interface0207
    {
        /// <summary>
        /// 拓扑排序，BFS
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            (int _in, List<int> adj)[] graph = new (int _in, List<int> adj)[numCourses];
            for (int i = 0; i < numCourses; i++) graph[i] = (0, new List<int>());
            foreach (var arr in prerequisites)
            {
                graph[arr[0]]._in++; graph[arr[1]].adj.Add(arr[0]);
            }
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++) if (graph[i]._in == 0) queue.Enqueue(i);

            List<int> result = new List<int>();
            int vid; while (queue.Count > 0)
            {
                vid = queue.Dequeue();
                result.Add(vid);
                foreach (int _vid in graph[vid].adj)
                {
                    if (--graph[_vid]._in == 0) queue.Enqueue(_vid);
                }
            }

            return result.Count == numCourses;
        }
    }
}
