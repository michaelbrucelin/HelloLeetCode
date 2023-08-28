using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0509
{
    public class Solution0509 : Interface0509
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n < 2) return n;
            return Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib2(int n)
        {
            if (n < 2) return n;
            int last2, last1 = 0, curr = 1;
            for (int i = 0; i < n - 1; i++)
            {
                last2 = last1; last1 = curr; curr = last2 + last1;
            }

            return curr;
        }
    }
}
