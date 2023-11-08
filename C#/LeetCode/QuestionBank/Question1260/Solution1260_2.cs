using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1260
{
    public class Solution1260_2 : Interface1260
    {
        /// <summary>
        /// 数学
        /// 假设grid有r行，c列，需要执行k次，等价于下面的操作
        ///     1. 所有列向下滚动 k/c%r 次   或  前 c-k%c 列向下滚动 k/c%r 次
        ///     2. 最后 k%c 列向下滚动 1 次  或  最后 k%c 列向下滚动 k/c%r+1 次
        ///     3. 所有列横向滚动 k%c 次
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> ShiftGrid2(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length, cborder = ccnt - k % ccnt, time;
            int[,] temp = new int[rcnt, ccnt];
            // 向下滚动
            time = k / ccnt % rcnt;
            for (int c = 0; c < cborder; c++) for (int r = 0; r < rcnt; r++)
                {
                    temp[r, c] = grid[r - time >= 0 ? r - time : r - time + rcnt][c];
                }
            time = k / ccnt % rcnt + 1;
            for (int c = cborder; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                {
                    temp[r, c] = grid[r - time >= 0 ? r - time : r - time + rcnt][c];
                }
            // 向右滚动
            time = k % ccnt;
            for (int c = 0; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                {
                    grid[r][c] = temp[r, c - time >= 0 ? c - time : c - time + ccnt];
                }

            return grid;
        }

        /// <summary>
        /// 与Solution1260()逻辑一样，优化了空间复杂度，将中间数组由O(r*c)降为O(r+c)
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length, cborder = ccnt - k % ccnt, time;
            // 向下滚动
            int[] temp = new int[rcnt];
            if ((time = k / ccnt % rcnt) != 0) for (int c = 0; c < cborder; c++)
                {
                    for (int r = 0; r < rcnt; r++) temp[r] = grid[r - time >= 0 ? r - time : r - time + rcnt][c];
                    for (int r = 0; r < rcnt; r++) grid[r][c] = temp[r];
                }
            if ((time = k / ccnt % rcnt + 1) != 0) for (int c = cborder; c < ccnt; c++)
                {
                    for (int r = 0; r < rcnt; r++) temp[r] = grid[r - time >= 0 ? r - time : r - time + rcnt][c];
                    for (int r = 0; r < rcnt; r++) grid[r][c] = temp[r];
                }
            // 向右滚动
            temp = new int[ccnt];
            if ((time = k % ccnt) != 0) for (int r = 0; r < rcnt; r++)
                {
                    for (int c = 0; c < ccnt; c++) temp[c] = grid[r][c - time >= 0 ? c - time : c - time + ccnt];
                    for (int c = 0; c < ccnt; c++) grid[r][c] = temp[c];
                }

            return grid;
        }
    }
}
