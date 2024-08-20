using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3154
{
    public class Utils3154
    {
        public void Dial()
        {
            Interface3154 solution = new Solution3154();
            for (int i = 0, k; i <= (int)1e9; i++)
            {
                k = solution.WaysToReachStair(i);
                if (k != 0) Console.WriteLine($"{i}, {k}");
            }
        }
    }
}
