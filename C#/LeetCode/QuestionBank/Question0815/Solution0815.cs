using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0815
{
    public class Solution0815 : Interface0815
    {
        /// <summary>
        /// BFS
        /// 队列中记录线路，而不是站点
        /// 提前预处理出每个站点都有哪些线路途经
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target) return 0;

            List<HashSet<int>> r2s = new List<HashSet<int>>();
            Dictionary<int, List<int>> s2r = new Dictionary<int, List<int>>();
            int max = -1;  // 题目没有保证站点是连续的，担心站点是离散的
            for (int i = 0; i < routes.Length; i++)
            {
                r2s.Add(new HashSet<int>(routes[i]));
                for (int j = 0; j < routes[i].Length; j++)
                {
                    max = Math.Max(max, routes[i][j]);
                    s2r.TryAdd(routes[i][j], new List<int>()); s2r[routes[i][j]].Add(i);
                }
            }
            max++;
            bool[] visited_r = new bool[routes.Length];
            bool[] visited_s = new bool[max];

            int result = 1, cnt;
            Queue<int> queue = new Queue<int>();
            if (!s2r.ContainsKey(source)) return -1;    // 坑
            foreach (int i in s2r[source])
            {
                queue.Enqueue(i); visited_r[i] = true;
            }
            visited_s[source] = true;
            int line;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    line = queue.Dequeue();
                    if (r2s[line].Contains(target)) return result;
                    foreach (int s in r2s[line]) if (!visited_s[s])
                        {
                            visited_s[s] = true;
                            foreach (int r in s2r[s]) if (!visited_r[r])
                                {
                                    queue.Enqueue(r); visited_r[r] = true;
                                }
                        }
                }
                result++;
            }

            return -1;
        }
    }
}
