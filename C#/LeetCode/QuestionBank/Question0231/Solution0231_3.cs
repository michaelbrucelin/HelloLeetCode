using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0231
{
    public class Solution0231_3 : Interface0231
    {
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        public bool IsPowerOfTwo2(int n)
        {
            return n > 0 && (n & -n) == n;
        }
    }
}
