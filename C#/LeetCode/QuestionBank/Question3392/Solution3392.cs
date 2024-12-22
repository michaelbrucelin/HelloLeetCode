using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3392
{
    public class Solution3392 : Interface3392
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountSubarrays(int[] nums)
        {
            int result = 0;
            for (int i = 2; i < nums.Length; i++) if (((nums[i - 2] + nums[i]) << 1) == nums[i - 1]) result++;

            return result;
        }
    }
}
