using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2485
{
    public class Solution2485_2 : Interface2485
    {
        /// <summary>
        /// 数学
        /// 即求解方程 (1+x)x = (x+n)(n-x+1) 的整数解，化简得到 x^2 = (n^2 + n)/2
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PivotInteger(int n)
        {
            int pow = (n * n + n) >> 1;
            int sqrt = (int)Math.Sqrt(pow);

            return sqrt * sqrt == pow ? sqrt : -1;
        }
    }
}
