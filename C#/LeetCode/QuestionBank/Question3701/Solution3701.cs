using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3701
{
    public class Solution3701 : Interface3701
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int AlternatingSum(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, k = 1; i < len; i++, k *= -1) result += nums[i] * k;

            return result;
        }
    }
}
