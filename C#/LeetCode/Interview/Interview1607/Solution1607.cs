using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1607
{
    public class Solution1607 : Interface1607
    {
        public int Maximum(int a, int b)
        {
            long _a = a, _b = b;
            return (int)(((decimal)(_a + _b)) / 2 + ((decimal)Math.Abs(_a - _b)) / 2);
        }

        public int Maximum2(int a, int b)
        {
            long x = (long)a - (long)b;
            int k = (int)(x >> 63);      // a-b的符号位

            return (1 + k) * a - b * k;
        }
    }
}
