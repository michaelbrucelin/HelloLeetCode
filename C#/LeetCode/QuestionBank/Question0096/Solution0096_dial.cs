using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0096
{
    public class Solution0096_dial : Interface0096
    {
        private static readonly int[] dial = [1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190];

        public int NumTrees(int n)
        {
            return dial[n];
        }
    }
}
