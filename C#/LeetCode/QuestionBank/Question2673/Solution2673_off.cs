using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2673
{
    public class Solution2673_off : Interface2673
    {
        public int MinIncrements(int n, int[] cost)
        {
            int result = 0;
            for (int i = n - 2; i > 0; i -= 2)
            {
                result += Math.Abs(cost[i] - cost[i + 1]);
                cost[i >> 1] += Math.Max(cost[i], cost[i + 1]);
            }

            return result;
        }
    }
}
