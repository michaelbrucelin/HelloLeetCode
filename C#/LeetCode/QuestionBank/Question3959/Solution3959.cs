using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3959
{
    public class Solution3959 : Interface3959
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CheckGoodInteger(int n)
        {
            int squareSum = 0, digitSum = 0, d;
            while (n > 0)
            {
                d = n % 10;
                squareSum += d * d;
                digitSum += d;
                n /= 10;
            }

            return squareSum - digitSum >= 50;
        }
    }
}
