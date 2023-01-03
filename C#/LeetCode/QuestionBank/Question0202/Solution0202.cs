using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0202
{
    public class Solution0202 : Interface0202
    {
        public bool IsHappy(int n)
        {
            HashSet<int> buffer = new HashSet<int>();
            while (!buffer.Contains(n))
            {
                buffer.Add(n);
                int t = 0;
                while (n > 0)
                {
                    var info = Math.DivRem(n, 10);
                    t += info.Remainder * info.Remainder;
                    n = info.Quotient;
                }
                if (t == 1) return true;
                n = t;
            }

            return false;
        }
    }
}
