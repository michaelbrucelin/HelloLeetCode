using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0202
{
    public class Solution0202_3 : Interface0202
    {
        public bool IsHappy(int n)
        {
            int slow = n, fast = GetNext(n);
            while (fast != 1 && fast != slow)
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast));
            }

            return fast == 1;
        }

        private int GetNext(int n)
        {
            int t = 0;
            while (n > 0)
            {
                var info = Math.DivRem(n, 10);
                t += info.Remainder * info.Remainder;
                n = info.Quotient;
            }

            return t;
        }
    }
}
