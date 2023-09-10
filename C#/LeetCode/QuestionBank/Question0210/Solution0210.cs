using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0210
{
    public class Solution0210 : Interface0210
    {
        /// <summary>
        /// 拓扑排序，BFS
        /// 类深度优先遍历
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            (int _in, List<int> adj)[] graph = new (int _in, List<int> adj)[numCourses];
            for (int i = 0; i < numCourses; i++) graph[i] = (0, new List<int>());
            foreach (var arr in prerequisites)
            {
                graph[arr[0]]._in++; graph[arr[1]].adj.Add(arr[0]);
            }
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numCourses; i++) if (graph[i]._in == 0) stack.Push(i);

            List<int> result = new List<int>();
            int vid; while (stack.Count > 0)
            {
                vid = stack.Pop();
                result.Add(vid);
                foreach (int _vid in graph[vid].adj)
                {
                    if (--graph[_vid]._in == 0) stack.Push(_vid);
                }
            }

            return result.Count == numCourses ? result.ToArray() : new int[] { };
        }

        /// <summary>
        /// 拓扑排序，BFS
        /// 类广度优先遍历，只是将FindOrder()中的Stack改为了Queue
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder2(int numCourses, int[][] prerequisites)
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

            return result.Count == numCourses ? result.ToArray() : new int[] { };
        }
    }
}
