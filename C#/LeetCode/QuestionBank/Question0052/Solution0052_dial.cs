using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0052
{
    public class Solution0052_dial : Interface0052
    {
        private static readonly int[] dial = [0, 1, 0, 0, 2, 10, 4, 40, 92, 352];

        public int TotalNQueens(int n)
        {
            return dial[n];
        }
    }
}
