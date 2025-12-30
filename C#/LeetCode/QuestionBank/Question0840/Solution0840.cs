using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0840
{
    public class Solution0840 : Interface0840
    {
        /// <summary>
        /// 枚举
        /// 利用好下面两条性质
        /// 1. 幻方的行 列 对角线的和一定是15
        /// 2. 容易证明 中心 位置一定是5
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumMagicSquaresInside(int[][] grid)
        {
            const int SUM = 15, CENTER = 5, MASK = 511;
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 1; r < rcnt - 1; r++) for (int c = 1; c < ccnt - 1; c++)
                {
                    if (grid[r][c] == CENTER && Check(r, c)) result++;
                }

            return result;

            bool Check(int r, int c)
            {
                int check = 0;
                for (int _r = r - 1; _r <= r + 1; _r++) for (int _c = c - 1; _c <= c + 1; _c++) check |= (1 << (grid[_r][_c] - 1));
                if (check != MASK) return false;

                for (int _r = r - 1; _r <= r + 1; _r++)
                {
                    check = 0;
                    for (int _c = c - 1; _c <= c + 1; _c++) check += grid[_r][_c];
                    if (check != SUM) return false;
                }
                for (int _c = c - 1; _c <= c + 1; _c++)
                {
                    check = 0;
                    for (int _r = r - 1; _r <= r + 1; _r++) check += grid[_r][_c];
                    if (check != SUM) return false;
                }
                if (grid[r - 1][c - 1] + grid[r][c] + grid[r + 1][c + 1] != SUM) return false;
                if (grid[r + 1][c - 1] + grid[r][c] + grid[r - 1][c + 1] != SUM) return false;

                return true;
            }
        }
    }
}
