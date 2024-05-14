using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3142
{
    public class Solution3142 : Interface3142
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool SatisfiesConditions(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            for (int c = 0; c < ccnt; c++) for (int r = 1; r < rcnt; r++) if (grid[r][c] != grid[0][c]) return false;
            for (int c = 1; c < ccnt; c++) if (grid[0][c] == grid[0][c - 1]) return false;

            return true;
        }
    }
}
