using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2600
{
    public class Solution2600 : Interface2600
    {
        public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            if (k <= numOnes) return k;
            if (k <= numOnes + numZeros) return numOnes;
            return (numOnes << 1) + numZeros - k;
        }
    }
}
