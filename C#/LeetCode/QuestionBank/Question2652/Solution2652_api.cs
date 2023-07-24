using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2652
{
    public class Solution2652_api : Interface2652
    {
        public int SumOfMultiples(int n)
        {
            return Enumerable.Range(1, n).Where(i => i % 3 == 0 || i % 5 == 0 || i % 7 == 0).Sum();
        }
    }
}
