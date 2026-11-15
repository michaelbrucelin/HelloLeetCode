using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4111
{
    public class Solution4111 : Interface4111
    {
        /// <summary>
        /// 模拟
        /// 简单题简单做
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountConsistent(int[] nums)
        {
            int result = 0, min, and, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = i; j < len; j++)
                {
                    min = and = nums[i];
                    for (int k = i + 1; k <= j; k++) { min = Math.Min(min, nums[k]); and &= nums[k]; }
                    if (min == and) result++;
                }

            return result;
        }
    }
}
