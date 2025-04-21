using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3423
{
    public class Solution3423 : Interface3423
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxAdjacentDistance(int[] nums)
        {
            int result = Math.Abs(nums[0] - nums[^1]), len = nums.Length;
            for (int i = 1; i < len; i++) result = Math.Max(result, Math.Abs(nums[i] - nums[i - 1]));

            return result;
        }
    }
}
