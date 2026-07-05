using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1301
{
    public class Solution1301 : Interface1301
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int[] PathsWithMaxScore(IList<string> board)
        {
            int n = board.Count;
            const int MOD = (int)1e9 + 7;
            int[,,] dp = new int[n, n, 2];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (board[r][c] != 'X') dp[r, c, 0] = board[r][c] - '0';
            dp[0, 0, 0] = 2000; dp[0, 0, 1] = 1; dp[n - 1, n - 1, 0] = -2000;  // 2000 与 -2000 相消，哨兵
            for (int c = 1; c < n; c++) if (dp[0, c, 0] != 0 && dp[0, c - 1, 0] != 0) { dp[0, c, 0] += dp[0, c - 1, 0]; dp[0, c, 1] = 1; }
            for (int r = 1; r < n; r++) if (dp[r, 0, 0] != 0 && dp[r - 1, 0, 0] != 0) { dp[r, 0, 0] += dp[r - 1, 0, 0]; dp[r, 0, 1] = 1; }
            for (int r = 1, max; r < n; r++) for (int c = 1; c < n; c++) if (dp[r, c, 0] != 0)
                    {
                        max = Math.Max(dp[r - 1, c - 1, 0], Math.Max(dp[r - 1, c, 0], dp[r, c - 1, 0]));
                        if (max != 0)
                        {
                            dp[r, c, 0] += max;
                            if (dp[r - 1, c - 1, 0] == max) dp[r, c, 1] += dp[r - 1, c - 1, 1];
                            if (dp[r - 1, c, 0] == max) dp[r, c, 1] = (dp[r, c, 1] + dp[r - 1, c, 1]) % MOD;
                            if (dp[r, c - 1, 0] == max) dp[r, c, 1] = (dp[r, c, 1] + dp[r, c - 1, 1]) % MOD;
                        }
                    }

            return dp[n - 1, n - 1, 0] >= 0 ? [dp[n - 1, n - 1, 0], dp[n - 1, n - 1, 1]] : [0, 0];
        }
    }
}
