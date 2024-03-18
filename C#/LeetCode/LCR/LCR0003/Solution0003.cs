using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0003
{
    public class Solution0003 : Interface0003
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            int[] result = new int[n + 1];
            for (int i = 1; i <= n; i++) result[i] = CountBit(i);

            return result;
        }

        private int CountBit(int n)
        {
            int result = 0;

            while (n > 0)
            {
                n &= n - 1; result++;
            }

            return result;
        }
    }
}
