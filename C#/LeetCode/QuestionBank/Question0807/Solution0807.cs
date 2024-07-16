using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0807
{
    public class Solution0807 : Interface0807
    {
        /// <summary>
        /// 遍历
        /// 先预处理每一行每一列的最大值，然后遍历计算即可
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int result = 0, n = grid.Length;
            int[,] max = new int[2, n];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                {
                    max[0, r] = Math.Max(max[0, r], grid[r][c]);
                }
            for (int c = 0; c < n; c++) for (int r = 0; r < n; r++)
                {
                    max[1, c] = Math.Max(max[1, c], grid[r][c]);
                }

            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                {
                    result += Math.Min(max[0, r], max[1, c]) - grid[r][c];
                }

            return result;
        }
    }
}
