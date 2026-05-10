using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0009
{
    public class Solution0009 : Interface0009
    {
        /// <summary>
        /// 滑动窗口，双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k < 2) return 0;  // 题目限定nums[i]>=1

            int result = 0, len = nums.Length; long prod = 1;
            for (int p1 = 0, p2 = 0; p2 < len; p2++)
            {
                prod *= nums[p2];
                while (prod >= k) prod /= nums[p1++];
                result += p2 - p1 + 1;
            }

            return result;
        }
    }
}
