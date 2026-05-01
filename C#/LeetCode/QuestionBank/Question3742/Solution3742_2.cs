using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3742
{
    public class Solution3742_2 : Interface3742
    {
        /// <summary>
        /// DP
        /// 
        /// 提交通过了，原则上时间复杂度与Solution3742相同的，可能就是快在数组与Hash上吧
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxPathScore(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            Dictionary<int, int>[,] dp = new Dictionary<int, int>[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) dp[r, c] = new Dictionary<int, int>();
            dp[0, 0].Add(k - Math.Sign(grid[0][0]), grid[0][0]);
            for (int c = 1; c < ccnt; c++) foreach ((int _k, int score) in dp[0, c - 1]) if (_k - Math.Sign(grid[0][c]) >= 0)
                    {
                        dp[0, c].Add(_k - Math.Sign(grid[0][c]), score + grid[0][c]);
                    }
            for (int r = 1; r < rcnt; r++) foreach ((int _k, int score) in dp[r - 1, 0]) if (_k - Math.Sign(grid[r][0]) >= 0)
                    {
                        dp[r, 0].Add(_k - Math.Sign(grid[r][0]), score + grid[r][0]);
                    }
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    foreach ((int _k, int score) in dp[r - 1, c]) if (_k - Math.Sign(grid[r][c]) >= 0)
                        {
                            dp[r, c].TryAdd(_k - Math.Sign(grid[r][c]), -1);
                            dp[r, c][_k - Math.Sign(grid[r][c])] = Math.Max(dp[r, c][_k - Math.Sign(grid[r][c])], score + grid[r][c]);
                        }
                    foreach ((int _k, int score) in dp[r, c - 1]) if (_k - Math.Sign(grid[r][c]) >= 0)
                        {
                            dp[r, c].TryAdd(_k - Math.Sign(grid[r][c]), -1);
                            dp[r, c][_k - Math.Sign(grid[r][c])] = Math.Max(dp[r, c][_k - Math.Sign(grid[r][c])], score + grid[r][c]);
                        }
                }

            int result = -1;
            foreach ((int _, int score) in dp[rcnt - 1, ccnt - 1]) result = Math.Max(result, score);
            return result;
        }
    }
}
