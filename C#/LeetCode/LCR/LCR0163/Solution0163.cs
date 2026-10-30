using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0163
{
    public class Solution0163 : Interface0163
    {
        /// <summary>
        /// 找规律
        /// 1位数，9*1   共 9    位
        /// 2位数，90*2  共 180  位
        /// 3位数，900*3 共 2700 位
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthNumber(int k)
        {
            if (k < 10) return k;

            long total = 0, next = 0, cnt = 9; int len = 1;
            while (next < k)
            {
                total = next; next += cnt * len; cnt *= 10; len++;
            }
            len -= 1;

            int x = (int)(Math.Pow(10, len - 1) + (k - total) / len);
            int offset = (int)((k - total) / len);
            int mod = (int)((k - total) % len);

            if (mod == 0) return (x - 1) % 10;
            mod = len - mod;
            while (mod-- > 0) x /= 10;
            return x % 10;
        }
    }
}
