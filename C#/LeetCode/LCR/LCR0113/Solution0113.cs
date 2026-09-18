using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0113
{
    public class Solution0113 : Interface0113
    {
        /// <summary>
        /// 拓扑排序
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int n = numCourses;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();  // List<int>[0] 是入度，从第二个元素开始是下一个顶点
            for (int i = 0; i < n; i++) graph.Add(i, [0]);
            foreach (int[] r in prerequisites) { graph[r[0]][0]++; graph[r[1]].Add(r[0]); }

            int[] result = new int[n];
            int id = 0; bool flag = true;
            while (flag && graph.Count > 0)
            {
                flag = false;
                foreach (int x in graph.Keys) if (graph[x][0] == 0)
                    {
                        flag = true;
                        result[id++] = x;
                        for (int i = graph[x].Count - 1; i > 0; i--) graph[graph[x][i]][0]--;
                        graph.Remove(x);
                    }
            }
            if (graph.Count > 0) return [];

            return result;
        }
    }
}
