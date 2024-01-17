using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2639
{
    public class Solution2639_api : Interface2639
    {
        public int[] FindColumnWidth(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            return Enumerable.Range(0, ccnt)
                             .Select(c => Enumerable.Range(0, rcnt).Max(r => grid[r][c].ToString().Length))
                             .ToArray();
        }
    }
}
