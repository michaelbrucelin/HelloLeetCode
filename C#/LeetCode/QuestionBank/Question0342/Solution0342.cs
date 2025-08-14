using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0342
{
    public class Solution0342 : Interface0342
    {
        public bool IsPowerOfFour(int n)
        {
            if (n < 1) return false;

            while (n >= 4)
            {
                var info = Math.DivRem(n, 4);
                if (info.Remainder != 0) return false;
                n = info.Quotient;
            }

            return n == 1;
        }

        public bool IsPowerOfFour2(int n)
        {
            if (n == 1) return true;
            if (n < 4) return false;

            var info = Math.DivRem(n, 4);
            if (info.Remainder != 0) return false;
            return IsPowerOfFour2(info.Quotient);
        }
    }
}
