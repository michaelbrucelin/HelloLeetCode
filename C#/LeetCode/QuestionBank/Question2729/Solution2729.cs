using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2729
{
    public class Solution2729 : Interface2729
    {
        public bool IsFascinating(int n)
        {
            if (n >= 333) return false;

            int mask = 0;
            for (int i = 1, _n = n, _d; i <= 3; _n = n * ++i) while (_n > 0)
                {
                    if ((_d = _n % 10) == 0) return false;
                    if (((mask >> (_d - 1)) & 1) == 1) return false;
                    mask |= 1 << (_d - 1);
                    _n /= 10;
                }

            return true;
        }
    }
}
