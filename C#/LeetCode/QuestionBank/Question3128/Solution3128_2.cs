using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3128
{
    public class Solution3128_2 : Interface3128
    {
        /// <summary>
        /// 数学
        /// 思路与Solution3128如出一辙，Solution3128中枚举的横边，这里枚举的是直角点，这样更简单
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public long NumberOfRightTriangles(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] rcnts = new int[rcnt], ccnts = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        rcnts[r]++; ccnts[c]++;
                    }

            long result = 0;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        result += (rcnts[r] - 1) * (ccnts[c] - 1);
                    }

            return result;
        }
    }
}
