using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0210
{
    public class Solution0210_2 : Interface0210
    {
        /// <summary>
        /// 拓扑排序，DFS
        /// 
        /// 错误的，错误发生在判断环上面，例如:[[1,0],[2,0],[3,1],[3,2]]
        /// 0 --> 1 --> 3
        /// |          /\
        /// | --> 2 --- |
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();
            foreach (var arr in prerequisites) graph[arr[1]].Add(arr[0]);
            int[] visited = new int[numCourses];

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] != 0) continue;
                if (dfs(graph, visited, i, stack)) return new int[] { };
            }

            int[] result = new int[numCourses];
            for (int i = 0; i < numCourses; i++) result[i] = stack.Pop();
            return result;
        }

        private bool dfs(List<int>[] graph, int[] visited, int vid, Stack<int> stack)
        {
            if (visited[vid] == 1) return true; visited[vid] = 1;

            foreach (int _vid in graph[vid])
                if (dfs(graph, visited, _vid, stack)) return true;
            stack.Push(vid);

            return false;
        }
    }
}
