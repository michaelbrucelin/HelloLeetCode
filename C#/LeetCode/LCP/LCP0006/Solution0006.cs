using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0006
{
    public class Solution0006 : Interface0006
    {
        public int MinCount(int[] coins)
        {
            int result = 0;
            foreach (int coin in coins)
                result += (coin >> 1) + (coin & 1);  // result += (coin + 1) >> 1;
            return result;
        }
    }
}
