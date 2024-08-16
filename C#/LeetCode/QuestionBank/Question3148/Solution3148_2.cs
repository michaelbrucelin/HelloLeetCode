using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3148
{
    public class Solution3148_2 : Interface3148
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution3148，Solution3148中计算(r,c)时，需要计算到达这一行以及这一列后面所有位置的结果的最大值
        /// 例如计算到达(r1,c)时，结果为grid[r1,c]-grid[r,c]+Max(dp[r1,c],0)
        /// 所以不需要逐一判断，只需要维护好每一行每一列的grid[r,c]+Max(dp[r,c],0)的最大值即可
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxScore(IList<IList<int>> grid)
        {
            int result = int.MinValue, rcnt = grid.Count, ccnt = grid[0].Count;
            int[] dp_r = new int[rcnt], dp_c = new int[ccnt];

            int[,] dp = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) dp[r, c] = int.MinValue;
            dp[rcnt - 1, ccnt - 1] = 0;
            for (int r = rcnt - 1; r >= 0; r--) for (int c = ccnt - 1; c >= 0; c--)
                {
                    for (int _r = r + 1; _r < rcnt; _r++) dp[r, c] = Math.Max(dp[r, c], grid[_r][c] - grid[r][c] + Math.Max(dp[_r, c], 0));
                    for (int _c = c + 1; _c < ccnt; _c++) dp[r, c] = Math.Max(dp[r, c], grid[r][_c] - grid[r][c] + Math.Max(dp[r, _c], 0));
                }
            dp[rcnt - 1, ccnt - 1] = int.MinValue;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result = Math.Max(result, dp[r, c]);

            return result;
        }
    }
}
