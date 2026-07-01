using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1288
{
    public class Solution1288 : Interface1288
    {
        /// <summary>
        /// 排序 + 两层循环
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            if (intervals.Length == 1) return 1;

            int result = intervals.Length, len = intervals.Length;
            Array.Sort(intervals, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            for (int i = 1; i < len; i++) for (int j = 0; j < i; j++)
                {
                    if (intervals[j][0] <= intervals[i][0] && intervals[j][1] >= intervals[i][1])
                    {
                        result--; break;
                    }
                }

            return result;
        }

        /// <summary>
        /// 核心逻辑同RemoveCoveredIntervals()，优化
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int RemoveCoveredIntervals2(int[][] intervals)
        {
            if (intervals.Length == 1) return 1;

            int result = intervals.Length, len = intervals.Length;
            Array.Sort(intervals, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            for (int i = 1, rmax = int.MinValue; i < len; i++)
            {
                rmax = Math.Max(rmax, intervals[i - 1][1]);
                if (intervals[i][1] <= rmax) result--;
            }

            return result;
        }
    }
}
