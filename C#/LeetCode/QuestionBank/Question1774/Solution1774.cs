using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1774
{
    public class Solution1774 : Interface1774
    {
        /// <summary>
        /// 暴力解
        /// 选取一种基料，然后每种配料有3中选择：0份、1份、2份
        /// 一次循环可以搞定选取基料，dfs可以搞定选取配料
        /// </summary>
        /// <param name="baseCosts"></param>
        /// <param name="toppingCosts"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
        {
            int result = baseCosts[0];
            for (int i = 0; i < baseCosts.Length; i++)
            {
                int baseCost = baseCosts[i];
                if (baseCost == target) return target;
                if (baseCost > target)
                {
                    if ((baseCost - target) < Math.Abs(result - target)) result = baseCost;
                    continue;
                }

                int _result = 0;
                dfs(toppingCosts, target - baseCost, 0, 0, ref _result);
                _result += baseCost;
                if (_result == target) return target;
                if (Math.Abs(_result - target) < Math.Abs(result - target) ||
                    (Math.Abs(_result - target) == Math.Abs(result - target) && _result < result))
                    result = _result;
            }

            return result;
        }

        private void dfs(int[] toppingCosts, int target, int id, int cost, ref int result)
        {
            if (id + 1 < toppingCosts.Length) dfs(toppingCosts, target, id + 1, cost, ref result);  // 0份
            dfs2(toppingCosts, target, id, cost + toppingCosts[id], ref result);                    // 1份
            if (cost + toppingCosts[id] < target)
                dfs2(toppingCosts, target, id, cost + (toppingCosts[id] << 1), ref result);         // 2份
        }

        private void dfs2(int[] toppingCosts, int target, int id, int cost, ref int result)
        {
            int distance = Math.Abs(result - target);
            if (cost == target) { result = target; return; }
            else if (cost > target) { if (cost - target < distance) result = cost; }
            else  // if (cost < target)
            {
                int _distance = target - cost;
                if (_distance < distance || (_distance == distance && cost < result)) { result = cost; }
                if (id + 1 < toppingCosts.Length) dfs(toppingCosts, target, id + 1, cost, ref result);
            }
        }
    }
}
