using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0126
{
    public class Solution0126 : Interface0126
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n < 2) return n;

            const int MOD = (int)1e9 + 7;
            int F0, F1 = 0, F2 = 1;
            for (int i = 2; i <= n; i++)
            {
                F0 = F1;
                F1 = F2;
                F2 = (F0 + F1) % MOD;
            }

            return F2;
        }

        /// <summary>
        /// 与Fib()完全一样，只是将值替换改为元组进行批处理
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib2(int n)
        {
            if (n < 2) return n;

            const int MOD = (int)1e9 + 7;
            int F1 = 0, F2 = 1;
            for (int i = 2; i <= n; i++)
            {
                (F1, F2) = (F2, (F1 + F2) % MOD);
            }

            return F2;
        }
    }
}
