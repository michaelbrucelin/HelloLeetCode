using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3607
{
    public class Solution3607 : Interface3607
    {
        /// <summary>
        /// 堆 + Hash + dfs
        /// 使用dfs查找图的连通量，每一个连通量都用一个小顶堆维护，hash懒删除
        /// </summary>
        /// <param name="c"></param>
        /// <param name="connections"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            // 构建图
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            foreach (int[] conn in connections)
            {
                if (graph.TryGetValue(conn[0], out List<int> list1)) list1.Add(conn[1]); else graph.Add(conn[0], [conn[1]]);
                if (graph.TryGetValue(conn[1], out List<int> list2)) list2.Add(conn[0]); else graph.Add(conn[1], [conn[0]]);
            }

            int[] points = new int[c + 1];
            List<PriorityQueue<int, int>> minpqs = [];
            bool[] mask = new bool[c + 1];
            for (int i = 1; i <= c; i++) if (!mask[i])
                {
                    minpqs.Add(new PriorityQueue<int, int>());
                    dfs(i, minpqs.Count - 1);
                }

            List<int> result = [];
            PriorityQueue<int, int> minpq;
            foreach (int[] query in queries)
            {
                if (query[0] == 2)
                {
                    mask[query[1]] = false;
                }
                else
                {
                    if (mask[query[1]])
                    {
                        result.Add(query[1]);
                    }
                    else
                    {
                        minpq = minpqs[points[query[1]]];
                        while (minpq.Count > 0 && !mask[minpq.Peek()]) minpq.Dequeue();
                        result.Add(minpq.Count > 0 ? minpq.Peek() : -1);
                    }
                }
            }

            return [.. result];

            void dfs(int x, int y)
            {
                points[x] = y;
                minpqs[y].Enqueue(x, x);
                mask[x] = true;
                if (graph.TryGetValue(x, out var list)) foreach (int next in list) if (!mask[next]) dfs(next, y);
            }
        }
    }
}
