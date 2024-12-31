using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3219
{
    public class Solution3219 : Interface3219
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 逻辑与Solution3218_2一样
        /// 
        /// MLE，参考测试用例07
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="horizontalCut"></param>
        /// <param name="verticalCut"></param>
        /// <returns></returns>
        public long MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
        {
            if (m == 1) return verticalCut.Sum();
            if (n == 1) return horizontalCut.Sum();

            long[,,,] memory = new long[m, m, n, n];
            for (int r1 = 0; r1 < m; r1++) for (int r2 = 0; r2 < m; r2++) for (int c1 = 0; c1 < n; c1++) for (int c2 = 0; c2 < n; c2++) memory[r1, r2, c1, c2] = -1;
            for (int r = 0; r < m; r++) for (int c = 0; c < n; c++) memory[r, r, c, c] = 0;
            return dfs(0, m - 1, 0, n - 1);

            long dfs(int r1, int r2, int c1, int c2)
            {
                if (memory[r1, r2, c1, c2] == -1)
                {
                    long cost = long.MaxValue;
                    if (r2 > r1) for (int i = r1; i < r2; i++) cost = Math.Min(cost, dfs(r1, i, c1, c2) + dfs(i + 1, r2, c1, c2) + horizontalCut[i]);
                    if (c2 > c1) for (int i = c1; i < c2; i++) cost = Math.Min(cost, dfs(r1, r2, c1, i) + dfs(r1, r2, i + 1, c2) + verticalCut[i]);
                    memory[r1, r2, c1, c2] = cost;
                }

                return memory[r1, r2, c1, c2];
            }
        }
    }
}
