using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0106
{
    public class Solution0106 : Interface0106
    {
        /// <summary>
        /// BFS
        /// 1. 顶点0属于集合A，与顶点0相邻的顶点属于集合B
        /// 2. 继续找与顶点0相邻顶点的相邻顶点，有冲突返回false
        /// 3. 最后返回true
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {
            int len = graph.Length;
            int[] group = new int[len];  // 0表示未分组,1表示第1组,2表示第2组
            Queue<int> queue = new Queue<int>();
            for (int node = 0; node < len; node++) if (group[node] == 0)
                {
                    group[node] = 1;
                    queue.Enqueue(node);
                    while (queue.Count > 0) for (int i = queue.Count, x; i > 0; i--)
                        {
                            x = queue.Dequeue();
                            foreach (int y in graph[x])
                            {
                                if (group[y] == group[x]) return false;
                                if (group[y] + group[x] == 3) continue;
                                group[y] = 3 - group[x]; queue.Enqueue(y);  // if (group[y] == 0)
                            }
                        }
                }

            return true;
        }
    }
}
