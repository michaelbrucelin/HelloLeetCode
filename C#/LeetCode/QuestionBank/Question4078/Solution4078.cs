using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4078
{
    public class Solution4078 : Interface4078
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool ThreeFibonacciSum(int n)
        {
            if (n == 2) return true;
            long[] fib3 = [0, 1, 1]; long sum = 0;
            while (sum < n)
            {
                (fib3[0], fib3[1], fib3[2]) = (fib3[1], fib3[2], fib3[1] + fib3[2]);
                if ((sum = fib3[0] + fib3[1] + fib3[2]) == n) return true;
                if (sum > n) return false;
            }

            return false;
        }
    }
}
