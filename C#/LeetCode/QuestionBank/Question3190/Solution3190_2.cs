using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3190
{
    public class Solution3190_2 : Interface3190
    {
        /// <summary>
        /// 位运算
        /// 逻辑同Solution3190，使用位运算加速这个过程
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            int result = 0, mod;
            foreach (int num in nums)
            {
                mod = num % 3;
                result -= (mod | -mod) >> 31;
            }

            return result;
        }
    }
}
