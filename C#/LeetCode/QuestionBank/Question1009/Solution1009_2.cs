using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1009
{
    public class Solution1009_2 : Interface1009
    {
        public int BitwiseComplement(int n)
        {
            if (n == 0) return 1;

            int result = 0, pos = 0;
            while (n > 0)
            {
                result |= ((1 - (n & 1)) << (pos++));
                n >>= 1;
            }

            return result;
        }
    }
}
