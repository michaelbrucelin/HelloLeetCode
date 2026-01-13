using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0861
{
    public class Solution0861 : Interface0861
    {
        /// <summary>
        /// 贪心
        /// 1. 不要想成每一行的二进制的和，而要看成每个点（单元格）的二进制的和，所以指定下面的贪心策略
        ///     1. 逐行操作，保证每一行的第一列为1
        ///     2. 从第二列开始逐列操作，如果这一列0的数量大于1的数量，就翻转这一列
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MatrixScore(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] cnts1 = new int[ccnt];  // 每一列1的数量
            for (int r = 0; r < rcnt; r++)
            {
                if (grid[r][0] == 1)
                    for (int c = 0; c < ccnt; c++) cnts1[c] += grid[r][c];
                else
                    for (int c = 0; c < ccnt; c++) cnts1[c] += 1 - grid[r][c];
            }

            int result = 0;
            for (int c = ccnt - 1, bv = 1; c >= 0; c--, bv <<= 1)
            {
                result += bv * Math.Max(cnts1[c], rcnt - cnts1[c]);
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同MatrixScore()，稍稍玩点花活
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MatrixScore2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] cnts1 = new int[ccnt];  // 每一列1的数量
            Func<int, int>[] funcs = [x => 1 - x, x => x];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) cnts1[c] += funcs[grid[r][0]](grid[r][c]);

            int result = 0;
            for (int c = ccnt - 1, bv = 1; c >= 0; c--, bv <<= 1)
            {
                result += bv * Math.Max(cnts1[c], rcnt - cnts1[c]);
            }

            return result;
        }
    }
}
