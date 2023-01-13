using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0190
{
    public class Solution0190_3 : Interface0190
    {
        private const int M1 = 0x55555555;  // 01010101010101010101010101010101
        private const int M2 = 0x33333333;  // 00110011001100110011001100110011
        private const int M4 = 0x0f0f0f0f;  // 00001111000011110000111100001111
        private const int M8 = 0x00ff00ff;  // 00000000111111110000000011111111

        public uint reverseBits(uint n)
        {
            n = n >> 1 & M1 | (n & M1) << 1;
            n = n >> 2 & M2 | (n & M2) << 2;
            n = n >> 4 & M4 | (n & M4) << 4;
            n = n >> 8 & M8 | (n & M8) << 8;
            return n >> 16 | n << 16;
        }
    }
}
