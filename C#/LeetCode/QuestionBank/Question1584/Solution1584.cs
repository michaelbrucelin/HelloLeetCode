using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1584
{
    public class Solution1584 : Interface1584
    {
        /// <summary>
        /// Prim
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinCostConnectPoints(int[][] points)
        {
            if (points.Length < 2) return 0;
            if (points.Length == 2) return Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][1] - points[0][1]);

            int result = 0, cnt = 1, n = points.Length;
            bool[] visited = new bool[n];
            visited[0] = true;
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();
            for (int i = 1, d; i < n; i++)
            {
                d = Math.Abs(points[i][0] - points[0][0]) + Math.Abs(points[i][1] - points[0][1]);
                minpq.Enqueue((i, d), d);
            }

            int next, dist;
            while (cnt < n)
            {
                (next, dist) = minpq.Dequeue();
                if (visited[next]) continue; visited[next] = true;
                result += dist;
                if (++cnt == n) break;
                for (int i = 1; i < n; i++) if (!visited[i])  // i = 1 是起点
                    {
                        dist = Math.Abs(points[i][0] - points[next][0]) + Math.Abs(points[i][1] - points[next][1]);
                        minpq.Enqueue((i, dist), dist);
                    }
            }

            return result;
        }
    }
}
