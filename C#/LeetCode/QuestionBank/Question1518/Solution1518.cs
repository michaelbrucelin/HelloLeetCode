using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1518
{
    public class Solution1518 : Interface1518
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int result = numBottles;
            while (numBottles >= numExchange)
            {
                var info = Math.DivRem(numBottles, numExchange);
                result += info.Quotient;
                numBottles = info.Quotient + info.Remainder;
            }

            return result;
        }

        public int NumWaterBottles2(int numBottles, int numExchange)
        {
            int result = 0, numEmpty = 0;
            while (numBottles > 0 || numEmpty >= numExchange)
            {
                numBottles += numEmpty / numExchange;            // 换
                result += numBottles;                            // 喝
                numEmpty = numEmpty % numExchange + numBottles;
                numBottles = 0;
            }

            return result;
        }
    }
}
