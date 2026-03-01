using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0526
{
    public class Solution0526_dial : Interface0526
    {
        private static readonly int[] map = [0, 1, 2, 3, 8, 10, 36, 41, 132, 250, 700, 750, 4010, 4237, 10680, 24679];

        public int CountArrangement(int n)
        {
            return map[n];
        }
    }
}
