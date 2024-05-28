using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3158
{
    public class Solution3158 : Interface3158
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DuplicateNumbersXOR(int[] nums)
        {
            int result = 0;
            bool[] has = new bool[51];  // 题目限定nums [1, 50]
            foreach (int num in nums)
                if (has[num]) result ^= num; else has[num] = true;

            return result;
        }
    }
}
