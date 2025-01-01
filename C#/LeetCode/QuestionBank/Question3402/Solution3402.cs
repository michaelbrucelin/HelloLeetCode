using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3402
{
    public class Solution3402 : Interface3402
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumOperations(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int c = 0; c < ccnt; c++) for (int r = 0, last = grid[0][c] - 1; r < rcnt; r++)
                {
                    if (grid[r][c] <= last)
                    {
                        result += last + 1 - grid[r][c];
                        last++;
                    }
                    else
                    {
                        last = grid[r][c];
                    }
                }

            return result;
        }
    }
}
