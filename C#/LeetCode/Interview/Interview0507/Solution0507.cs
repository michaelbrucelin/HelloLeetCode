using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0507
{
    public class Solution0507 : Interface0507
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int ExchangeBits2(int num)
        {
            int result = num;
            for (int i = 0; i < 32; i += 2)
            {
                if (((result >> i) & 1) != ((result >> (i + 1)) & 1)) result ^= 3 << i;
            }

            return result;
        }

        /// <summary>
        /// 一次性移动
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int ExchangeBits(int num)
        {
            //                1010..1010                  0101..0101
            long lr = ((num & 0xAAAAAAAA) >> 1) | ((num & 0x55555555) << 1);
            return (int)lr;
        }
    }
}
