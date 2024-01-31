using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Solution2873_3 : Interface2873
    {
        /// <summary>
        /// 枚举k
        /// 枚举k的同时需要维护nums[0..(k-1)]中nums[i]-nums[j]的最大值与最小值，维护的过程与“单调栈”或“股票利益最大化”的思路差不多
        /// 
        /// 题目保证没有负数，所以不用考虑两个极小的负数乘积的情况，这里考虑了，就不更改了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            long result = 0;
            int min_i = nums[0], max_i = nums[0], min = nums[0] - nums[1], max = nums[0] - nums[1], len = nums.Length;
            for (int i = 2; i < len; i++)
            {
                max = Math.Max(max, max_i - nums[i - 1]); max_i = Math.Max(max_i, nums[i - 1]);
                min = Math.Min(min, min_i - nums[i - 1]); min_i = Math.Min(min_i, nums[i - 1]);
                result = Math.Max(result, (long)nums[i] * max);
                result = Math.Max(result, (long)nums[i] * min);
            }

            return result;
        }
    }
}
