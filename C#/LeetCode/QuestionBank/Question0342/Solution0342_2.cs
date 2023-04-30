using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0342
{
    public class Solution0342_2 : Interface0342
    {
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && (n & 0xAAAAAAAA) == 0;  // 10101010101010101010101010101010
        }

        public bool IsPowerOfFour2(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) == n;  // 01010101010101010101010101010101
        }
    }
}
