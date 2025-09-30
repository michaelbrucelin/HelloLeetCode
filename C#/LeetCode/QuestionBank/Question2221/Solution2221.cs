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
            if (nums.Length == 1) return nums[0];

            int len = nums.Length;
            for (int i = len; i > 1; i--) for (int j = 1; j < i; j++) nums[j - 1] = (nums[j - 1] + nums[j]) % 10;

            return nums[0];
        }
    }
}
