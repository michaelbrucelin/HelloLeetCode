using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0463
{
    public class Solution0463_3 : Interface0463
    {
        private static readonly int[] dr = new int[] { -1, 0, 1, 0 };  // 上 右 下 左
        private static readonly int[] dc = new int[] { 0, 1, 0, -1 };  // 上 右 下 左

        public int IslandPerimeter(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                    if (grid[r][c] == 1) result += dfs(grid, r, c, rcnt, ccnt);

            return result;
        }

        private int dfs(int[][] grid, int r, int c, int rcnt, int ccnt)
        {
            if (r < 0 || r >= rcnt || c < 0 || c >= ccnt || grid[r][c] == 0) return 1;
            if (grid[r][c] == 2) return 0;

            grid[r][c] = 2;
            int result = 0;
            for (int i = 0; i < 4; i++) result += dfs(grid, r + dr[i], c + dc[i], rcnt, ccnt);

            return result;
        }
    }
}
