using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0190
{
    public class Solution0190_2 : Interface0190
    {
        /// <summary>
        /// 分治
        /// abcdefgh --> efghabcd --> ghefcdab --> hgfedcba
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseBits(int n)
        {
            return dc(n, 32);

            static int dc(int x, int bits)
            {
                if (bits == 1) return x;

                bits >>= 1;
                int x1 = x >> bits, x2 = x & ((1 << bits) - 1);

                return (dc(x2, bits) << bits) | (dc(x1, bits));
            }
        }

        /// <summary>
        /// 逻辑与ReverseBits()相同，将递归改为位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseBits2(int n)
        {
            const int mask16 = 0B00000000000000001111111111111111;
            const int mask08 = 0B00000000111111110000000011111111;
            const int mask04 = 0B00001111000011110000111100001111;
            const int mask02 = 0B00110011001100110011001100110011;
            const int mask01 = 0B01010101010101010101010101010101;

            n = ((n & mask16) << 16) | ((n & (~mask16)) >>> 16);
            n = ((n & mask08) << 08) | ((n & (~mask08)) >>> 08);
            n = ((n & mask04) << 04) | ((n & (~mask04)) >>> 04);
            n = ((n & mask02) << 02) | ((n & (~mask02)) >>> 02);
            n = ((n & mask01) << 01) | ((n & (~mask01)) >>> 01);

            return n;
        }
    }
}
