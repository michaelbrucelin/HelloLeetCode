using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1584
{
    public class Solution1584_2 : Interface1584
    {
        /// <summary>
        /// Kruskal
        /// 这里是稠密图，不适合用Kruskal算法，写写玩玩而已
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinCostConnectPoints(int[][] points)
        {
            if (points.Length < 2) return 0;
            if (points.Length == 2) return Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][1] - points[0][1]);

            int n = points.Length;
            PriorityQueue<(int, int, int), int> minpq = new PriorityQueue<(int, int, int), int>();
            // 可以将全部的项放入列表，然后让堆一次性构建，而不是逐个Enqueue()，这样更快，这里就不写了
            for (int i = 0, d; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    d = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                    minpq.Enqueue((i, j, d), d);
                }

            int result = 0, cnt = 0;
            bool[] visited = new bool[n];
            Disjoint disjoint = new Disjoint(n);
            int v1, v2, dist;
            while (cnt < n - 1)
            {
                (v1, v2, dist) = minpq.Dequeue();
                if (!disjoint.union(v1, v2)) continue;
                result += dist; cnt++;
                visited[v1] = visited[v2] = true;
            }

            return result;
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                uf = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) uf[i] = i;
            }

            private int[] uf, rank;

            private int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }

            public bool union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return false;
                switch (rank[x] - rank[y])
                {
                    case < 0: uf[x] = y; break;
                    case > 0: uf[y] = x; break;
                    default: uf[y] = x; rank[x]++; break;
                }

                return true;
            }
        }
    }
}
