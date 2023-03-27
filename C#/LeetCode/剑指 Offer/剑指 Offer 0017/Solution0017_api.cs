using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0017
{
    public class Solution0017_api : Interface0017
    {
        public int[] PrintNumbers(int n)
        {
            return Enumerable.Range(1, (int)Math.Pow(10, n) - 1).ToArray();
        }
    }
}
