using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3212
{
    public class Solution3212_2 : Interface3212
    {
        /// <summary>
        /// 维护每一列的前缀和
        /// 本质上就是Solution3212的滚动数组，换一种几何理解，维护的是每一列自上而下的前缀和
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumberOfSubmatrices(char[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] pre = new int[ccnt, 2];
            int cntx = 0, cnty = 0;
            for (int r = 0; r < rcnt; r++, cntx = cnty = 0) for (int c = 0; c < ccnt; c++)
                {
                    pre[c, 0] += (grid[r][c] switch { 'X' => 1, _ => 0 });
                    pre[c, 1] += (grid[r][c] switch { 'Y' => 1, _ => 0 });
                    cntx += pre[c, 0];
                    cnty += pre[c, 1];
                    if (cntx > 0 && cntx == cnty) result++;
                }

            return result;
        }
    }
}
