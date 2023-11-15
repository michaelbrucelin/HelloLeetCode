using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2656
{
    public class Solution2656 : Interface2656
    {
        /// <summary>
        /// 贪心，数学
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximizeSum(int[] nums, int k)
        {
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++) max = Math.Max(max, nums[i]);

            return (((max << 1) + k - 1) * k) >> 1;
        }
    }
}
