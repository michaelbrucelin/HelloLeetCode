using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1260
{
    public class Solution1260 : Interface1260
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] temp = new int[rcnt];
            for (int i = 0; i < k; i++)
            {
                temp[0] = grid[rcnt - 1][ccnt - 1];
                for (int r = 1; r < rcnt; r++) temp[r] = grid[r - 1][ccnt - 1];

                for (int c = ccnt - 1; c > 0; c--) for (int r = 0; r < rcnt; r++)
                    {
                        grid[r][c] = grid[r][c - 1];
                    }

                for (int r = 0; r < rcnt; r++) grid[r][0] = temp[r];
            }

            return grid;
        }
    }
}
