using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0973
{
    public class Solution0973_2 : Interface0973
    {
        /// <summary>
        /// 快速选择
        /// </summary>
        /// <param name="points"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int k)
        {
            if (points.Length == k) return points;

            int len = points.Length;
            int[] dist = new int[len];
            for (int i = 0; i < len; i++) dist[i] = points[i][0] * points[i][0] + points[i][1] * points[i][1];

            int p, lo = 0, hi = len - 1;
            while ((p = partition(lo, hi)) != k) if (p < k) lo = p + 1; else hi = p - 1;

            return points[..k];

            int partition(int lo, int hi)
            {
                int v = dist[lo], i = lo, j = hi + 1;
                while (true)
                {
                    while (dist[++i] < v) if (i == hi) break;
                    while (dist[--j] > v) ;
                    if (i >= j) break;
                    (points[i], points[j]) = (points[j], points[i]);
                    (dist[i], dist[j]) = (dist[j], dist[i]);
                }
                (points[lo], points[j]) = (points[j], points[lo]);
                (dist[lo], dist[j]) = (dist[j], dist[lo]);

                return j;
            }
        }
    }
}
