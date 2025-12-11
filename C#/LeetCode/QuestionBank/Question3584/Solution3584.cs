using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3584
{
    public class Solution3584 : Interface3584
    {
        /// <summary>
        /// 遍历
        /// 遍历到nums[i]时，处理好nums[0..i-m+1]的最大值与最小值即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public long MaximumProduct(int[] nums, int m)
        {
            long result = long.MinValue; int len = nums.Length;
            if (m == 1)
            {
                for (int i = 0; i < len; i++) result = Math.Max(result, 1L * nums[i] * nums[i]);
                return result;
            }

            long min = nums[0], max = nums[0];
            for (int i = m - 1, j = 0; i < len; i++, j++)
            {
                min = Math.Min(min, nums[j]);
                max = Math.Max(max, nums[j]);
                result = Math.Max(result, Math.Max(1L * nums[i] * min, 1L * nums[i] * max));
            }

            return result;
        }
    }
}
