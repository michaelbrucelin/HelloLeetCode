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
        /// 前缀和
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
    }
}
