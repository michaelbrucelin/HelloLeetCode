using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2739
{
    public class Solution2739_2 : Interface2739
    {
        /// <summary>
        /// 数学
        /// 本质上就是买饮料，每3个空瓶换1瓶饮料的问题
        /// 先不考虑additionalTank的限制，多枚举几个结果就找到规律了
        /// </summary>
        /// <param name="mainTank"></param>
        /// <param name="additionalTank"></param>
        /// <returns></returns>
        public int DistanceTraveled(int mainTank, int additionalTank)
        {
            int x = (mainTank - 1) >> 2;
            int y = mainTank + (x <= additionalTank ? x : additionalTank);

            return y * 10;
        }
    }
}
