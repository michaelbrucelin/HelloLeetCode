using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2144
{
    public class Solution2144_api : Interface2144
    {
        public int MinimumCost(int[] cost)
        {
            return cost.OrderBy(i => -i)
                       .Where((i, id) => id % 3 != 2)
                       .Sum();
        }
    }
}
