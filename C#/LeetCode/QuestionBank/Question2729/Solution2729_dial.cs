using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2729
{
    public class Solution2729_dial : Interface2729
    {
        private static readonly HashSet<int> set = new HashSet<int> { 192, 219, 273, 327 };

        public bool IsFascinating(int n)
        {
            return set.Contains(n);
        }
    }
}
