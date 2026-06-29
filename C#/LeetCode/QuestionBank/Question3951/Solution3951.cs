using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3951
{
    public class Solution3951 : Interface3951
    {
        /// <summary>
        /// 合并区间
        /// 阅读理解题
        /// </summary>
        /// <param name="n"></param>
        /// <param name="brightness"></param>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public long MinEnergy(int n, int brightness, int[][] intervals)
        {
            long result = 0;
            Array.Sort(intervals, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);
            int x = (brightness + 2) / 3, start = intervals[0][0], end = intervals[0][1], len = intervals.Length;
            for (int i = 1; i < len; i++)
            {
                if (intervals[i][0] <= end)
                {
                    end = Math.Max(end, intervals[i][1]);
                }
                else
                {
                    result += 1L * x * (end - start + 1);
                    start = intervals[i][0]; end = intervals[i][1];
                }
            }
            result += 1L * x * (end - start + 1);

            return result;
        }
    }
}
