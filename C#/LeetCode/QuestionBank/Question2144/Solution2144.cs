using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2144
{
    public class Solution2144 : Interface2144
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinimumCost(int[] cost)
        {
            Array.Sort(cost, (x, y) => y - x);

            int result = 0;
            for (int i = 0, len = cost.Length; i < len; i++) if (i % 3 != 2) result += cost[i];

            return result;
        }

        /// <summary>
        /// 贪心 + 状态机
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinimumCost2(int[] cost)
        {
            Array.Sort(cost, (x, y) => y - x);

            int result = 0, state = 2, len = cost.Length;
            for (int i = 0; i < len; i++)
            {
                state = state switch { 2 => 0, 0 => 1, 1 => 2, _ => -1 };
                if (state != 2) result += cost[i];
            }

            return result;
        }

        public int MinimumCost3(int[] cost)
        {
            Array.Sort(cost, (x, y) => y - x);
            int[] map = [1, 2, 0];

            int result = 0, state = 2, len = cost.Length;
            for (int i = 0; i < len; i++) if ((state = map[state]) != 2) result += cost[i];

            return result;
        }
    }
}
