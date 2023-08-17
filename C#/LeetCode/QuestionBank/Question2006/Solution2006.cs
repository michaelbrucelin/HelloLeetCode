using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2006
{
    public class Solution2006 : Interface2006
    {
        /// <summary>
        /// 暴力模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountKDifference(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k) result++;
                }

            return result;
        }
    }
}
