using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0132
{
    public class Solution0132_2 : Interface0132
    {
        /// <summary>
        /// 快速幂
        /// 逻辑同Solution0132，这是用快速幂写一下
        /// </summary>
        /// <param name="bamboo_len"></param>
        /// <returns></returns>
        public int CuttingBamboo(int bamboo_len)
        {
            if (bamboo_len < 5) return 1 << (bamboo_len - 2);

            long result = 1;
            int pow = 1, offset = 1;
            const int MOD = (int)1e9 + 7;
            switch (bamboo_len % 3)
            {
                case 0: pow = bamboo_len / 3; offset = 0; break;
                case 1: pow = bamboo_len / 3 - 1; offset = 2; break;
                case 2: pow = bamboo_len / 3; offset = 1; break;
            }
            result = (quickpow(3, pow) << offset) % MOD;

            return (int)result;

            long quickpow(int x, int y)
            {
                long result = (y & 1) == 1 ? x : 1, unit = x;
                y >>= 1;
                while (y > 0)
                {
                    unit = unit * unit % MOD;
                    if ((y & 1) == 1) result = result * unit % MOD;
                    y >>= 1;
                }

                return (int)result;
            }
        }
    }
}
