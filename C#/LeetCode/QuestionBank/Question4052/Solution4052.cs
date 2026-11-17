using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4052
{
    public class Solution4052 : Interface4052
    {
        /// <summary>
        /// 原地模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="grid"></param>
        /// <param name="rowShift"></param>
        /// <param name="colShift"></param>
        /// <returns></returns>
        public int[][] CyclicShift(int n, int[][] grid, int[] rowShift, int[] colShift)
        {
            int[] buffer = new int[n];
            for (int r = 0, shift; r < n; r++)
            {
                shift = rowShift[r];
                for (int c = 0; c < shift; c++) buffer[c] = grid[r][c];
                for (int c = shift; c < n; c++) grid[r][c - shift] = grid[r][c];
                for (int c = n - shift, i = 0; c < n; c++) grid[r][c] = buffer[i++];
            }
            for (int c = 0, shift; c < n; c++)
            {
                shift = colShift[c];
                for (int r = 0; r < shift; r++) buffer[r] = grid[r][c];
                for (int r = shift; r < n; r++) grid[r - shift][c] = grid[r][c];
                for (int r = n - shift, i = 0; r < n; r++) grid[r][c] = buffer[i++];
            }

            return grid;
        }
    }
}
