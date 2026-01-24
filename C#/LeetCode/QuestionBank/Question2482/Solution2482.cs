using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2482
{
    public class Solution2482 : Interface2482
    {
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] OnesMinusZeros(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] cntr = new int[rcnt], cntc = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    cntr[r] += grid[r][c]; cntc[c] += grid[r][c];
                }

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++)
            {
                result[r] = new int[ccnt];
                for (int c = 0; c < ccnt; c++) result[r][c] = (cntr[r] << 1) - rcnt + (cntc[c] << 1) - ccnt;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同OnesMinusZeros()，略加优化
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] OnesMinusZeros2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] cntr = new int[rcnt], cntc = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != 0)
                    {
                        cntr[r] += 2; cntc[c] += 2;
                    }

            int[][] result = new int[rcnt][];
            int rccnt = rcnt + ccnt;
            for (int r = 0; r < rcnt; r++)
            {
                result[r] = new int[ccnt];
                for (int c = 0; c < ccnt; c++) result[r][c] = cntr[r] + cntc[c] - rccnt;
            }

            return result;
        }
    }
}
