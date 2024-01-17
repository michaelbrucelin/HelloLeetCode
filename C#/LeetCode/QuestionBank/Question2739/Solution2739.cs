using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2739
{
    public class Solution2739 : Interface2739
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="mainTank"></param>
        /// <param name="additionalTank"></param>
        /// <returns></returns>
        public int DistanceTraveled(int mainTank, int additionalTank)
        {
            int result = 0;
            while (mainTank >= 5 && additionalTank > 0)
            {
                result += 50;
                mainTank -= 4;
                additionalTank -= 1;
            }
            result += mainTank * 10;

            return result;
        }

        /// <summary>
        /// 与DistanceTraveled()一样，稍加优化
        /// </summary>
        /// <param name="mainTank"></param>
        /// <param name="additionalTank"></param>
        /// <returns></returns>
        public int DistanceTraveled2(int mainTank, int additionalTank)
        {
            int result = 0;
            while (mainTank >= 5 && additionalTank > 0)
            {
                var info = Math.DivRem(mainTank, 5);
                int x = Math.Min(info.Quotient, additionalTank);
                result += x * 50;
                mainTank -= x << 2;
                additionalTank -= x;
            }
            result += mainTank * 10;

            return result;
        }
    }
}
