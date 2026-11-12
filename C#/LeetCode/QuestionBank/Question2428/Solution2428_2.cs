using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2428
{
    public class Solution2428_2 : Interface2428
    {
        /// <summary>
        /// 二维前缀和
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxSum(int[][] grid)
        {
            int result = 0, _result, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r + 1, c] + sums[r, c + 1] - sums[r, c] + grid[r][c];
                }
            for (int r = 2; r < rcnt; r++) for (int c = 2; c < ccnt; c++)
                {
                    _result = sums[r + 1, c + 1] - sums[r + 1, c - 2] - sums[r - 2, c + 1] + sums[r - 2, c - 2];
                    _result -= grid[r - 1][c - 2] + grid[r - 1][c];
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
