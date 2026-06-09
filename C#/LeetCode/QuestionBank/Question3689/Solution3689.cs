using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3689
{
    public class Solution3689 : Interface3689
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxTotalValue(int[] nums, int k)
        {
            int min = nums[0], max = nums[0];
            for (int i = 1, len = nums.Length; i < len; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            return 1L * (max - min) * k;
        }
    }
}
