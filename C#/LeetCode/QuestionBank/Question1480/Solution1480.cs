using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1480
{
    public class Solution1480 : Interface1480
    {
        /// <summary>
        /// 非原地
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum(int[] nums)
        {
            int[] result = new int[nums.Length];
            result[0] = nums[0];
            for (int i = 1; i < nums.Length; i++) result[i] = result[i - 1] + nums[i];

            return result;
        }

        /// <summary>
        /// 原地
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum2(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++) nums[i] += nums[i - 1];

            return nums;
        }
    }
}
