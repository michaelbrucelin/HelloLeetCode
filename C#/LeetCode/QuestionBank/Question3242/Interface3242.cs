using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3242
{
    /// <summary>
    /// Your NeighborSum object will be instantiated and called as such:
    /// NeighborSum obj = new NeighborSum(grid);
    /// int param_1 = obj.AdjacentSum(value);
    /// int param_2 = obj.DiagonalSum(value);
    /// </summary>
    public interface Interface3242
    {
        // public NeighborSum(int[][] grid)
        // {
        // }

        public int AdjacentSum(int value);

        public int DiagonalSum(int value);
    }
}
