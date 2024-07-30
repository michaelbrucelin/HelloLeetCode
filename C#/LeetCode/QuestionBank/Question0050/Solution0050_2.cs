using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0050
{
    public class Solution0050_2 : Interface0050
    {
        /// <summary>
        /// 快速幂
        /// 借助二进制实现快速幂
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (x == 0 || x == 1) return x;
            if (x == -1) return ((n & 1) == 0) ? 1 : -1;
            if (n == 0) return 1;

            bool sign = true, minst = false;
            if (n < 0)
            {
                sign = false;
                if (n == int.MinValue)
                {
                    n = int.MaxValue; minst = true;
                }
                else
                {
                    n = -n;
                }
            }

            double result = 1, pow = x;
            while (n > 0)
            {
                if ((n & 1) != 0) result *= pow;
                pow *= pow;
                n >>= 1;
            }

            if (minst) result *= x;
            return sign ? result : 1 / result;
        }
    }
}
