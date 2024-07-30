using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0050
{
    public class Solution0050 : Interface0050
    {
        /// <summary>
        /// 快速幂
        /// 借助分治 + 递归实现快速幂
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
            double result = _MyPow(x, n);
            if (minst) result *= x;

            return sign ? result : 1 / result;

            double _MyPow(double x, int n)
            {
                if (n == 1) return x;
                double half = _MyPow(x, n >> 1);
                return (n & 1) == 0 ? half * half : half * half * x;
            }
        }
    }
}
