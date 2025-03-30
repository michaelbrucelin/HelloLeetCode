using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2360
{
    public class Solution2360_2 : Interface2360
    {
        /// <summary>
        /// 遍历
        /// 逻辑同Solution2360，但是不用移除入读为0的节点，直接遍历就可以了
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int LongestCycle(int[] edges)
        {
            int result = -1, n = edges.Length;
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, int> path = new Dictionary<int, int>();
            for (int i = 0, j = -1, id = -1; i < n; i++) if (!visited.Contains(i))
                {
                    j = i; id = 0;
                    path.Clear();
                    while (!visited.Contains(j))
                    {
                        visited.Add(j);
                        path.Add(j, id++);
                        if ((j = edges[j]) == -1) break;
                    }

                    if (path.ContainsKey(j)) result = Math.Max(result, id - path[j]);
                }

            return result;
        }

        /// <summary>
        /// 逻辑同LongestCycle()，将Hash换成数组
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int LongestCycle2(int[] edges)
        {
            int result = -1, n = edges.Length;
            bool[] visited = new bool[n];
            Dictionary<int, int> path = new Dictionary<int, int>();
            for (int i = 0, j = -1, id = -1; i < n; i++) if (!visited[i])
                {
                    j = i; id = 0;
                    path.Clear();
                    while (!visited[j])
                    {
                        visited[j] = true;
                        path.Add(j, id++);
                        if ((j = edges[j]) == -1) break;
                    }

                    if (path.ContainsKey(j)) result = Math.Max(result, id - path[j]);
                }

            return result;
        }
    }
}
