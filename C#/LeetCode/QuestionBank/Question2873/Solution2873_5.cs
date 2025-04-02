using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Solution2873_5 : Interface2873
    {
        /// <summary>
        /// 枚举 nums[k]
        /// 枚举 nums[k]，预处理 nums[i] - nums[j]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            int len = nums.Length;
            long[] max = new long[len];
            for (int i = 1, _max = nums[0]; i < len; i++)
            {
                max[i] = Math.Max(max[i - 1], _max - nums[i]);
                _max = Math.Max(_max, nums[i]);
            }

            long result = 0;
            for (int i = 2; i < len; i++) result = Math.Max(result, nums[i] * max[i - 1]);

            return result;
        }
    }
}
