using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Solution2873 : Interface2873
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            long result = 0; int len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++) for (int k = j + 1; k < len; k++)
                    {
                        result = Math.Max(result, ((long)nums[i] - nums[j]) * nums[k]);
                    }

            return result;
        }
    }
}
