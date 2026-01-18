using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1895
{
    public class Solution1895 : Interface1895
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LargestMagicSquare(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            for (int k = Math.Min(rcnt, ccnt), sum, _sum; k > 1; k--) for (int r = k - 1; r < rcnt; r++) for (int c = k - 1; c < ccnt; c++)
                    {
                        sum = 0; _sum = 0;
                        for (int i = k - 1; i >= 0; i--) { sum += grid[r - i][c - i]; _sum += grid[r - i][c + i - k + 1]; }
                        if (_sum != sum) goto CONTINUE;
                        for (int _r = r - k + 1; _r <= r; _r++)
                        {
                            _sum = 0;
                            for (int _c = c - k + 1; _c <= c; _c++) if ((_sum += grid[_r][_c]) > sum) goto CONTINUE;
                            if (_sum != sum) goto CONTINUE;
                        }
                        for (int _c = c - k + 1; _c <= c; _c++)
                        {
                            _sum = 0;
                            for (int _r = r - k + 1; _r <= r; _r++) if ((_sum += grid[_r][_c]) > sum) goto CONTINUE;
                            if (_sum != sum) goto CONTINUE;
                        }
                        return k;
                    CONTINUE:;
                    }

            return 1;
        }
    }
}
