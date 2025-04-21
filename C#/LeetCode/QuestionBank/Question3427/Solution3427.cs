using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3427
{
    public class Solution3427 : Interface3427
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];

            int result = 0;
            for (int i = 0, j; i < len; i++)
            {
                j = Math.Max(i - nums[i], 0);
                result += sums[i + 1] - sums[j];
            }

            return result;
        }
    }
}
