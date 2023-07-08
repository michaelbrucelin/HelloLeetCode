using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2500
{
    public class Solution2500 : Interface2500
    {
        public int DeleteGreatestValue(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) Array.Sort(grid[r], (i, j) => j - i);

            int result = 0;
            for (int c = 0; c < ccnt; c++)
            {
                int max = -1;
                for (int r = 0; r < rcnt; r++) max = Math.Max(max, grid[r][c]);
                result += max;
            }
            return result;
        }
    }
}
