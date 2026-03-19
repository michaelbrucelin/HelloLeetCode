using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3212
{
    public class Solution3212 : Interface3212
    {
        /// <summary>
        /// 二维前缀和
        /// 直接记录X-Y的前缀和，这样不行，题目要求至少含有一个X，所以还需要记录X
        /// 那还是老老实实记录X和Y吧
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumberOfSubmatrices(char[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,,] pre = new int[rcnt + 1, ccnt + 1, 2];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1, c + 1, 0] = pre[r, c + 1, 0] + pre[r + 1, c, 0] - pre[r, c, 0] + (grid[r][c] switch { 'X' => 1, _ => 0 });
                    pre[r + 1, c + 1, 1] = pre[r, c + 1, 1] + pre[r + 1, c, 1] - pre[r, c, 1] + (grid[r][c] switch { 'Y' => 1, _ => 0 });
                    if (pre[r + 1, c + 1, 0] > 0 && pre[r + 1, c + 1, 0] == pre[r + 1, c + 1, 1]) result++;
                }

            return result;
        }

        /// <summary>
        /// 逻辑同NumberOfSubmatrices()，滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumberOfSubmatrices2(char[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] pre = new int[ccnt + 1, 2];
            int lrx = 0, lry = 0, cntx, cnty;
            for (int r = 0; r < rcnt; r++, lrx = lry = 0) for (int c = 0; c < ccnt; c++)
                {
                    cntx = pre[c + 1, 0] + pre[c, 0] - lrx + (grid[r][c] switch { 'X' => 1, _ => 0 });
                    cnty = pre[c + 1, 1] + pre[c, 1] - lry + (grid[r][c] switch { 'Y' => 1, _ => 0 });
                    if (cntx > 0 && cntx == cnty) result++;
                    lrx = pre[c + 1, 0]; pre[c + 1, 0] = cntx;
                    lry = pre[c + 1, 1]; pre[c + 1, 1] = cnty;
                }

            return result;
        }
    }
}
