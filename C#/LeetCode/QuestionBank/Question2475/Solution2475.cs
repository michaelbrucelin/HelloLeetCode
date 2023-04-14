using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2475
{
    public class Solution2475 : Interface2475
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UnequalTriplets(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++) for (int k = j + 1; k < len; k++)
                        if (nums[i] != nums[j] && nums[j] != nums[k] && nums[k] != nums[i]) result++;

            return result;
        }

        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UnequalTriplets2(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++)
                {
                    if (nums[j] == nums[i]) continue;
                    for (int k = j + 1; k < len; k++)
                        if (nums[j] != nums[k] && nums[k] != nums[i]) result++;
                }
            return result;
        }
    }
}
