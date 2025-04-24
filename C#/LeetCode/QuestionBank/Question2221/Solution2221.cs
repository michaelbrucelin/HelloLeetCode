using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2221
{
    public class Solution2221 : Interface2221
    {
        /// <summary>
        /// 模拟
        /// 原地模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            int len = nums.Length;
            // for (int i = len - 1; i > 0; i--) for (int j = 0; j < i; j++) nums[j] += nums[j + 1];  // 溢出了
            for (int i = len - 1; i > 0; i--) for (int j = 0; j < i; j++) nums[j] = (nums[j] + nums[j + 1]) % 10;

            return nums[0];
        }
    }
}
