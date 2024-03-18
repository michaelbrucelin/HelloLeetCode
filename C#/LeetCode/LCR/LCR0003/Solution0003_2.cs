using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0003
{
    public class Solution0003_2 : Interface0003
    {
        /// <summary>
        /// DP
        /// 1. [0, 1]的结果已知
        /// 2. [2, 3]的结果即[0, 1]的结果+1
        /// 3. [4, 8]的结果即[0, 3]的结果+1
        /// 4. ... ...
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            if (n == 0) return new int[] { 0 };
            if (n == 1) return new int[] { 0, 1 };

            int[] result = new int[n + 1]; result[1] = 1;
            int k = 2, _n;
            while (k <= n)
            {
                _n = Math.Min(n, (k << 1) - 1);
                for (int i = k, j = 0; i <= _n; i++, j++) result[i] = result[j] + 1;
                k <<= 1;
            }

            return result;
        }
    }
}
