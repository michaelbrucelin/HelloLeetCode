using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3195
{
    public class Solution3195 : Interface3195
    {
        /// <summary>
        /// 遍历
        /// 遍历找四边，题目保证了输入至少有1个1
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumArea(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int r1 = rcnt, r2 = -1, c1 = ccnt, c2 = -1;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        if (r < r1) r1 = r;
                        if (r > r2) r2 = r;
                        if (c < c1) c1 = c;
                        if (c > c2) c2 = c;
                    }

            return (r2 - r1 + 1) * (c2 - c1 + 1);
        }

        /// <summary>
        /// 逻辑与MinimumArea()一样，稍加优化
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumArea2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int r1 = rcnt, r2 = -1, c1 = ccnt, c2 = -1;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        r1 = Math.Min(r1, r);
                        r2 = Math.Max(r2, r);
                        c1 = Math.Min(c1, c);
                        c2 = Math.Max(c2, c);
                    }

            return (r2 - r1 + 1) * (c2 - c1 + 1);
        }
    }
}
