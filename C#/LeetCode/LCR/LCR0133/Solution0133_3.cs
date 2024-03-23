using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0133
{
    public class Solution0133_3 : Interface0133
    {
        private const int M1 = 0x55555555;   // 01010101010101010101010101010101
        private const int M2 = 0x33333333;   // 00110011001100110011001100110011
        private const int M4 = 0x0f0f0f0f;   // 00001111000011110000111100001111
        private const int M8 = 0x00ff00ff;   // 00000000111111110000000011111111
        private const int M16 = 0x0000ffff;  // 00000000000000001111111111111111

        public int HammingWeight(uint n)
        {
            n = (n & M1) + ((n >> 1) & M1);
            n = (n & M2) + ((n >> 2) & M2);
            n = (n & M4) + ((n >> 4) & M4);
            n = (n & M8) + ((n >> 8) & M8);
            n = (n & M16) + ((n >> 16) & M16);

            return (int)n;
        }
    }
}
