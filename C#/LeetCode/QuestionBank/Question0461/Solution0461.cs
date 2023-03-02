using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0461
{
    public class Solution0461 : Interface0461
    {
        public int HammingDistance(int x, int y)
        {
            return BitCount(x ^ y);
        }

        private int BitCount(int n)
        {
            int result = 0;

            while (n > 0)
            {
                result++; n &= (n - 1);
            }

            return result;
        }
    }
}
