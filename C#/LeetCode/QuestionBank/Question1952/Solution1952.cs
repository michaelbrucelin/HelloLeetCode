using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1952
{
    public class Solution1952 : Interface1952
    {
        /// <summary>
        /// 数学
        /// 三除数只能是 (1, 自身, 平方根) 这一种可能，或者说，三除数一定是质数的平方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsThree(int n)
        {
            if (n == 1) return false;
            int sqrt = (int)Math.Floor(Math.Sqrt(n));
            if (sqrt * sqrt != n) return false;

            for (int i = 2; i < sqrt; i++)
                if (n % i == 0) return false;

            return true;
        }
    }
}
