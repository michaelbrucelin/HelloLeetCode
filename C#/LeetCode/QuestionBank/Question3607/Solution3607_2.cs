using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3607
{
    public class Solution3607_2 : Interface3607
    {
        /// <summary>
        /// 堆 + Hash + 并查集
        /// 逻辑与Solution3607完全一样，只是改为借助并查集来查找每一个连通量
        /// </summary>
        /// <param name="c"></param>
        /// <param name="connections"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            int[] uf = new int[c + 1], uf_h = new int[c + 1];
            for (int i = 1; i <= c; i++) uf[i] = i;
            foreach (int[] conn in connections) union(conn[0], conn[1]);
            Dictionary<int, PriorityQueue<int, int>> minpqs = new Dictionary<int, PriorityQueue<int, int>>();
            for (int i = 1, key; i <= c; i++)
            {
                key = find(i);
                if (minpqs.TryGetValue(key, out var _minpq)) _minpq.Enqueue(i, i);
                else { minpqs.Add(key, new PriorityQueue<int, int>()); minpqs[key].Enqueue(i, i); }
            }

            List<int> result = [];
            PriorityQueue<int, int> minpq;
            bool[] mask = new bool[c + 1];
            Array.Fill(mask, true);
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
                        minpq = minpqs[find(query[1])];
                        while (minpq.Count > 0 && !mask[minpq.Peek()]) minpq.Dequeue();
                        result.Add(minpq.Count > 0 ? minpq.Peek() : -1);
                    }
                }
            }

            return [.. result];

            void union(int x, int y)
            {
                x = find(x);
                y = find(y);
                if (x == y) return;
                if (uf_h[x] <= uf_h[y])
                {
                    uf_h[y]++; uf[x] = y;
                }
                else
                {
                    uf_h[x]++; uf[y] = x;
                }
            }

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }
        }
    }
}
