using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1482
{
    public class Solution1482 : Interface1482
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="bloomDay"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinDays(int[] bloomDay, int m, int k)
        {
            int len = bloomDay.Length;
            if (1L * m * k > len) return -1;

            int max = bloomDay[0];
            for (int i = 0; i < len; i++) max = Math.Max(max, bloomDay[i]);
            if (1L * m * k == len) return max;
            int result = max, lo = 1, hi = max, mid, cnt;
            while (lo <= hi)
            {
                mid = lo + ((hi - lo) >> 1); cnt = 0;
                for (int i = 0, _cnt = 0; i < len; i++)
                {
                    if (bloomDay[i] <= mid)
                    {
                        if (++_cnt == k) { cnt++; _cnt = 0; }
                        if (cnt == m) break;
                    }
                    else
                    {
                        _cnt = 0;
                    }
                }
                if (cnt == m) { result = mid; hi = mid - 1; } else lo = mid + 1;
            }

            return result;
        }
    }
}
