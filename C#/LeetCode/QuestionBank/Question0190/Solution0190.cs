using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0190
{
    public class Solution0190 : Interface0190
    {
        public uint reverseBits(uint n)
        {
            uint[] mask = new uint[32];
            int ptr = 0; while (n > 0)
            {
                mask[ptr++] = n & 1;
                n >>= 1;
            }

            uint result = 0;
            for (int i = 0; i < 32; i++) result |= mask[31 - i] << i;

            return result;
        }

        public uint reverseBits2(uint n)
        {
            uint result = 0;
            int ptr = 0; while (n > 0)
            {
                result |= (n & 1) << (31 - ptr);
                n >>= 1;
                ptr++;
            }

            return result;
        }
    }
}
