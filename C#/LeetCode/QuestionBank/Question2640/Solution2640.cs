using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2640
{
    public class Solution2640 : Interface2640
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long[] FindPrefixScore(int[] nums)
        {
            int max = nums[0], len = nums.Length;
            long[] result = new long[len];
            result[0] = nums[0] << 1;
            for (int i = 1; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
                result[i] = result[i - 1] + nums[i] + max;
            }

            return result;
        }
    }
}
