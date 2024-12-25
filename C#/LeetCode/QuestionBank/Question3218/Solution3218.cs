using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3218
{
    public class Solution3218 : Interface3218
    {
        /// <summary>
        /// DFS
        /// 无论怎样切，都要切m*n-1刀，因为每切一刀，都增加一块
        /// 直觉上贪心也可以，先走DFS --> 记忆化搜索 --> DP这条路
        /// 
        /// 逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="horizontalCut"></param>
        /// <param name="verticalCut"></param>
        /// <returns></returns>
        public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
        {
            if (m == 1) return verticalCut.Sum();
            if (n == 1) return horizontalCut.Sum();
            return dfs(0, m - 2, 0, n - 2);

            int dfs(int r1, int r2, int c1, int c2)
            {
                if (r2 < r1 && c2 < c1) return 0;

                int cost = int.MaxValue;
                if (r2 >= r1) for (int i = r1; i <= r2; i++) cost = Math.Min(cost, dfs(r1, i - 1, c1, c2) + dfs(i + 1, r2, c1, c2) + horizontalCut[i]);
                if (c2 >= c1) for (int i = c1; i <= c2; i++) cost = Math.Min(cost, dfs(r1, r2, c1, i - 1) + dfs(r1, r2, i + 1, c2) + verticalCut[i]);

                return cost;
            }
        }

        /// <summary>
        /// 逻辑同MinimumCost()，只是偏移了dfs()的参数，为记忆化搜索做准备
        ///     MinimumCost() 中dfs()的参数是“切”的位置
        ///     MinimumCost2()中dfs()的参数是“块”的位置
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="horizontalCut"></param>
        /// <param name="verticalCut"></param>
        /// <returns></returns>
        public int MinimumCost2(int m, int n, int[] horizontalCut, int[] verticalCut)
        {
            if (m == 1) return verticalCut.Sum();
            if (n == 1) return horizontalCut.Sum();
            return dfs(0, m - 1, 0, n - 1);

            int dfs(int r1, int r2, int c1, int c2)
            {
                if (r2 == r1 && c2 == c1) return 0;

                int cost = int.MaxValue;
                if (r2 > r1) for (int i = r1; i < r2; i++) cost = Math.Min(cost, dfs(r1, i, c1, c2) + dfs(i + 1, r2, c1, c2) + horizontalCut[i]);
                if (c2 > c1) for (int i = c1; i < c2; i++) cost = Math.Min(cost, dfs(r1, r2, c1, i) + dfs(r1, r2, i + 1, c2) + verticalCut[i]);

                return cost;
            }
        }
    }
}
