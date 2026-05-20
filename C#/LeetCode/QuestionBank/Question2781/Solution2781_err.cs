using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2781
{
    public class Solution2781_err : Interface2781
    {
        /// <summary>
        /// 贪心
        /// 1. 最小值一定是整个数组的AND值
        /// 2. 从前向后遍历，找出每一段AND值等于最小值的段即可，如果最后一段大于最小值，合并到前一段中即可
        /// 
        /// 审错题了，题目要求和更小，而不是每一项更小，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubarrays(int[] nums)
        {
            int min = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) min &= nums[i];
            if (min == int.MaxValue) return 1;

            int result = 0;
            for (int i = 0, _min = int.MaxValue; i < len; i++) if ((_min &= nums[i]) == min)
                {
                    result++; _min = int.MaxValue;
                }

            return result;
        }
    }
}
