using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3232
{
    public class Solution3232 : Interface3232
    {
        /// <summary>
        /// 遍历
        /// 题目限定只有1位数和2位数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanAliceWin(int[] nums)
        {
            int sum1 = 0, sum2 = 0;
            foreach (int num in nums) if (num < 10) sum1 += num; else sum2 += num;

            return sum1 != sum2;
        }
    }
}
