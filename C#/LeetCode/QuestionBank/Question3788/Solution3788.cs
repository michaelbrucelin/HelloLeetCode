using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3788
{
    public class Solution3788 : Interface3788
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumScore(int[] nums)
        {
            long sum = 0; int len = nums.Length;
            for (int i = 0; i < len; i++) sum += nums[i];

            long result = long.MinValue; int min = int.MaxValue;
            for (int i = len - 1; i > 0; i--)
            {
                sum -= nums[i]; min = Math.Min(min, nums[i]);
                result = Math.Max(result, sum - min);
            }

            return result;
        }
    }
}
