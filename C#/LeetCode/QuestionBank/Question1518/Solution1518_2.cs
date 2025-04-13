using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1518
{
    public class Solution1518_2 : Interface1518
    {
        /// <summary>
        /// 数学
        /// 具体解释见Solution1518_2.md
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            if (numBottles < numExchange) return numBottles;

            return numBottles + (numBottles - numExchange) / (numExchange - 1) + 1;
        }

        public int NumWaterBottles2(int numBottles, int numExchange)
        {
            if (numBottles % (numExchange - 1) > 0)
                return numBottles + numBottles / (numExchange - 1);
            else
                return numBottles + numBottles / (numExchange - 1) - 1;
        }
    }
}
