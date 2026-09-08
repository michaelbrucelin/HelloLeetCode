using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0436
{
    public class Solution0436 : Interface0436
    {
        /// <summary>
        /// 排序 + 二分
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[] FindRightInterval(int[][] intervals)
        {
            int len = intervals.Length;
            int[] idxs = new int[len];
            for (int i = 0; i < len; i++) idxs[i] = i;
            Array.Sort(idxs, (x, y) => intervals[x][0] - intervals[y][0]);

            int[] result = new int[len];
            Array.Fill(result, -1);
            for (int i = 0, end, lo, hi, mid; i < len; i++)
            {
                if (intervals[i][0] == intervals[i][1]) { result[i] = i; continue; }
                end = intervals[i][1];
                lo = 0; hi = len - 1;
                while (lo <= hi)
                {
                    mid = lo + ((hi - lo) >> 1);
                    if (intervals[idxs[mid]][0] >= end)
                    {
                        result[i] = idxs[mid]; hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
            }
            return result;
        }
    }
}
