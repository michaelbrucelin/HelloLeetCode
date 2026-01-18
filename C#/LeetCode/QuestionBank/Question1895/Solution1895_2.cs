using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1895
{
    public class Solution1895_2 : Interface1895
    {
        /// <summary>
        /// 暴力查找
        /// 逻辑同Solution1895，使用前缀和加速，对角线前缀和这里就不做了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LargestMagicSquare(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[,,] sums = new int[rcnt + 1, ccnt + 1, 3];                 // sums[,,0] 二维前缀和, sums[,,1] 行前缀换, sums[,,2]列前缀和
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1, 0] = sums[r + 1, c, 0] + sums[r, c + 1, 0] - sums[r, c, 0] + grid[r][c];
                    sums[r + 1, c + 1, 1] = sums[r + 1, c, 1] + grid[r][c];
                    sums[r + 1, c + 1, 2] = sums[r, c + 1, 2] + grid[r][c];
                }

            for (int k = Math.Min(rcnt, ccnt), sum, _sum; k > 1; k--) for (int r = k - 1; r < rcnt; r++) for (int c = k - 1; c < ccnt; c++)
                    {
                        sum = sums[r + 1, c + 1, 0] - sums[r + 1, c + 1 - k, 0] - sums[r + 1 - k, c + 1, 0] + sums[r + 1 - k, c + 1 - k, 0];
                        if (sum % k != 0) goto CONTINUE;
                        sum /= k;
                        for (int _r = r - k + 1; _r <= r; _r++) if (sums[_r + 1, c + 1, 1] - sums[_r + 1, c + 1 - k, 1] != sum) goto CONTINUE;
                        for (int _c = c - k + 1; _c <= c; _c++) if (sums[r + 1, _c + 1, 2] - sums[r + 1 - k, _c + 1, 2] != sum) goto CONTINUE;
                        _sum = 0; for (int i = k - 1; i >= 0; i--) _sum += grid[r - i][c - i];
                        if (_sum != sum) goto CONTINUE;
                        _sum = 0; for (int i = k - 1; i >= 0; i--) _sum += grid[r - i][c + i - k + 1];
                        if (_sum != sum) goto CONTINUE;
                        return k;
                    CONTINUE:;
                    }

            return 1;
        }

        /// <summary>
        /// 逻辑完全同LargestMagicSquare()，改成锯齿数组试一下
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LargestMagicSquare2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[][][] sums = new int[rcnt + 1][][];         // sums[,,0] 二维前缀和, sums[,,1] 行前缀换, sums[,,2]列前缀和
            for (int r = 0; r <= rcnt; r++) { sums[r] = new int[ccnt + 1][]; for (int c = 0; c <= ccnt; c++) sums[r][c] = new int[3]; }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1][c + 1][0] = sums[r + 1][c][0] + sums[r][c + 1][0] - sums[r][c][0] + grid[r][c];
                    sums[r + 1][c + 1][1] = sums[r + 1][c][1] + grid[r][c];
                    sums[r + 1][c + 1][2] = sums[r][c + 1][2] + grid[r][c];
                }

            for (int k = Math.Min(rcnt, ccnt), sum, _sum; k > 1; k--) for (int r = k - 1; r < rcnt; r++) for (int c = k - 1; c < ccnt; c++)
                    {
                        sum = sums[r + 1][c + 1][0] - sums[r + 1][c + 1 - k][0] - sums[r + 1 - k][c + 1][0] + sums[r + 1 - k][c + 1 - k][0];
                        if (sum % k != 0) goto CONTINUE;
                        sum /= k;
                        for (int _r = r - k + 1; _r <= r; _r++) if (sums[_r + 1][c + 1][1] - sums[_r + 1][c + 1 - k][1] != sum) goto CONTINUE;
                        for (int _c = c - k + 1; _c <= c; _c++) if (sums[r + 1][_c + 1][2] - sums[r + 1 - k][_c + 1][2] != sum) goto CONTINUE;
                        _sum = 0; for (int i = k - 1; i >= 0; i--) _sum += grid[r - i][c - i];
                        if (_sum != sum) goto CONTINUE;
                        _sum = 0; for (int i = k - 1; i >= 0; i--) _sum += grid[r - i][c + i - k + 1];
                        if (_sum != sum) goto CONTINUE;
                        return k;
                    CONTINUE:;
                    }

            return 1;
        }
    }
}
