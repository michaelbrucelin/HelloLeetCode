using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2658
{
    public class Solution2658 : Interface2658
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int FindMaxFish(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] mask = new bool[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] > 0 && !mask[r, c])
                    {
                        result = Math.Max(result, dfs(r, c));
                    }

            return result;

            int dfs(int r, int c)
            {
                int result = grid[r][c];
                mask[r, c] = true;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] > 0 && !mask[_r, _c]) result += dfs(_r, _c);
                }

                return result;
            }
        }
    }
}
