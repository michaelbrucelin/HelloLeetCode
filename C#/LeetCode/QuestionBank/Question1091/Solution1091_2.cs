using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1091
{
    public class Solution1091_2 : Interface1091
    {
        /// <summary>
        /// DFS
        /// 先不考虑记忆化
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例06
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int len = grid.Length;
            if (grid[0][0] == 1 || grid[len - 1][len - 1] == 1) return -1;
            if (len == 1) return 1;

            grid[0][0] = 1;
            int border = len * len;  // border是结果的上线，也可以取10000或者int.MaxValue
            int result = ShortestPath(grid, len, (0, 0), border);
            return result != border ? result + 1 : -1;
        }

        private int ShortestPath(int[][] grid, int n, (int r, int c) point, int border)
        {
            int result = border, _r, _c;
            for (int r = -1; r <= 1; r++) for (int c = -1; c <= 1; c++)
                {
                    _r = point.r + r; _c = point.c + c;
                    if (_r >= 0 && _r < n && _c >= 0 && _c < n && grid[_r][_c] == 0)
                    {
                        if (_r == n - 1 && _c == n - 1) return 1;
                        int[][] _grid = DeepClone(grid, n); _grid[_r][_c] = 1;
                        result = Math.Min(result, ShortestPath(_grid, n, (_r, _c), border));
                    }
                }
            return result != border ? result + 1 : result;
        }

        private int[][] DeepClone(int[][] grid, int n)
        {
            int[][] cloned = new int[n][];
            for (int r = 0; r < n; r++)
            {
                cloned[r] = new int[n];
                for (int c = 0; c < n; c++) cloned[r][c] = grid[r][c];
            }

            return cloned;
        }
    }
}
