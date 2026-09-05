using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0452
{
    public class Solution0452 : Interface0452
    {
        /// <summary>
        /// 排序 + 贪心
        /// 干掉第一个气球，顺便看看还能干掉几个气球
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int FindMinArrowShots(int[][] points)
        {
            // Array.Sort(points, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);  // 溢出
            Array.Sort(points, (x, y) => x[0] != y[0] ? x[0].CompareTo(y[0]) : x[1].CompareTo(y[1]));
            int result = 0, id = -1, left, right, len = points.Length;
            while (++id < len)
            {
                result++;
                left = points[id][0]; right = points[id][1];
                while (id + 1 < len && points[id + 1][0] <= right)
                {
                    right = Math.Min(right, points[++id][1]);
                }
            }

            return result;
        }
    }
}
