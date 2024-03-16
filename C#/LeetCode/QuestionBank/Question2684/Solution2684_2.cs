using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2684
{
    public class Solution2684_2 : Interface2684
    {
        /// <summary>
        /// DP
        /// 从右到左DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxMoves(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dp = new int[rcnt], _dp = new int[rcnt], offset = new int[] { -1, 0, 1 };
            for (int c = ccnt - 2; c >= 0; c--)
            {
                for (int r = 0, _r; r < rcnt; r++) for (int i = 0; i < 3; i++)
                    {
                        _r = r + offset[i];
                        if (_r >= 0 && _r < rcnt && grid[r][c] < grid[_r][c + 1])
                        {
                            _dp[r] = Math.Max(_dp[r], dp[_r] + 1);
                        }
                    }
                Array.Copy(_dp, dp, rcnt);
                Array.Fill(_dp, 0);
            }

            int result = 0;
            for (int i = 0; i < rcnt; i++) result = Math.Max(result, dp[i]);
            return result;
        }
    }
}
