using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0980
{
    public class Solution0980 : Interface0980
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// DFS，无返回值
        /// 
        /// 提交竟然一次过了，原以为会超时
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int UniquePathsIII(int[][] grid)
        {
            int result = 0, step = 0, start_r = -1, start_c = -1, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 0) step++; if (grid[r][c] == 1) { start_r = r; start_c = c; }
                }
            dfs(grid, step, start_r, start_c, rcnt, ccnt, ref result);

            return result;
        }

        private void dfs(int[][] grid, int step, int r, int c, int rcnt, int ccnt, ref int result)
        {
            int _r, _c;
            if (step > 0) for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0)
                    {
                        int[][] _grid = CopyArray(grid, rcnt, ccnt);
                        _grid[_r][_c] = -1;
                        dfs(_grid, step - 1, _r, _c, rcnt, ccnt, ref result);
                    }
                }
            else for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 2)
                    {
                        result++; break;
                    }
                }
        }

        private int[][] CopyArray(int[][] source, int rcnt, int ccnt)
        {
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++)
            {
                result[r] = new int[ccnt];
                for (int c = 0; c < ccnt; c++) result[r][c] = source[r][c];
            }

            return result;
        }
    }
}
