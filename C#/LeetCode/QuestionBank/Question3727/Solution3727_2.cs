using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3727
{
    public class Solution3727_2 : Interface3727
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxAlternatingSum(int[] nums)
        {
            if (nums.Length == 1) return 1L * nums[0] * nums[0];
            if (nums.Length == 2) return Math.Max(1L * nums[0] * nums[0] - 1L * nums[1] * nums[1], 1L * nums[1] * nums[1] - 1L * nums[0] * nums[0]);

            int len = nums.Length;
            long[] _nums = new long[len];
            for (int i = 0; i < len; i++) _nums[i] = 1L * nums[i] * nums[i];

            int p, lo = 0, hi = len - 1, boundary = len >> 1;
            while ((p = partition(lo, hi)) != boundary) if (p < boundary) lo = p + 1; else hi = p - 1;

            long result = 0;
            for (int i = 0; i < boundary; i++) result -= _nums[i];
            for (int i = boundary; i < len; i++) result += _nums[i];

            return result;

            int partition(int lo, int hi)
            {
                long v = _nums[lo], t; int i = lo, j = hi + 1;
                while (true)
                {
                    while (_nums[++i] < v) if (i == hi) break;
                    while (_nums[--j] > v) if (j == lo) break;
                    if (i >= j) break;
                    t = _nums[i]; _nums[i] = _nums[j]; _nums[j] = t;
                }
                _nums[lo] = _nums[j]; _nums[j] = v;

                return j;
            }
        }
    }
}
