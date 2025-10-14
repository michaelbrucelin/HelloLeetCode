using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3100
{
    public class Solution3100 : Interface3100
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int MaxBottlesDrunk(int numBottles, int numExchange)
        {
            int result = 0, numEmpty = 0;
            while (numBottles > 0 || numEmpty >= numExchange)
            {
                while (numEmpty >= numExchange)  // 换
                {
                    numBottles++; numEmpty -= numExchange; numExchange++;
                }
                result += numBottles;            // 喝
                numEmpty += numBottles;
                numBottles = 0;
            }

            return result;
        }
    }
}
