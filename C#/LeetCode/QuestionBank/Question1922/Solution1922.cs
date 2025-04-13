using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1922
{
    public class Solution1922 : Interface1922
    {
        /// <summary>
        /// 排列组合 + 快速幂
        /// n是偶数，20^(n/2)，n是奇数，20^(n/2) * 5
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountGoodNumbers(long n)
        {
            const int MOD = (int)1e9 + 7;

            if ((n & 1) == 0)
                return quickpow(20, n >> 1);
            else
                return (int)(quickpow(20, n >> 1) * 5L % MOD);

            int quickpow(int x, long y)
            {
                if (x == 1 || y == 0) return 1;

                long result = (y & 1) != 0 ? x : 1, unit = x;
                y >>= 1;
                while (y > 0)
                {
                    unit *= unit; unit %= MOD;
                    if ((y & 1) != 0) { result *= unit; result %= MOD; }
                    y >>= 1;
                }

                return (int)result;
            }
        }
    }
}
