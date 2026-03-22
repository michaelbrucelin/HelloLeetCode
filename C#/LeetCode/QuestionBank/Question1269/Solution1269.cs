using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1269
{
    public class Solution1269 : Interface1269
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="arrLen"></param>
        /// <returns></returns>
        public int NumWays(int steps, int arrLen)
        {
            const int MOD = (int)1e9 + 7;
            int limit = Math.Min(steps >> 1, arrLen - 1);         // 最远走到limit位置，含limit
            long[,] memory = new long[steps + 1, limit + 1];
            for (int i = 1; i <= steps; i++) for (int j = 0; j <= limit; j++) memory[i, j] = -1;
            memory[0, 0] = 1;

            return (int)dfs(steps, 0);

            long dfs(int steps, int pos)
            {
                if (pos == -1 || pos > limit) return 0;           // steps == -1 不会到达
                if (memory[steps, pos] != -1) return memory[steps, pos];

                memory[steps, pos] = (dfs(steps - 1, pos) + dfs(steps - 1, pos - 1) + dfs(steps - 1, pos + 1)) % MOD;
                return memory[steps, pos];
            }
        }
    }
}
