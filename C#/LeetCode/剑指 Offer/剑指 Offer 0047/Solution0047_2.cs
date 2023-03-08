using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0047
{
    public class Solution0047_2 : Interface0047
    {
        /// <summary>
        /// DFS
        /// 很慢，没有提交，参考测试用例4
        /// 这个可以记忆化搜索吗？没想到怎么实现。
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MaxValue(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 1 || ccnt == 1) return grid.Sum(arr => arr.Sum());

            int result = 0;
            dfs(grid, rcnt, ccnt, 0, 0, grid[0][0], ref result);
            return result;
        }

        private void dfs(int[][] grid, int rcnt, int ccnt, int r, int c, int _result, ref int result)
        {
            if (r == rcnt - 1 && c == ccnt - 1)
            {
                result = Math.Max(result, _result);
                return;
            }

            if (c + 1 < ccnt) dfs(grid, rcnt, ccnt, r, c + 1, _result + grid[r][c + 1], ref result);
            if (r + 1 < rcnt) dfs(grid, rcnt, ccnt, r + 1, c, _result + grid[r + 1][c], ref result);
        }
    }
}
