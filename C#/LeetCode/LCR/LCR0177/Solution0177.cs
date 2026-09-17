using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0177
{
    public class Solution0177 : Interface0177
    {
        /// <summary>
        /// 位运算
        /// 假定结果为 x, y
        /// 1. 数组中所有值异或的结果为 xor = x^y != 0
        /// 2. 找出 xor 的某个位不等于 0，假定 (xor>>i)&1 !=0 
        /// 3. 数组中每个值按照第 i 位是 0 还是 1 分为 2 组，每组的异或结果就是最终结果
        /// </summary>
        /// <param name="sockets"></param>
        /// <returns></returns>
        public int[] SockCollocation(int[] sockets)
        {
            int xor = 0, len = sockets.Length;
            for (int i = 0; i < len; i++) xor ^= sockets[i];

            int offset = 0;
            while ((xor & 1) != 1) { xor >>= 1; offset++; }  // 题目限定 xor != 0

            int[] result = [0, 0];
            for (int i = 0; i < len; i++) result[(sockets[i] >> offset) & 1] ^= sockets[i];
            return result;
        }
    }
}
