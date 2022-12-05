using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1774
{
    public class Solution1774_2 : Interface1774
    {
        public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
        {
            int result = baseCosts[0];
            for (int i = 0; i < baseCosts.Length; i++)
                dfs(toppingCosts, target, 0, baseCosts[i], ref result);

            return result;
        }

        private void dfs(int[] toppingCosts, int target, int id, int cost, ref int result)
        {
            int distance = Math.Abs(result - target);
            if (cost == target) result = target;
            else if (cost > target) { if (cost - target < distance) result = cost; }
            else  // if (cost < target)
            {
                int _distance = target - cost;
                if (_distance < distance || (_distance == distance && cost < result)) result = cost;

                if (id == toppingCosts.Length) return;
                dfs(toppingCosts, target, id + 1, cost, ref result);                                // 0份
                dfs(toppingCosts, target, id + 1, cost + toppingCosts[id], ref result);             // 1份
                if (cost + toppingCosts[id] < target)
                    dfs(toppingCosts, target, id + 1, cost + (toppingCosts[id] << 1), ref result);  // 2份
            }
        }
    }
}
