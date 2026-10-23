using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4057
{
    public class Solution4057 : Interface4057
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public long CountIntersectingIntervals(int[][] intervals)
        {
            long result = 0; int len = intervals.Length;
            Array.Sort(intervals, (x, y) => x[0] - y[0]);
            for (int i = 0; i + 1 < len; i++) if (intervals[i + 1][0] <= intervals[i][1])
                {
                    result += binary_search(intervals, i + 1, len - 1, intervals[i][1]) - i;
                }

            return result;

            static int binary_search(int[][] intervals, int lo, int hi, int target)
            {
                int last = -1, mid;
                while (lo <= hi)
                {
                    mid = lo + ((hi - lo) >> 1);
                    if (intervals[mid][0] <= target) { last = mid; lo = mid + 1; } else hi = mid - 1;
                }
                if (last == -1) return 0;

                return last;
            }
        }
    }
}
