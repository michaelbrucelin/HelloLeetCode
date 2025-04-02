using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Solution2873_4 : Interface2873
    {
        /// <summary>
        /// 枚举 nums[i] - nums[j]
        /// 枚举 nums[i] - nums[j]，预处理出 nums[k]，即 nums[(j+1)..] 的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            int len = nums.Length;
            long[] max = new long[len];
            max[^1] = nums[^1];
            for (int i = len - 2; i >= 0; i--) max[i] = Math.Max(max[i + 1], nums[i]);

            long result = 0;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++)
                {
                    result = Math.Max(result, (nums[i] - nums[j]) * max[j + 1]);
                }

            return result;
        }
    }
}
