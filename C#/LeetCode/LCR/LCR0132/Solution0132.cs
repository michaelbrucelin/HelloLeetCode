using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0132
{
    public class Solution0132 : Interface0132
    {
        /// <summary>
        /// 数学
        /// 分成若干个3，最多2个2，不能有1
        /// </summary>
        /// <param name="bamboo_len"></param>
        /// <returns></returns>
        public int CuttingBamboo(int bamboo_len)
        {
            if (bamboo_len < 5) return 1 << (bamboo_len - 2);

            long result = 1;
            const int MOD = (int)1e9 + 7;
            while (bamboo_len > 4)
            {
                result = (result * 3) % MOD;
                bamboo_len -= 3;
            }
            result = (result * bamboo_len) % MOD;

            return (int)result;
        }
    }
}
