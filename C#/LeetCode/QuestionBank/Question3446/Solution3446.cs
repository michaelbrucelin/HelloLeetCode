using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3446
{
    public class Solution3446 : Interface3446
    {
        /// <summary>
        /// API
        /// 使用内置的API排序
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] SortMatrix(int[][] grid)
        {
            if (grid.Length == 1) return grid;

            int n = grid.Length;
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++) result[i] = new int[n];
            result[0][n - 1] = grid[0][n - 1];
            result[n - 1][0] = grid[n - 1][0];
            List<int> buffer = new List<int>() { 0 };
            for (int i = n - 2; i > 0; i--)
            {
                buffer.Add(0);
                for (int r = 0, c = i; c < n; r++, c++) buffer[r] = grid[r][c];
                buffer.Sort();
                for (int r = 0, c = i; c < n; r++, c++) result[r][c] = buffer[r];

                for (int r = i, c = 0; r < n; r++, c++) buffer[c] = grid[r][c];
                buffer.Sort((x, y) => y - x);
                for (int r = i, c = 0; r < n; r++, c++) result[r][c] = buffer[c];
            }
            buffer.Add(0);
            for (int i = 0; i < n; i++) buffer[i] = grid[i][i];
            buffer.Sort((x, y) => y - x);
            for (int i = 0; i < n; i++) result[i][i] = buffer[i];

            return result;
        }
    }
}
