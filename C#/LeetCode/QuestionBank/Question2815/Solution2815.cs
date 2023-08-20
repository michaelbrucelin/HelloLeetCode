using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2815
{
    public class Solution2815 : Interface2815
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSum(int[] nums)
        {
            int result = -1, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if (MaxDigit(nums[i]) == MaxDigit(nums[j]))
                        result = Math.Max(result, nums[i] + nums[j]);
                }

            return result;
        }

        private int MaxDigit(int num)
        {
            int digit = 0;
            while (num > 0)
            {
                digit = Math.Max(digit, num % 10); num /= 10;
            }

            return digit;
        }
    }
}
