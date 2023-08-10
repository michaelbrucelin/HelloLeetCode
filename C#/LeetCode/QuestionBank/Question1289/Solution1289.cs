using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1289
{
    public class Solution1289 : Interface1289
    {
        /// <summary>
        /// 排序 + DP
        /// 同Solution1289_error的逻辑，只是相邻行不从两个相邻列获取，而是取列不等的最小值
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFallingPathSum2(int[][] grid)
        {
            int len = grid.Length;
            if (len == 1) return grid[0][0];
            if (len == 2) return Math.Min(grid[0][0] + grid[1][1], grid[0][1] + grid[1][0]);

            (int val, int id)[] dp = new (int val, int id)[len], _dp;
            for (int r = len - 1, _val; r >= 0; r--)
            {
                _dp = new (int val, int id)[len];
                for (int c = 0; c < len; c++)
                {
                    _val = grid[r][c] + (c != dp[0].id ? dp[0].val : dp[1].val);
                    _dp[c] = (_val, c);
                }
                dp = _dp;
                Array.Sort(dp, (t1, t2) => t1.val - t2.val);
            }

            int result = dp[0].val;
            for (int i = 1; i < len; i++) result = Math.Min(result, dp[i].val);
            return result;
        }

        /// <summary>
        /// DP
        /// 同MinFallingPathSum()，但是不需要排序，只需要记录最小值与次小值即可
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] grid)
        {
            int len = grid.Length;
            if (len == 1) return grid[0][0];
            if (len == 2) return Math.Min(grid[0][0] + grid[1][1], grid[0][1] + grid[1][0]);

            (int val, int id) t1 = (0, 0), t2 = (0, 0), _t1, _t2, _t;
            for (int r = len - 1; r >= 0; r--)
            {
                _t1 = (grid[r][0] + (t1.id != 0 ? t1.val : t2.val), 0);
                _t2 = (grid[r][1] + (t1.id != 1 ? t1.val : t2.val), 1);
                if (_t2.val < _t1.val) (_t1, _t2) = (_t2, _t1);
                for (int c = 2; c < len; c++)
                {
                    _t = (grid[r][c] + (t1.id != c ? t1.val : t2.val), c);
                    if (_t.val < _t1.val) { _t2 = _t1; _t1 = _t; }
                    else if (_t.val < _t2.val) { _t2 = _t; }
                }
                t1 = _t1; t2 = _t2;
            }

            return t1.val;
        }
    }
}
