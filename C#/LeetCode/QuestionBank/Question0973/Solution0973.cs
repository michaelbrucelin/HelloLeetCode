using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0973
{
    public class Solution0973 : Interface0973
    {
        /// <summary>
        /// 大顶堆
        /// </summary>
        /// <param name="points"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int k)
        {
            if (points.Length == k) return points;

            PriorityQueue<int[], int> maxpq = new PriorityQueue<int[], int>();
            foreach (int[] point in points)
            {
                maxpq.Enqueue(point, -point[0] * point[0] - point[1] * point[1]);
                if (maxpq.Count > k) maxpq.Dequeue();
            }

            int[][] result = new int[k][];
            int idx = 0;
            foreach (var item in maxpq.UnorderedItems) result[idx++] = item.Element;

            return result;
        }
    }
}
