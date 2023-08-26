using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0693
{
    public class Solution0693 : Interface0693
    {
        public bool HasAlternatingBits(int n)
        {
            int last = (n & 1) ^ 1;
            while (n > 0)
            {
                if ((n & 1) == last) return false;
                last ^= 1; n >>= 1;
            }

            return true;
        }
    }
}
