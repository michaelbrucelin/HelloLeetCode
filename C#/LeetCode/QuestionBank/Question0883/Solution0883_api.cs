using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0883
{
    public class Solution0883_api : Interface0883
    {
        public int ProjectionArea(int[][] grid)
        {
            //int r1 = grid.Sum(row => row.Count(i => i > 0));
            //int r2 = grid.Sum(row => row.Max());
            //int r3 = grid.Aggregate((row1, row2) => Enumerable.Range(0, grid.Length).Select(i => Math.Max(row1[i], row2[i])).ToArray()).Sum();
            return   grid.Sum(row => row.Count(i => i > 0) + row.Max())
                   + grid.Aggregate((row1, row2) => Enumerable.Range(0, grid.Length)
                                                              .Select(i => Math.Max(row1[i], row2[i])).ToArray())
                         .Sum();
        }
    }
}
