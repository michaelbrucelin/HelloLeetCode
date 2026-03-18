using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3070
{
    public class Solution3070 : Interface3070
    {
        /// <summary>
        /// 遍历
        /// 本质上就是构造二位前缀和的过程
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubmatrices(int[][] grid, int k)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if ((sums[r + 1, c + 1] = sums[r, c + 1] + sums[r + 1, c] - sums[r, c] + grid[r][c]) <= k) result++;
                }

            return result;
        }

        /// <summary>
        /// 逻辑同CountSubmatrices()，滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubmatrices2(int[][] grid, int k)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] sums = new int[ccnt + 1];
            int sum, lr = 0;  // lr表示sums[r-1, c-1]
            for (int r = 0; r < rcnt; r++, lr = 0) for (int c = 0; c < ccnt; c++)
                {
                    sum = sums[c + 1] + sums[c] - lr + grid[r][c];
                    if (sum <= k) result++;
                    lr = sums[c + 1];
                    sums[c + 1] = sum;
                }

            return result;
        }
    }
}
