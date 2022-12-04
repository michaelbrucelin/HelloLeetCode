using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1774
{
    public class Solution1774 : Interface1774
    {
        public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
        {
            int result = 0;
            for (int i = 0; i < baseCosts.Length; i++)
            {
                int _target = target - baseCosts[i];
                int _result = baseCosts[i];
                if (Math.Abs(_target - _result) < Math.Abs(target - result) ||
                    (Math.Abs(_target - _result) == Math.Abs(target - result) && _result < result))
                    result = _result;
            }

            return result;
        }

        private int dfs(int[] toppingCosts, int target, int cost)
        {
            throw new NotImplementedException();
        }
    }
}
