using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCP0001
{
    public class Solution0001 : Interface0001
    {
        /// <summary>
        /// 除法转减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Divide(int a, int b)
        {
            // if (b == 0) throw new Exception("the divisor is equal to 0.");  // 题目保证了b != 0
            if (a == 0) return 0;
            if (a == int.MinValue && b == -1) return int.MaxValue;
            if (b == 1) return a; else if (b == -1) return -a;

            int flag = 1;
            if (a > 0) { a = -a; flag *= -1; }
            if (b > 0) { b = -b; flag *= -1; }

            int result = 0;
            while (a <= b) { result++; a -= b; }

            return result * flag;
        }
    }
}
