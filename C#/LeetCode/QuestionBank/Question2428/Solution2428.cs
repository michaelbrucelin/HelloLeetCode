using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2428
{
    public class Solution2428 : Interface2428
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxSum(int[][] grid)
        {
            int result = 0, _result, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 2; r < rcnt; r++) for (int c = 2; c < ccnt; c++)
                {
                    _result = 0;
                    for (int _r = 0; _r < 3; _r++) for (int _c = 0; _c < 3; _c++) _result += grid[r - _r][c - _c];
                    _result -= grid[r - 1][c - 2] + grid[r - 1][c];
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
