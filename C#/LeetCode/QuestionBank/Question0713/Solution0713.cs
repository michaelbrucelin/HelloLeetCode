using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0713
{
    public class Solution0713 : Interface0713
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k < 2 || nums.Length == 0) return 0;

            int result = 0, p1 = 0, p2 = -1, prod = 1, len = nums.Length;
            while (p1 < len)
            {
                if (nums[p1] >= k) { p2 = p1++; prod = 1; continue; }
                while (p2 + 1 < len && prod * nums[p2 + 1] < k) prod *= nums[++p2];
                result += p2 - p1 + 1;
                prod /= nums[p1++];
            }

            return result;
        }
    }
}
