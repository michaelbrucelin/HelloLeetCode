using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2684
{
    public class Solution2684 : Interface2684
    {
        /// <summary>
        /// DP
        /// 从左到右DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxMoves(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dp = new int[rcnt], _dp = new int[rcnt], offset = new int[] { -1, 0, 1 };
            for (int c = 1; c < ccnt; c++)
            {
                Array.Fill(_dp, -1);
                for (int r = 0, _r; r < rcnt; r++) for (int i = 0; i < 3; i++)
                    {
                        _r = r + offset[i];
                        if (_r >= 0 && _r < rcnt && dp[_r] != -1 && grid[_r][c - 1] < grid[r][c])
                        {
                            _dp[r] = Math.Max(_dp[r], dp[_r] + 1);
                            result = Math.Max(result, _dp[r]);
                        }
                    }
                Array.Copy(_dp, dp, rcnt);
            }

            return result;
        }
    }
}
