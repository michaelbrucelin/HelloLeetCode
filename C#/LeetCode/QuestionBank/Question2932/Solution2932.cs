using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2932
{
    public class Solution2932 : Interface2932
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumStrongPairXor(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= Math.Min(nums[i], nums[j]))
                        result = Math.Max(result, nums[i] ^ nums[j]);
                }

            return result;
        }
    }
}
