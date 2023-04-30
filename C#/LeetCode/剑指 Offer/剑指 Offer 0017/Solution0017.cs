using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0017
{
    public class Solution0017 : Interface0017
    {
        public int[] PrintNumbers(int n)
        {
            int[] result = new int[(int)Math.Pow(10, n) - 1];
            for (int i = 0; i < result.Length; i++) result[i] = i + 1;

            return result;
        }
    }
}
