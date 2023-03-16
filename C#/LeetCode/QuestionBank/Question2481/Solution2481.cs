using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2481
{
    public class Solution2481 : Interface2481
    {
        public int NumberOfCuts(int n)
        {
            if (n == 1) return 0;
            if ((n & 1) != 0) return n; else return n >> 1;
        }

        public int NumberOfCuts2(int n)
        {
            if (n == 1) return 0;
            return n >> (1 - (n & 1));
        }
    }
}
