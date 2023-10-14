using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0892
{
    public class Solution0892 : Interface0892
    {
        /// <summary>
        /// 立体几何
        /// 总表面积 - 重叠的表面积
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SurfaceArea(int[][] grid)
        {
            int result = 0, n = grid.Length;
            // 总面积 - 垂直重叠面积
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) result += grid[r][c] * 6 - ((grid[r][c] > 0 ? grid[r][c] : 1) - 1) * 2;
            // 横向重叠面积
            for (int r = 0; r < n; r++) for (int c = 1; c < n; c++) result -= Math.Min(grid[r][c - 1], grid[r][c]) * 2;
            // 纵向重叠面积
            for (int c = 0; c < n; c++) for (int r = 1; r < n; r++) result -= Math.Min(grid[r - 1][c], grid[r][c]) * 2;

            return result;
        }
    }
}
