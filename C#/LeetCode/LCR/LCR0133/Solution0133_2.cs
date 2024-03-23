using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0133
{
    public class Solution0133_2 : Interface0133
    {
        public int HammingWeight(uint n)
        {
            int result = 0;
            while (n > 0)
            {
                result++;
                n &= n - 1;
            }

            return result;
        }
    }
}
