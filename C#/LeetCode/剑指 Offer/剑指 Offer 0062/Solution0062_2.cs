using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0062
{
    public class Solution0062_2 : Interface0062
    {
        /// <summary>
        /// 约瑟夫环，迭代
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining(int n, int m)
        {
            int result = 0;
            for (int i = 1; i < n; i++) result = (result + m) % (i + 1);

            return result;
        }

        /// <summary>
        /// 约瑟夫环，递归
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining2(int n, int m)
        {
            if (n == 1) return 0;

            return (LastRemaining(n - 1, m) + m) % n;
        }
    }
}
