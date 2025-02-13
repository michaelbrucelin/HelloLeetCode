using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1742
{
    public class Solution1742_4 : Interface1742
    {
        /// <summary>
        /// DP
        /// 数字x的各位数字之和是y，如果x的最后一位不是9，那么x+1的各位数字之和是y+1，如果x的最后一位是9，那么x+1的各位数字之和重新计算
        /// </summary>
        /// <param name="lowLimit"></param>
        /// <param name="highLimit"></param>
        /// <returns></returns>
        public int CountBalls(int lowLimit, int highLimit)
        {
            int[] cnts = new int[46];  // 题目限定最大值是10^5
            int digit_sum = SumDigit(lowLimit - 1);
            for (int i = lowLimit; i <= highLimit; i++)
            {
                digit_sum = i % 10 != 0 ? digit_sum + 1 : SumDigit(i);
                cnts[digit_sum]++;
            }

            int result = 0;
            for (int i = 1; i < 46; i++) result = Math.Max(result, cnts[i]);
            return result;

            int SumDigit(int x)
            {
                int sum = 0;
                for (; x > 0; x /= 10) sum += x % 10;
                return sum;
            }
        }
    }
}
