using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3169
{
    public class Solution3169 : Interface3169
    {
        /// <summary>
        /// 排序
        /// 排序后逐个分析每个会议的时间段即可
        /// 
        /// 注意这里不能使用差分数组，因为days的范围达到了10^9，会TLE+OLE
        /// 差分数组可以像线段树那样使用动态区间更新？
        /// </summary>
        /// <param name="days"></param>
        /// <param name="meetings"></param>
        /// <returns></returns>
        public int CountDays(int days, int[][] meetings)
        {
            if (meetings.Length == 1) return days + meetings[0][0] - meetings[0][1] - 1;

            Array.Sort(meetings, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            int result = days, left, right = 0;
            foreach (int[] meet in meetings)
            {
                if (meet[1] <= right) continue;
                left = meet[0] > right ? meet[0] : right + 1;
                result -= meet[1] - left + 1;
                right = meet[1];
            }

            return result;
        }
    }
}
