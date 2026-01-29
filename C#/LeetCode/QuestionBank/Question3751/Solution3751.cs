using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3751
{
    public class Solution3751 : Interface3751
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int TotalWaviness(int num1, int num2)
        {
            int result = 0;
            int[] digits = new int[6];  // 题目限定数据 <= 10^5
            for (int i = num1, num, j; i <= num2; i++)
            {
                num = i; j = 0;
                while (num > 0) { digits[j++] = num % 10; num /= 10; }
                while (--j > 1) if ((digits[j - 1] - digits[j - 2]) * (digits[j - 1] - digits[j]) > 0) result++;
            }

            return result;
        }
    }
}
