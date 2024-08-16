using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3148
{
    public class Solution3148 : Interface3148
    {
        /// <summary>
        /// DP
        /// 以(r,c)为起点的结果是到达这一行以及这一列后面所有位置的结果的最大值，所以可以自底向上DP
        /// 时间复杂度为O(mn(m+n))，显然易见的会TLE，先写出来，然后再优化
        /// 
        /// ... ...提交竟然通过了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxScore(IList<IList<int>> grid)
        {
            int result = int.MinValue, rcnt = grid.Count, ccnt = grid[0].Count;
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
